using System;
using System.Windows.Media;
using Ccr.PresentationCore.Media;

namespace Ccr.Core.Extensions
{
	public static class MediaExtensions
	{
		public static int GetHue(
			this Color @this)
		{
			var min = Math.Min(Math.Min(@this.R, @this.G), @this.B);
			var max = Math.Max(Math.Max(@this.R, @this.G), @this.B);

			float hue;
			if (max == @this.R)
				hue = ((float)@this.G - @this.B) / ((float)max - min);
			
			else if (max == @this.G)
				hue = 2f + ((float)@this.B - @this.R) / ((float)max - min);
			
			else
				hue = 4f + ((float)@this.R - @this.G) / ((float)max - min);
			
			hue = hue * 60;

			if (hue < 0)
				hue = hue + 360;

			return (int)Math.Round(hue);
		}
		public static HslColor ToHslColor(
			this Color @this)
		{
			return HslColor.FromColor(
				@this);
		}

		public static HsvColor ToHsvColor(
			this Color @this)
		{
			return HsvColor.FromColor(
				@this);
		}
	}
}
