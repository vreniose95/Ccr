using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Head
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Head()
			: base("head")
		{
		}
	}
}