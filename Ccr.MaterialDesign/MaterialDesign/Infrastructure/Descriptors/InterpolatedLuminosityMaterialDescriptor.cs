using System.Windows.Media;
using Ccr.Core.Extensions;

namespace Ccr.MaterialDesign.Infrastructure.Descriptors
{
	public class InterpolatedLuminosityMaterialDescriptor
	  : AbstractMaterialDescriptor
	{
		public Luminosity Luminosity1 { get; }

		public Luminosity Luminosity2 { get; }

		public double Progression { get; }


		public override MaterialBrush GetMaterial(
		  Swatch materialSet)
		{
			var material1 = materialSet.GetMaterial(Luminosity1); 
			var material2 = materialSet.GetMaterial(Luminosity2);

		  var avgLumIndex = (Luminosity1.LuminosityIndex + Luminosity2.LuminosityIndex) / 2d;
		  var finalLum = new Luminosity((int) avgLumIndex.Round(), Luminosity1.IsAccent);

			var interpolatedMaterial = material1.Brush.Color.Blend(material2, Progression);

		  var finalColor = interpolatedMaterial.WithOpacity(Opacity);

		  var finalMaterial = MaterialBrush.Create(finalColor,
		                                           new MaterialIdentity(
		                                             material1.Identity.SwatchClassifier,
		                                             material1.Identity.IsAccent,
		                                             finalLum,
		                                             Opacity));
		  return finalMaterial;
		}

		public InterpolatedLuminosityMaterialDescriptor(
			Luminosity luminosity1, 
			Luminosity luminosity2,
			double progression, 
			double opacity = 1.0)
		{
			Luminosity1 = luminosity1;
			Luminosity2 = luminosity2;
			Progression = progression;
			Opacity = opacity;
		}
	}
}