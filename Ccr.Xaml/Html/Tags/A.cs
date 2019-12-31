using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class A
		: Tag, 
			ISupportsRelAttribute,
			ISupportsTargetAttribute,
			ISupportsDownloadAttribute, 
			ISupportsMediaQueryAttribute
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public A(string href) 
			: base("a")
		{
			if (!string.IsNullOrEmpty(href))
				AddAttribute("href", href);
		}
	}
}