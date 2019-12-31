using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Param 
		: Tag,
			ISupportsNameAttribute, 
			ISupportsStringValueAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.SelfClosing;
		}


		public Param()
			: base("param")
		{
		}
	}
}