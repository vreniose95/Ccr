using Ccr.Html.Attributes;
using Ccr.Html.Attributes.Extensions;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Base 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.SelfClosing;
		}


		public Base(
			string href,
			Target? target = null)
				: base("base")
		{
			if (!string.IsNullOrEmpty(href))
				AddAttribute("href", href);

			if (target.HasValue)
				AddAttribute("target", target.Value.LiteralValue());
		}

		public Base(
			Target target) 
				: base("base")
		{
			AddAttribute("target", target.LiteralValue());
		}
	}
}