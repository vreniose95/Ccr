using System;
using Ccr.Html.Attributes.Traits.Interfaces;

namespace Ccr.Html.Attributes.Traits.Extensions
{
	public static class MIMETypeAttributeExtensions
	{
		public static void AddType(
			this ISupportsMIMETypeAttribute tag, 
			string type)
		{
			if (string.IsNullOrWhiteSpace(type))
				throw new ArgumentException();

			tag.AddAttribute("type", type);
		}
	}
}