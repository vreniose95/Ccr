using Ccr.Html.Attributes;
using Ccr.Html.Attributes.Extensions;
using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Th 
		: Tag, 
			ISupportsColspanAttribute, 
			ISupportsRowspanAttribute,
			ISupportsHeadersAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Th()
			: base("th")
		{
		}


		public virtual void AddScope(
			Scope scope)
		{
			AddAttribute("scope", scope.LiteralValue());
		}
	}
}