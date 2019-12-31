using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class I 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public I()
			: base("i")
		{
		}
	}
}