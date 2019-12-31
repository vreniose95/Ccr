using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Table 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Table()
			: base("table")
		{
		}
	}
}