using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Datalist
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Datalist()
			: base("datalist")
		{
		}
	}
}