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
        foreach (var primary in swatch.Primaries)
        {
          //var color = primary.Color;

        }

      }
    }

  }
}
