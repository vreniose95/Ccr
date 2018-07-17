using Ccr.Std.Core.Extensions.NumericExtensions;

namespace Ccr.Std.Colorimetry.Color.Spaces
{
  public class LMSColor
  {
    public double L { get; }

    public double M { get; }

    public double S { get; }


    public LMSColor(
      double l,
      double m,
      double s)
    {
      l.ThrowIfNotWithin((-1, 1), nameof(l));
      m.ThrowIfNotWithin((-1, 1), nameof(m));
      s.ThrowIfNotWithin((-1, 1), nameof(s));

      L = l;
      M = m;
      S = s;
    }
  }
}