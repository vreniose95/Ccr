using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Article
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Article()
			: base("article")
		{
		}
	}
}