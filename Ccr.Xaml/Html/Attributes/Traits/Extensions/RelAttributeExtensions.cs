using Ccr.Html.Attributes.Extensions;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class RelAttributeExtensions
	{
		public static void AddRel(
			this ISupportsRelAttribute tag, 
			Rel rel)
		{
			tag.AddAttribute("rel", rel.LiteralValue());
		}
	}
}