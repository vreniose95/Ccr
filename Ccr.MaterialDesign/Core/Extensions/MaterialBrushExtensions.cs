using System;
using Ccr.MaterialDesign;
using Ccr.Std.Core.Extensions.NumericExtensions;
using Ccr.Std.Core.Numerics.Ranges;

namespace Ccr.Core.Extensions
{
  public static class MaterialBrushExtensions
  {

    /// <summary>
    /// 
    /// </summary>
    /// <param name="this"></param>
    /// <param name="opacity"></param>
    /// <returns></returns>
    public static MaterialBrush WithOpacity(
      this MaterialBrush @this,
      double opacity)
    {
      @this.IsNotNull(nameof(@this));

      if (opacity.IsNotWithin(new DoubleRange(0d, 1d)))
        throw new ArgumentOutOfRangeException(
          nameof(opacity),
          opacity,
          "The opacity parameter must be between 0 and 1, inclusively.");
      
      var color = @this
                  .Brush
                  .Color
                  .WithOpacity(
                    opacity);

      var identity = new MaterialIdentity(
        @this.Identity.SwatchClassifier,
        @this.Identity.IsAccent,
        @this.Identity.Luminosity,
        opacity);

      return MaterialBrush.Create(
        color,
        identity);
    }
  }
}
