using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Mark 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Mark()
			: base("mark")
		{
		}
	}
}