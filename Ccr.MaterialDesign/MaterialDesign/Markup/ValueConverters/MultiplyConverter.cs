using Ccr.Xaml.Markup.Converters.Infrastructure;

namespace Ccr.MaterialDesign.Markup.ValueConverters
{
	public class MultiplyConverter
		: XamlConverter<double, ConverterParam<double>, double>
	{
		public override double Convert(
			double value, 
			ConverterParam<double> param)
		{
			return value * param.Value;
		}
	}
}