using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Select
		: Tag,
			ISupportsAutofocusAttribute,
			ISupportsDisabledAttribute,
			ISupportsFormAttribute, 
			ISupportsMultipleAttribute,
			ISupportsNameAttribute,
			ISupportsRequiredAttribute, 
			ISupportsSizeAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Select()
			: base("select")
		{
		}
	}
}