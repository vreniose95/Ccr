using System.Text;

namespace Ccr.Html.Tags.Infrastructure
{
	public interface IInnerHtml
	{
		StringBuilder Render(
			StringBuilder stringBuilder);
	}
}
