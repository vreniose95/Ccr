using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Data
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Data(
			string value) 
				: base("data")
		{
			AddAttribute("value", value);
		}
	}
}