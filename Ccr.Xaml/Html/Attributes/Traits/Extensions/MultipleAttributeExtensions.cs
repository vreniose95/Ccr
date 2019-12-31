using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class MultipleAttributeExtensions
	{
		public static void AddMultiple(
			this ISupportsMultipleAttribute tag)
		{
			tag.AddAttribute("multiple", "multiple");
		}
	}
}