using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Samp
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Samp()
			: base("samp")
		{
		}
	}
}