using Ccr.Xaml.Markup.Converters.Infrastructure;

namespace Ccr.MaterialDesign.Markup.ValueConverters
{
	public class ToUpperConverter
		: XamlConverter<
			object,
			NullParam,
			string>
	{
		public override string Convert(
			object arg1,
			NullParam param)
		{
			return arg1.ToString().ToUpper();
		}
	}
}
