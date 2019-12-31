using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Address
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Address()
			: base("address")
		{
		}
	}
}