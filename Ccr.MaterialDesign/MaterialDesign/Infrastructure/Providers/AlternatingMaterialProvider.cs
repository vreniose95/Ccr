using Ccr.MaterialDesign.Static;

namespace Ccr.MaterialDesign.Infrastructure.Providers
{
	public class AlternatingMaterialProvider 
		: ISlicableMaterialProvider
	{
		#region Fields
		private int _currentIndex;

		#endregion


		#region Properties
		public Swatch Swatch1 { get; set; } = PaletteResources.Blue;

		public Swatch Swatch2 { get; set; } = PaletteResources.Green;

		#endregion
		

		#region Constructors
		public AlternatingMaterialProvider()
		{
		}

		public AlternatingMaterialProvider(
			Swatch swatch1, 
			Swatch swatch2)
				: this()
		{
			Swatch1 = swatch1;
			Swatch2 = swatch2;
		}
		#endregion


		#region Methods
		public Swatch ProvideNext(ProviderContext context)
		{
			var Swatch = _currentIndex % 2 == 0 
				? Swatch1
				: Swatch2;

			_currentIndex++;
			
			return Swatch;
		}

		public void Reset(ProviderContext context)
		{
			_currentIndex = 0;
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
		public static AlternatingMaterialProvider AltGP =
			new AlternatingMaterialProvider(
				PaletteResources.Green, 
				PaletteResources.Pink);

		public static AlternatingMaterialProvider AltGPRev =
			new AlternatingMaterialProvider(
				PaletteResources.Pink,
				PaletteResources.Green);

		public static AlternatingMaterialProvider NonAltB =
			new AlternatingMaterialProvider(
				PaletteResources.Blue,
				PaletteResources.Blue);

		#endregion
	}
}

