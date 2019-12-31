using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags.YouTube
{
	public class YouTubePaperButton
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public YouTubePaperButton()
			: base(
				"paper_button")
		{
		}
	}
}