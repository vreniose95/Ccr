using Ccr.Xaml.Markup.Converters.Infrastructure;

namespace Ccr.MaterialDesign.Markup.ValueConverters
{
	public class MultiplyMultiConverter
		: XamlConverter<double, double, NullParam, double>
	{
		public override double Convert(
			double value,
			double value2, 
			NullParam param)
		{
			return value * value2;
		}
	}
}
