using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Object 
		: Tag, 
			ISupportsFormAttribute,
			ISupportsHeightAttribute,
			ISupportsNameAttribute,
			ISupportsMIMETypeAttribute, 
			ISupportsUsemapAttribute,
			ISupportsWidthAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Object()
			: base("object")
		{
		}


		public void AddData(
			string data)
		{
			AddAttribute("data", data);
		}
	}
}