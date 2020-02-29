using System.Windows.Media;
using Ccr.Core.Extensions;

namespace Ccr.MaterialDesign.Infrastructure.Descriptors
{
	public class LuminosityMaterialDescriptor
		: AbstractMaterialDescriptor
	{
		public Luminosity Luminosity { get; set; }
		

		public LuminosityMaterialDescriptor(
			Luminosity luminosity)
		{
			Luminosity = luminosity;
		}

		public LuminosityMaterialDescriptor(
			Luminosity luminosity,
			double opacity)
		{
			Luminosity = luminosity;
			Opacity = opacity;
		}


		public override SolidColorBrush GetMaterial(
			Swatch swatch)
		{
			var material = swatch.GetMaterial(Luminosity);

			if (Opacity == 1d)
				return material;

			return material.WithOpacity(Opacity);
		}
	}
}