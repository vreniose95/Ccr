using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Main 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Main()
			: base("main")
		{
		}
	}
}