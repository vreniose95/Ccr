using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Strong 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Strong()
			: base("strong")
		{
		}
	}
}