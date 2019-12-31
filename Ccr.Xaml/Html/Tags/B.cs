using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class B 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public B()
			: base("b")
		{
		}
	}
}