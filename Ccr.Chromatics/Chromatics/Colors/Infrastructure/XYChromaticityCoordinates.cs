/*
Ccr.Chromatics is an adaptation of Colorful

Copyright (c) 2018 Tomáš Pažourek

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:
*/

using Ccr.Std.Core.Extensions.NumericExtensions;

namespace Ccr.Chromatics.Colors.Infrastructure
{
	/// <summary>
	/// Coordinates of CIE XY Chromaticity Space
	/// </summary>
	public struct XYChromaticityCoordinates
	{
		#region Properties
		/// <summary>
		/// Chromaticity Coordinate X
		/// </summary>
		/// <remarks>
		/// This value must be between [0.00 to 1.00], inclusively.
		/// </remarks>
		public double X { get; }

		/// <summary>
		/// Chromaticity Coordinate Y
		/// </summary>
		/// <remarks>
		/// This value must be between [0.00 to 1.00], inclusively.
		/// </remarks>
		public double Y { get; }

		#endregion


		#region Constructors
		/// <param name="x">
		/// Chromaticity Coordinate X, which must be between [0.00 to 1.00], inclusively.
		/// </param>
		/// <param name="y">
		/// Chromaticity Coordinate X, which must be between [0.00 to 1.00], inclusively.
		/// </param>
		public XYChromaticityCoordinates(
			double x,
			double y)
		{
			x.ThrowIfNotWithin((0d, 1d), nameof(x));
			y.ThrowIfNotWithin((0d, 1d), nameof(y));

			X = x;
			Y = y;
		}

		#endregion


		#region Methods
		/// <summary>
		/// Converts this <see cref="XYChromaticityCoordinates"/> instance to its <see cref="string"/> representation.
		/// </summary>
		/// <returns>
		/// Returns the <see cref="string"/> representation of this <see cref="XYChromaticityCoordinates"/> instance.
		/// </returns>
		public override string ToString()
		{
			return $"XY [X={X:0.##} Y={Y:0.##}]";
		}

		#endregion


		#region Equality
		/// <inheritdoc cref="object"/>
		public bool Equals(
			XYChromaticityCoordinates other)
		{
			return X.Equals(other.X)
				&& Y.Equals(other.Y);
		}

		/// <inheritdoc cref="object"/>
		public override bool Equals(
			object obj)
		{
			return obj is XYChromaticityCoordinates coordinates 
				&& Equals(coordinates);
		}

		/// <inheritdoc cref="object"/>
		public override int GetHashCode()
		{
			unchecked
			{
				return (X.GetHashCode() * 397) ^ X.GetHashCode();
			}
		}

		#endregion


		#region Operators
		/// <inheritdoc cref="object"/>
		public static bool operator ==(
			XYChromaticityCoordinates left,
			XYChromaticityCoordinates right)
		{
			return left.Equals(right);
		}

		/// <inheritdoc cref="object"/>
		public static bool operator !=(
			XYChromaticityCoordinates left,
			XYChromaticityCoordinates right)
		{
			return !left.Equals(right);
		}

		#endregion
	}
}
