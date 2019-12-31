using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Sub 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Sub()
			: base("sub")
		{
		}
	}
}