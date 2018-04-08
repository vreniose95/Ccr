using System.Windows.Media;

namespace Ccr.MaterialDesign.Infrastructure.Descriptors
{
	public class LuminosityMaterialDescriptor : AbstractMaterialDescriptor
	{
		public Luminosity Luminosity { get; set; }

		public override SolidColorBrush GetMaterial(Swatch materialSet)
		{
			return materialSet.GetMaterial(Luminosity);//.WithOpacity(Opacity);
		}

		public LuminosityMaterialDescriptor(Luminosity luminosity, double opacity = 1.0)
		{
			Luminosity = luminosity;
			Opacity = opacity;
		}
	}
}