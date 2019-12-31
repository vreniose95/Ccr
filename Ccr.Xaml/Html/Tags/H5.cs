using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class H5 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public H5()
			: base("h5")
		{
		}
	}
}