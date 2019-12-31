using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class ReadonlyAttributeExtensions
	{
		public static void AddReadonly(
			this ISupportsReadonlyAttribute tag)
		{
			tag.AddAttribute("readonly", "readonly");
		}
	}
}