using Ccr.Chromatics.Colors.Infrastructure.WorkingSpaces;

namespace Ccr.Chromatics.Implementation.RGB
{
	/// <summary>
	/// Pair of companding functions for <see cref="IRGBWorkingSpace"/>.
	/// Used for conversion to XYZ and backwards. 
	/// </summary>
	/// <remarks>
	/// See also: <seealso cref="IRGBWorkingSpace.Companding"/>
	/// </remarks>
	public interface ICompanding
	{
		/// <summary>
		/// Companded channel is made linear with respect to the energy.
		/// </summary>
		/// <remarks>
		/// For more information, see:
		/// http://www.brucelindbloom.com/index.html?Eqn_RGB_to_XYZ.html
		/// </remarks>
		double InverseCompanding(double channel);

		/// <summary>
		/// Uncompanded channel (linear) is made nonlinear (depends on the RGB color system).
		/// </summary>
		/// <remarks>
		/// For more information, see:
		/// http://www.brucelindbloom.com/index.html?Eqn_XYZ_to_RGB.html
		/// </remarks>
		double Companding(double channel);
	}
}
