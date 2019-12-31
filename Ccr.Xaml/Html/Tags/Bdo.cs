using Ccr.Html.Attributes;
using Ccr.Html.Attributes.Extensions;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Bdo
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Bdo(
			Dir dir) 
			: base("bdo")
		{
			AddAttribute("dir", dir.LiteralValue());
		}
	}
}