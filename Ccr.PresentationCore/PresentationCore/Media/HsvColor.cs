using System;
using System.Windows.Media;
using Ccr.Core.Extensions;

namespace Ccr.PresentationCore.Media
{
	public struct HsvColor
	{
		public double H { get; }

		public double S { get; }

		public double V { get; }


		public HsvColor(
			double h, 
			double s, 
			double v)
		{
			H = h;
			S = s;
			V = v;
		}


		public static implicit operator Color(
			HsvColor @this)
		{
			return @this.ToColor();
		}

		public static implicit operator HsvColor(
			Color @this)
		{
			return FromColor(@this);
		}


		public static HsvColor FromColor(
			Color color)
		{
			int max = Math.Max(color.R, Math.Max(color.G, color.B));
			int min = Math.Min(color.R, Math.Min(color.G, color.B));

			var h = color.GetHue();
			var s = max == 0 ? 0 : 1d - 1d * min / max;
			var v = max / 255d;

			return new HsvColor(
				h,
				s,
				v);
		}

		public Color ToColor()
		{
			var h = H;
			var s = S;
			var v = V;

			var hi = Convert.ToInt32(Math.Floor(h / 60)) % 6; //TODO 60d
			var f = h / 60 - Math.Floor(h / 60); //TODO 60d?

			v = v * 255;

			var _v = (byte)v;
			var p = (byte)(v * (1 - s));
			var q = (byte)(v * (1 - f * s));
			var t = (byte)(v * (1 - (1 - f) * s));

			switch (hi)
			{
				case 0:
					return Color.FromArgb(255, _v, t, p);
				case 1:
					return Color.FromArgb(255, q, _v, p);
				case 2:
					return Color.FromArgb(255, p, _v, t);
				case 3:
					return Color.FromArgb(255, p, q, _v);
				case 4:
					return Color.FromArgb(255, t, p, _v);
				default:
					return Color.FromArgb(255, _v, p, q);
			}

			
			
		}
	}
}
