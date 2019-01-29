using Ccr.Core.Extensions.NumericExtensions;
using Ccr.PresentationCore.Media;
using System;
using System.Windows.Media;

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
      if (percentage.IsNotWithin((0d, 1d)))
        throw new ArgumentOutOfRangeException(
          nameof(percentage),
          percentage,
          "The percentage parameter must be between 0 and 1, inclusively.");

      var r = @this.R.ScaleDown(percentage);
      var g = @this.G.ScaleDown(percentage);
      var b = @this.B.ScaleDown(percentage);

      return Color.FromRgb(r, g, b);
    }


    public static Color Lighten(
      this Color @this,
      double percentage)
    {
      if (percentage.IsNotWithin((0d, 1d)))
        throw new ArgumentOutOfRangeException(
          nameof(percentage),
          percentage,
          "The percentage parameter must be between 0 and 1, inclusively.");

      var r = @this.R.ScaleDown(percentage);
      var g = @this.G.ScaleDown(percentage);
      var b = @this.B.ScaleDown(percentage);

      return Color.FromRgb(r, g, b);
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
    ///   Converts the Equivalent <see cref="HslColor"/> Hsl color
    ///   model.
    /// </summary>
    /// <param name="this">
    ///   The color to convert.
    /// </param>
    /// <returns>
    ///   The Equivalent <see cref="HslColor"/> Hsl color model.
    /// </returns>
    public static HslColor ToHslColor(
      this Color @this)
    {
      return HslColor.FromColor(
        @this);
    }


    /// <summary>
    ///   Converts the Equivalent <see cref="HsvColor"/> Hsv color
    ///   model.
    /// </summary>
    /// <param name="this">
    ///   The color to convert.
    /// </param>
    /// <returns>
    ///   The Equivalent <see cref="HsvColor"/> Hsv color model.
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
  ///   Calculates the constrast luminance between the subject <paramref name="background"/> Color
  ///   and the <see cref="foreground"/> Color.
  /// </summary>
  /// <param name="background">
  ///   The background <see cref="Color"/> that the <paramref name="foreground"/> parameter is to
  ///   be compared against.
  /// </param>
  /// <param name="foreground">
  ///   The foreground <see cref="Color"/> that the <paramref name="background"/> parameter is to
  ///   be compared against.
  /// </param>
  /// <returns>
  ///   Returns a <see cref="double"/> value representing the constrast ratio between the two
  ///   provided Color instances, which range from 1 to 21, inclusively.
  /// </returns>
  public static double ContrastRatio(
    this Color background,
    Color foreground)
  {
    var backgroundLum = background.RelativeLuminance();
    var foregroundLum = foreground.RelativeLuminance();

    return foregroundLum > backgroundLum
      ? (foregroundLum + 0.05) / (backgroundLum + 0.05)
      : (backgroundLum + 0.05) / (foregroundLum + 0.05);
  }

  /// <summary>
  ///   Calculates the color relative luminance of the sRGB channels of a <see cref="Color"/> instance.
  /// </summary>
  /// <param name="this">
  ///   The subject color.
  /// </param>
  /// <returns>
  ///   The <paramref name="@this"/> Color's relative luminance.
  /// </returns>
  public static double RelativeLuminance(
    this Color @this)
  {
    var r = @this.RelativeChannelLuminance(t => ((double)t.R / 255));
    var g = @this.RelativeChannelLuminance(t => ((double)t.G / 255));
    var b = @this.RelativeChannelLuminance(t => ((double)t.B / 255));

			return 0.2126 * r
      + 0.7152 * g
      + 0.0722 * b;
  }

  /// <summary>
  ///   Calculates the relative luminance of one sRGB channel of a <see cref="Color"/> instance.
  /// </summary>
  /// <param name="this">
  ///   The subject color.
  /// </param>
  /// <param name="channelFunc">
  ///   A <see cref="Func{Color, Float}"/> identifying the channel of which to calculate the
  ///   relative luminance upon.
  /// </param>
  /// <returns>
  ///   Returns a <see cref="double"/> value indicating the relative luminance of the selected
  ///   channel provided by the <paramref name="channelFunc"/> parameter Func. 
  /// </returns>
  private static double RelativeChannelLuminance(
    this Color @this,
    Func<Color, double> channelFunc)
  {
    var sc = channelFunc(@this);
    return sc <= 0.03928
      ? sc / 12.92
      : ((sc + 0.055) / 1.055).Power(2.4);
  }
    

    /// <summary>
    ///    Calculates the color differential between two colors.
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



    public static double LuminosityContrast(this Color foreground, Color background)
    {
	    var foregroundLuminosity = RelativeLuminance(foreground.R, foreground.G, foreground.B);
	    var backgroundLuminosity = RelativeLuminance(background.R, background.G, background.B);

	    if (foregroundLuminosity > backgroundLuminosity)
	    {
		    return (foregroundLuminosity + 0.05) / (backgroundLuminosity + 0.05);
	    }
	    else
	    {
		    return (backgroundLuminosity + 0.05) / (foregroundLuminosity + 0.05);
	    }
    }

		private static double RelativeLuminance(byte r, byte g, byte b)
    {
	    double rs = ((double)r / 255);
	    double gs = ((double)g / 255);
	    double bs = ((double)b / 255);
	    double R = 0;
	    double G = 0;
	    double B = 0;

	    R = (rs <= 0.03928) ? (double)(rs / 12.92) : Math.Pow(((rs + 0.055) / 1.055), 2.4);
	    G = (gs <= 0.03928) ? (double)(gs / 12.92) : Math.Pow(((gs + 0.055) / 1.055), 2.4);
	    B = (bs <= 0.03928) ? (double)(bs / 12.92) : Math.Pow(((bs + 0.055) / 1.055), 2.4);

	    return ((double)(0.2126 * R)) + ((double)(0.7152 * G)) + ((double)(0.0722 * B));
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
      if (percentage.IsNotWithin((0d, 1d)))
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
      if (percentage.IsNotWithin((0d, 1d)))
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

      if (opacity.IsNotWithin((0d, 1d)))
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













/*

public class MYCLASSNAME
{
(function() {
var Color, DEG2RAD, LAB_CONSTANTS, PI, PITHIRD, RAD2DEG, TWOPI, _average_lrgb, _guess_formats, _guess_formats_sorted, _input, _interpolators, abs, atan2, bezier, blend, blend_f, brewer, burn, chroma, clip_rgb, cmyk2rgb, colors, cos, css2rgb, darken, dodge, each, floor, hcg2rgb, hex2rgb, hsi2rgb, hsl2css, hsl2rgb, hsv2rgb, interpolate, interpolate_hsx, interpolate_lab, interpolate_lrgb, interpolate_num, interpolate_rgb, lab2lch, lab2rgb, lab_xyz, lch2lab, lch2rgb, lighten, limit, log, luminance_x, m, max, multiply, normal, num2rgb, overlay, pow, rgb2cmyk, rgb2css, rgb2hcg, rgb2hex, rgb2hsi, rgb2hsl, rgb2hsv, rgb2lab, rgb2lch, rgb2luminance, rgb2num, rgb2temperature, rgb2xyz, rgb_xyz, rnd, root, round, screen, sin, sqrt, temperature2rgb, type, unpack, w3cx11, xyz_lab, xyz_rgb,
slice = [].slice;

type = (function() {

/*
for browser-safe type checking+
ported from jQuery's $.type
 */
//    var classToType, len, name, o, ref;
//    classToType = {};
//    ref = "Boolean Number string Function Array Date RegExp Undefined Null".split(" ");
//    for (o = 0, len = ref.length; o<len; o++) {
//      name = ref[o];
//      classToType["[object " + name + "]"] = name.toLowerCase();
//    }
//    return function(obj)
//  {
//    FIXME_VAR_TYPE strType;
//    strType = Object.prototype.toString.call(obj);
//    return classToType[strType] || "object";
//  };
//})();

//  limit = function(x, min, max)
//{
//  if (min == null)
//  {
//    min = 0;
//  }
//  if (max == null)
//  {
//    max = 1;
//  }
//  if (x < min)
//  {
//    x = min;
//  }
//  if (x > max)
//  {
//    x = max;
//  }
//  return x;
//};

//unpack = function(args)
//{
//  if (args.length >= 3)
//  {
//    return [].slice.call(args);
//  }
//  else
//  {
//    return args[0];
//  }
//};

//clip_rgb = function(rgb)
//{
//  var i, o;
//  rgb._clipped = false;
//  rgb._unclipped = rgb.slice(0);
//  for (i = o = 0; o < 3; i = ++o)
//  {
//    if (i < 3)
//    {
//      if (rgb[i] < 0 || rgb[i] > 255)
//      {
//        rgb._clipped = true;
//      }
//      if (rgb[i] < 0)
//      {
//        rgb[i] = 0;
//      }
//      if (rgb[i] > 255)
//      {
//        rgb[i] = 255;
//      }
//    }
//    else if (i === 3)
//    {
//      if (rgb[i] < 0)
//      {
//        rgb[i] = 0;
//      }
//      if (rgb[i] > 1)
//      {
//        rgb[i] = 1;
//      }
//    }
//  }
//  if (!rgb._clipped)
//  {
//    delete rgb._unclipped;
//  }
//  return rgb;
//};

//PI = Math.PI, round = Math.round, cos = Math.cos, floor = Math.floor, pow = Math.pow, log = Math.log, sin = Math.sin, sqrt = Math.sqrt, atan2 = Math.atan2, max = Math.max, abs = Math.abs;

//  TWOPI = PI* 2;

//  PITHIRD = PI / 3;

//  DEG2RAD = PI / 180;

//  RAD2DEG = 180 / PI;

//  chroma = function()
//{
//  if (arguments[0] instanceof Color) {
//    return arguments[0];
//  }
//  return (function(func, args, ctor) {
//    ctor.prototype = func.prototype;
//    FIXME_VAR_TYPE child = new ctor, result = func.apply(child, args);
//    return Object(result) === result ? result : child;
//  })(Color, arguments, function(){ });
//};

//chroma["default"] = chroma;

//  _interpolators = [];

//  if ((typeof module !== "undefined" && module !== null) && (module.exports != null)) {
//    module.exports = chroma;
//  }

//  if (typeof define === 'function' && define.amd) {
//    define([], function() {
//  return chroma;
//});
//  } else {
//    root = typeof exports !== "undefined" && exports !== null ? exports : this;
//    root.chroma = chroma;
//  }

//chroma.version = '1.3f.5';

//  _input = {};

//  _guess_formats = [];

//  _guess_formats_sorted = false;

//  Color = (function() {
//    void Color()
//{
//  var arg, args, chk, len, len1, me, mode, o, w;
//  me = this;
//  args = [];
//  for (o = 0, len = arguments.length; o < len; o++)
//  {
//    arg = arguments[o];
//    if (arg != null)
//    {
//      args.push(arg);
//    }
//  }
//  if (args.length > 1)
//  {
//    mode = args[args.length - 1];
//  }
//  if (_input[mode] != null)
//  {
//    me._rgb = clip_rgb(_input[mode](unpack(args.slice(0, -1))));
//  }
//  else
//  {
//    if (!_guess_formats_sorted)
//    {
//      _guess_formats = _guess_formats.sort(function(a, b) {
//        return b.p - a.p;
//      });
//      _guess_formats_sorted = true;
//    }
//    for (w = 0, len1 = _guess_formats.length; w < len1; w++)
//    {
//      chk = _guess_formats[w];
//      mode = chk.test.apply(chk, args);
//      if (mode)
//      {
//        break;
//      }
//    }
//    if (mode)
//    {
//      me._rgb = clip_rgb(_input[mode].apply(_input, args));
//    }
//  }
//  if (me._rgb == null)
//  {
//    console.warn('unknown format: ' + args);
//  }
//  if (me._rgb == null)
//  {
//    me._rgb = [0, 0, 0];
//  }
//  if (me._rgb.length === 3)
//  {
//    me._rgb.push(1);
//  }
//}

//Color.prototype.toString = function()
//{
//  return this.hex();
//};

//Color.prototype.clone = function()
//{
//  return chroma(me._rgb);
//};

//    return Color;

//  })();

//  chroma._input = _input;


//    public static void LabToRgb(
//      )
//    {

//    }
//  lab2rgb = function()
//{
//  var a, args, b, g, l, r, x, y, z;
//  args = unpack(arguments);
//  l = args[0], a = args[1], b = args[2];
//  y = (l + 16) / 116;
//  x = isNaN(a) ? y : y + a / 500;
//  z = isNaN(b) ? y : y - b / 200;
//  y = LAB_CONSTANTS.Yn * lab_xyz(y);
//  x = LAB_CONSTANTS.Xn * lab_xyz(x);
//  z = LAB_CONSTANTS.Zn * lab_xyz(z);
//  r = xyz_rgb(3.2404542f * x - 1.5371385f * y - 0.4985314f * z);
//  g = xyz_rgb(-0.9692660f * x + 1.8760108f * y + 0.0415560f * z);
//  b = xyz_rgb(0.0556434f * x - 0.2040259f * y + 1.0572252f * z);
//  return [r, g, b, args.length > 3 ? args[3] : 1];
//};

//xyz_rgb = function(r)
//{
//  return 255 * (r <= 0.00304f ? 12.92f * r : 1.055f * pow(r, 1 / 2.4f) - 0.055f);
//};

//lab_xyz = function(t)
//{
//  if (t > LAB_CONSTANTS.t1)
//  {
//    return t * t * t;
//  }
//  else
//  {
//    return LAB_CONSTANTS.t2 * (t - LAB_CONSTANTS.t0);
//  }
//};

//LAB_CONSTANTS = {
//    Kn: 18,
//    Xn: 0.950470f,
//    Yn: 1,
//    Zn: 1.088830f,
//    t0: 0.137931034f,
//    t1: 0.206896552f,
//    t2: 0.12841855f,
//    t3: 0.008856452f
//  };

//  rgb2lab = function()
//{
//  var b, g, r, ref, ref1, x, y, z;
//  ref = unpack(arguments), r = ref[0], g = ref[1], b = ref[2];
//  ref1 = rgb2xyz(r, g, b), x = ref1[0], y = ref1[1], z = ref1[2];
//  return [116 * y - 16, 500 * (x - y), 200 * (y - z)];
//};

//rgb_xyz = function(r)
//{
//  if ((r /= 255) <= 0.04045f)
//  {
//    return r / 12.92f;
//  }
//  else
//  {
//    return pow((r + 0.055f) / 1.055f, 2.4f);
//  }
//};

//xyz_lab = function(t)
//{
//  if (t > LAB_CONSTANTS.t3)
//  {
//    return pow(t, 1 / 3);
//  }
//  else
//  {
//    return t / LAB_CONSTANTS.t2 + LAB_CONSTANTS.t0;
//  }
//};

//rgb2xyz = function()
//{
//  var b, g, r, ref, x, y, z;
//  ref = unpack(arguments), r = ref[0], g = ref[1], b = ref[2];
//  r = rgb_xyz(r);
//  g = rgb_xyz(g);
//  b = rgb_xyz(b);
//  x = xyz_lab((0.4124564f * r + 0.3575761f * g + 0.1804375f * b) / LAB_CONSTANTS.Xn);
//  y = xyz_lab((0.2126729f * r + 0.7151522f * g + 0.0721750f * b) / LAB_CONSTANTS.Yn);
//  z = xyz_lab((0.0193339f * r + 0.1191920f * g + 0.9503041f * b) / LAB_CONSTANTS.Zn);
//  return [x, y, z];
//};

//chroma.lab = function()
//{
//  return (function(func, args, ctor) {
//    ctor.prototype = func.prototype;
//    FIXME_VAR_TYPE child = new ctor, result = func.apply(child, args);
//    return Object(result) === result ? result : child;
//  })(Color, slice.call(arguments).concat(['lab']), function(){ });
//};

//_input.lab = lab2rgb;

//  Color.prototype.lab = function()
//{
//  return rgb2lab(this._rgb);
//};

//bezier = function(colors)
//{
//  var I, I0, I1, c, lab0, lab1, lab2, lab3, ref, ref1, ref2;
//  colors = (function() {
//    var len, o, results;
//    results = [];
//    for (o = 0, len = colors.length; o < len; o++)
//    {
//      c = colors[o];
//      results.push(chroma(c));
//    }
//    return results;
//  })();
//  if (colors.length === 2)
//  {
//    ref = (function() {
//      var len, o, results;
//      results = [];
//      for (o = 0, len = colors.length; o < len; o++)
//      {
//        c = colors[o];
//        results.push(c.lab());
//      }
//      return results;
//    })(), lab0 = ref[0], lab1 = ref[1];
//    I = function(t) {
//      var i, lab;
//      lab = (function() {
//        var o, results;
//        results = [];
//        for (i = o = 0; o <= 2; i = ++o)
//        {
//          results.push(lab0[i] + t * (lab1[i] - lab0[i]));
//        }
//        return results;
//      })();
//      return chroma.lab.apply(chroma, lab);
//    };
//  }
//  else if (colors.length === 3)
//  {
//    ref1 = (function() {
//      var len, o, results;
//      results = [];
//      for (o = 0, len = colors.length; o < len; o++)
//      {
//        c = colors[o];
//        results.push(c.lab());
//      }
//      return results;
//    })(), lab0 = ref1[0], lab1 = ref1[1], lab2 = ref1[2];
//    I = function(t) {
//      var i, lab;
//      lab = (function() {
//        var o, results;
//        results = [];
//        for (i = o = 0; o <= 2; i = ++o)
//        {
//          results.push((1 - t) * (1 - t) * lab0[i] + 2 * (1 - t) * t * lab1[i] + t * t * lab2[i]);
//        }
//        return results;
//      })();
//      return chroma.lab.apply(chroma, lab);
//    };
//  }
//  else if (colors.length === 4)
//  {
//    ref2 = (function() {
//      var len, o, results;
//      results = [];
//      for (o = 0, len = colors.length; o < len; o++)
//      {
//        c = colors[o];
//        results.push(c.lab());
//      }
//      return results;
//    })(), lab0 = ref2[0], lab1 = ref2[1], lab2 = ref2[2], lab3 = ref2[3];
//    I = function(t) {
//      var i, lab;
//      lab = (function() {
//        var o, results;
//        results = [];
//        for (i = o = 0; o <= 2; i = ++o)
//        {
//          results.push((1 - t) * (1 - t) * (1 - t) * lab0[i] + 3 * (1 - t) * (1 - t) * t * lab1[i] + 3 * (1 - t) * t * t * lab2[i] + t * t * t * lab3[i]);
//        }
//        return results;
//      })();
//      return chroma.lab.apply(chroma, lab);
//    };
//  }
//  else if (colors.length === 5)
//  {
//    I0 = bezier(colors.slice(0, 3));
//    I1 = bezier(colors.slice(2, 5));
//    I = function(t) {
//      if (t < 0.5f)
//      {
//        return I0(t * 2);
//      }
//      else
//      {
//        return I1((t - 0.5f) * 2);
//      }
//    };
//  }
//  return I;
//};

//chroma.bezier = function(colors)
//{
//  FIXME_VAR_TYPE f;
//  f = bezier(colors);
//  f.scale = function() {
//    return chroma.scale(f);
//  };
//  return f;
//};







//chroma.cubehelix = function(start, rotations, hue, gamma, lightness)
//{
//  var dh, dl, f;
//  if (start == null)
//  {
//    start = 300;
//  }
//  if (rotations == null)
//  {
//    rotations = -1.5f;
//  }
//  if (hue == null)
//  {
//    hue = 1;
//  }
//  if (gamma == null)
//  {
//    gamma = 1;
//  }
//  if (lightness == null)
//  {
//    lightness = [0, 1];
//  }
//  dh = 0;
//  if (type(lightness) === 'array')
//  {
//    dl = lightness[1] - lightness[0];
//  }
//  else
//  {
//    dl = 0;
//    lightness = [lightness, lightness];
//  }
//  f = function(fract) {
//    var a, amp, b, cos_a, g, h, l, r, sin_a;
//    a = TWOPI * ((start + 120) / 360 + rotations * fract);
//    l = pow(lightness[0] + dl * fract, gamma);
//    h = dh !== 0 ? hue[0] + fract * dh : hue;
//    amp = h * l * (1 - l) / 2;
//    cos_a = cos(a);
//    sin_a = sin(a);
//    r = l + amp * (-0.14861f * cos_a + 1.78277f * sin_a);
//    g = l + amp * (-0.29227f * cos_a - 0.90649f * sin_a);
//    b = l + amp * (+1.97294f * cos_a);
//    return chroma(clip_rgb([r * 255, g * 255, b * 255]));
//  };
//  f.start = function(s) {
//    if (s == null)
//    {
//      return start;
//    }
//    start = s;
//    return f;
//  };
//  f.rotations = function(r) {
//    if (r == null)
//    {
//      return rotations;
//    }
//    rotations = r;
//    return f;
//  };
//  f.gamma = function(g) {
//    if (g == null)
//    {
//      return gamma;
//    }
//    gamma = g;
//    return f;
//  };
//  f.hue = function(h) {
//    if (h == null)
//    {
//      return hue;
//    }
//    hue = h;
//    if (type(hue) === 'array')
//    {
//      dh = hue[1] - hue[0];
//      if (dh === 0)
//      {
//        hue = hue[1];
//      }
//    }
//    else
//    {
//      dh = 0;
//    }
//    return f;
//  };
//  f.lightness = function(h) {
//    if (h == null)
//    {
//      return lightness;
//    }
//    if (type(h) === 'array')
//    {
//      lightness = h;
//      dl = h[1] - h[0];
//    }
//    else
//    {
//      lightness = [h, h];
//      dl = 0;
//    }
//    return f;
//  };
//  f.scale = function() {
//    return chroma.scale(f);
//  };
//  f.hue(hue);
//  return f;
//};

//chroma.random = function()
//{
//  var code, digits, i, o;
//  digits = '0123456789abcdef';
//  code = '#';
//  for (i = o = 0; o < 6; i = ++o)
//  {
//    code += digits.charAt(floor(Math.random() * 16));
//  }
//  return new Color(code);
//};

//_interpolators = [];

//  interpolate = function(col1, col2, f, m)
//{
//  var interpol, len, o, res;
//  if (f == null)
//  {
//    f = 0.5f;
//  }
//  if (m == null)
//  {
//    m = 'rgb';
//  }

//  /*
//  interpolates between colors
//  f = 0 --> me
//  f = 1 --> col
//   */
//  if (type(col1) !== 'object')
//  {
//    col1 = chroma(col1);
//  }
//  if (type(col2) !== 'object')
//  {
//    col2 = chroma(col2);
//  }
//  for (o = 0, len = _interpolators.length; o < len; o++)
//  {
//    interpol = _interpolators[o];
//    if (m === interpol[0])
//    {
//      res = interpol[1](col1, col2, f, m);
//      break;
//    }
//  }
//  if (res == null)
//  {
//    throw "color mode " + m + " is not supported";
//  }
//  return res.alpha(col1.alpha() + f * (col2.alpha() - col1.alpha()));
//};

//chroma.interpolate = interpolate;

//  Color.prototype.interpolate = function(col2, f, m)
//{
//  return interpolate(this, col2, f, m);
//};

//chroma.mix = interpolate;

//  Color.prototype.mix = Color.prototype.interpolate;

//  _input.rgb = function()
//{
//  var k, ref, results, v;
//  ref = unpack(arguments);
//  results = [];
//  foreach (k in ref) {
//    v = ref[k];
//    results.push(v);
//  }
//  return results;
//};

//chroma.rgb = function()
//{
//  return (function(func, args, ctor) {
//    ctor.prototype = func.prototype;
//    FIXME_VAR_TYPE child = new ctor, result = func.apply(child, args);
//    return Object(result) === result ? result : child;
//  })(Color, slice.call(arguments).concat(['rgb']), function(){ });
//};

//Color.prototype.rgb = function(round)
//{
//  if (round == null)
//  {
//    round = true;
//  }
//  if (round)
//  {
//    return this._rgb.map(Math.round).slice(0, 3);
//  }
//  else
//  {
//    return this._rgb.slice(0, 3);
//  }
//};

//Color.prototype.rgba = function(round)
//{
//  if (round == null)
//  {
//    round = true;
//  }
//  if (!round)
//  {
//    return this._rgb.slice(0);
//  }
//  return [Math.round(this._rgb[0]), Math.round(this._rgb[1]), Math.round(this._rgb[2]), this._rgb[3]];
//};

//_guess_formats.push({
//    p: 3,
//    test: function(n)
//{
//  FIXME_VAR_TYPE a;
//  a = unpack(arguments);
//  if (type(a) === 'array' && a.length === 3)
//  {
//    return 'rgb';
//  }
//  if (a.length === 4 && type(a[3]) === "number" && a[3] >= 0 && a[3] <= 1)
//  {
//    return 'rgb';
//  }
//}
//  });

//  _input.lrgb = _input.rgb;

//  interpolate_lrgb = function(col1, col2, f, m)
//{
//  var xyz0, xyz1;
//  xyz0 = col1._rgb;
//  xyz1 = col2._rgb;
//  return new Color(sqrt(pow(xyz0[0], 2) * (1 - f) + pow(xyz1[0], 2) * f), sqrt(pow(xyz0[1], 2) * (1 - f) + pow(xyz1[1], 2) * f), sqrt(pow(xyz0[2], 2) * (1 - f) + pow(xyz1[2], 2) * f), m);
//};

//_average_lrgb = function(colors)
//{
//  var col, f, len, o, rgb, xyz;
//  f = 1 / colors.length;
//  xyz = [0, 0, 0, 0];
//  for (o = 0, len = colors.length; o < len; o++)
//  {
//    col = colors[o];
//    rgb = col._rgb;
//    xyz[0] += pow(rgb[0], 2) * f;
//    xyz[1] += pow(rgb[1], 2) * f;
//    xyz[2] += pow(rgb[2], 2) * f;
//    xyz[3] += rgb[3] * f;
//  }
//  xyz[0] = sqrt(xyz[0]);
//  xyz[1] = sqrt(xyz[1]);
//  xyz[2] = sqrt(xyz[2]);
//  return new Color(xyz);
//};

//_interpolators.push(['lrgb', interpolate_lrgb]);

//  chroma.average = function(colors, mode)
//{
//  var A, alpha, c, cnt, dx, dy, first, i, l, len, o, xyz, xyz2;
//  if (mode == null)
//  {
//    mode = 'rgb';
//  }
//  l = colors.length;
//  colors = colors.map(function(c) {
//    return chroma(c);
//  });
//  first = colors.splice(0, 1)[0];
//  if (mode === 'lrgb')
//  {
//    return _average_lrgb(colors);
//  }
//  xyz = first.get(mode);
//  cnt = [];
//  dx = 0;
//  dy = 0;
//  foreach (i in xyz)
//  {
//    xyz[i] = xyz[i] || 0;
//    cnt.push(!isNaN(xyz[i]) ? 1 : 0);
//    if (mode.charAt(i) === 'h' && !isNaN(xyz[i]))
//    {
//      A = xyz[i] / 180 * PI;
//      dx += cos(A);
//      dy += sin(A);
//    }
//  }
//  alpha = first.alpha();
//  for (o = 0, len = colors.length; o < len; o++)
//  {
//    c = colors[o];
//    xyz2 = c.get(mode);
//    alpha += c.alpha();
//    foreach (i in xyz)
//    {
//      if (!isNaN(xyz2[i]))
//      {
//        xyz[i] += xyz2[i];
//        cnt[i] += 1;
//        if (mode.charAt(i) === 'h')
//        {
//          A = xyz[i] / 180 * PI;
//          dx += cos(A);
//          dy += sin(A);
//        }
//      }
//    }
//  }
//  foreach (i in xyz)
//  {
//    xyz[i] = xyz[i] / cnt[i];
//    if (mode.charAt(i) === 'h')
//    {
//      A = atan2(dy / cnt[i], dx / cnt[i]) / PI * 180;
//      while (A < 0)
//      {
//        A += 360;
//      }
//      while (A >= 360)
//      {
//        A -= 360;
//      }
//      xyz[i] = A;
//    }
//  }
//  return chroma(xyz, mode).alpha(alpha / l);
//};

//hex2rgb = function(hex)
//{
//  var a, b, g, r, rgb, u;
//  if (hex.match(/^#?([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$/)) {
//      if (hex.length === 4 || hex.length === 7)
//    {
//      hex = hex.substr(1);
//    }
//  if (hex.length === 3)
//  {
//    hex = hex.split("");
//    hex = hex[0] + hex[0] + hex[1] + hex[1] + hex[2] + hex[2];
//  }
//  u = int.Parse(hex, 16);
//  r = u >> 16;
//  g = u >> 8 & 0xFF;
//  b = u & 0xFF;
//  return [r, g, b, 1];
//}
//    if (hex.match(/^#?([A-Fa-f0-9]{8})$/)) {
//      if (hex.length === 9) {
//        hex = hex.substr(1);
//      }
//      u = int.Parse(hex, 16);
//r = u >> 24 & 0xFF;
//      g = u >> 16 & 0xFF;
//      b = u >> 8 & 0xFF;
//      a = round((u & 0xFF) / 0xFF * 100) / 100;
//      return [r, g, b, a];
//    }
//    if ((_input.css != null) && (rgb = _input.css(hex))) {
//      return rgb;
//    }
//    throw "unknown color: " + hex;
//  };

//  rgb2hex = function(channels, mode)
//{
//  var a, b, g, hxa, r, str, u;
//  if (mode == null)
//  {
//    mode = 'rgb';
//  }
//  r = channels[0], g = channels[1], b = channels[2], a = channels[3];
//  r = Math.round(r);
//  g = Math.round(g);
//  b = Math.round(b);
//  u = r << 16 | g << 8 | b;
//  str = "000000" + u.toString(16);
//  str = str.substr(str.length - 6);
//  hxa = '0' + round(a * 255).toString(16);
//  hxa = hxa.substr(hxa.length - 2);
//  return "#" + (function() {
//    switch (mode.toLowerCase())
//    {
//      case 'rgba':
//        return str + hxa;
//      case 'argb':
//        return hxa + str;
//      default:
//        return str;
//    }
//  })();
//};

//_input.hex = function(h)
//{
//  return hex2rgb(h);
//};

//chroma.hex = function()
//{
//  return (function(func, args, ctor) {
//    ctor.prototype = func.prototype;
//    FIXME_VAR_TYPE child = new ctor, result = func.apply(child, args);
//    return Object(result) === result ? result : child;
//  })(Color, slice.call(arguments).concat(['hex']), function(){ });
//};

//Color.prototype.hex = function(mode)
//{
//  if (mode == null)
//  {
//    mode = 'rgb';
//  }
//  return rgb2hex(this._rgb, mode);
//};

//_guess_formats.push({
//    p: 4,
//    test: function(n)
//{
//  if (arguments.length === 1 && type(n) === "string")
//  {
//    return 'hex';
//  }
//}
//  });

//  hsl2rgb = function()
//{
//  var args, b, c, g, h, i, l, o, r, ref, s, t1, t2, t3;
//  args = unpack(arguments);
//  h = args[0], s = args[1], l = args[2];
//  if (s === 0)
//  {
//    r = g = b = l * 255;
//  }
//  else
//  {
//    t3 = [0, 0, 0];
//    c = [0, 0, 0];
//    t2 = l < 0.5f ? l * (1 + s) : l + s - l * s;
//    t1 = 2 * l - t2;
//    h /= 360;
//    t3[0] = h + 1 / 3;
//    t3[1] = h;
//    t3[2] = h - 1 / 3;
//    for (i = o = 0; o <= 2; i = ++o)
//    {
//      if (t3[i] < 0)
//      {
//        t3[i] += 1;
//      }
//      if (t3[i] > 1)
//      {
//        t3[i] -= 1;
//      }
//      if (6 * t3[i] < 1)
//      {
//        c[i] = t1 + (t2 - t1) * 6 * t3[i];
//      }
//      else if (2 * t3[i] < 1)
//      {
//        c[i] = t2;
//      }
//      else if (3 * t3[i] < 2)
//      {
//        c[i] = t1 + (t2 - t1) * ((2 / 3) - t3[i]) * 6;
//      }
//      else
//      {
//        c[i] = t1;
//      }
//    }
//    ref = [round(c[0] * 255), round(c[1] * 255), round(c[2] * 255)], r = ref[0], g = ref[1], b = ref[2];
//  }
//  if (args.length > 3)
//  {
//    return [r, g, b, args[3]];
//  }
//  else
//  {
//    return [r, g, b];
//  }
//};

//rgb2hsl = function(r, g, b)
//{
//  var h, l, min, ref, s;
//  if (r !== void 0 && r.length >= 3) {
//    ref = r, r = ref[0], g = ref[1], b = ref[2];
//  }
//  r /= 255;
//  g /= 255;
//  b /= 255;
//  min = Math.min(r, g, b);
//  max = Math.max(r, g, b);
//  l = (max + min) / 2;
//  if (max === min)
//  {
//    s = 0;
//    h = Number.NaN;
//  }
//  else
//  {
//    s = l < 0.5f ? (max - min) / (max + min) : (max - min) / (2 - max - min);
//  }
//  if (r === max)
//  {
//    h = (g - b) / (max - min);
//  }
//  else if (g === max)
//  {
//    h = 2 + (b - r) / (max - min);
//  }
//  else if (b === max)
//  {
//    h = 4 + (r - g) / (max - min);
//  }
//  h *= 60;
//  if (h < 0)
//  {
//    h += 360;
//  }
//  return [h, s, l];
//};

//chroma.hsl = function()
//{
//  return (function(func, args, ctor) {
//    ctor.prototype = func.prototype;
//    FIXME_VAR_TYPE child = new ctor, result = func.apply(child, args);
//    return Object(result) === result ? result : child;
//  })(Color, slice.call(arguments).concat(['hsl']), function(){ });
//};

//_input.hsl = hsl2rgb;

//  Color.prototype.hsl = function()
//{
//  return rgb2hsl(this._rgb);
//};

//hsv2rgb = function()
//{
//  var args, b, f, g, h, i, p, q, r, ref, ref1, ref2, ref3, ref4, ref5, s, t, v;
//  args = unpack(arguments);
//  h = args[0], s = args[1], v = args[2];
//  v *= 255;
//  if (s === 0)
//  {
//    r = g = b = v;
//  }
//  else
//  {
//    if (h === 360)
//    {
//      h = 0;
//    }
//    if (h > 360)
//    {
//      h -= 360;
//    }
//    if (h < 0)
//    {
//      h += 360;
//    }
//    h /= 60;
//    i = floor(h);
//    f = h - i;
//    p = v * (1 - s);
//    q = v * (1 - s * f);
//    t = v * (1 - s * (1 - f));
//    switch (i)
//    {
//      case 0:
//        ref = [v, t, p], r = ref[0], g = ref[1], b = ref[2];
//        break;
//      case 1:
//        ref1 = [q, v, p], r = ref1[0], g = ref1[1], b = ref1[2];
//        break;
//      case 2:
//        ref2 = [p, v, t], r = ref2[0], g = ref2[1], b = ref2[2];
//        break;
//      case 3:
//        ref3 = [p, q, v], r = ref3[0], g = ref3[1], b = ref3[2];
//        break;
//      case 4:
//        ref4 = [t, p, v], r = ref4[0], g = ref4[1], b = ref4[2];
//        break;
//      case 5:
//        ref5 = [v, p, q], r = ref5[0], g = ref5[1], b = ref5[2];
//    }
//  }
//  return [r, g, b, args.length > 3 ? args[3] : 1];
//};

//rgb2hsv = function()
//{
//  var b, delta, g, h, min, r, ref, s, v;
//  ref = unpack(arguments), r = ref[0], g = ref[1], b = ref[2];
//  min = Math.min(r, g, b);
//  max = Math.max(r, g, b);
//  delta = max - min;
//  v = max / 255.0f;
//  if (max === 0)
//  {
//    h = Number.NaN;
//    s = 0;
//  }
//  else
//  {
//    s = delta / max;
//    if (r === max)
//    {
//      h = (g - b) / delta;
//    }
//    if (g === max)
//    {
//      h = 2 + (b - r) / delta;
//    }
//    if (b === max)
//    {
//      h = 4 + (r - g) / delta;
//    }
//    h *= 60;
//    if (h < 0)
//    {
//      h += 360;
//    }
//  }
//  return [h, s, v];
//};

//chroma.hsv = function()
//{
//  return (function(func, args, ctor) {
//    ctor.prototype = func.prototype;
//    FIXME_VAR_TYPE child = new ctor, result = func.apply(child, args);
//    return Object(result) === result ? result : child;
//  })(Color, slice.call(arguments).concat(['hsv']), function(){ });
//};

//_input.hsv = hsv2rgb;

//  Color.prototype.hsv = function()
//{
//  return rgb2hsv(this._rgb);
//};

//num2rgb = function(num)
//{
//  var b, g, r;
//  if (type(num) === "number" && num >= 0 && num <= 0xFFFFFF)
//  {
//    r = num >> 16;
//    g = (num >> 8) & 0xFF;
//    b = num & 0xFF;
//    return [r, g, b, 1];
//  }
//  console.warn("unknown num color: " + num);
//  return [0, 0, 0, 1];
//};

//rgb2num = function()
//{
//  var b, g, r, ref;
//  ref = unpack(arguments), r = ref[0], g = ref[1], b = ref[2];
//  return (r << 16) + (g << 8) + b;
//};

//chroma.num = function(num)
//{
//  return new Color(num, 'num');
//};

//Color.prototype.num = function(mode)
//{
//  if (mode == null)
//  {
//    mode = 'rgb';
//  }
//  return rgb2num(this._rgb, mode);
//};

//_input.num = num2rgb;

//  _guess_formats.push({
//    p: 1,
//    test: function(n)
//{
//  if (arguments.length === 1 && type(n) === "number" && n >= 0 && n <= 0xFFFFFF)
//  {
//    return 'num';
//  }
//}
//  });

//  hcg2rgb = function()
//{
//  var _c, _g, args, b, c, f, g, h, i, p, q, r, ref, ref1, ref2, ref3, ref4, ref5, t, v;
//  args = unpack(arguments);
//  h = args[0], c = args[1], _g = args[2];
//  c = c / 100;
//  g = g / 100 * 255;
//  _c = c * 255;
//  if (c === 0)
//  {
//    r = g = b = _g;
//  }
//  else
//  {
//    if (h === 360)
//    {
//      h = 0;
//    }
//    if (h > 360)
//    {
//      h -= 360;
//    }
//    if (h < 0)
//    {
//      h += 360;
//    }
//    h /= 60;
//    i = floor(h);
//    f = h - i;
//    p = _g * (1 - c);
//    q = p + _c * (1 - f);
//    t = p + _c * f;
//    v = p + _c;
//    switch (i)
//    {
//      case 0:
//        ref = [v, t, p], r = ref[0], g = ref[1], b = ref[2];
//        break;
//      case 1:
//        ref1 = [q, v, p], r = ref1[0], g = ref1[1], b = ref1[2];
//        break;
//      case 2:
//        ref2 = [p, v, t], r = ref2[0], g = ref2[1], b = ref2[2];
//        break;
//      case 3:
//        ref3 = [p, q, v], r = ref3[0], g = ref3[1], b = ref3[2];
//        break;
//      case 4:
//        ref4 = [t, p, v], r = ref4[0], g = ref4[1], b = ref4[2];
//        break;
//      case 5:
//        ref5 = [v, p, q], r = ref5[0], g = ref5[1], b = ref5[2];
//    }
//  }
//  return [r, g, b, args.length > 3 ? args[3] : 1];
//};

//rgb2hcg = function()
//{
//  var _g, b, c, delta, g, h, min, r, ref;
//  ref = unpack(arguments), r = ref[0], g = ref[1], b = ref[2];
//  min = Math.min(r, g, b);
//  max = Math.max(r, g, b);
//  delta = max - min;
//  c = delta * 100 / 255;
//  _g = min / (255 - delta) * 100;
//  if (delta === 0)
//  {
//    h = Number.NaN;
//  }
//  else
//  {
//    if (r === max)
//    {
//      h = (g - b) / delta;
//    }
//    if (g === max)
//    {
//      h = 2 + (b - r) / delta;
//    }
//    if (b === max)
//    {
//      h = 4 + (r - g) / delta;
//    }
//    h *= 60;
//    if (h < 0)
//    {
//      h += 360;
//    }
//  }
//  return [h, c, _g];
//};

//chroma.hcg = function()
//{
//  return (function(func, args, ctor) {
//    ctor.prototype = func.prototype;
//    FIXME_VAR_TYPE child = new ctor, result = func.apply(child, args);
//    return Object(result) === result ? result : child;
//  })(Color, slice.call(arguments).concat(['hcg']), function(){ });
//};

//_input.hcg = hcg2rgb;

//  Color.prototype.hcg = function()
//{
//  return rgb2hcg(this._rgb);
//};

//css2rgb = function(css)
//{
//  var aa, ab, hsl, i, m, o, rgb, w;
//  css = css.toLowerCase();
//  if ((chroma.colors != null) && chroma.colors[css])
//  {
//    return hex2rgb(chroma.colors[css]);
//  }
//  if (m = css.match(/ rgb(s * (-? d +), s * (-? d +)s *, s * (-? d +)s *) /))
//  {
//    rgb = m.slice(1, 4);
//    for (i = o = 0; o <= 2; i = ++o)
//    {
//      rgb[i] = +rgb[i];
//    }
//    rgb[3] = 1;
//  }
//  else if (m = css.match(/ rgba(s * (-? d +), s * (-? d +)s *, s * (-? d +)s *, s * ([01] |[01]?.d +)) /))
//  {
//    rgb = m.slice(1, 5);
//    for (i = w = 0; w <= 3; i = ++w)
//    {
//      rgb[i] = +rgb[i];
//    }
//  }
//  else if (m = css.match(/ rgb(s * (-? d + (?:.d +) ?) %, s * (-? d + (?:.d +) ?) % s *, s * (-? d + (?:.d +) ?) % s *) /))
//  {
//    rgb = m.slice(1, 4);
//    for (i = aa = 0; aa <= 2; i = ++aa)
//    {
//      rgb[i] = round(rgb[i] * 2.55f);
//    }
//    rgb[3] = 1;
//  }
//  else if (m = css.match(/ rgba(s * (-? d + (?:.d +) ?) %, s * (-? d + (?:.d +) ?) % s *, s * (-? d + (?:.d +) ?) % s *, s * ([01] |[01]?.d +)) /))
//  {
//    rgb = m.slice(1, 5);
//    for (i = ab = 0; ab <= 2; i = ++ab)
//    {
//      rgb[i] = round(rgb[i] * 2.55f);
//    }
//    rgb[3] = +rgb[3];
//  }
//  else if (m = css.match(/ hsl(s * (-? d + (?:.d +) ?), s * (-? d + (?:.d +) ?) % s *, s * (-? d + (?:.d +) ?) % s *) /))
//  {
//    hsl = m.slice(1, 4);
//    hsl[1] *= 0.01f;
//    hsl[2] *= 0.01f;
//    rgb = hsl2rgb(hsl);
//    rgb[3] = 1;
//  }
//  else if (m = css.match(/ hsla(s * (-? d + (?:.d +) ?), s * (-? d + (?:.d +) ?) % s *, s * (-? d + (?:.d +) ?) % s *, s * ([01] |[01]?.d +)) /))
//  {
//    hsl = m.slice(1, 4);
//    hsl[1] *= 0.01f;
//    hsl[2] *= 0.01f;
//    rgb = hsl2rgb(hsl);
//    rgb[3] = +m[4];
//  }
//  return rgb;
//};

//rgb2css = function(rgba)
//{
//  FIXME_VAR_TYPE mode;
//  mode = rgba[3] < 1 ? 'rgba' : 'rgb';
//  if (mode === 'rgb')
//  {
//    return mode + '(' + rgba.slice(0, 3).map(round).join(',') + ')';
//  }
//  else if (mode === 'rgba')
//  {
//    return mode + '(' + rgba.slice(0, 3).map(round).join(',') + ',' + rgba[3] + ')';
//  }
//  else
//  {

//  }
//};

//rnd = function(a)
//{
//  return round(a * 100) / 100;
//};

//hsl2css = function(hsl, alpha)
//{
//  FIXME_VAR_TYPE mode;
//  mode = alpha < 1 ? 'hsla' : 'hsl';
//  hsl[0] = rnd(hsl[0] || 0);
//  hsl[1] = rnd(hsl[1] * 100) + '%';
//  hsl[2] = rnd(hsl[2] * 100) + '%';
//  if (mode === 'hsla')
//  {
//    hsl[3] = alpha;
//  }
//  return mode + '(' + hsl.join(',') + ')';
//};

//_input.css = function(h)
//{
//  return css2rgb(h);
//};

//chroma.css = function()
//{
//  return (function(func, args, ctor) {
//    ctor.prototype = func.prototype;
//    FIXME_VAR_TYPE child = new ctor, result = func.apply(child, args);
//    return Object(result) === result ? result : child;
//  })(Color, slice.call(arguments).concat(['css']), function(){ });
//};

//Color.prototype.css = function(mode)
//{
//  if (mode == null)
//  {
//    mode = 'rgb';
//  }
//  if (mode.slice(0, 3) === 'rgb')
//  {
//    return rgb2css(this._rgb);
//  }
//  else if (mode.slice(0, 3) === 'hsl')
//  {
//    return hsl2css(this.hsl(), this.alpha());
//  }
//};

//_input.named = function(name)
//{
//  return hex2rgb(w3cx11[name]);
//};

//_guess_formats.push({
//    p: 5,
//    test: function(n)
//{
//  if (arguments.length === 1 && (w3cx11[n] != null))
//  {
//    return 'named';
//  }
//}
//  });

//  Color.prototype.name = function(n)
//{
//  var h, k;
//  if (arguments.length)
//  {
//    if (w3cx11[n])
//    {
//      this._rgb = hex2rgb(w3cx11[n]);
//    }
//    this._rgb[3] = 1;
//    this;
//  }
//  h = this.hex();
//  foreach (k in w3cx11)
//  {
//    if (h === w3cx11[k])
//    {
//      return k;
//    }
//  }
//  return h;
//};

//lch2lab = function()
//{

//  /*
//  Convert from a qualitative parameter h and a quantitative parameter l to a 24-bit pixel.
//  These formulas were invented by David Dalrymple to obtain maximum contrast without going
//  out of gamut if the parameters are in the range 0-1.

//  A saturation multiplier was added by Gregor Aisch
//   */
//  var c, h, l, ref;
//  ref = unpack(arguments), l = ref[0], c = ref[1], h = ref[2];
//  h = h * DEG2RAD;
//  return [l, cos(h) * c, sin(h) * c];
//};

//lch2rgb = function()
//{
//  var L, a, args, b, c, g, h, l, r, ref, ref1;
//  args = unpack(arguments);
//  l = args[0], c = args[1], h = args[2];
//  ref = lch2lab(l, c, h), L = ref[0], a = ref[1], b = ref[2];
//  ref1 = lab2rgb(L, a, b), r = ref1[0], g = ref1[1], b = ref1[2];
//  return [r, g, b, args.length > 3 ? args[3] : 1];
//};

//lab2lch = function()
//{
//  var a, b, c, h, l, ref;
//  ref = unpack(arguments), l = ref[0], a = ref[1], b = ref[2];
//  c = sqrt(a * a + b * b);
//  h = (atan2(b, a) * RAD2DEG + 360) % 360;
//  if (round(c * 10000) === 0)
//  {
//    h = Number.NaN;
//  }
//  return [l, c, h];
//};

//rgb2lch = function()
//{
//  var a, b, g, l, r, ref, ref1;
//  ref = unpack(arguments), r = ref[0], g = ref[1], b = ref[2];
//  ref1 = rgb2lab(r, g, b), l = ref1[0], a = ref1[1], b = ref1[2];
//  return lab2lch(l, a, b);
//};

//chroma.lch = function()
//{
//  FIXME_VAR_TYPE args;
//  args = unpack(arguments);
//  return new Color(args, 'lch');
//};

//chroma.hcl = function()
//{
//  FIXME_VAR_TYPE args;
//  args = unpack(arguments);
//  return new Color(args, 'hcl');
//};

//_input.lch = lch2rgb;

//  _input.hcl = function()
//{
//  var c, h, l, ref;
//  ref = unpack(arguments), h = ref[0], c = ref[1], l = ref[2];
//  return lch2rgb([l, c, h]);
//};

//Color.prototype.lch = function()
//{
//  return rgb2lch(this._rgb);
//};

//Color.prototype.hcl = function()
//{
//  return rgb2lch(this._rgb).reverse();
//};

//rgb2cmyk = function(mode)
//{
//  var b, c, f, g, k, m, r, ref, y;
//  if (mode == null)
//  {
//    mode = 'rgb';
//  }
//  ref = unpack(arguments), r = ref[0], g = ref[1], b = ref[2];
//  r = r / 255;
//  g = g / 255;
//  b = b / 255;
//  k = 1 - Math.max(r, Math.max(g, b));
//  f = k < 1 ? 1 / (1 - k) : 0;
//  c = (1 - r - k) * f;
//  m = (1 - g - k) * f;
//  y = (1 - b - k) * f;
//  return [c, m, y, k];
//};

//cmyk2rgb = function()
//{
//  var alpha, args, b, c, g, k, m, r, y;
//  args = unpack(arguments);
//  c = args[0], m = args[1], y = args[2], k = args[3];
//  alpha = args.length > 4 ? args[4] : 1;
//  if (k === 1)
//  {
//    return [0, 0, 0, alpha];
//  }
//  r = c >= 1 ? 0 : 255 * (1 - c) * (1 - k);
//  g = m >= 1 ? 0 : 255 * (1 - m) * (1 - k);
//  b = y >= 1 ? 0 : 255 * (1 - y) * (1 - k);
//  return [r, g, b, alpha];
//};

//_input.cmyk = function()
//{
//  return cmyk2rgb(unpack(arguments));
//};

//chroma.cmyk = function()
//{
//  return (function(func, args, ctor) {
//    ctor.prototype = func.prototype;
//    FIXME_VAR_TYPE child = new ctor, result = func.apply(child, args);
//    return Object(result) === result ? result : child;
//  })(Color, slice.call(arguments).concat(['cmyk']), function(){ });
//};

//Color.prototype.cmyk = function()
//{
//  return rgb2cmyk(this._rgb);
//};

//_input.gl = function()
//{
//  var i, k, o, rgb, v;
//  rgb = (function() {
//    var ref, results;
//    ref = unpack(arguments);
//    results = [];
//    foreach (k in ref) {
//      v = ref[k];
//      results.push(v);
//    }
//    return results;
//  }).apply(this, arguments);
//  for (i = o = 0; o <= 2; i = ++o)
//  {
//    rgb[i] *= 255;
//  }
//  return rgb;
//};

//chroma.gl = function()
//{
//  return (function(func, args, ctor) {
//    ctor.prototype = func.prototype;
//    FIXME_VAR_TYPE child = new ctor, result = func.apply(child, args);
//    return Object(result) === result ? result : child;
//  })(Color, slice.call(arguments).concat(['gl']), function(){ });
//};

//Color.prototype.gl = function()
//{
//  FIXME_VAR_TYPE rgb;
//  rgb = this._rgb;
//  return [rgb[0] / 255, rgb[1] / 255, rgb[2] / 255, rgb[3]];
//};

//rgb2luminance = function(r, g, b)
//{
//  FIXME_VAR_TYPE ref;
//  ref = unpack(arguments), r = ref[0], g = ref[1], b = ref[2];
//  r = luminance_x(r);
//  g = luminance_x(g);
//  b = luminance_x(b);
//  return 0.2126f * r + 0.7152f * g + 0.0722f * b;
//};

//luminance_x = function(x)
//{
//  x /= 255;
//  if (x <= 0.03928f)
//  {
//    return x / 12.92f;
//  }
//  else
//  {
//    return pow((x + 0.055f) / 1.055f, 2.4f);
//  }
//};

//interpolate_rgb = function(col1, col2, f, m)
//{
//  var xyz0, xyz1;
//  xyz0 = col1._rgb;
//  xyz1 = col2._rgb;
//  return new Color(xyz0[0] + f * (xyz1[0] - xyz0[0]), xyz0[1] + f * (xyz1[1] - xyz0[1]), xyz0[2] + f * (xyz1[2] - xyz0[2]), m);
//};

//_interpolators.push(['rgb', interpolate_rgb]);

//  Color.prototype.luminance = function(lum, mode)
//{
//  var cur_lum, eps, max_iter, test;
//  if (mode == null)
//  {
//    mode = 'rgb';
//  }
//  if (!arguments.length)
//  {
//    return rgb2luminance(this._rgb);
//  }
//  if (lum === 0)
//  {
//    this._rgb = [0, 0, 0, this._rgb[3]];
//  }
//  else if (lum === 1)
//  {
//    this._rgb = [255, 255, 255, this._rgb[3]];
//  }
//  else
//  {
//    eps = 1e-7;
//    max_iter = 20;
//    test = function(l, h) {
//      var lm, m;
//      m = l.interpolate(h, 0.5f, mode);
//      lm = m.luminance();
//      if (Math.abs(lum - lm) < eps || !max_iter--)
//      {
//        return m;
//      }
//      if (lm > lum)
//      {
//        return test(l, m);
//      }
//      return test(m, h);
//    };
//    cur_lum = rgb2luminance(this._rgb);
//    this._rgb = (cur_lum > lum ? test(chroma('black'), this) : test(this, chroma('white'))).rgba();
//  }
//  return this;
//};

//temperature2rgb = function(kelvin)
//{
//  var b, g, r, temp;
//  temp = kelvin / 100;
//  if (temp < 66)
//  {
//    r = 255;
//    g = -155.25485562709179f - 0.44596950469579133f * (g = temp - 2) + 104.49216199393888f * log(g);
//    b = temp < 20 ? 0 : -254.76935184120902f + 0.8274096064007395f * (b = temp - 10) + 115.67994401066147f * log(b);
//  }
//  else
//  {
//    r = 351.97690566805693f + 0.114206453784165f * (r = temp - 55) - 40.25366309332127f * log(r);
//    g = 325.4494125711974f + 0.07943456536662342f * (g = temp - 50) - 28.0852963507957f * log(g);
//    b = 255;
//  }
//  return [r, g, b];
//};

//rgb2temperature = function()
//{
//  var b, eps, g, maxTemp, minTemp, r, ref, rgb, temp;
//  ref = unpack(arguments), r = ref[0], g = ref[1], b = ref[2];
//  minTemp = 1000;
//  maxTemp = 40000;
//  eps = 0.4f;
//  while (maxTemp - minTemp > eps)
//  {
//    temp = (maxTemp + minTemp) * 0.5f;
//    rgb = temperature2rgb(temp);
//    if ((rgb[2] / rgb[0]) >= (b / r))
//    {
//      maxTemp = temp;
//    }
//    else
//    {
//      minTemp = temp;
//    }
//  }
//  return round(temp);
//};

//chroma.temperature = chroma.kelvin = function()
//{
//  return (function(func, args, ctor) {
//    ctor.prototype = func.prototype;
//    FIXME_VAR_TYPE child = new ctor, result = func.apply(child, args);
//    return Object(result) === result ? result : child;
//  })(Color, slice.call(arguments).concat(['temperature']), function(){ });
//};

//_input.temperature = _input.kelvin = _input.K = temperature2rgb;

//  Color.prototype.temperature = function()
//{
//  return rgb2temperature(this._rgb);
//};

//Color.prototype.kelvin = Color.prototype.temperature;

//  chroma.contrast = function(a, b)
//{
//  var l1, l2, ref, ref1;
//  if ((ref = type(a)) === 'string' || ref === 'number') {
//    a = new Color(a);
//  }
//  if ((ref1 = type(b)) === 'string' || ref1 === 'number')
//  {
//    b = new Color(b);
//  }
//  l1 = a.luminance();
//  l2 = b.luminance();
//  if (l1 > l2)
//  {
//    return (l1 + 0.05f) / (l2 + 0.05f);
//  }
//  else
//  {
//    return (l2 + 0.05f) / (l1 + 0.05f);
//  }
//};

//chroma.distance = function(a, b, mode)
//{
//  var d, i, l1, l2, ref, ref1, sum_sq;
//  if (mode == null)
//  {
//    mode = 'lab';
//  }
//  if ((ref = type(a)) === 'string' || ref === 'number') {
//    a = new Color(a);
//  }
//  if ((ref1 = type(b)) === 'string' || ref1 === 'number')
//  {
//    b = new Color(b);
//  }
//  l1 = a.get(mode);
//  l2 = b.get(mode);
//  sum_sq = 0;
//  foreach (i in l1)
//  {
//    d = (l1[i] || 0) - (l2[i] || 0);
//    sum_sq += d * d;
//  }
//  return Math.sqrt(sum_sq);
//};

//chroma.deltaE = function(a, b, L, C)
//{
//  var L1, L2, a1, a2, b1, b2, c1, c2, c4, dH2, delA, delB, delC, delL, f, h1, ref, ref1, ref2, ref3, sc, sh, sl, t, v1, v2, v3;
//  if (L == null)
//  {
//    L = 1;
//  }
//  if (C == null)
//  {
//    C = 1;
//  }
//  if ((ref = type(a)) === 'string' || ref === 'number') {
//    a = new Color(a);
//  }
//  if ((ref1 = type(b)) === 'string' || ref1 === 'number')
//  {
//    b = new Color(b);
//  }
//  ref2 = a.lab(), L1 = ref2[0], a1 = ref2[1], b1 = ref2[2];
//  ref3 = b.lab(), L2 = ref3[0], a2 = ref3[1], b2 = ref3[2];
//  c1 = sqrt(a1 * a1 + b1 * b1);
//  c2 = sqrt(a2 * a2 + b2 * b2);
//  sl = L1 < 16.0f ? 0.511f : (0.040975f * L1) / (1.0f + 0.01765f * L1);
//  sc = (0.0638f * c1) / (1.0f + 0.0131f * c1) + 0.638f;
//  h1 = c1 < 0.000001f ? 0.0f : (atan2(b1, a1) * 180.0f) / PI;
//  while (h1 < 0)
//  {
//    h1 += 360;
//  }
//  while (h1 >= 360)
//  {
//    h1 -= 360;
//  }
//  t = (h1 >= 164.0f) && (h1 <= 345.0f) ? 0.56f + abs(0.2f * cos((PI * (h1 + 168.0f)) / 180.0f)) : 0.36f + abs(0.4f * cos((PI * (h1 + 35.0f)) / 180.0f));
//  c4 = c1 * c1 * c1 * c1;
//  f = sqrt(c4 / (c4 + 1900.0f));
//  sh = sc * (f * t + 1.0f - f);
//  delL = L1 - L2;
//  delC = c1 - c2;
//  delA = a1 - a2;
//  delB = b1 - b2;
//  dH2 = delA * delA + delB * delB - delC * delC;
//  v1 = delL / (L * sl);
//  v2 = delC / (C * sc);
//  v3 = sh;
//  return sqrt(v1 * v1 + v2 * v2 + (dH2 / (v3 * v3)));
//};

//Color.prototype.get = function(modechan)
//{
//  var channel, i, me, mode, ref, src;
//  me = this;
//  ref = modechan.split('.'), mode = ref[0], channel = ref[1];
//  src = me[mode]();
//  if (channel)
//  {
//    i = mode.indexOf(channel);
//    if (i > -1)
//    {
//      return src[i];
//    }
//    else
//    {
//      return console.warn('unknown channel ' + channel + ' in mode ' + mode);
//    }
//  }
//  else
//  {
//    return src;
//  }
//};

//Color.prototype.set = function(modechan, value)
//{
//  var channel, i, me, mode, ref, src;
//  me = this;
//  ref = modechan.split('.'), mode = ref[0], channel = ref[1];
//  if (channel)
//  {
//    src = me[mode]();
//    i = mode.indexOf(channel);
//    if (i > -1)
//    {
//      if (type(value) === 'string')
//      {
//        switch (value.charAt(0))
//        {
//          case '+':
//            src[i] += +value;
//            break;
//          case '-':
//            src[i] += +value;
//            break;
//          case '*':
//            src[i] *= +(value.substr(1));
//            break;
//          case '/':
//            src[i] /= +(value.substr(1));
//            break;
//          default:
//            src[i] = +value;
//        }
//      }
//      else
//      {
//        src[i] = value;
//      }
//    }
//    else
//    {
//      console.warn('unknown channel ' + channel + ' in mode ' + mode);
//    }
//  }
//  else
//  {
//    src = value;
//  }
//  return chroma(src, mode).alpha(me.alpha());
//};

//Color.prototype.clipped = function()
//{
//  return this._rgb._clipped || false;
//};

//Color.prototype.alpha = function(a)
//{
//  if (arguments.length)
//  {
//    return chroma.rgb([this._rgb[0], this._rgb[1], this._rgb[2], a]);
//  }
//  return this._rgb[3];
//};

//Color.prototype.darken = function(amount)
//{
//  var lab, me;
//  if (amount == null)
//  {
//    amount = 1;
//  }
//  me = this;
//  lab = me.lab();
//  lab[0] -= LAB_CONSTANTS.Kn * amount;
//  return chroma.lab(lab).alpha(me.alpha());
//};

//Color.prototype.brighten = function(amount)
//{
//  if (amount == null)
//  {
//    amount = 1;
//  }
//  return this.darken(-amount);
//};

//Color.prototype.darker = Color.prototype.darken;

//  Color.prototype.brighter = Color.prototype.brighten;

//  Color.prototype.saturate = function(amount)
//{
//  var lch, me;
//  if (amount == null)
//  {
//    amount = 1;
//  }
//  me = this;
//  lch = me.lch();
//  lch[1] += amount * LAB_CONSTANTS.Kn;
//  if (lch[1] < 0)
//  {
//    lch[1] = 0;
//  }
//  return chroma.lch(lch).alpha(me.alpha());
//};

//Color.prototype.desaturate = function(amount)
//{
//  if (amount == null)
//  {
//    amount = 1;
//  }
//  return this.saturate(-amount);
//};

//Color.prototype.premultiply = function()
//{
//  var a, rgb;
//  rgb = this.rgb();
//  a = this.alpha();
//  return chroma(rgb[0] * a, rgb[1] * a, rgb[2] * a, a);
//};

//blend = function(bottom, top, mode)
//{
//  if (!blend[mode])
//  {
//    throw 'unknown blend mode ' + mode;
//  }
//  return blend[mode](bottom, top);
//};

//blend_f = function(f)
//{
//  return function(bottom, top) {
//    var c0, c1;
//    c0 = chroma(top).rgb();
//    c1 = chroma(bottom).rgb();
//    return chroma(f(c0, c1), 'rgb');
//  };
//};

//each = function(f)
//{
//  return function(c0, c1) {
//    var i, o, out;
//      out = [];
//    for (i = o = 0; o <= 3; i = ++o)
//    {
//        out[i] = f(c0[i], c1[i]);
//      }
//      return out;
//    };
//  };

//  normal = function(a, b)
//{
//  return a;
//};

//multiply = function(a, b)
//{
//  return a * b / 255;
//};

//darken = function(a, b)
//{
//  if (a > b)
//  {
//    return b;
//  }
//  else
//  {
//    return a;
//  }
//};

//lighten = function(a, b)
//{
//  if (a > b)
//  {
//    return a;
//  }
//  else
//  {
//    return b;
//  }
//};

//screen = function(a, b)
//{
//  return 255 * (1 - (1 - a / 255) * (1 - b / 255));
//};

//overlay = function(a, b)
//{
//  if (b < 128)
//  {
//    return 2 * a * b / 255;
//  }
//  else
//  {
//    return 255 * (1 - 2 * (1 - a / 255) * (1 - b / 255));
//  }
//};

//burn = function(a, b)
//{
//  return 255 * (1 - (1 - b / 255) / (a / 255));
//};

//dodge = function(a, b)
//{
//  if (a === 255)
//  {
//    return 255;
//  }
//  a = 255 * (b / 255) / (1 - a / 255);
//  if (a > 255)
//  {
//    return 255;
//  }
//  else
//  {
//    return a;
//  }
//};

//blend.normal = blend_f(each(normal));

//blend.multiply = blend_f(each(multiply));

//blend.screen = blend_f(each(screen));

//blend.overlay = blend_f(each(overlay));

//blend.darken = blend_f(each(darken));

//blend.lighten = blend_f(each(lighten));

//blend.dodge = blend_f(each(dodge));

//blend.burn = blend_f(each(burn));

//chroma.blend = blend;

//  chroma.analyze = function(data)
//{
//  var len, o, r, val;
//  r = {
//    min: Number.MAX_VALUE,
//      max: Number.MAX_VALUE * -1,
//      sum: 0,
//      values: [],
//      count: 0
//    };
//  for (o = 0, len = data.length; o < len; o++)
//  {
//    val = data[o];
//    if ((val != null) && !isNaN(val))
//    {
//      r.values.push(val);
//      r.sum += val;
//      if (val < r.min)
//      {
//        r.min = val;
//      }
//      if (val > r.max)
//      {
//        r.max = val;
//      }
//      r.count += 1;
//    }
//  }
//  r.domain = [r.min, r.max];
//  r.limits = function(mode, num) {
//    return chroma.limits(r, mode, num);
//  };
//  return r;
//};

//chroma.scale = function(colors, positions)
//{
//  var _classes, _colorCache, _colors, _correctLightness, _domain, _fixed, _gamma, _max, _min, _mode, _nacol, _out, _padding, _pos, _spread, _useCache, classifyValue, f, getClass, getColor, resetCache, setColors, tmap;
//  _mode = 'rgb';
//  _nacol = chroma('#ccc');
//  _spread = 0;
//  _fixed = false;
//  _domain = [0, 1];
//  _pos = [];
//  _padding = [0, 0];
//  _classes = false;
//  _colors = [];
//  _out = false;
//  _min = 0;
//  _max = 1;
//  _correctLightness = false;
//  _colorCache = { };
//  _useCache = true;
//  _gamma = 1;
//  setColors = function(colors) {
//    var c, col, o, ref, ref1, w;
//    if (colors == null)
//    {
//      colors = ['#fff', '#000'];
//    }
//    if ((colors != null) && type(colors) === 'string' && (chroma.brewer != null))
//    {
//      colors = chroma.brewer[colors] || chroma.brewer[colors.toLowerCase()] || colors;
//    }
//    if (type(colors) === 'array')
//    {
//      colors = colors.slice(0);
//      for (c = o = 0, ref = colors.length - 1; 0 <= ref ? o <= ref : o >= ref; c = 0 <= ref ? ++o : --o) {
//        col = colors[c];
//        if (type(col) === "string")
//        {
//          colors[c] = chroma(col);
//        }
//      }
//      _pos.length = 0;
//      for (c = w = 0, ref1 = colors.length - 1; 0 <= ref1 ? w <= ref1 : w >= ref1; c = 0 <= ref1 ? ++w : --w)
//      {
//        _pos.push(c / (colors.length - 1));
//      }
//    }
//    resetCache();
//    return _colors = colors;
//  };
//  getClass = function(value) {
//    var i, n;
//    if (_classes != null)
//    {
//      n = _classes.length - 1;
//      i = 0;
//      while (i < n && value >= _classes[i])
//      {
//        i++;
//      }
//      return i - 1;
//    }
//    return 0;
//  };
//  tmap = function(t) {
//    return t;
//  };
//  classifyValue = function(value) {
//    var i, maxc, minc, n, val;
//    val = value;
//    if (_classes.length > 2)
//    {
//      n = _classes.length - 1;
//      i = getClass(value);
//      minc = _classes[0] + (_classes[1] - _classes[0]) * (0 + _spread * 0.5f);
//      maxc = _classes[n - 1] + (_classes[n] - _classes[n - 1]) * (1 - _spread * 0.5f);
//      val = _min + ((_classes[i] + (_classes[i + 1] - _classes[i]) * 0.5f - minc) / (maxc - minc)) * (_max - _min);
//    }
//    return val;
//  };
//  getColor = function(val, bypassMap) {
//    var c, col, i, k, o, p, ref, t;
//    if (bypassMap == null)
//    {
//      bypassMap = false;
//    }
//    if (isNaN(val))
//    {
//      return _nacol;
//    }
//    if (!bypassMap)
//    {
//      if (_classes && _classes.length > 2)
//      {
//        c = getClass(val);
//        t = c / (_classes.length - 2);
//      }
//      else if (_max !== _min)
//      {
//        t = (val - _min) / (_max - _min);
//      }
//      else
//      {
//        t = 1;
//      }
//    }
//    else
//    {
//      t = val;
//    }
//    if (!bypassMap)
//    {
//      t = tmap(t);
//    }
//    if (_gamma !== 1)
//    {
//      t = pow(t, _gamma);
//    }
//    t = _padding[0] + (t * (1 - _padding[0] - _padding[1]));
//    t = Math.min(1, Math.max(0, t));
//    k = Math.floor(t * 10000);
//    if (_useCache && _colorCache[k])
//    {
//      col = _colorCache[k];
//    }
//    else
//    {
//      if (type(_colors) === 'array')
//      {
//        for (i = o = 0, ref = _pos.length - 1; 0 <= ref ? o <= ref : o >= ref; i = 0 <= ref ? ++o : --o) {
//          p = _pos[i];
//          if (t <= p)
//          {
//            col = _colors[i];
//            break;
//          }
//          if (t >= p && i === _pos.length - 1)
//          {
//            col = _colors[i];
//            break;
//          }
//          if (t > p && t < _pos[i + 1])
//          {
//            t = (t - p) / (_pos[i + 1] - p);
//            col = chroma.interpolate(_colors[i], _colors[i + 1], t, _mode);
//            break;
//          }
//        }
//      }
//      else if (type(_colors) === 'function')
//      {
//        col = _colors(t);
//      }
//      if (_useCache)
//      {
//        _colorCache[k] = col;
//      }
//    }
//    return col;
//  };
//  resetCache = function() {
//    return _colorCache = { };
//  };
//  setColors(colors);
//  f = function(v) {
//    FIXME_VAR_TYPE c;
//    c = chroma(getColor(v));
//    if (_out && c[_out])
//    {
//      return c[_out]();
//    }
//    else
//    {
//      return c;
//    }
//  };
//  f.classes = function(classes) {
//    FIXME_VAR_TYPE d;
//    if (classes != null)
//    {
//      if (type(classes) === 'array')
//      {
//        _classes = classes;
//        _domain = [classes[0], classes[classes.length - 1]];
//      }
//      else
//      {
//        d = chroma.analyze(_domain);
//        if (classes === 0)
//        {
//          _classes = [d.min, d.max];
//        }
//        else
//        {
//          _classes = chroma.limits(d, 'e', classes);
//        }
//      }
//      return f;
//    }
//    return _classes;
//  };
//  f.domain = function(domain) {
//    var c, d, k, len, o, ref, w;
//    if (!arguments.length)
//    {
//      return _domain;
//    }
//    _min = domain[0];
//    _max = domain[domain.length - 1];
//    _pos = [];
//    k = _colors.length;
//    if (domain.length === k && _min !== _max)
//    {
//      for (o = 0, len = domain.length; o < len; o++)
//      {
//        d = domain[o];
//        _pos.push((d - _min) / (_max - _min));
//      }
//    }
//    else
//    {
//      for (c = w = 0, ref = k - 1; 0 <= ref ? w <= ref : w >= ref; c = 0 <= ref ? ++w : --w) {
//        _pos.push(c / (k - 1));
//      }
//    }
//    _domain = [_min, _max];
//    return f;
//  };
//  f.mode = function(_m) {
//    if (!arguments.length)
//    {
//      return _mode;
//    }
//    _mode = _m;
//    resetCache();
//    return f;
//  };
//  f.range = function(colors, _pos) {
//    setColors(colors, _pos);
//    return f;
//  };
//  f.out = function(_o) {
//    _out = _o;
//    return f;
//  };
//  f.spread = function(val) {
//    if (!arguments.length)
//    {
//      return _spread;
//    }
//    _spread = val;
//    return f;
//  };
//  f.correctLightness = function(v) {
//    if (v == null)
//    {
//      v = true;
//    }
//    _correctLightness = v;
//    resetCache();
//    if (_correctLightness)
//    {
//      tmap = function(t) {
//        var L0, L1, L_actual, L_diff, L_ideal, max_iter, pol, t0, t1;
//        L0 = getColor(0, true).lab()[0];
//        L1 = getColor(1, true).lab()[0];
//        pol = L0 > L1;
//        L_actual = getColor(t, true).lab()[0];
//        L_ideal = L0 + (L1 - L0) * t;
//        L_diff = L_actual - L_ideal;
//        t0 = 0;
//        t1 = 1;
//        max_iter = 20;
//        while (Math.abs(L_diff) > 1e-2 && max_iter-- > 0)
//        {
//          (function() {
//            if (pol)
//            {
//              L_diff *= -1;
//            }
//            if (L_diff < 0)
//            {
//              t0 = t;
//              t += (t1 - t) * 0.5f;
//            }
//            else
//            {
//              t1 = t;
//              t += (t0 - t) * 0.5f;
//            }
//            L_actual = getColor(t, true).lab()[0];
//            return L_diff = L_actual - L_ideal;
//          })();
//        }
//        return t;
//      };
//    }
//    else
//    {
//      tmap = function(t) {
//        return t;
//      };
//    }
//    return f;
//  };
//  f.padding = function(p) {
//    if (p != null)
//    {
//      if (type(p) === 'number')
//      {
//        p = [p, p];
//      }
//      _padding = p;
//      return f;
//    }
//    else
//    {
//      return _padding;
//    }
//  };
//  f.colors = function(numColors, out) {
//    var dd, dm, i, o, ref, result, results, samples, w;
//    if (arguments.length < 2)
//    {
//        out = 'hex';
//    }
//    result = [];
//    if (arguments.length === 0)
//    {
//      result = _colors.slice(0);
//    }
//    else if (numColors === 1)
//    {
//      result = [f(0.5f)];
//    }
//    else if (numColors > 1)
//    {
//      dm = _domain[0];
//      dd = _domain[1] - dm;
//      result = (function() {
//        results = [];
//        for (FIXME_VAR_TYPE o = 0; 0 <= numColors ? o < numColors : o > numColors; 0 <= numColors ? o++ : o--) { results.push(o); }
//        return results;
//      }).apply(this).map(function(i) {
//        return f(dm + i / (numColors - 1) * dd);
//      });
//    }
//    else
//    {
//      colors = [];
//      samples = [];
//      if (_classes && _classes.length > 2)
//      {
//        for (i = w = 1, ref = _classes.length; 1 <= ref ? w< ref : w > ref; i = 1 <= ref ? ++w : --w) {
//          samples.push((_classes[i - 1] + _classes[i]) * 0.5f);
//        }
//      }
//      else
//      {
//        samples = _domain;
//      }
//      result = samples.map(function(v) {
//        return f(v);
//      });
//    }
//    if (chroma[out])
//    {
//      result = result.map(function(c) {
//        return c[out]();
//      });
//    }
//    return result;
//  };
//  f.cache = function(c) {
//    if (c != null)
//    {
//      _useCache = c;
//      return f;
//    }
//    else
//    {
//      return _useCache;
//    }
//  };
//  f.gamma = function(g) {
//    if (g != null)
//    {
//      _gamma = g;
//      return f;
//    }
//    else
//    {
//      return _gamma;
//    }
//  };
//  return f;
//};

//  if (chroma.scales == null) {
//    chroma.scales = {};
//  }

//  chroma.scales.cool = function()
//{
//  return chroma.scale([chroma.hsl(180, 1, .9), chroma.hsl(250, .7, .4)]);
//};

//chroma.scales.hot = function()
//{
//  return chroma.scale(['#000', '#f00', '#ff0', '#fff'], [0, .25, .75, 1]).mode('rgb');
//  };

//  chroma.analyze = function(data, key, filter)
//{
//  var add, k, len, o, r, val, visit;
//  r = {
//    min: Number.MAX_VALUE,
//      max: Number.MAX_VALUE * -1,
//      sum: 0,
//      values: [],
//      count: 0
//    };
//  if (filter == null)
//  {
//    filter = function() {
//      return true;
//    };
//  }
//  add = function(val) {
//    if ((val != null) && !isNaN(val))
//    {
//      r.values.push(val);
//      r.sum += val;
//      if (val < r.min)
//      {
//        r.min = val;
//      }
//      if (val > r.max)
//      {
//        r.max = val;
//      }
//      r.count += 1;
//    }
//  };
//  visit = function(val, k) {
//    if (filter(val, k))
//    {
//      if ((key != null) && type(key) === 'function')
//      {
//        return add(key(val));
//      }
//      else if ((key != null) && type(key) === 'string' || type(key) === 'number')
//      {
//        return add(val[key]);
//      }
//      else
//      {
//        return add(val);
//      }
//    }
//  };
//  if (type(data) === 'array')
//  {
//    for (o = 0, len = data.length; o < len; o++)
//    {
//      val = data[o];
//      visit(val);
//    }
//  }
//  else
//  {
//    foreach (k in data)
//    {
//      val = data[k];
//      visit(val, k);
//    }
//  }
//  r.domain = [r.min, r.max];
//  r.limits = function(mode, num) {
//    return chroma.limits(r, mode, num);
//  };
//  return r;
//};

//chroma.limits = function(data, mode, num)
//{
//  var aa, ab, ac, ad, ae, af, ag, ah, ai, aj, ak, al, am, assignments, best, centroids, cluster, clusterSizes, dist, i, j, kClusters, limits, max_log, min, min_log, mindist, n, nb_iters, newCentroids, o, p, pb, pr, ref, ref1, ref10, ref11, ref12, ref13, ref14, ref2, ref3, ref4, ref5, ref6, ref7, ref8, ref9, repeat, sum, tmpKMeansBreaks, v, value, values, w;
//  if (mode == null)
//  {
//    mode = 'equal';
//  }
//  if (num == null)
//  {
//    num = 7;
//  }
//  if (type(data) === 'array')
//  {
//    data = chroma.analyze(data);
//  }
//  min = data.min;
//  max = data.max;
//  sum = data.sum;
//  values = data.values.sort(function(a, b) {
//    return a - b;
//  });
//  if (num === 1)
//  {
//    return [min, max];
//  }
//  limits = [];
//  if (mode.substr(0, 1) === 'c')
//  {
//    limits.push(min);
//    limits.push(max);
//  }
//  if (mode.substr(0, 1) === 'e')
//  {
//    limits.push(min);
//    for (i = o = 1, ref = num - 1; 1 <= ref ? o <= ref : o >= ref; i = 1 <= ref ? ++o : --o) {
//      limits.push(min + (i / num) * (max - min));
//    }
//    limits.push(max);
//  }
//  else if (mode.substr(0, 1) === 'l')
//  {
//    if (min <= 0)
//    {
//      throw 'Logarithmic scales are only possible for values > 0';
//    }
//    min_log = Math.LOG10E * log(min);
//    max_log = Math.LOG10E * log(max);
//    limits.push(min);
//    for (i = w = 1, ref1 = num - 1; 1 <= ref1 ? w <= ref1 : w >= ref1; i = 1 <= ref1 ? ++w : --w)
//    {
//      limits.push(pow(10, min_log + (i / num) * (max_log - min_log)));
//    }
//    limits.push(max);
//  }
//  else if (mode.substr(0, 1) === 'q')
//  {
//    limits.push(min);
//    for (i = aa = 1, ref2 = num - 1; 1 <= ref2 ? aa <= ref2 : aa >= ref2; i = 1 <= ref2 ? ++aa : --aa)
//    {
//      p = (values.length - 1) * i / num;
//      pb = floor(p);
//      if (pb === p)
//      {
//        limits.push(values[pb]);
//      }
//      else
//      {
//        pr = p - pb;
//        limits.push(values[pb] * (1 - pr) + values[pb + 1] * pr);
//      }
//    }
//    limits.push(max);
//  }
//  else if (mode.substr(0, 1) === 'k')
//  {

//    /*
//    implementation based on
//    http://code.google.com/p/figue/source/browse/trunk/figue.js#336
//    simplified for 1-d input values
//     */
//    n = values.length;
//    assignments = new Array(n);
//    clusterSizes = new Array(num);
//    repeat = true;
//    nb_iters = 0;
//    centroids = null;
//    centroids = [];
//    centroids.push(min);
//    for (i = ab = 1, ref3 = num - 1; 1 <= ref3 ? ab <= ref3 : ab >= ref3; i = 1 <= ref3 ? ++ab : --ab)
//    {
//      centroids.push(min + (i / num) * (max - min));
//    }
//    centroids.push(max);
//    while (repeat)
//    {
//      for (j = ac = 0, ref4 = num - 1; 0 <= ref4 ? ac <= ref4 : ac >= ref4; j = 0 <= ref4 ? ++ac : --ac)
//      {
//        clusterSizes[j] = 0;
//      }
//      for (i = ad = 0, ref5 = n - 1; 0 <= ref5 ? ad <= ref5 : ad >= ref5; i = 0 <= ref5 ? ++ad : --ad)
//      {
//        value = values[i];
//        mindist = Number.MAX_VALUE;
//        for (j = ae = 0, ref6 = num - 1; 0 <= ref6 ? ae <= ref6 : ae >= ref6; j = 0 <= ref6 ? ++ae : --ae)
//        {
//          dist = abs(centroids[j] - value);
//          if (dist < mindist)
//          {
//            mindist = dist;
//            best = j;
//          }
//        }
//        clusterSizes[best]++;
//        assignments[i] = best;
//      }
//      newCentroids = new Array(num);
//      for (j = af = 0, ref7 = num - 1; 0 <= ref7 ? af <= ref7 : af >= ref7; j = 0 <= ref7 ? ++af : --af)
//      {
//        newCentroids[j] = null;
//      }
//      for (i = ag = 0, ref8 = n - 1; 0 <= ref8 ? ag <= ref8 : ag >= ref8; i = 0 <= ref8 ? ++ag : --ag)
//      {
//        cluster = assignments[i];
//        if (newCentroids[cluster] === null)
//        {
//          newCentroids[cluster] = values[i];
//        }
//        else
//        {
//          newCentroids[cluster] += values[i];
//        }
//      }
//      for (j = ah = 0, ref9 = num - 1; 0 <= ref9 ? ah <= ref9 : ah >= ref9; j = 0 <= ref9 ? ++ah : --ah)
//      {
//        newCentroids[j] *= 1 / clusterSizes[j];
//      }
//      repeat = false;
//      for (j = ai = 0, ref10 = num - 1; 0 <= ref10 ? ai <= ref10 : ai >= ref10; j = 0 <= ref10 ? ++ai : --ai)
//      {
//        if (newCentroids[j] !== centroids[i])
//        {
//          repeat = true;
//          break;
//        }
//      }
//      centroids = newCentroids;
//      nb_iters++;
//      if (nb_iters > 200)
//      {
//        repeat = false;
//      }
//    }
//    kClusters = { };
//    for (j = aj = 0, ref11 = num - 1; 0 <= ref11 ? aj <= ref11 : aj >= ref11; j = 0 <= ref11 ? ++aj : --aj)
//    {
//      kClusters[j] = [];
//    }
//    for (i = ak = 0, ref12 = n - 1; 0 <= ref12 ? ak <= ref12 : ak >= ref12; i = 0 <= ref12 ? ++ak : --ak)
//    {
//      cluster = assignments[i];
//      kClusters[cluster].push(values[i]);
//    }
//    tmpKMeansBreaks = [];
//    for (j = al = 0, ref13 = num - 1; 0 <= ref13 ? al <= ref13 : al >= ref13; j = 0 <= ref13 ? ++al : --al)
//    {
//      tmpKMeansBreaks.push(kClusters[j][0]);
//      tmpKMeansBreaks.push(kClusters[j][kClusters[j].length - 1]);
//    }
//    tmpKMeansBreaks = tmpKMeansBreaks.sort(function(a, b) {
//      return a - b;
//    });
//    limits.push(tmpKMeansBreaks[0]);
//    for (i = am = 1, ref14 = tmpKMeansBreaks.length - 1; am <= ref14; i = am += 2)
//    {
//      v = tmpKMeansBreaks[i];
//      if (!isNaN(v) && limits.indexOf(v) === -1)
//      {
//        limits.push(v);
//      }
//    }
//  }
//  return limits;
//};

//hsi2rgb = function(h, s, i)
//{

//  /*
//  borrowed from here:
//  http://hummer.stanford.edu/museinfo/doc/examples/humdrum/keyscape2/hsi2rgb.cpp
//   */
//  var args, b, g, r;
//  args = unpack(arguments);
//  h = args[0], s = args[1], i = args[2];
//  if (isNaN(h))
//  {
//    h = 0;
//  }
//  h /= 360;
//  if (h < 1 / 3)
//  {
//    b = (1 - s) / 3;
//    r = (1 + s * cos(TWOPI * h) / cos(PITHIRD - TWOPI * h)) / 3;
//    g = 1 - (b + r);
//  }
//  else if (h < 2 / 3)
//  {
//    h -= 1 / 3;
//    r = (1 - s) / 3;
//    g = (1 + s * cos(TWOPI * h) / cos(PITHIRD - TWOPI * h)) / 3;
//    b = 1 - (r + g);
//  }
//  else
//  {
//    h -= 2 / 3;
//    g = (1 - s) / 3;
//    b = (1 + s * cos(TWOPI * h) / cos(PITHIRD - TWOPI * h)) / 3;
//    r = 1 - (g + b);
//  }
//  r = limit(i * r * 3);
//  g = limit(i * g * 3);
//  b = limit(i * b * 3);
//  return [r * 255, g * 255, b * 255, args.length > 3 ? args[3] : 1];
//};

//rgb2hsi = function()
//{

//  /*
//  borrowed from here:
//  http://hummer.stanford.edu/museinfo/doc/examples/humdrum/keyscape2/rgb2hsi.cpp
//   */
//  var b, g, h, i, min, r, ref, s;
//  ref = unpack(arguments), r = ref[0], g = ref[1], b = ref[2];
//  TWOPI = Math.PI * 2;
//  r /= 255;
//  g /= 255;
//  b /= 255;
//  min = Math.min(r, g, b);
//  i = (r + g + b) / 3;
//  s = 1 - min / i;
//  if (s === 0)
//  {
//    h = 0;
//  }
//  else
//  {
//    h = ((r - g) + (r - b)) / 2;
//    h /= Math.sqrt((r - g) * (r - g) + (r - b) * (g - b));
//    h = Math.acos(h);
//    if (b > g)
//    {
//      h = TWOPI - h;
//    }
//    h /= TWOPI;
//  }
//  return [h * 360, s, i];
//};

//chroma.hsi = function()
//{
//  return (function(func, args, ctor) {
//    ctor.prototype = func.prototype;
//    FIXME_VAR_TYPE child = new ctor, result = func.apply(child, args);
//    return Object(result) === result ? result : child;
//  })(Color, slice.call(arguments).concat(['hsi']), function(){ });
//};

//_input.hsi = hsi2rgb;

//  Color.prototype.hsi = function()
//{
//  return rgb2hsi(this._rgb);
//};

//interpolate_hsx = function(col1, col2, f, m)
//{
//  var dh, hue, hue0, hue1, lbv, lbv0, lbv1, res, sat, sat0, sat1, xyz0, xyz1;
//  if (m === 'hsl')
//  {
//    xyz0 = col1.hsl();
//    xyz1 = col2.hsl();
//  }
//  else if (m === 'hsv')
//  {
//    xyz0 = col1.hsv();
//    xyz1 = col2.hsv();
//  }
//  else if (m === 'hcg')
//  {
//    xyz0 = col1.hcg();
//    xyz1 = col2.hcg();
//  }
//  else if (m === 'hsi')
//  {
//    xyz0 = col1.hsi();
//    xyz1 = col2.hsi();
//  }
//  else if (m === 'lch' || m === 'hcl')
//  {
//    m = 'hcl';
//    xyz0 = col1.hcl();
//    xyz1 = col2.hcl();
//  }
//  if (m.substr(0, 1) === 'h')
//  {
//    hue0 = xyz0[0], sat0 = xyz0[1], lbv0 = xyz0[2];
//    hue1 = xyz1[0], sat1 = xyz1[1], lbv1 = xyz1[2];
//  }
//  if (!isNaN(hue0) && !isNaN(hue1))
//  {
//    if (hue1 > hue0 && hue1 - hue0 > 180)
//    {
//      dh = hue1 - (hue0 + 360);
//    }
//    else if (hue1 < hue0 && hue0 - hue1 > 180)
//    {
//      dh = hue1 + 360 - hue0;
//    }
//    else
//    {
//      dh = hue1 - hue0;
//    }
//    hue = hue0 + f * dh;
//  }
//  else if (!isNaN(hue0))
//  {
//    hue = hue0;
//    if ((lbv1 === 1 || lbv1 === 0) && m !== 'hsv')
//    {
//      sat = sat0;
//    }
//  }
//  else if (!isNaN(hue1))
//  {
//    hue = hue1;
//    if ((lbv0 === 1 || lbv0 === 0) && m !== 'hsv')
//    {
//      sat = sat1;
//    }
//  }
//  else
//  {
//    hue = Number.NaN;
//  }
//  if (sat == null)
//  {
//    sat = sat0 + f * (sat1 - sat0);
//  }
//  lbv = lbv0 + f * (lbv1 - lbv0);
//  return res = chroma[m](hue, sat, lbv);
//};

//_interpolators = _interpolators.concat((function() {
//    var len, o, ref, results;
//    ref = ['hsv', 'hsl', 'hsi', 'hcl', 'lch', 'hcg'];
//    results = [];
//    for (o = 0, len = ref.length; o<len; o++) {
//      m = ref[o];
//      results.push([m, interpolate_hsx]);
//    }
//    return results;
//  })());

//  interpolate_num = function(col1, col2, f, m)
//{
//  var n1, n2;
//  n1 = col1.num();
//  n2 = col2.num();
//  return chroma.num(n1 + (n2 - n1) * f, 'num');
//};

//_interpolators.push(['num', interpolate_num]);

//  interpolate_lab = function(col1, col2, f, m)
//{
//  var res, xyz0, xyz1;
//  xyz0 = col1.lab();
//  xyz1 = col2.lab();
//  return res = new Color(xyz0[0] + f * (xyz1[0] - xyz0[0]), xyz0[1] + f * (xyz1[1] - xyz0[1]), xyz0[2] + f * (xyz1[2] - xyz0[2]), m);
//};

//_interpolators.push(['lab', interpolate_lab]);

//}).call(this);
//}
//  }
//}
