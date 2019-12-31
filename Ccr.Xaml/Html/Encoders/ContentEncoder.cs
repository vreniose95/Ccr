using System.Web;

namespace Ccr.Html.Encoders
{
	public class ContentEncoder 
		: IStringEncoder
	{
		public string Encode(
			string original)
		{
			return HttpUtility.HtmlEncode(original);
		}
	}
}