using System;
using System.Windows.Media;
using Ccr.Std.Core.Extensions.NumericExtensions;
using Ccr.Std.Core.Numerics.Ranges;
using JetBrains.Annotations;

namespace Ccr.Core.Extensions
{
  public static class BrushExtensions
  {
    public static SolidColorBrush Darken(
      this SolidColorBrush @this,
      double percentage)
    {
      if (percentage.IsNotWithin(new DoubleRange(0d, 1d)))
        throw new ArgumentOutOfRangeException(
          nameof(percentage),
          percentage,
          "The percentage parameter must be between 0 and 1, inclusively.");

      return @this
             .Color
             .Darken(
               percentage)
             .ToSCB();
    }


    public static SolidColorBrush Lighten(
      this SolidColorBrush @this,
      double percentage)
    {
      if (percentage.IsNotWithin(new DoubleRange(0d, 1d)))
        throw new ArgumentOutOfRangeException(
          nameof(percentage),
          percentage,
          "The percentage parameter must be between 0 and 1, inclusively.");

      return @this
             .Color
             .Lighten(
               percentage)
             .ToSCB();
    }


    public static SolidColorBrush Invert(
      this SolidColorBrush @this)
    {
      return @this
             .Color
             .Invert()
             .ToSCB();
    }


    public static int Differential(
      this SolidColorBrush @this,
      SolidColorBrush brush)
    {
      return @this
             .Color
             .Differential(
               brush.Color);
    }


    /// <summary>
    ///   Method to mix two <c>SolidColorBrush</c> objects at a given opacity
    /// </summary>
    /// <param name="this">
    ///   Background <c>SolidColorBrush</c> object
    /// </param>
    /// <param name="foreground">
    ///   Foreground <c>SolidColorBrush</c> object
    /// </param>
    /// <param name="opacity">
    ///   Opacity value [0.0-1.0] of the overlayed foreground <c>SolidColorBrush</c> object
    /// </param>
    /// <returns>
    ///   The mixed <c>SolidColorBrush</c> object
    /// </returns>
    public static SolidColorBrush Blend(
      [NotNull] this SolidColorBrush @this,
      [NotNull] SolidColorBrush foreground,
      double opacity)
    {
      @this.IsNotNull(nameof(@this));
      foreground.IsNotNull(nameof(foreground));

      return @this
             .Color
             .Blend(
               foreground.Color,
               opacity)
             .ToSCB();
    }





    /// <summary>
    /// Method to create a <c>SolidColorBrush</c> object from a GreyScale value
    /// </summary>
    /// <param name="value">
    /// A Greyscale value [0-255] 
    /// </param>
    /// <returns>
    /// The created <c>SolidColorBrush</c> object
    /// </returns>
    public static SolidColorBrush Grayscale(
      byte value)
    {
      return Color.FromRgb(
        value,
        value,
        value).ToSCB();
    }


    public static SolidColorBrush Interpolate(
      [NotNull] this SolidColorBrush @this,
      [NotNull] SolidColorBrush brush,
      double percentage)
    {
      @this.IsNotNull(nameof(@this));
      brush.IsNotNull(nameof(brush));

      if (percentage.IsNotWithin(new DoubleRange(0d, 1d)))
        throw new ArgumentOutOfRangeException(
          nameof(percentage),
          percentage,
          "The percentage parameter must be between 0 and 1, inclusively.");

      return @this
             .Color
             .Interpolate(
               brush.Color,
               percentage)
             .ToSCB();
    }


    public static SolidColorBrush WithOpacity(
      [NotNull] this SolidColorBrush @this,
      double opacity)
    {
      @this.IsNotNull(nameof(@this));

      if (opacity.IsNotWithin(new DoubleRange(0d, 1d)))
        throw new ArgumentOutOfRangeException(
          nameof(opacity),
          opacity,
          "The opacity parameter must be between 0 and 1, inclusively.");

      return @this
             .Color
             .WithOpacity(
               opacity)
             .ToSCB();
    }

  }
}
