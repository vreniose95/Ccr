using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Markup;
using Ccr.Core.Extensions;
using Ccr.MaterialDesign.Static;
using Ccr.Std.Core.Extensions.NumericExtensions;

namespace Ccr.MaterialDesign.Infrastructure.Providers
{
	//TODO circular providers that autofade back to set end to set begin
	//TODO make sure all contentpropertyattributes use nameof, not strings
	[ContentProperty(nameof(GradientStepData))]
	public class GradientMaterialProvider 
		: ISlicableMaterialProvider
	{
		private int currentIndex;

		public List<GradientMaterialStop> GradientStepData { get; }

		public void Reset()
		{
			currentIndex = 0;
		}

		public void Reset(ProviderContext context)
		{
			currentIndex = 0;
		}
		public GradientMaterialProvider()
		{
			GradientStepData = new List<GradientMaterialStop>();
		}


		public GradientMaterialProvider(List<GradientMaterialStop> gradientStepData)
		{
			GradientStepData = gradientStepData;
		}

		public Swatch ProvideNext(ProviderContext context)
		{
			if (currentIndex > context.CycleLength) currentIndex = 0;

			var position = 1.0 / context.CycleLength * currentIndex;
			var gradientStepSpan = GradientStepData.Sum(step => step.Offset);
			var additivestepPercentage = 0d;
			
			Swatch interpolatedMaterialSet = PaletteResources.Red;

			if (position >= 1)
			{
				currentIndex++;
				return GradientStepData.Last().Swatch;
			}

			for (var x = 0; x <= GradientStepData.Count - 2; x++)
			{
				var stepPercentage = GradientStepData[x].Offset / gradientStepSpan;
				var stepProgression = position - additivestepPercentage;
				var stepProgressionPercentage = stepProgression / stepPercentage;

				if (position >= additivestepPercentage && position < (additivestepPercentage + stepPercentage))
				{
					interpolatedMaterialSet = MediaExtensions.Interpolate(GradientStepData[x].Swatch,
						GradientStepData[x + 1].Swatch, stepProgressionPercentage);
					break;
				}
				additivestepPercentage += stepPercentage;
			}
			currentIndex++;
			return interpolatedMaterialSet;
		}

		//public IMaterialProvider Slice(int sampleSize, int offset, int totalSize)
		//{

		//}
		//public IMaterialProvider Slice(double offsetPercentage, double lengthPercentage)
		//{
		//	var gradientStops = GetSlicedGradientStopsAtProgression(offsetPercentage, lengthPercentage);

		//	return new GradientMaterialProvider(gradientStops);
		//}

		public IMaterialProvider Slice(double offsetPercentage, double lengthPercentage)
		{
			var gradientStop1 = GetMaterialSetAtProgression(offsetPercentage);
			var gradientStop2 = GetMaterialSetAtProgression(offsetPercentage + lengthPercentage);

			return new GradientMaterialProvider(new List<GradientMaterialStop>
			{
				new GradientMaterialStop(gradientStop1),
				new GradientMaterialStop(gradientStop2, 0)
			});
		}

		//TODO RollRange for outside bounds
		//TODO redo this system. 
		public IMaterialProvider SliceSimple(int index, SimpleSliceMode sliceMode)
		{
			switch (sliceMode)
			{
				case SimpleSliceMode.Gradient:
					var gradientStop1 = GradientStepData[index].Swatch;
					var gradientStop2 = GradientStepData[index + 1].Swatch;

					return new GradientMaterialProvider(new List<GradientMaterialStop>
					{
						new GradientMaterialStop(gradientStop1),
						new GradientMaterialStop(gradientStop2, 0)
					});
				case SimpleSliceMode.Literal:
					var gradientStop = GradientStepData[index].Swatch;

					return new LiteralMaterialProvider(gradientStop);
				default:
					throw new InvalidEnumArgumentException();
			}
		}

		private List<GradientMaterialStop> GetSlicedGradientStopsAtProgression(double offsetPercentage, double lengthPercentage)//double progression)
		{
			var lapsedStops = new List<GradientMaterialStop>();
			var totalGradientSpan = GradientStepData.Sum(t => t.Offset);

			var sliceStartPercentage = offsetPercentage;
			var sliceEndPercentage = offsetPercentage + lengthPercentage;

			//if (progression <= 0)
			//{
			//	return GradientStepData.First().MaterialSet;
			//}
			//if (progression >= 1)
			//{
			//	return GradientStepData.Last().MaterialSet;
			//}
			//if (offsetPercentage > 0)
			//{
			//	var actualGradientStepLength = 1 * progressionThroughStep;
			//	lapsedStops.Add(new GradientMaterialStop(materialSet, actualGradientStepLength));

			//}
			var currentOffset = 0d;
			for (var x = 0; x <= GradientStepData.Count - 2; x++)
			{
				var startGradientStep = GradientStepData[x];
				var endGradientStep = GradientStepData[x + 1];

				var stepSpanPercentage = startGradientStep.Offset / totalGradientSpan;
				var stepEndOffset = currentOffset + stepSpanPercentage;

				//the left bound is past the start position
				if (currentOffset >= sliceStartPercentage)
				{
					//the right bound is past the start position
					//The whole segment lies within selection
					if (stepEndOffset < sliceEndPercentage)
					{
						lapsedStops.Add(GradientStepData[x]);
					}
					// The segment starts in the selection, but continues outside it
					else
					{
						//	var clipped = sliceEndPercentage - currentOffset;
						//	var actualGradientStepLength = 1 - clipped;
						lapsedStops.Add(new GradientMaterialStop(GradientStepData[x].Swatch, .5));
					}
				}
				//The left bound is not inside the selected range 
				else
				{
					//the right bound is inside the selected range
					// The segment starts outside the selection, but continues inside it
					if (currentOffset >= stepEndOffset)
					{
						lapsedStops.Add(new GradientMaterialStop(GradientStepData[x].Swatch, .5));
					}
					// The segment is completely outside the selection
					else
					{
						//	var clipped = sliceEndPercentage - currentOffset;
						//	var actualGradientStepLength = 1 - clipped;

					}
				}
				//if (progression >= currentOffset && progression < stepEndOffset)
				//{
				//	var progressionThroughStep = progression.Map(currentOffset, stepEndOffset, 0, 1);
				//	var materialSet = MediaExtensions.Interpolate(startGradientStep.MaterialSet,
				//		endGradientStep.MaterialSet, progressionThroughStep);
				//	var actualGradientStepLength = 1 * progressionThroughStep;
				//	lapsedStops.Add(new GradientMaterialStop(materialSet, actualGradientStepLength));
				//	return lapsedStops;
				//}
				//else if (offsetPercentage >= currentOffset)
				//{
				//	lapsedStops.Add(GradientStepData[x]);
				//	currentOffset = stepEndOffset;
				//}
			}
			return lapsedStops;
			//throw new ArgumentOutOfRangeException();
		}
		private Swatch GetMaterialSetAtProgression(double progression)
		{
			var totalGradientSpan = GradientStepData.Sum(t => t.Offset);

			if (progression <= 0)
			{
				return GradientStepData.First().Swatch;
			}
			if (progression >= 1)
			{
				return GradientStepData.Last().Swatch;
			}

			var currentOffset = 0d;
			for (var x = 0; x <= GradientStepData.Count - 2; x++)
			{
				var startGradientStep = GradientStepData[x];
				var endGradientStep = GradientStepData[x + 1];

				var stepSpanPercentage = startGradientStep.Offset / totalGradientSpan;
				var stepEndOffset = currentOffset + stepSpanPercentage;

				if (progression >= currentOffset && progression < stepEndOffset)
				{
					var progressionThroughStep = progression.LinearMap((currentOffset, stepEndOffset), (0, 1));
					var materialSet = MediaExtensions.Interpolate(startGradientStep.Swatch,
						endGradientStep.Swatch, progressionThroughStep);
					return materialSet;
				}
				currentOffset = stepEndOffset;
			}
			throw new ArgumentOutOfRangeException();
		}


		public static GradientMaterialProvider PY = new GradientMaterialProvider
		(new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.Pink),
				new GradientMaterialStop(PaletteResources.Yellow, 0)
			});


		public static GradientMaterialProvider MaterialRYG => new GradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.Red),
				new GradientMaterialStop(PaletteResources.Yellow),
				new GradientMaterialStop(PaletteResources.Green, 0)
			});

		public static GradientMaterialProvider MaterialPR => new GradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.Pink),
				new GradientMaterialStop(PaletteResources.Red, 0)
			});
		public static GradientMaterialProvider MaterialTA => new GradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.Teal),
				new GradientMaterialStop(PaletteResources.Amber, 0)
			});
		public static GradientMaterialProvider MaterialTC => new GradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.Teal),
				new GradientMaterialStop(PaletteResources.Amber, 0)
			});
		public static GradientMaterialProvider MaterialHLbB => new GradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.Pink),
				new GradientMaterialStop(PaletteResources.Purple ),
				new GradientMaterialStop(PaletteResources.DeepPurple),
				new GradientMaterialStop(PaletteResources.Blue),
				new GradientMaterialStop(PaletteResources.LightBlue),
				new GradientMaterialStop(PaletteResources.Teal, 0),
			});
		public static GradientMaterialProvider MateriaLbLg => new GradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.LightBlue),
				new GradientMaterialStop(PaletteResources.LightGreen, 0),
			});
		public static GradientMaterialProvider RainbowPaletteOrder => new GradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.Red),
				new GradientMaterialStop(PaletteResources.Pink ),
				new GradientMaterialStop(PaletteResources.Purple),
				new GradientMaterialStop(PaletteResources.DeepPurple),
				new GradientMaterialStop(PaletteResources.Indigo),
				new GradientMaterialStop(PaletteResources.Blue),
				new GradientMaterialStop(PaletteResources.LightBlue),
				new GradientMaterialStop(PaletteResources.Cyan),
				new GradientMaterialStop(PaletteResources.Teal),
				new GradientMaterialStop(PaletteResources.Green),
				new GradientMaterialStop(PaletteResources.LightGreen),
				new GradientMaterialStop(PaletteResources.Lime),
				new GradientMaterialStop(PaletteResources.Yellow),
				new GradientMaterialStop(PaletteResources.Amber),
				new GradientMaterialStop(PaletteResources.Orange),
				new GradientMaterialStop(PaletteResources.DeepOrange, 0)
			});
		public static GradientMaterialProvider RainbowRefractionOrder => new GradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.Red),
				new GradientMaterialStop(PaletteResources.DeepOrange),
				new GradientMaterialStop(PaletteResources.Orange),
				new GradientMaterialStop(PaletteResources.Amber),
				new GradientMaterialStop(PaletteResources.Lime),
				new GradientMaterialStop(PaletteResources.Yellow),
				new GradientMaterialStop(PaletteResources.LightGreen),
				new GradientMaterialStop(PaletteResources.Green),
				new GradientMaterialStop(PaletteResources.Teal),
				new GradientMaterialStop(PaletteResources.Cyan),
				new GradientMaterialStop(PaletteResources.LightBlue),
				new GradientMaterialStop(PaletteResources.Blue),
				new GradientMaterialStop(PaletteResources.Indigo),
				new GradientMaterialStop(PaletteResources.DeepPurple),
				new GradientMaterialStop(PaletteResources.Purple),
				new GradientMaterialStop(PaletteResources.Pink, 0)
			});

		public static GradientMaterialProvider CoolColors => new GradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.Purple),
				new GradientMaterialStop(PaletteResources.DeepPurple),
				new GradientMaterialStop(PaletteResources.Indigo),
				new GradientMaterialStop(PaletteResources.Blue),
				new GradientMaterialStop(PaletteResources.LightBlue),
				new GradientMaterialStop(PaletteResources.Cyan),
				new GradientMaterialStop(PaletteResources.Teal),
				new GradientMaterialStop(PaletteResources.Green),
				new GradientMaterialStop(PaletteResources.Purple, 0)
			});
		public static GradientMaterialProvider CoolColorsNonCirc => new GradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.Purple),
				new GradientMaterialStop(PaletteResources.DeepPurple),
				new GradientMaterialStop(PaletteResources.Indigo),
				new GradientMaterialStop(PaletteResources.Blue),
				new GradientMaterialStop(PaletteResources.LightBlue),
				new GradientMaterialStop(PaletteResources.Cyan),
				new GradientMaterialStop(PaletteResources.Teal),
				new GradientMaterialStop(PaletteResources.Green, 0)
			});

		public static GradientMaterialProvider WarmColors => new GradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.Pink),
				new GradientMaterialStop(PaletteResources.Red),
				new GradientMaterialStop(PaletteResources.DeepOrange),
				new GradientMaterialStop(PaletteResources.Orange),
				new GradientMaterialStop(PaletteResources.Yellow),
				new GradientMaterialStop(PaletteResources.Pink, 0),
			});
		public static GradientMaterialProvider WarmColorsNonCirc => new GradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.Pink),
				new GradientMaterialStop(PaletteResources.Red),
				new GradientMaterialStop(PaletteResources.DeepOrange),
				new GradientMaterialStop(PaletteResources.Orange),
				new GradientMaterialStop(PaletteResources.Yellow, 0),
			});
		/*
				//		new ComplexGradientStep(Material.Pink),
				//		new ComplexGradientStep(Material.Red),
		//		new ComplexGradientStep(Material.DeepOrange),
		//		new ComplexGradientStep(Material.Orange),
		//		new ComplexGradientStep(Material.Amber),
		//		new ComplexGradientStep(Material.Yellow),*/

		//public static ComplexGradientBrushProvider MaterialPBDark => new ComplexGradientBrushProvider(
		//	new List<ComplexGradientStep>
		//	{
		//		new ComplexGradientStep(Material.Pink.Darken(.4)),
		//		new ComplexGradientStep(Material.Teal.Lighten(.05), 0)
		//	})
		//{ ProviderFunction = new DarkenBrushFunction { DarkenPercentage = 0 } };
		//public static ComplexGradientBrushProvider MaterialBPDark => new ComplexGradientBrushProvider(
		//	new List<ComplexGradientStep>
		//	{
		//		new ComplexGradientStep(Material.Blue.Darken(.2)),
		//		new ComplexGradientStep(Material.Pink, 0)
		//	})
		//{ ProviderFunction = new DarkenBrushFunction { DarkenPercentage = .1 } };
		//public static ComplexGradientBrushProvider MaterialGB => new ComplexGradientBrushProvider(
		//	new List<ComplexGradientStep>
		//	{
		//		new ComplexGradientStep(Material.Green),
		//		new ComplexGradientStep(Material.Teal),
		//		new ComplexGradientStep(Material.LightBlue),
		//		new ComplexGradientStep(Material.Indigo, 0)
		//	})
		//{ ProviderFunction = new LightenBrushFunction { LightenPercentage = .3 } };
		//public static ComplexGradientBrushProvider MaterialBG => new ComplexGradientBrushProvider(
		//	new List<ComplexGradientStep>
		//	{
		//		new ComplexGradientStep(Material.Indigo),
		//		new ComplexGradientStep(Material.LightBlue),
		//		new ComplexGradientStep(Material.Teal),
		//		new ComplexGradientStep(Material.Green, 0)
		//	})
		//{ ProviderFunction = new LightenBrushFunction { LightenPercentage = .3 } };

		//public static ComplexGradientBrushProvider MaterialRainbow => new ComplexGradientBrushProvider(
		//	new List<ComplexGradientStep>
		//	{
		//		new ComplexGradientStep(Material.Red),
		//		new ComplexGradientStep(Material.DeepOrange),
		//		new ComplexGradientStep(Material.Orange),
		//		new ComplexGradientStep(Material.Amber),
		//		new ComplexGradientStep(Material.Yellow),
		//		new ComplexGradientStep(Material.Lime),
		//		new ComplexGradientStep(Material.LightGreen),
		//		new ComplexGradientStep(Material.Green),
		//		new ComplexGradientStep(Material.Teal),
		//		new ComplexGradientStep(Material.Cyan),
		//		new ComplexGradientStep(Material.LightBlue),
		//		new ComplexGradientStep(Material.Blue),
		//		new ComplexGradientStep(Material.Indigo),
		//		new ComplexGradientStep(Material.DeepPurple),
		//		new ComplexGradientStep(Material.Purple),
		//		new ComplexGradientStep(Material.Pink),
		//		new ComplexGradientStep(Material.Red, 0)
		//	});
		//public static ComplexGradientBrushProvider MaterialCoolColors => new ComplexGradientBrushProvider(
		//	new List<ComplexGradientStep>
		//	{
		//		new ComplexGradientStep(Material.Blue),
		//		new ComplexGradientStep(Material.Indigo),
		//		new ComplexGradientStep(Material.DeepPurple),
		//		new ComplexGradientStep(Material.Purple),
		//		new ComplexGradientStep(Material.Pink.Darken(.15), 0)
		//	});
	}
}
