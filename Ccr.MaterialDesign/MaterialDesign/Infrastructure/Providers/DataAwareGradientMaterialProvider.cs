using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;
using Ccr.Core.Extensions;
using Ccr.MaterialDesign.Static;
using Ccr.Std.Core.Extensions.NumericExtensions;

namespace Ccr.MaterialDesign.Infrastructure.Providers
{
	[ContentProperty(nameof(GradientStepData))]
	public class DataAwareGradientMaterialProvider
		: IDataAwareMaterialProvider
	{
		public List<GradientMaterialStop> GradientStepData { get; }


		public DataAwareGradientMaterialProvider()
		{
			GradientStepData = new List<GradientMaterialStop>();
		}

		public DataAwareGradientMaterialProvider(List<GradientMaterialStop> gradientStepData)
		{
			GradientStepData = gradientStepData;
		}


		public void Reset()
		{
		}

		public void Reset(ProviderContext context)
		{
		}


		public Swatch ProvideNext(ProviderContext context)
		{
			throw new NotSupportedException(
				"ProvideNext cannot be used on a IDataAwareMaterialProvider. Use ProvideNextDataAware.");
		}

		public IMaterialProvider Slice(double offsetPercentage, double lengthPercentage)
		{
			throw new NotSupportedException(
				"Slice cannot be used on a IDataAwareMaterialProvider.");
		}

		public IMaterialProvider SliceSimple(int index, SimpleSliceMode sliceMode)
		{
			throw new NotSupportedException(
				"SliceSimple cannot be used on a IDataAwareMaterialProvider.");
		}

		public Swatch ProvideNextDataAware(DataAwareProviderContext context, double dataPoint)
		{
			var progression = dataPoint.LinearMap((context.DataMin, context.DataMax), (0d, 1d));
			var swatch = GetSwatchAtProgression(progression);

			return swatch;
		}

		private Swatch GetSwatchAtProgression(double progression)
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
					var progressionThroughStep = progression.LinearMap((currentOffset, stepEndOffset), (0d, 1d));
					var Swatch = MediaExtensions.Interpolate(startGradientStep.Swatch,
						endGradientStep.Swatch, progressionThroughStep);
					return Swatch;
				}
				currentOffset = stepEndOffset;
			}
			throw new ArgumentOutOfRangeException();
		}



		public static DataAwareGradientMaterialProvider PY = new DataAwareGradientMaterialProvider
		(new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.Pink),
				new GradientMaterialStop(PaletteResources.Yellow, 0)
			});

		public static DataAwareGradientMaterialProvider MaterialRYG => new DataAwareGradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.Red),
				new GradientMaterialStop(PaletteResources.Yellow),
				new GradientMaterialStop(PaletteResources.Green, 0)
			});

		public static DataAwareGradientMaterialProvider MaterialPR => new DataAwareGradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.Pink),
				new GradientMaterialStop(PaletteResources.Red, 0)
			});
		
		public static DataAwareGradientMaterialProvider MaterialTA => new DataAwareGradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.Teal),
				new GradientMaterialStop(PaletteResources.Amber, 0)
			});
		
		public static DataAwareGradientMaterialProvider MaterialTC => new DataAwareGradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.Teal),
				new GradientMaterialStop(PaletteResources.Amber, 0)
			});
		
		public static DataAwareGradientMaterialProvider MaterialHLbB => new DataAwareGradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.Pink),
				new GradientMaterialStop(PaletteResources.Purple ),
				new GradientMaterialStop(PaletteResources.DeepPurple),
				new GradientMaterialStop(PaletteResources.Blue),
				new GradientMaterialStop(PaletteResources.LightBlue),
				new GradientMaterialStop(PaletteResources.Teal, 0),
			});
		
		public static DataAwareGradientMaterialProvider MateriaLbLg => new DataAwareGradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.LightBlue),
				new GradientMaterialStop(PaletteResources.LightGreen, 0),
			});

		public static DataAwareGradientMaterialProvider RainbowPaletteOrder => new DataAwareGradientMaterialProvider(
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

		public static DataAwareGradientMaterialProvider RainbowRefractionOrder => new DataAwareGradientMaterialProvider(
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

		public static DataAwareGradientMaterialProvider CoolColors => new DataAwareGradientMaterialProvider(
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

		public static DataAwareGradientMaterialProvider CoolColorsNonCirc => new DataAwareGradientMaterialProvider(
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

		public static DataAwareGradientMaterialProvider WarmColors => new DataAwareGradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.Pink),
				new GradientMaterialStop(PaletteResources.Red),
				new GradientMaterialStop(PaletteResources.DeepOrange),
				new GradientMaterialStop(PaletteResources.Orange),
				new GradientMaterialStop(PaletteResources.Yellow),
				new GradientMaterialStop(PaletteResources.Pink, 0),
			});

		public static DataAwareGradientMaterialProvider WarmColorsNonCirc => new DataAwareGradientMaterialProvider(
			new List<GradientMaterialStop>
			{
				new GradientMaterialStop(PaletteResources.Pink),
				new GradientMaterialStop(PaletteResources.Red),
				new GradientMaterialStop(PaletteResources.DeepOrange),
				new GradientMaterialStop(PaletteResources.Orange),
				new GradientMaterialStop(PaletteResources.Yellow, 0),
			});
	}
}
