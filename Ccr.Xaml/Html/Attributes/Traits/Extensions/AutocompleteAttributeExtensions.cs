using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class AutocompleteAttributeExtensions
	{
		public static void AddAutocomplete(
			this ISupportsAutocompleteAttribute tag,
			bool autocomplete)
		{
			tag.AddAttribute(
				"autocomplete", 
				autocomplete ? "on" : "off");
		}
	}
}