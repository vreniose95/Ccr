using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Ccr.MaterialDesign.Static;

namespace Ccr.MaterialDesign.Infrastructure.Providers
{
	public class SequentialMaterialProvider
		: IMaterialProvider
		{
			#region Properties
			//public ReadSwatchOnlyCollection<Swatch> SwatchSequence { get; }

			public List<Swatch> SwatchSequence { get; }

			public CyclicalBehavior CyclicalMode { get; }

			public bool Reverse { get; set; }

			#endregion

			#region Fields
			private MirrorDirection _mirrorDirection = MirrorDirection.Forward;
			private int _currentIndex;

			#endregion


			#region Constructors
			public SequentialMaterialProvider()
				: this(new List<Swatch>())
			{
			}

			public SequentialMaterialProvider(
				params Swatch[] materialSetSequence)
					: this(CyclicalBehavior.Repeat, materialSetSequence)
			{
			}

			public SequentialMaterialProvider(
				IList<Swatch> materialSetSequence)
					: this(CyclicalBehavior.Repeat, materialSetSequence)
			{
			}

			public SequentialMaterialProvider(
				CyclicalBehavior mode = CyclicalBehavior.Repeat,
				params Swatch[] materialSetSequence)
					: this(
						mode,
						materialSetSequence.ToList())
			{
			}

			public SequentialMaterialProvider(
				CyclicalBehavior mode, 
				IList<Swatch> materialSetSequence)
			{
				SwatchSequence = new List<Swatch>(materialSetSequence);
				CyclicalMode = mode;
			}

			#endregion


			#region Methods
			public Swatch ProvideNext(ProviderContext context)
			{
				switch (CyclicalMode)
				{
					case CyclicalBehavior.Repeat:
						{
							if (_currentIndex > SwatchSequence.Count - 1)
								_currentIndex = 0;
							if (_currentIndex < 0)
								_currentIndex = SwatchSequence.Count - 1;

							var currentSet = SwatchSequence[_currentIndex];
							if (Reverse)
								_currentIndex--;
							else
								_currentIndex++;
							return currentSet;
						}
					case CyclicalBehavior.Mirror:
						{
							if (_currentIndex > SwatchSequence.Count - 1)
							{
								_currentIndex = SwatchSequence.Count - 2;
								_mirrorDirection = MirrorDirection.Backward;
							}
							else if (_currentIndex < 0)
							{
								_currentIndex = 1;
								_mirrorDirection = MirrorDirection.Forward;
							}
							var currentSet = SwatchSequence[_currentIndex];

							switch (_mirrorDirection)
							{
								case MirrorDirection.Forward:
									_currentIndex++;
									break;
								case MirrorDirection.Backward:
									_currentIndex--;
									break;
							}
							return currentSet;
						}
					default:
						throw new NotSupportedException(
							$"Cyclical Mode {CyclicalMode} is not supported.");
				}
			}

			public void Reset(ProviderContext context)
			{
				if (Reverse)
					_currentIndex = context.CycleLength - 1;
				else
					_currentIndex = 0;
			}
			public IMaterialProvider Slice(double offsetPercentage, double lengthPercentage)
			{
				return this;
			}
			//TODO RollRange for outside bounds
			public IMaterialProvider SliceSimple(int index, SimpleSliceMode sliceMode)
			{
				switch (sliceMode)
				{
					case SimpleSliceMode.Gradient:
						var materialSet1 = SwatchSequence[index];
						var materialSet2 = SwatchSequence[index + 1];

						return new GradientMaterialProvider(new List<GradientMaterialStop>
					{
						new GradientMaterialStop(materialSet1),
						new GradientMaterialStop(materialSet2, 0)
					});
					case SimpleSliceMode.Literal:
						var materialSet = SwatchSequence[index];

						return new LiteralMaterialProvider(materialSet);
					default:
						throw new InvalidEnumArgumentException();
				}
			}
			#endregion

			#region Static Sequences
			public static SequentialMaterialProvider RainbowPaletteOrder = new SequentialMaterialProvider
			(
				PaletteResources.Red,
				PaletteResources.Pink,
				PaletteResources.Purple,
				PaletteResources.DeepPurple,
				PaletteResources.Indigo,
				PaletteResources.Blue,
				PaletteResources.LightBlue,
				PaletteResources.Cyan,
				PaletteResources.Teal,
				PaletteResources.Green,
				PaletteResources.LightGreen,
				PaletteResources.Lime,
				PaletteResources.Yellow,
				PaletteResources.Amber,
				PaletteResources.Orange,
				PaletteResources.DeepOrange
			);
			public static SequentialMaterialProvider RainbowRefractionOrder = new SequentialMaterialProvider
			(
				PaletteResources.Red,
				PaletteResources.DeepOrange,
				PaletteResources.Orange,
				PaletteResources.Amber,
				PaletteResources.Lime,
				PaletteResources.Yellow,
				PaletteResources.LightGreen,
				PaletteResources.Green,
				PaletteResources.Teal,
				PaletteResources.Cyan,
				PaletteResources.LightBlue,
				PaletteResources.Blue,
				PaletteResources.Indigo,
				PaletteResources.DeepPurple,
				PaletteResources.Purple,
				PaletteResources.Pink
			);
			public static SequentialMaterialProvider CoolColors = new SequentialMaterialProvider
			(
				PaletteResources.Purple,
				PaletteResources.DeepPurple,
				PaletteResources.Indigo,
				PaletteResources.Blue,
				PaletteResources.LightBlue,
				PaletteResources.Cyan,
				PaletteResources.Teal,
				PaletteResources.Green
			);
			public static SequentialMaterialProvider CoolColorsReverse = new SequentialMaterialProvider
			(
				PaletteResources.Purple,
				PaletteResources.DeepPurple,
				PaletteResources.Indigo,
				PaletteResources.Blue,
				PaletteResources.LightBlue,
				PaletteResources.Cyan,
				PaletteResources.Teal,
				PaletteResources.Green
			)
			{ Reverse = true };
			public static SequentialMaterialProvider RBSFO = new SequentialMaterialProvider
			(
				PaletteResources.Green,
				PaletteResources.Blue,
				PaletteResources.Purple,
				PaletteResources.Red,
				PaletteResources.DeepOrange
			);
			public static SequentialMaterialProvider ACDpR = new SequentialMaterialProvider
			(
				PaletteResources.Amber,
				PaletteResources.Cyan,
				PaletteResources.DeepPurple,
				PaletteResources.Red
			);
			public static SequentialMaterialProvider RBSFORev = new SequentialMaterialProvider
			(
				PaletteResources.Green,
				PaletteResources.Blue,
				PaletteResources.Purple,
				PaletteResources.Red,
				PaletteResources.DeepOrange
			)
			{ Reverse = true };

			//public static SequentialMaterialProvider RBSFORevAlt = new SequentialMaterialProvider
			//(
			//	PaletteResources.Teal,
			//	PaletteResources.Indigo,
			//	PaletteResources.DeepPurple,
			//	PaletteResources.Red,
			//	PaletteResources.DeepOrange
			//)
			//{ Reverse = true };
			//public static SequentialMaterialProvider RBSFORevAlt2 = new SequentialMaterialProvider
			//(
			//	PaletteResources.Teal,
			//	PaletteResources.Indigo,
			//	PaletteResources.DeepPurple,
			//	PaletteResources.Red,
			//	PaletteResources.Orange
			//)
			//{ Reverse = true };


			public static SequentialMaterialProvider TOR = new SequentialMaterialProvider
			(
				PaletteResources.Teal,
				PaletteResources.Orange,
				PaletteResources.Red
			);
			public static SequentialMaterialProvider TORRev = new SequentialMaterialProvider
			(
				PaletteResources.Teal,
				PaletteResources.Orange,
				PaletteResources.Red
			)
			{ Reverse = true };
			public static SequentialMaterialProvider LgLbR = new SequentialMaterialProvider
			(
				PaletteResources.LightGreen,
				PaletteResources.LightBlue,
				PaletteResources.Red
			);
			public static SequentialMaterialProvider GBR = new SequentialMaterialProvider
			(
				PaletteResources.Green,
				PaletteResources.Blue,
				PaletteResources.Red
			);
			#endregion
		}
		//public class BETASequentialMaterialProvider : IBETAMaterialProvider
		//{
		//	#region Properties
		//	public ReadOnlyCollection<Swatch> SwatchSequence { get; }

		//	public CyclicalBehavior CyclicalMode { get; }

		//	public bool Reverse { get; set; }
		//	#endregion

		//	#region Fields
		//	private MirrorDirection mirrorDirection = MirrorDirection.Forward;
		//	#endregion

		//	#region Constructors
		//	public BETASequentialMaterialProvider(params Swatch[] materialSetSequence)
		//		: this(CyclicalBehavior.Repeat, materialSetSequence)
		//	{ }

		//	public BETASequentialMaterialProvider(IList<Swatch> materialSetSequence)
		//		: this(CyclicalBehavior.Repeat, materialSetSequence)
		//	{ }

		//	public BETASequentialMaterialProvider(CyclicalBehavior mode = CyclicalBehavior.Repeat,
		//		params Swatch[] materialSetSequence) : this(mode, materialSetSequence.ToList())
		//	{ }

		//	public BETASequentialMaterialProvider(CyclicalBehavior mode, IList<Swatch> materialSetSequence)
		//	{
		//		SwatchSequence = new ReadOnlyCollection<Swatch>(materialSetSequence);
		//		CyclicalMode = mode;
		//	}
		//	#endregion

		//	#region Methods
		//	public Swatch ProvideNext(ref ProviderContext context)
		//	{
		//		switch (CyclicalMode)
		//		{
		//			case CyclicalBehavior.Repeat:
		//				{
		//					if (context.ProviderIndex > SwatchSequence.Count - 1)
		//						context.ProviderIndex = 0;
		//					if (context.ProviderIndex < 0)
		//						context.ProviderIndex = SwatchSequence.Count - 1;

		//					var currentSet = SwatchSequence[context.ProviderIndex];
		//					if (Reverse)
		//						context.ProviderIndex = context.ProviderIndex - 1;
		//					else
		//						context.ProviderIndex = context.ProviderIndex + 1;
		//					return currentSet;
		//				}
		//			case CyclicalBehavior.Mirror:
		//				{
		//					if (context.ProviderIndex > SwatchSequence.Count - 1)
		//					{
		//						context.ProviderIndex = SwatchSequence.Count - 2;
		//						mirrorDirection = MirrorDirection.Backward;
		//					}
		//					else if (context.ProviderIndex < 0)
		//					{
		//						context.ProviderIndex = 1;
		//						mirrorDirection = MirrorDirection.Forward;
		//					}
		//					var currentSet = SwatchSequence[context.ProviderIndex];

		//					switch (mirrorDirection)
		//					{
		//						case MirrorDirection.Forward:
		//							context.ProviderIndex = context.ProviderIndex + 1;
		//							break;
		//						case MirrorDirection.Backward:
		//							context.ProviderIndex = context.ProviderIndex - 1;
		//							break;
		//					}
		//					return currentSet;
		//				}
		//			default:
		//				throw new NotSupportedException($"Cyclical Mode {CyclicalMode} is not supported.");
		//		}
		//	}

		//	public void Reset(ref ProviderContext context)
		//	{
		//		if (Reverse)
		//			context.ProviderIndex = context.CycleLength - 1;
		//		else
		//			context.ProviderIndex = 0;
		//	}
		//	#endregion

		//	#region Static Sequences
		//	public static BETASequentialMaterialProvider BETARainbowPaletteOrder = new BETASequentialMaterialProvider
		//	(
		//		PaletteResources.Red,
		//		PaletteResources.Pink,
		//		PaletteResources.Purple,
		//		PaletteResources.DeepPurple,
		//		PaletteResources.Indigo,
		//		PaletteResources.Blue,
		//		PaletteResources.LightBlue,
		//		PaletteResources.Cyan,
		//		PaletteResources.Teal,
		//		PaletteResources.Green,
		//		PaletteResources.LightGreen,
		//		PaletteResources.Lime,
		//		PaletteResources.Yellow,
		//		PaletteResources.Amber,
		//		PaletteResources.Orange,
		//		PaletteResources.DeepOrange
		//	);
		//	#endregion
		//}
	}

