using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class StringValueAttributeExtensions
	{
		public static void AddValue(
			this ISupportsStringValueAttribute tag,
			string value)
		{
			tag.AddAttribute("value", value);
		}
	}
}