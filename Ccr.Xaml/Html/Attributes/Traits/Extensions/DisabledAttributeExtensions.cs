using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class DisabledAttributeExtensions
	{
		public static void AddDisabled(
			this ISupportsDisabledAttribute tag)
		{
			tag.AddAttribute("disabled", "disabled");
		}
	}
}