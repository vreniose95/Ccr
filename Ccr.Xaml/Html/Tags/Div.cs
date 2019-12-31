using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
    public class Div : Tag
    {
        public override TagRenderMode TagRenderMode => TagRenderMode.Normal;
        public Div() : base("div") { }
    }
}