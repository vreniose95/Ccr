using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class LabelAttributeExtensions
	{
		public static void AddLabel(
			this ISupportsLabelAttribute tag, 
			string label)
		{
			tag.AddAttribute("label", label);
		}
	}
}