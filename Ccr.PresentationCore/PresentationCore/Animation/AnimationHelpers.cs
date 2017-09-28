using System;
using System.Windows;

namespace Ccr.PresentationCore.Animation
{
	internal static class AnimationHelpers
	{
		internal static bool IsValidAnimationValueCornerRadius(CornerRadius value)
		{
			return IsValidAnimationValueDouble(value.TopLeft) ||
				IsValidAnimationValueDouble(value.TopRight) ||
				IsValidAnimationValueDouble(value.BottomRight) ||
				IsValidAnimationValueDouble(value.BottomLeft);

			//bool cr1Valid;
			//var targetStaticType = Type.GetType("MS.Internal.PresentationFramework.AnimatedTypeHelpers");
			////var targetStaticType = typeof (AnimatedTypeHelpers);
			//targetStaticType.TryInvokeInternalStaticMethod("IsValidAnimationValueDouble", out cr1Valid, value.BottomLeft);
			//return true;
			//var i = 0.TryInvokeInternalMethod("IsValidAnimationValueDouble", out cr1Valid, value.BottomLeft);
			// return AnimatedTypeHelpers.IsValidAnimationValueDouble(value.Left) || AnimatedTypeHelpers.IsValidAnimationValueDouble(value.Top) || (AnimatedTypeHelpers.IsValidAnimationValueDouble(value.Right) || AnimatedTypeHelpers.IsValidAnimationValueDouble(value.Bottom));
		}
		internal static CornerRadius AddCornerRadius(
			CornerRadius value1,
			CornerRadius value2)
		{
			//double c1, c2, c3, c4;
			//var targetStaticType = Type.GetType("MS.Internal.PresentationFramework.AnimatedTypeHelpers");
			//targetStaticType.TryInvokeInternalStaticMethod("IsValidAnimationValueDouble", out c1, value.BottomLeft);
			return new CornerRadius(
				value1.TopLeft + value2.TopLeft,
				value1.TopRight + value2.TopRight,
				value1.BottomRight + value2.BottomRight,
				value1.BottomLeft + value2.BottomLeft);

			//return new CornerRadius(AnimatedTypeHelpers.AddDouble(value1.Left, value2.Left), AnimatedTypeHelpers.AddDouble(value1.Top, value2.Top), AnimatedTypeHelpers.AddDouble(value1.Right, value2.Right), AnimatedTypeHelpers.AddDouble(value1.Bottom, value2.Bottom));
		}
		private static bool IsInvalidDouble(double value)
		{
			if (!double.IsInfinity(value))
				return Double.IsNaN(value);
			return true;
		}

		private static bool IsValidAnimationValueDouble(double value)
		{
			return !IsInvalidDouble(value);
		}

		internal static CornerRadius ScaleCornerRadius(CornerRadius value, double factor)
		{
			return new CornerRadius(
				ScaleDouble(value.TopLeft, factor),
				ScaleDouble(value.TopRight, factor),
				ScaleDouble(value.BottomRight, factor),
				ScaleDouble(value.BottomLeft, factor));


		}

		private static double ScaleDouble(double value, double factor)
		{
			return value * factor;
		}

		private static double InterpolateDouble(double from, double to, double progress)
		{
			return from + (to - from) * progress;
		}

		internal static CornerRadius InterpolateCornerRadius(CornerRadius from, CornerRadius to, double progress)
		{
			return new CornerRadius(
				InterpolateDouble(from.TopLeft, to.TopLeft, progress),
				InterpolateDouble(from.TopRight, to.TopRight, progress),
				InterpolateDouble(from.BottomLeft, to.BottomLeft, progress),
				InterpolateDouble(from.BottomRight, to.BottomRight, progress));

		}
		
		internal static CornerRadius SubtractCornerRadius(CornerRadius value1, CornerRadius value2)
		{
			return new CornerRadius(
				value1.TopLeft + value2.TopLeft,
				value1.TopRight + value2.TopRight,
				value1.BottomRight + value2.BottomRight,
				value1.BottomLeft + value2.BottomLeft);
			//	return new CornerRadius(value1.Left - value2.Left, value1.Top - value2.Top, value1.Right - value2.Right, value1.Bottom - value2.Bottom);
		}

	}
}
