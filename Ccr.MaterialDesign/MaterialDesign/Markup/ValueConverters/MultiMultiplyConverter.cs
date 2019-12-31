using Ccr.Xaml.Markup.Converters.Infrastructure;

namespace Ccr.MaterialDesign.Markup.ValueConverters
{
	public class MultiplyConverter : XamlConverter<double, ConverterParam<double>, double>
  {
    public override double Convert(double value, ConverterParam<double> param)
    {
      return value * param.Value;
    }
  }

  public class MultiplyMultiConverter : XamlConverter<double, double, NullParam, double>
  {
    public override double Convert(double value, double value2, NullParam param)
    {
      return value * value2;
    }
  }
}
