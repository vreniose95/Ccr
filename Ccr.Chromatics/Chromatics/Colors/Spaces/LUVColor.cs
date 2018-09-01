using Ccr.Std.Core.Extensions.NumericExtensions;

namespace Ccr.Chromatics.Colors.Spaces
{
  public struct LuvColor
  {
    public double L { get; }

    public double U { get; }

    public double V { get; }


    public LuvColor(
      double l,
      double u,
      double v)
    {
      l.ThrowIfNotWithin((0, 100), nameof(l));
      u.ThrowIfNotWithin((-100, 100), nameof(u));
      v.ThrowIfNotWithin((-100, 100), nameof(v));

      L = l;
      U = u;
      V = v;
    }
  }
}