using System;
using System.Windows.Media;
using Ccr.Core.Extensions.NumericExtensions;
using Ccr.Core.Numerics.Ranges;
using Ccr.PresentationCore.Media;

namespace Ccr.Core.Extensions
{
  public static class ColorExtensions
  {
    public static SolidColorBrush ToSCB(
      this Color @this)
    {
      return new SolidColorBrush(
        @this);
    }


    public static Color Darken(
      this Color @this,
      double percentage)
    {
      if (percentage.IsNotWithin(new DoubleRange(0d, 1d)))
        throw new ArgumentOutOfRangeException(
          nameof(percentage),
          percentage,
          "The percentage parameter must be between 0 and 1, inclusively.");

      var r = @this.R.ScaleDown(percentage);
      var g = @this.G.ScaleDown(percentage);
      var b = @this.B.ScaleDown(percentage);

      return Color.FromRgb(
        r,
        g,
        b);
    }

    public static Color Lighten(
      this Color @this,
      double percentage)
    {
      if (percentage.IsNotWithin(new DoubleRange(0d, 1d)))
        throw new ArgumentOutOfRangeException(
          nameof(percentage),
          percentage,
          "The percentage parameter must be between 0 and 1, inclusively.");

      var r = @this.R.ScaleDown(percentage);
      var g = @this.G.ScaleDown(percentage);
      var b = @this.B.ScaleDown(percentage);

      return Color.FromRgb(
        r,
        g,
        b);
    }


    public static int GetHue(
      this Color @this)
    {
      var min = Math.Min(
        Math.Min(
          @this.R, 
          @this.G), 
        @this.B);

      var max = Math.Max(
        Math.Max(
          @this.R,
          @this.G), 
        @this.B);


      float hue;
      if (max == @this.R)
        hue = (@this.G - @this.B).To<float>() / (max - min).To<float>();

      else if (max == @this.G)
        hue = 2f + (@this.B - @this.R).To<float>() / (max - min).To<float>();

      else
        hue = 4f + (@this.R - @this.G).To<float>() / (max - min).To<float>();


      hue *= 60f;

      if (hue < 0)
        hue += 360f;

      return (int)Math.Round(hue);
    }


    /// <summary>
    ///   Converts the equivelent <see cref="HslColor"/> Hsl color
    ///   model.
    /// </summary>
    /// <param name="this">
    ///   The color to convert.
    /// </param>
    /// <returns>
    ///   The equivelent <see cref="HslColor"/> Hsl color model.
    /// </returns>
		public static HslColor ToHslColor(
      this Color @this)
    {
      return HslColor.FromColor(
        @this);
    }


    /// <summary>
    ///   Converts the equivelent <see cref="HsvColor"/> Hsv color
    ///   model.
    /// </summary>
    /// <param name="this">
    ///   The color to convert.
    /// </param>
    /// <returns>
    ///   The equivelent <see cref="HsvColor"/> Hsv color model.
    /// </returns>
    public static HsvColor ToHsvColor(
      this Color @this)
    {
      return HsvColor.FromColor(
        @this);
    }


    /// <summary>
    ///   Calculates the inverted negative of the provided <see cref="@this"/>
    ///   parameter. 
    /// </summary>
    /// <param name="this">
    ///   The color to convert.
    /// </param>
    /// <returns>
    ///   The inverted negative of the provided <see cref="@this"/> color.
    /// </returns>
    public static Color Invert(
      this Color @this)
    {
      return new Color
      {
        ScR = 1f - @this.ScR,
        ScB = 1f - @this.ScB,
        ScG = 1f - @this.ScG,
        ScA = 1f
      };
    }


    /// <summary>
    ///   Calculates the color differential between two colors.
    /// </summary>
    /// <param name="this">
    ///   The subject color.
    /// </param>
    /// <param name="color">
    ///   The color to calculate the differential against.
    /// </param>
    /// <returns>
    ///   The color differential between the two colors.
    /// </returns>
	  public static int Differential(
      this Color @this,
      Color color)
    {
      var r = (@this.R - color.R).Abs();
      var g = (@this.G - color.G).Abs();
      var b = (@this.B - color.B).Abs();

      return r + g + b;
    }

    /// <summary>
    ///   Method to mix two <see cref="Color"/> objects at a given opacity.
    /// </summary>
    /// <param name="this">
    ///   Background <see cref="Color"/> object.
    /// </param>
    /// <param name="foreground">
    ///   Foreground <see cref="Color"/> object.
    /// </param>
    /// <param name="percentage">
    ///   Ther percentage value [0.0-1.0] of the overlayed <see cref="Color"/> object.
    /// </param>
    /// <returns>
    ///   The mixed <see cref="Color"/> object.
    /// </returns>
    public static Color Blend(
      this Color @this,
      Color foreground,
      double percentage)
    {
      if (percentage.IsNotWithin(new DoubleRange(0d, 1d)))
        throw new ArgumentOutOfRangeException(
          nameof(percentage),
          percentage,
          "The percentage parameter must be between 0 and 1, inclusively.");

      var difference = Color.Subtract(foreground, @this);
      var opacityFlt = Convert.ToSingle(percentage);
      var delta = Color.Multiply(difference, opacityFlt);
      var result = Color.Add(@this, delta);

      return result;
    }


    public static Color Interpolate(
      this Color @this,
      Color color,
      double percentage)
    {
      if (percentage.IsNotWithin(new DoubleRange(0d, 1d)))
        throw new ArgumentOutOfRangeException(
          nameof(percentage),
          percentage,
          "The percentage parameter must be between 0 and 1, inclusively.");

      var nR = (color.R - @this.R) * percentage;
      var nG = (color.G - @this.G) * percentage;
      var nB = (color.B - @this.B) * percentage;

      var eR = Convert.ToByte(@this.R + nR);
      var eG = Convert.ToByte(@this.G + nG);
      var eB = Convert.ToByte(@this.B + nB);

      return Color.FromRgb(eR, eG, eB);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="this"></param>
    /// <param name="opacity"></param>
    /// <returns></returns>
    public static Color WithOpacity(
      this Color @this,
      double opacity)
    {
      @this.IsNotNull(nameof(@this));

      if (opacity.IsNotWithin(new DoubleRange(0d, 1d)))
        throw new ArgumentOutOfRangeException(
          nameof(opacity),
          opacity,
          "The opacity parameter must be between 0 and 1, inclusively.");

      var fOpacity = Convert.ToSingle(opacity);

      return Color.FromScRgb(
        fOpacity,
        @this.ScR,
        @this.ScG,
        @this.ScB);
    }
  }
}
