using Ccr.MaterialDesign.Static;

namespace Ccr.MaterialDesign.Infrastructure.Providers
{
	public class LiteralMaterialProvider : IMaterialProvider
	{
		public Swatch MaterialSet { get; set; } = PaletteResources.Blue;


		public LiteralMaterialProvider() { }

		public LiteralMaterialProvider(Swatch materialSet)
		{
			MaterialSet = materialSet;
		}

		#region Methods
		public Swatch ProvideNext(ProviderContext context)
		{
			return MaterialSet;
		}

		public void Reset(ProviderContext context)
		{
		}
		public IMaterialProvider Slice(double offsetPercentage, double lengthPercentage)
		{
			return this;
		}
		public IMaterialProvider SliceSimple(int index, SimpleSliceMode sliceMode)
		{
			return this;
		}

		#endregion

		#region Static Sequences
		public static LiteralMaterialProvider RedProvider = new LiteralMaterialProvider(PaletteResources.Red);

		public static LiteralMaterialProvider PinkProvider = new LiteralMaterialProvider(PaletteResources.Pink);

		public static LiteralMaterialProvider PurpleProvider = new LiteralMaterialProvider(PaletteResources.Purple);

		public static LiteralMaterialProvider DeepPurpleProvider = new LiteralMaterialProvider(PaletteResources.DeepPurple);

		public static LiteralMaterialProvider IndigoProvider = new LiteralMaterialProvider(PaletteResources.Indigo);

		public static LiteralMaterialProvider BlueProvider = new LiteralMaterialProvider(PaletteResources.Blue);

		public static LiteralMaterialProvider LightBlueProvider = new LiteralMaterialProvider(PaletteResources.LightBlue);

		public static LiteralMaterialProvider CyanProvider = new LiteralMaterialProvider(PaletteResources.Cyan);

		public static LiteralMaterialProvider TealProvider = new LiteralMaterialProvider(PaletteResources.Teal);

		public static LiteralMaterialProvider GreenProvider = new LiteralMaterialProvider(PaletteResources.Green);

		public static LiteralMaterialProvider LightGreenProvider = new LiteralMaterialProvider(PaletteResources.LightGreen);

		public static LiteralMaterialProvider LimeProvider = new LiteralMaterialProvider(PaletteResources.Lime);

		public static LiteralMaterialProvider YellowProvider = new LiteralMaterialProvider(PaletteResources.Yellow);

		public static LiteralMaterialProvider AmberProvider = new LiteralMaterialProvider(PaletteResources.Amber);

		public static LiteralMaterialProvider OrangeProvider = new LiteralMaterialProvider(PaletteResources.Orange);

		public static LiteralMaterialProvider DeepOrangeProvider = new LiteralMaterialProvider(PaletteResources.DeepOrange);

		public static LiteralMaterialProvider BrownProvider = new LiteralMaterialProvider(PaletteResources.Brown);

		public static LiteralMaterialProvider GreyProvider = new LiteralMaterialProvider(PaletteResources.Grey);

		public static LiteralMaterialProvider BlueGreyProvider = new LiteralMaterialProvider(PaletteResources.BlueGrey);
		
		#endregion
	}
}
