using Ccr.Html.Attributes;
using Ccr.Html.Attributes.Extensions;
using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Link 
		: Tag, 
			ISupportsMediaQueryAttribute, 
			ISupportsMIMETypeAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.SelfClosing;
		}


		public Link(string href) 
			: base("link")
		{
			AddAttribute("href", href);
		}


		public virtual void AddRel(
			LinkRel rel)
		{
			AddAttribute("rel", rel.LiteralValue());
		}

		public virtual void AddCrossorigin(
			Crossorigin crossorigin)
		{
			AddAttribute("crossorigin", crossorigin.LiteralValue());
		}
	}
}