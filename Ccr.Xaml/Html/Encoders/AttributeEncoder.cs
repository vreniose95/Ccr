using System.Web;

namespace Ccr.Html.Encoders
{
	public class AttributeEncoder 
		: IStringEncoder
	{
		public string Encode(
			string original)
		{
			return original == null
				? original 
				: HttpUtility.HtmlAttributeEncode(original);
		}
	}
}
