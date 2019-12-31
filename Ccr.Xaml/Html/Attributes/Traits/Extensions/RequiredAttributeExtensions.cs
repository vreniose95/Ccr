using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class RequiredAttributeExtensions
	{
		public static void AddRequired(
			this ISupportsRequiredAttribute tag)
		{
			tag.AddAttribute("required", "required");
		}
	}
}