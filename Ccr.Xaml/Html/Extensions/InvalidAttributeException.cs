using System;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Extensions
{
	public class InvalidAttributeException 
		: Exception
	{
		public InvalidAttributeException(
			string attributeName, 
			Tag tag)
				: base(
					ExceptionMessages.InvalidAttributeForTag(
						attributeName,
						tag.TagName))
		{
		}
	}
}