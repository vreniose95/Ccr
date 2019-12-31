using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class ControlsAttributeExtensions
	{
		public static void AddControls(
			this ISupportsControlsAttribute tag)
		{
			tag.AddAttribute("controls", "controls");
		}
	}
}