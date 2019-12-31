using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class PlaceholderAttributeExtensions
	{
		public static void AddPlaceholder(
			this ISupportsPlaceholderAttribute tag,
			string placeholder)
		{
			tag.AddAttribute("placeholder", placeholder);
		}
	}
}