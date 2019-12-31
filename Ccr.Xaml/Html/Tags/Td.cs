using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Td 
		: Tag,
			ISupportsColspanAttribute, 
			ISupportsRowspanAttribute, 
			ISupportsHeadersAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Td()
			: base("td")
		{
		}
	}
}