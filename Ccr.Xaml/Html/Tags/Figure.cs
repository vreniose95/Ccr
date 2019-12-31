using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Figure 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Figure()
			: base("figure")
		{
		}
	}
}