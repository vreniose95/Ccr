using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Ul
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Ul()
			: base("ul")
		{
		}
	}
}