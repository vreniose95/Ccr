using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Dfn 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Dfn()
			: base("dfn")
		{
		}
	}
}