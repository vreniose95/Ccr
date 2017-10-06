using System;
using System.Windows;
using Ccr.Core.Extensions;
using Ccr.Core.Extensions.NumericExtensions;
using Ccr.Core.Helpers;
// ReSharper disable ConvertToAutoProperty
namespace Ccr.PresentationCore.Layout
{
	public struct PolarPoint
	{
		private double _angleInDegrees;
		private double? _angleInRadians;
		private double _radius;

		/// <summary>
		///		Creates a new <see cref="PolarPoint"/> structure that contains the specified polar coordinates.
		/// </summary>
		/// <param name="angleInDegrees">
		///		The angle coordinate of the new <see cref="PolarPoint"/> structure, specified in degrees.
		/// </param>
		/// <param name="radius">
		///		The radius coordinate of the new <see cref="PolarPoint"/> structure.
		/// </param>
		public PolarPoint(
			double angleInDegrees,
			double radius)
		{
			_angleInDegrees = angleInDegrees;
			_angleInRadians = null;

			_radius = radius;
		}

		/// <summary>
		///		Gets the angle in Angle of the <see cref="PolarPoint"/> structure, specified in degrees.
		/// </summary>
		public double AngleInDegrees
		{
			get => _angleInDegrees;
			set
			{
				_angleInRadians = null;
				_angleInDegrees = value;
			}
		}

		/// <summary>
		/// 	Gets the angle in Angle of the <see cref="PolarPoint"/> structure, specified in radians.
		/// </summary>
		public double AngleInRadians
		{
			get => _angleInRadians ?? (_angleInRadians
				= MathHelpers.ToRadians(_angleInDegrees))
					.Value;
		}

		/// <summary>
		/// 	Gets the angle in Radius of the <see cref="PolarPoint"/> structure.
		/// </summary>
		public double Radius
		{
			get => _radius;
			set => _radius = value;
		}

		/// <summary>
		///		Converts the instance of the <see cref="PolarPoint"/> structure to a cartesian <see cref="Point"/>
		/// </summary>
		public Point ToCartesian()
		{
			var x = Radius * Math.Cos(AngleInRadians);
			var y = Radius * Math.Sin(AngleInRadians);

			return new Point(x, y);
		}
		/// <summary>
		///		Creates a <see cref="PolarPoint"/> structure from a cartesian <see cref="Point"/> structure.
		/// </summary>
		/// <param name="point">
		///		The cartesian <see cref="Point"/> structure to convert to a <see cref="PolarPoint"/> structure.
		/// </param>
		/// <returns>
		///		A <see cref="PolarPoint"/> structure created from the <paramref name="point"/> parameter.
		/// </returns>
		public static PolarPoint FromCartesian(
			Point point)
		{
			var angle = point.Atan2();
			var angleDegrees = MathHelpers.ToDegrees(angle);
			var radius = (point.X.Squared() + point.Y.Squared()).Root();

			return new PolarPoint(angleDegrees, radius);
		}
	}
}
