using Ccr.Html.Tags;

namespace Ccr.Html.Extensions
{
	public static class ExceptionMessages
	{
		public static string NotNullOrWhitespace(string parameterName)
			=> $"{parameterName} must contain a character different from whitespace";

		public static string InvalidAttributeForTag(string attributeName, string tagName)
			=> $"Cannot add {attributeName} attribute to {tagName}";
	}
}
