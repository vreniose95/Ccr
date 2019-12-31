using Ccr.Html.Attributes;
using Ccr.Html.Attributes.Extensions;
using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Button
		: Tag,
			ISupportsAutofocusAttribute, 
			ISupportsDisabledAttribute,
			ISupportsFormAttribute,
			ISupportsNameAttribute, 
			ISupportsStringValueAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Button(
			ButtonType type) 
				: base("button")
		{
			AddAttribute("type", type.LiteralValue());
		}
	}
}