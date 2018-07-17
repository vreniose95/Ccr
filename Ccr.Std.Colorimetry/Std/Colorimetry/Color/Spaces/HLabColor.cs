using Ccr.Std.Core.Extensions.NumericExtensions;

namespace Ccr.Std.Colorimetry.Color.Spaces
{
  public struct HLabColor
  {
    public double L { get; }

    public double A { get; }

    public double B { get; }


    public HLabColor(
      double l,
      double a,
      double b)
    {
      l.ThrowIfNotWithin((0, 100), nameof(l));
      a.ThrowIfNotWithin((-100, 100), nameof(a));
      b.ThrowIfNotWithin((-100, 100), nameof(b));

      L = l;
      A = a;
      B = b;
    }
  }
}