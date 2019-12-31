using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Details
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Details()
			: base("details")
		{
		}


		public virtual void AddOpen()
		{
			AddAttribute("open", "open");
		}
	}
}