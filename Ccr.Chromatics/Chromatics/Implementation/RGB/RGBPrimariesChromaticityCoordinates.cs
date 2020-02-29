using Ccr.Chromatics.Colors.Infrastructure;
using Ccr.Chromatics.Colors.Infrastructure.WorkingSpaces;

namespace Ccr.Chromatics.Implementation.RGB
{
	/// <summary>
	/// Chromaticity coordinates of RGB primaries.
	/// One of the specifiers of <see cref="IRGBWorkingSpace"/>.
	/// </summary>
	public struct RGBPrimariesChromaticityCoordinates
	{
		#region Properties
		/// <summary>
		/// Red Channel Chromaticity Coordinates
		/// </summary>
		public XYChromaticityCoordinates R { get; }

		/// <summary>
		/// Green Channel Chromaticity Coordinates
		/// </summary>
		public XYChromaticityCoordinates G { get; }

		/// <summary>
		/// Blue Channel Chromaticity Coordinates
		/// </summary>
		public XYChromaticityCoordinates B { get; }

		#endregion


		#region Constructors
		/// <summary>
		/// Constructor that creates an instance of the
		/// <see cref="RGBPrimariesChromaticityCoordinates"/> struct.
		/// </summary>
		public RGBPrimariesChromaticityCoordinates(
			XYChromaticityCoordinates r,
			XYChromaticityCoordinates g,
			XYChromaticityCoordinates b)
		{
			R = r;
			G = g;
			B = b;
		}

		#endregion


		#region Equality
		/// <inheritdoc cref="object"/>
		public bool Equals(
			RGBPrimariesChromaticityCoordinates other)
		{
			return R.Equals(other.R)
				&& G.Equals(other.G)
				&& B.Equals(other.B);
		}

		/// <inheritdoc cref="object"/>
		public override bool Equals(object obj)
		{
			return obj is RGBPrimariesChromaticityCoordinates other
				&& Equals(other);
		}

		/// <inheritdoc cref="object"/>
		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = R.GetHashCode();
				hashCode = (hashCode * 397) ^ G.GetHashCode();
				hashCode = (hashCode * 397) ^ B.GetHashCode();

				return hashCode;
			}
		}

		#endregion


		#region Operators
		/// <inheritdoc cref="object"/>
		public static bool operator ==(
			RGBPrimariesChromaticityCoordinates left,
			RGBPrimariesChromaticityCoordinates right)
		{
			return left.Equals(right);
		}

		/// <inheritdoc cref="object"/>
		public static bool operator !=(
			RGBPrimariesChromaticityCoordinates left,
			RGBPrimariesChromaticityCoordinates right)
		{
			return !left.Equals(right);
		}

		#endregion
	}
}
