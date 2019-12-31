using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Aside 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Aside()
			: base("aside")
		{
		}
	}
}