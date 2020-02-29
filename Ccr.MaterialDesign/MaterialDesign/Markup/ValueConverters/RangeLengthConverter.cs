using Ccr.Xaml.Markup.Converters.Infrastructure;

namespace Ccr.MaterialDesign.Markup.ValueConverters
{
	public class RangeLengthConverter
		: XamlConverter<
			double, 
			double, 
			double, 
			double, 
			NullParam, 
			double>
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

			return length > containerLength 
				? containerLength 
				: length;
		}
	}
}