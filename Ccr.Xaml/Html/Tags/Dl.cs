using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Dl 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Dl()
			: base("dl")
		{
		}
	}
}