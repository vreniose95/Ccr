using Ccr.Html.Attributes;
using Ccr.Html.Attributes.Extensions;
using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Form 
		: Tag,
			ISupportsAutocompleteAttribute,
			ISupportsNameAttribute,
			ISupportsTargetAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Form()
			: base("form")
		{
		}


		public virtual void AddMethod(
			Method method, 
			EncType? enctype = null)
		{
			AddAttribute("method", method.LiteralValue());

			if (method == Method.POST && enctype.HasValue)
				AddAttribute("enctype", enctype.Value.LiteralValue());
		}

		public virtual void AddAcceptCharset(
			Charset charset)
		{
			AddAttribute("accept-charset", charset.LiteralValue());
		}

		public virtual void AddAction(
			string action)
		{
			AddAttribute("action", action);
		}

		public virtual void AddNoValidate()
		{
			AddAttribute("novalidate", "novalidate");
		}
	}
}