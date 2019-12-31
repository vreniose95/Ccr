using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Tfoot
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Tfoot()
			: base("tfoot")
		{
		}
	}
}