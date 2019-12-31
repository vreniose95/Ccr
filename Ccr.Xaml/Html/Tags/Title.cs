using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Title 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Title()
			: base("title")
		{
		}
	}
}