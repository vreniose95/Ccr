using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class LoopAttributeExtensions
	{
		public static void AddLoop(
			this ISupportsLoopAttribute tag)
		{
			tag.AddAttribute("loop", "loop");
		}
	}
}