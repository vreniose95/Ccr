using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class AutofocusAttributeExtensions
	{
		public static void AddAutofocus(
			this ISupportsAutofocusAttribute tag)
		{
			tag.AddAttribute("autofocus", "autofocus");
		}
	}
}