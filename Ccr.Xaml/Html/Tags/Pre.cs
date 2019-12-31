using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Pre 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Pre()
			: base("pre")
		{
		}
	}
}