using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Rp 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Rp()
			: base("rp")
		{
		}
	}
}