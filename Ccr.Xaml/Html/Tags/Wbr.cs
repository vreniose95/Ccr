using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Wbr
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.SelfClosing;
		}


		public Wbr()
			: base("wbr")
		{
		}
	}
}