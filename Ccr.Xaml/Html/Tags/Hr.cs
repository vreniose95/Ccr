using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Hr 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.SelfClosing;
		}


		public Hr()
			: base("hr")
		{
		}
	}
}