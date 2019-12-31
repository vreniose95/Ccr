using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Picture 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Picture()
			: base("picture")
		{
		}
	}
}