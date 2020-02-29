using Ccr.Chromatics.Colors.Spaces;
using Ccr.Chromatics.Implementation.RGB;

namespace Ccr.Chromatics.Colors.Infrastructure.WorkingSpaces
{
	/// <summary>
	/// The RGB working color space
	/// </summary>
	public interface IRGBWorkingSpace
	{
		/// <summary>
		/// Reference white of the color space
		/// </summary>
		XYZColor WhitePoint { get; }

		/// <summary>
		/// Chromaticity coordinates of the primaries
		/// </summary>
		RGBPrimariesChromaticityCoordinates ChromaticityCoordinates { get; }

		/// <summary>
		/// The companding function associated with the RGB color system.
		/// Used for conversion to XYZ and backwards.   
		/// </summary>
		/// <remarks>
		/// Resources and More Information:
		/// http://www.brucelindbloom.com/index.html?Eqn_RGB_to_XYZ.html
		/// http://www.brucelindbloom.com/index.html?Eqn_XYZ_to_RGB.html
		/// </remarks>
		ICompanding Companding { get; }
	}
}
