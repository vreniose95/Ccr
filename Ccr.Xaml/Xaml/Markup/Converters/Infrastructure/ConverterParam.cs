using System.Globalization;

namespace Ccr.Xaml.Markup.Converters.Infrastructure
{
	public abstract class ConverterParam
	{
		public object Value { get; }

		public CultureInfo CultureInfo { get; }


		protected ConverterParam(
			object value,
			CultureInfo cultureInfo)
		{
			Value = value;
			CultureInfo = cultureInfo;
		}
	}

	public class ConverterParam<TValue>
		: ConverterParam
	{
		public new TValue Value { get; }

		public ConverterParam(
			TValue value,
			CultureInfo cultureInfo) : base(
			value,
			cultureInfo)
		{
			Value = value;
		}
	}
}
