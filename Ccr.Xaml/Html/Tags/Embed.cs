using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Embed 
		: Tag, 
			ISupportsHeightAttribute,
			ISupportsWidthAttribute, 
			ISupportsMIMETypeAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.SelfClosing;
		}


		public Embed(
			string src)
				: base("embed")
		{
			AddAttribute("src", src);
		}
	}
}