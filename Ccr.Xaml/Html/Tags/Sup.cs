using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Sup
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Sup()
			: base("sup")
		{
		}
	}
}