using Ccr.Std.Core.Extensions.NumericExtensions;

namespace Ccr.Std.Colorimetry.Color.Spaces
{
  public struct ScRGBColor
  {
    public double ScR { get; }

    public double ScG { get; }

    public double ScB { get; }


    public ScRGBColor(
      double scr,
      double scg,
      double scb)
    {
      scr.ThrowIfNotWithin((0, 1), nameof(scr));
      scg.ThrowIfNotWithin((0, 1), nameof(scg));
      scb.ThrowIfNotWithin((0, 1), nameof(scb));

      ScR = scr;
      ScG = scg;
      ScB = scb;
    }
  }
}