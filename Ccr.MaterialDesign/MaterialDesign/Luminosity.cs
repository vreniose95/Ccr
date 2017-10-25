using System;
using Ccr.Core.Extensions.NumericExtensions;

namespace Ccr.MaterialDesign
{
  public class Luminosity
  {
    public int LuminosityIndex { get; }

    public bool IsAccent { get; }


    public Luminosity(
      int luminosityIndex,
      bool isAccent)
    {
      if(luminosityIndex.IsNotWithin((0, 1000)))
        throw new ArgumentOutOfRangeException(
          nameof(luminosityIndex),
          luminosityIndex,
          $"Luminosity value is not valid. Must be between 0 and 1000, inclusively.");

      LuminosityIndex = luminosityIndex;
      IsAccent = isAccent;
    }
  }
}
