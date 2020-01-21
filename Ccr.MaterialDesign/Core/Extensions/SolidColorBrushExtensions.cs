using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Ccr.MaterialDesign;
using Ccr.MaterialDesign.Primitives.Behaviors;
using Ccr.MaterialDesign.Static;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Core.Extensions
{
	public static class MediaExtensions
	{

		public static SolidColorBrush Darken(this SolidColorBrush i, double percent)
		{
			return new SolidColorBrush(i.Color.Darken(percent));
		}

		public static SolidColorBrush Lighten(this SolidColorBrush i, double percent)
		{
			return new SolidColorBrush(i.Color.Lighten(percent));
		}

		//public static SolidColorBrush Invert(this SolidColorBrush i)
		//{
		//	return new SolidColorBrush(i.Color.Invert());
		//}
		
		public static int Differential(this SolidColorBrush c1, SolidColorBrush c2)
		{
			return c1.Color.Differential(c2.Color);
		}

		//public static HslColor ToHSL(this Color c1)
		//{
		//	return HslColor.FromColor(c1);
		//}

		/// <summary>
		/// Method to mix two <c>SolidColorBrush</c> objects at a given opacity
		/// </summary>
		/// <param name="this">
		/// Background <c>SolidColorBrush</c> object
		/// </param>
		/// <param name="foreground">
		/// Foreground <c>SolidColorBrush</c> object
		/// </param>
		/// <param name="opacity">
		/// Opacity value [0.0-1.0] of the overlayed foreground <c>SolidColorBrush</c> object
		/// </param>
		/// <returns>
		/// The mixed <c>SolidColorBrush</c> object
		/// </returns>
		public static SolidColorBrush Blend(
			this SolidColorBrush @this,
			SolidColorBrush foreground, 
			double opacity)
		{
			var mixedColor = @this.Color.Blend(foreground.Color, opacity);
			return new SolidColorBrush(mixedColor);
		}

		///// <summary>
		///// Method to mix two <c>Color</c> objects at a given opacity
		///// </summary>
		///// <param name="i">
		///// Background <c>Color</c> object
		///// </param>
		///// <param name="foreground">
		///// Foreground <c>Color</c> object
		///// </param>
		///// <param name="opacity">
		///// Opacity value [0.0-1.0] of the overlayed foreground <c>Color</c> object
		///// </param>
		///// <returns>
		///// The mixed <c>Color</c> object
		///// </returns>
		//public static Color Blend(this Color i, Color foreground, double opacity)
		//{
		//	var difference = Color.Subtract(foreground, i);
		//	var opacityFlt = Convert.ToSingle(opacity);
		//	var delta = Color.Multiply(difference, opacityFlt);
		//	var result = Color.Add(i, delta);
		//	return result;
		//}

		//public static SolidColorBrush ToSCB(this Color i) => new SolidColorBrush(i);

		/// <summary>
		/// Method to create a <c>SolidColorBrush</c> object from a GreyScale value
		/// </summary>
		/// <param name="value">
		/// A GreyScale value [0-255] 
		/// </param>
		/// <returns>
		/// The created <c>SolidColorBrush</c> object
		/// </returns>
		public static SolidColorBrush GrayScale(byte value) =>
			new SolidColorBrush(Color.FromRgb(value, value, value));

		public static SolidColorBrush Interpolate(Color a, Color b, double p)
		{
			if (!(p >= 0 && p <= 1)) throw new Exception("color interpolate");
			var nR = (b.R - a.R) * p;
			var nG = (b.G - a.G) * p;
			var nB = (b.B - a.B) * p;

			var eR = Convert.ToByte(a.R + nR);
			var eG = Convert.ToByte(a.G + nG);
			var eB = Convert.ToByte(a.B + nB);

			return new SolidColorBrush(Color.FromRgb(eR, eG, eB));
		}

		public static SolidColorBrush Interpolate(SolidColorBrush a, SolidColorBrush b, double p)
		{
			if (!(p >= 0 && p <= 1)) 
				throw new Exception("brush interpolate");

			var aIdentity = a.GetIdentity();
			var bIdentity = b.GetIdentity();
			
			var nR = (b.Color.R - a.Color.R) * p;
			var nG = (b.Color.G - a.Color.G) * p;
			var nB = (b.Color.B - a.Color.B) * p;

			var eR = Convert.ToByte(a.Color.R + nR);
			var eG = Convert.ToByte(a.Color.G + nG);
			var eB = Convert.ToByte(a.Color.B + nB);

			var interpolated = new SolidColorBrush(
				Color.FromRgb(eR, eG, eB));

			interpolated.SetIdentity(aIdentity);

			//if (aIdentity == bIdentity)
			//{
			//}
			//else
			//{
			//}

			return interpolated;
		}

		//TODO just make this a virtual function in MaterialSet/overriden in MaterialSet 
		public static Swatch Interpolate(Swatch a, Swatch b, double p)
		{
			var P050 = Interpolate(a.P050, b.P050, p);
			var P100 = Interpolate(a.P100, b.P100, p);
			var P200 = Interpolate(a.P200, b.P200, p);
			var P300 = Interpolate(a.P300, b.P300, p);
			var P400 = Interpolate(a.P400, b.P400, p);
			var P500 = Interpolate(a.P500, b.P500, p);
			var P600 = Interpolate(a.P600, b.P600, p);
			var P700 = Interpolate(a.P700, b.P700, p);
			var P800 = Interpolate(a.P800, b.P800, p);
			var P900 = Interpolate(a.P900, b.P900, p);

			if (!a.Accents.Any() || !b.Accents.Any())
			{
				return Swatch.Create(
					P050,
					P100,
					P200,
					P300,
					P400,
					P500,
					P600,
					P700,
					P800,
					P900);
			}

			var A100 = Interpolate(a.A100, b.A100, p);
			var A200 = Interpolate(a.A200, b.A200, p);
			var A400 = Interpolate(a.A400, b.A400, p);
			var A700 = Interpolate(a.A700, b.A700, p);
			
			return Swatch.Create(
				P050,
				P100,
				P200,
				P300,
				P400,
				P500,
				P600,
				P700,
				P800,
				P900,
				A100,
				A200,
				A400,
				A700);
		}

		public static SolidColorBrush WithOpacity(this SolidColorBrush i, double opactiy)
		{
			if (i == null)
				return new SolidColorBrush(PaletteResources.Brown.P500.Color)
				{
					Opacity = opactiy
				};

			return new SolidColorBrush(i.Color)
			{
				Opacity = opactiy
			};
		}
	}

	public static class SolidColorBrushExtensions
  {
    [CanBeNull]
    public static MaterialIdentity GetIdentity(
      [NotNull] this SolidColorBrush @this)
    {
      @this.IsNotNull(nameof(@this));

      var boxedValue = @this.GetValue(MDH.IdentityProperty);
      var identity = boxedValue as MaterialIdentity;

      if (boxedValue == null
          || boxedValue == DependencyProperty.UnsetValue
          || identity == null)
      {
        return null;
      }

      return identity;
    }

    [CanBeNull]
    public static SolidColorBrush SetIdentity(
      [NotNull] this SolidColorBrush @this,
      [CanBeNull] MaterialIdentity materialIdentity)
    {
      @this.IsNotNull(nameof(@this));

      if ((@this.CanFreeze && @this.IsFrozen) || @this.IsSealed)
      {
        //@this.Changed += (s, args) =>
        //{

        //};
        var cloned = @this.Clone();

        cloned.SetValue(
          MDH.IdentityProperty,
          materialIdentity);

        cloned.Freeze();

        return cloned;
      }
      else
      {
        //@this.Changed += (s, args) =>
        //{

        //};

        var existingIdentity = @this.GetIdentity();
        if (existingIdentity != null)
        {
          if (!existingIdentity.Equals(materialIdentity))
          {

          }
        }
        @this.SetValue(
          MDH.IdentityProperty,
          materialIdentity);

        if (@this.CanFreeze)
        {
          @this.Freeze();
        }

        return @this;
      }
    }
  }
}