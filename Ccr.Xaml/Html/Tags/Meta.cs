using Ccr.Html.Attributes;
using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;
using System;
using Ccr.Html.Attributes.Extensions;

namespace Ccr.Html.Tags
{
	public class Meta
		: Tag, 
			ISupportsCharsetAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.SelfClosing;
		}


		public Meta()
			: base("meta")
		{
		}


		public virtual void AddName(
			Name name,
			string content)
		{
			if (string.IsNullOrWhiteSpace(content))
				throw new ArgumentException();

			AddAttribute("content", content);
			AddAttribute("name", name.LiteralValue());
		}

		public virtual void AddHttpEquiv(
			HttpEquiv httpEquiv, 
			string content)
		{
			if (string.IsNullOrWhiteSpace(content))
				throw new ArgumentException();

			AddAttribute("content", content);
			AddAttribute("http-equiv", httpEquiv.LiteralValue());
		}
	}
}