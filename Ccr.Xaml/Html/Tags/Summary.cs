using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Summary 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Summary()
			: base("summary")
		{
		}
	}
}