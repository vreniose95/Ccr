//using System;
//using System.Windows.Media;
//using Ccr.Std.Core.Extensions.NumericExtensions;

//namespace Ccr.MaterialDesign.Extensions
//{
//	public static class MediaExtensions
//	{
//		public static Color Darken(
//		  this Color @this, 
//		  double percent)
//		{
//			@this.R = @this.R.ScaleDown(percent);
//			@this.G = @this.G.ScaleDown(percent);
//			@this.B = @this.B.ScaleDown(percent);
//			return @this;
//		}

//		public static Color Lighten(
//		  this Color @this, 
//		  double percent)
//		{
//			@this.R = @this.R.ScaleUp(percent);
//			@this.G = @this.G.ScaleUp(percent);
//			@this.B = @this.B.ScaleUp(percent);
//			return @this;
//		}


//		public static SolidColorBrush Darken(
//	    this SolidColorBrush @this, 
//	    double percent)
//		{
//			return new SolidColorBrush(
//			  @this.Color.Darken(percent));
//		}

//		public static SolidColorBrush Lighten(
//		  this SolidColorBrush @this, 
//		  double percent)
//		{
//			return new SolidColorBrush(
//			  @this.Color.Lighten(percent));
//		}

		
//		public static Color Invert(this Color i)
//		{
//			return new Color
//			{
//				ScR = 1f - i.ScR,
//				ScB = 1f - i.ScB,
//				ScG = 1f - i.ScG,
//				ScA = 1f
//			};
//		}

//		public static SolidColorBrush Invert(this SolidColorBrush i)
//		{
//			return new SolidColorBrush(i.Color.Invert());
//		}

//		public static int Differential(this Color c1, Color c2)
//		{
//			var R = Math.Abs(c1.R - c2.R);
//			var G = Math.Abs(c1.G - c2.G);
//			var B = Math.Abs(c1.B - c2.B);

//			return R + G + B;
//		}

//		public static int Differential(this SolidColorBrush c1, SolidColorBrush c2)
//		{
//			return c1.Color.Differential(c2.Color);
//		}

//		public static HSLColor ToHSL(this Color c1)
//		{
//			return HSLColor.FromColor(c1);
//		}

//		/// <summary>
//		/// Method to mix two <c>SolidColorBrush</c> objects at a given opacity
//		/// </summary>
//		/// <param name="i">
//		/// Background <c>SolidColorBrush</c> object
//		/// </param>
//		/// <param name="foreground">
//		/// Foreground <c>SolidColorBrush</c> object
//		/// </param>
//		/// <param name="opacity">
//		/// Opacity value [0.0-1.0] of the overlayed foreground <c>SolidColorBrush</c> object
//		/// </param>
//		/// <returns>
//		/// The mixed <c>SolidColorBrush</c> object
//		/// </returns>
//		public static SolidColorBrush Blend(this SolidColorBrush i, SolidColorBrush foreground, double opacity)
//		{
//			var MixedColor = i.Color.Blend(foreground.Color, opacity);
//			return new SolidColorBrush(MixedColor);
//		}

//		/// <summary>
//		/// Method to mix two <c>Color</c> objects at a given opacity
//		/// </summary>
//		/// <param name="i">
//		/// Background <c>Color</c> object
//		/// </param>
//		/// <param name="foreground">
//		/// Foreground <c>Color</c> object
//		/// </param>
//		/// <param name="opacity">
//		/// Opacity value [0.0-1.0] of the overlayed foreground <c>Color</c> object
//		/// </param>
//		/// <returns>
//		/// The mixed <c>Color</c> object
//		/// </returns>
//		public static Color Blend(this Color i, Color foreground, double opacity)
//		{
//			var difference = Color.Subtract(foreground, i);
//			var opacityFlt = Convert.ToSingle(opacity);
//			var delta = Color.Multiply(difference, opacityFlt);
//			var result = Color.Add(i, delta);
//			return result;
//		}

//		public static SolidColorBrush ToSCB(this Color i) => new SolidColorBrush(i);

//		/// <summary>
//		/// Method to create a <c>SolidColorBrush</c> object from a GreyScale value
//		/// </summary>
//		/// <param name="value">
//		/// A GreyScale value [0-255] 
//		/// </param>
//		/// <returns>
//		/// The created <c>SolidColorBrush</c> object
//		/// </returns>
//		public static SolidColorBrush GrayScale(byte value) =>
//			new SolidColorBrush(Color.FromRgb(value, value, value));

//		public static SolidColorBrush Interpolate(Color a, Color b, double p)
//		{
//			if (!(p >= 0 && p <= 1)) throw new Exception("color interpolate");
//			var nR = (b.R - a.R) * p;
//			var nG = (b.G - a.G) * p;
//			var nB = (b.B - a.B) * p;

//			var eR = Convert.ToByte(a.R + nR);
//			var eG = Convert.ToByte(a.G + nG);
//			var eB = Convert.ToByte(a.B + nB);

//			return new SolidColorBrush(Color.FromRgb(eR, eG, eB));
//		}
//		public static SolidColorBrush Interpolate(SolidColorBrush a, SolidColorBrush b, double p)
//		{
//			if (!(p >= 0 && p <= 1)) throw new Exception("brush interpolate");
//			var nR = (b.Color.R - a.Color.R) * p;
//			var nG = (b.Color.G - a.Color.G) * p;
//			var nB = (b.Color.B - a.Color.B) * p;

//			var eR = Convert.ToByte(a.Color.R + nR);
//			var eG = Convert.ToByte(a.Color.G + nG);
//			var eB = Convert.ToByte(a.Color.B + nB);

//			return new SolidColorBrush(Color.FromRgb(eR, eG, eB));
//		}
//		//TODO just make this a virtual function in MaterialSet/overriden in MaterialSet 
//		public static MaterialSet Interpolate(MaterialSet a, MaterialSet b, double p)
//		{
			
//			var mixedSet = new AccentedMaterialSet()
//			{
//				P050 = Interpolate(a.P050, b.P050, p),
//				P100 = Interpolate(a.P100, b.P100, p),
//				P200 = Interpolate(a.P200, b.P200, p),
//				P300 = Interpolate(a.P300, b.P300, p),
//				P400 = Interpolate(a.P400, b.P400, p),
//				P500 = Interpolate(a.P500, b.P500, p),
//				P600 = Interpolate(a.P600, b.P600, p),
//				P700 = Interpolate(a.P700, b.P700, p),
//				P800 = Interpolate(a.P800, b.P800, p),
//				P900 = Interpolate(a.P900, b.P900, p),
//			};
//			if (!(a is AccentedMaterialSet) || !(b is AccentedMaterialSet)) return mixedSet;
			
//			var aa = (AccentedMaterialSet)a;
//			var ab = (AccentedMaterialSet)b;

//			mixedSet.A100 = Interpolate(aa.A100, ab.A100, p);
//			mixedSet.A200 = Interpolate(aa.A200, ab.A200, p);
//			mixedSet.A400 = Interpolate(aa.A400, ab.A400, p);
//			mixedSet.A700 = Interpolate(aa.A700, ab.A700, p);

//			return mixedSet;
//		}

//		public static SolidColorBrush WithOpacity(this SolidColorBrush i, double opactiy)
//		{
//			if(i == null)
//				return new SolidColorBrush(Palette.Brown.P500.Color) {Opacity = opactiy};
//			return new SolidColorBrush(i.Color) {Opacity = opactiy};
//		}


//	}
//}
