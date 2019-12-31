using System;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class DatetimeAttributeExtensions
	{
		public static void AddDatetime(
			this ISupportsDatetimeAttribute tag, 
			DateTime datetime)
		{
			tag.AddAttribute("datetime", datetime.ToString("u"));
		}
	}
}