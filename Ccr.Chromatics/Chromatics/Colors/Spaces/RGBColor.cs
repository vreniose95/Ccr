using Ccr.Std.Core.Extensions.NumericExtensions;

namespace Ccr.Chromatics.Colors.Spaces
{
	public struct RGBColor
	{
		public byte R { get; }

		public byte G { get; }

		public byte B { get; }


		public RGBColor(
			byte r,
			byte g,
			byte b)
		{
			r.ThrowIfNotWithin((0, 255), nameof(r));
			g.ThrowIfNotWithin((0, 255), nameof(g));
			b.ThrowIfNotWithin((0, 255), nameof(b));

			R = r;
			G = g;
			B = b;
		}
	}
}