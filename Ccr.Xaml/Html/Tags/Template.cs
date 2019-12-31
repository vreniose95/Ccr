using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Template 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Template()
			: base("template")
		{
		}
	}
}