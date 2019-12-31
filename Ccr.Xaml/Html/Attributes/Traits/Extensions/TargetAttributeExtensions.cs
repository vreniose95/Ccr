using Ccr.Html.Attributes.Extensions;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class TargetAttributeExtensions
	{
		public static void AddTarget(
			this ISupportsTargetAttribute tag, 
			Target target)
		{
			tag.AddAttribute("target", target.LiteralValue());
		}
	}
}