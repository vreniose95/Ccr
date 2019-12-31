using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class MutedAttributeExtensions
	{
		public static void AddMuted(
			this ISupportsMutedAttribute tag)
		{
			tag.AddAttribute("muted", "muted");
		}
	}
}