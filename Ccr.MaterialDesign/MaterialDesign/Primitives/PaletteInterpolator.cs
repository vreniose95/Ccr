using System.Diagnostics;
using Ccr.Core.Extensions;

namespace Ccr.MaterialDesign.Primitives
{
	public class PaletteInterpolator
	{
		private readonly Palette _palette;


		public PaletteInterpolator(
		  Palette palette)
		{
			_palette = palette;
		}

		public void Analyze()
		{
			foreach (var swatch in _palette.Swatches)
			{
				Debug.WriteLine($"SwatchClassifier: {swatch.SwatchClassifier}");
				Debug.WriteLine("{");
				Debug.Indent();

				foreach (var primary in swatch.Primaries)
				{
					var color = primary.Brush.Color;
					var hsl = color.ToHslColor();
				}
			}
		}
	}
}
