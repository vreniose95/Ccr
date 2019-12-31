using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public abstract class Script 
		: Tag, 
			ISupportsMIMETypeAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		protected Script()
			: base("script")
		{
		}
	}
}