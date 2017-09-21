using System;
using System.Windows.Media;

namespace Ccr.PresentationCore.Media
{
	/// <summary>
	/// Describes a color in terms of hue, saturation, and lightness channels.
	/// </summary>
	/// <remarks>
	/// reworked version of http://www.geekymonkey.com/Programming/CSharp/RGB2HSL_HSL2RGB.htm
	/// </remarks>
	public struct HslColor
	{
		public double H { get; }

		public double S { get; }

		public double L { get; }


		public HslColor(
			double h, 
			double s,
			double l)
		{
			H = h;
			S = s;
			L = l;
		}

		public static implicit operator Color(
			HslColor @this)
		{
			return @this.ToColor();
		}
		public static implicit operator HslColor(
			Color @this)
		{
			return FromColor(@this);
		}


		public static HslColor FromColor(
			Color color)
		{
			var r = color.R / 255.0;
			var g = color.G / 255.0;
			var b = color.B / 255.0;

			var h = 0d;
			var s = 0d;
			var l = 0d;

			var v = Math.Max(r, g);
			v = Math.Max(v, b);
			var m = Math.Min(r, g);
			m = Math.Min(m, b);
			l = (m + v) / 2.0;
			if (l <= 0.0)
			{
				return new HslColor(h, s, l);
			}
			var vm = v - m;
			s = vm;
			if (s > 0.0)
			{
				s /= (l <= 0.5) ? (v + m) : (2.0 - v - m);
			}
			else
			{
				return new HslColor(h, s, l);
			}
			var r2 = (v - r) / vm;
			var g2 = (v - g) / vm;
			var b2 = (v - b) / vm;
			if (r == v)
			{
				h = (g == m ? 5.0 + b2 : 1.0 - g2);
			}
			else if (g == v)
			{
				h = (b == m ? 1.0 + r2 : 3.0 - b2);
			}
			else
			{
				h = (r == m ? 3.0 + g2 : 5.0 - r2);
			}
			h /= 6.0;
			return new HslColor(h, s, l);
		}

		public Color ToColor()
		{
			var h = H;
			var s = S;
			var l = L;

			var r = l;
			var g = l;
			var b = l;
			var v = (l <= 0.5) ? (l * (1.0 + s)) : (l + s - l * s);
			if (v > 0)
			{
				var m = l + l - v;
				var sv = (v - m) / v;
				h *= 6.0;
				var sextant = (int)h;
				var fract = h - sextant;
				var vsf = v * sv * fract;
				var mid1 = m + vsf;
				var mid2 = v - vsf;
				switch (sextant)
				{
					case 0:
						r = v;
						g = mid1;
						b = m;
						break;
					case 1:
						r = mid2;
						g = v;
						b = m;
						break;
					case 2:
						r = m;
						g = v;
						b = mid1;
						break;
					case 3:
						r = m;
						g = mid2;
						b = v;
						break;
					case 4:
						r = mid1;
						g = m;
						b = v;
						break;
					case 5:
						r = v;
						g = m;
						b = mid2;
						break;
				}
			}
			var _r = Convert.ToByte(r * 255.0f);
			var _g = Convert.ToByte(g * 255.0f);
			var _b = Convert.ToByte(b * 255.0f);

			return Color.FromRgb(_r, _g, _b);
		}
	}
}
