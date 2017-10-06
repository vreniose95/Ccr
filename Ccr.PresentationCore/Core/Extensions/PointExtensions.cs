using System;
using System.Windows;

namespace Ccr.Core.Extensions
{
	public static class PointExtensions
	{
		public static Point Add(
			this Point @this,
			Point value)
		{
			return new Point(
				@this.X + value.X,
				@this.Y + value.Y);
		}

		public static Point Subtract(
			this Point @this,
			Point value)
		{
			return new Point(
				@this.X + value.X,
				@this.Y + value.Y);
		}

		public static Point Invert(
			this Point @this)
		{
			return new Point(
				-@this.X,
				-@this.Y);
		}

		public static Point Push(
			this Point @this,
			double x,
			double y)
		{
			return new Point(
				@this.X + x,
				@this.Y + y);
		}

		public static Point PushVHorizontal(
			this Point @this,
			double x)
		{
			return new Point(
				@this.X + x,
				@this.Y);
		}

		public static Point PushVertical(
			this Point @this,
			double y)
		{
			return new Point(
				@this.X,
				@this.Y + y);
		}

		/// <inheritdoc cref="Math.Atan2"/>
		public static double Atan2(
			this Point @this)
		{
			return Math.Atan2(
				@this.Y,
				@this.X);
		}
		

	}
}
