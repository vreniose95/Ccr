using System.Xml.XPath;
using Ccr.Core.Extensions;

namespace Ccr.Extensions
{
	public static class XPathNavigatorExtensions
	{
		public static TValue Extract<TValue>(
			this XPathNavigator @this,
			string xpath)
		{
			var value = @this.Evaluate(xpath);
			var castValue = value.To<TValue>();
			return castValue;
		}
	}
}
