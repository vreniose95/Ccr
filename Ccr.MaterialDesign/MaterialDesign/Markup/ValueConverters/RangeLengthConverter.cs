using Ccr.Xaml.Markup.Converters.Infrastructure;

namespace Ccr.MaterialDesign.Markup.ValueConverters
{
	public class RangeLengthConverter
		: XamlConverter<double, double, double, double, NullParam, double>
	{
		public override double Convert(
			double min,
			double max,
			double value,
			double containerLength,
			NullParam param)
		{
			var percent = (value - min) / (max - min);
			var length = percent * containerLength;

			return length > containerLength ? containerLength : length;
		}
	}
}
/*public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
{
	if (values == null || values.Length != 4 || values.Any(v => v == null))
		return Binding.DoNothing;

	if (!double.TryParse(values[0].ToString(), out double min)
	    || !double.TryParse(values[1].ToString(), out double max)
	    || !double.TryParse(values[2].ToString(), out double value)
	    || !double.TryParse(values[3].ToString(), out double containerLength))

		return Binding.DoNothing;

	var percent = (value - min) / (max - min);
	var length = percent * containerLength;

	return length > containerLength ? containerLength : length;
}*/
