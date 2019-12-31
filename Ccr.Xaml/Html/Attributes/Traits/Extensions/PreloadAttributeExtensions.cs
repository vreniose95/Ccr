using Ccr.Html.Attributes.Extensions;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class PreloadAttributeExtensions
	{
		public static void AddPreload(
			this ISupportsPreloadAttribute tag,
			Preload preload)
		{
			tag.AddAttribute("preload", preload.LiteralValue());
		}
	}
}