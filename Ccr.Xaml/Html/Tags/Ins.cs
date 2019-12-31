using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Ins 
		: Tag,
			ISupportsCiteAttribute, 
			ISupportsDatetimeAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Ins()
			: base("ins")
		{
		}
	}
}