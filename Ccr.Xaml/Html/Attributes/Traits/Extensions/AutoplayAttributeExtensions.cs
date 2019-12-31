using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class AutoplayAttributeExtensions
	{
		public static void AddAutoplay(
			this ISupportsAutoplayAttribute tag)
		{
			tag.AddAttribute("autoplay", "autoplay");
		}
	}
}