using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Source 
		: Tag, 
			ISupportsMediaQueryAttribute, 
			ISupportsMIMETypeAttribute,
			ISupportsSrcAttribute,
			ISupportsSrcsetAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.SelfClosing;
		}


		public Source()
			: base("source")
		{
		}
	}
}