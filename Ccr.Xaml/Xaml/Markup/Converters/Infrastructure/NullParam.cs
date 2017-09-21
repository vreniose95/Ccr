using System.Globalization;

namespace Ccr.Xaml.Markup.Converters.Infrastructure
{
	public class NullParam : ConverterParam
	{
		public NullParam(
			object value,
			CultureInfo cultureInfo) : base(
			value,
			cultureInfo)
		{
		}
	}
}
