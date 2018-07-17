using Ccr.Std.Core.Extensions.NumericExtensions;

namespace Ccr.Std.Colorimetry.Color.Spaces
{
  public struct LChavColor
  {
    public double L { get; }

    public double C { get; }

    public double H { get; }


    public LChavColor(
      double l,
      double c,
      double h)
    {
      l.ThrowIfNotWithin((0, 100), nameof(l));
      c.ThrowIfNotWithin((0, 100), nameof(c));
      h.ThrowIfNotWithin((0, 360), nameof(h));

      L = l;
      C = c;
      H = h;
    }
  }
}