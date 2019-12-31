using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class S
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public S()
			: base("s")
		{
		}
	}
}