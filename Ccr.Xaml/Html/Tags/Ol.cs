using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Ol 
		: Tag
	{
		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Ol()
			: base("ol")
		{
		}


		public virtual void AddReversed()
		{
			AddAttribute("reversed", "reversed");
		}

		public virtual void AddStart(
			int start)
		{
			AddAttribute("start", start.ToString());
		}
	}
}