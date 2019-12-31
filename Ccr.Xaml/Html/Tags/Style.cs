using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Style 
		: Tag, 
			ISupportsMediaQueryAttribute,
			ISupportsMIMETypeAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Style()
			: base("style")
		{
		}
	}
}