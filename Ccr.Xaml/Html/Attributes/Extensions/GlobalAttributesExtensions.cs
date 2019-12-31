using System;
using System.Linq;
using Ccr.Html.Tags;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Attributes.Extensions
{
	public static class GlobalAttributesExtensions
	{
		public static void AddId(
			this ITag tag,
			string id)
		{
			if (string.IsNullOrEmpty(id))
				throw new ArgumentException(
					"id can't be empty");

			if (!id[0].IsLetter())
				throw new ArgumentException(
					"first id character must be a letter");
			
			for (int i = 1; i < id.Length; i++)
			{
				if (!id[i].IsValidIdCharacter())
					throw new ArgumentException(
						$"id cannot contain character {id[i]}"); 
			}

			tag.AddAttribute("id", id);
		}

		public static void AddClasses(
			this ITag tag,
			params string[] classes)
		{
			var distinctClasses = classes
				.GroupBy(c => c)
				.Select(c => c.First())
				.Where(c => !string.IsNullOrWhiteSpace(c));

			tag.AddAttribute("class", string.Join(" ", distinctClasses));
		}

		public static void AddData(
			this ITag tag,
			string key,
			string value)
		{
			if (string.IsNullOrWhiteSpace(key))
				throw new ArgumentException();
			
			tag.AddAttribute($"data-{key}", value);
		}

		public static void AddTitle(
			this ITag tag, 
			string title)
		{
			if (string.IsNullOrWhiteSpace(title))
				throw new ArgumentException();

			tag.AddAttribute("title", title);
		}

		// char utility methods for Id
		private static bool IsValidIdCharacter(
			this char c)
		{
			return c.IsLetter()
				|| c.IsDigit()
				|| c.IsAllowedSpecialCharacter();
		}

		private static bool IsLetter(
			this char c)
		{
			return 'A' <= c && c <= 'Z'
				|| 'a' <= c && c <= 'z';
		}

		private static bool IsDigit(
			this char c)
		{
			return '0' <= c && c <= '9';
		}

		private static bool IsAllowedSpecialCharacter(
			this char c)
		{
			switch (c)
			{
				case '-':
				case '_':
				case ':':
					// '.' character is not allowed here!
					return true;

				default:
					return false;
			}
		}
	}
}