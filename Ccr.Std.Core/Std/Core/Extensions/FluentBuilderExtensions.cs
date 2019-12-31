using System;

namespace Ccr.Std.Core.Extensions
{
	public static class FluentBuilderExtensions
	{
		public static void EnsureNotAssigned<TElement>(
			this TElement? element,
			string elementName)
				where TElement
					: struct
		{
			if (element.HasValue)
				throw new InvalidOperationException(
					$"The {elementName.SQuote()} cannot be set to {elementName.Quote()} because the instance of " +
					$"the fluent builder already has the {elementName.SQuote()} value {element.ToString().SQuote()}.");
		}

		public static void EnsureNotAssigned<TElement>(
			this TElement element,
			string elementName)
				where TElement
					: class
		{
			if (element != null)
				throw new InvalidOperationException(
					$"The {elementName.SQuote()} cannot be set to {elementName.Quote()} because the instance of " +
					$"the fluent builder already has the {elementName.SQuote()} value {element.ToString().SQuote()}.");
		}



		public static TElement EnsureAssigned<TElement>(
			this TElement element,
			string elementName)
				where TElement
					: class
		{
			if (element == null)
				throw new InvalidOperationException(
					$"The {elementName.SQuote()} is not configured on the fluent builder and is set to {"null".SQuote()}.");

			return element;
		}

		public static TElement EnsureAssigned<TElement>(
			this TElement? element,
			string elementName)
				where TElement
					: struct
		{
			if (!element.HasValue)
				throw new InvalidOperationException(
					$"The {elementName.SQuote()} is not configured on the fluent builder and is set to {"null".SQuote()}.");

			return element.Value;
		}


		//public static TElement EnsureAssigned<TElement>(
		//	this TElement element,
		//	string elementName)
		//{
		//	if (element != null)
		//		throw new InvalidOperationException(
		//			$"The {elementName.SQuote()} cannot be set to {elementName.Quote()} because the instance of " +
		//			$"the fluent builder already has the {elementName.SQuote()} value {element.ToString().SQuote()}.");

		//	return element;
		//}
	}
}
