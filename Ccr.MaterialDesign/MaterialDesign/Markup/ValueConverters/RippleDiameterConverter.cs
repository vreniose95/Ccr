using System.Windows;
using Ccr.Core.Extensions.NumericExtensions;
using Ccr.Xaml.Markup.Converters.Infrastructure;

namespace Ccr.MaterialDesign.Markup.ValueConverters
{
	public class RippleDiameterConverter
		: XamlConverter<
			double, 
			double,
			Point,
			ConverterParam<double>, 
			double>
	{
		public override double Convert(
			double width,
			double height, 
			Point cursorPosition,
			ConverterParam<double> scaleParameter)
		{
			var effectiveRippleCoverWidth
				= cursorPosition.X < width / 2
					? width - cursorPosition.X
					: cursorPosition.X;

			var effectiveRippleCoverHeight
				= cursorPosition.Y < height / 2
					? height - cursorPosition.Y
					: cursorPosition.Y;

			var radius =
				(effectiveRippleCoverWidth.Squared() 
					+ effectiveRippleCoverHeight.Squared())
						.Root();

			return radius * scaleParameter.Value;

		}
	}
}
