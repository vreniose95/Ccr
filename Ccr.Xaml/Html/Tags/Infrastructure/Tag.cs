using System;
using System.Collections.Generic;
using System.Text;
using Ccr.Html.Encoders;
using Ccr.Html.Extensions;

namespace Ccr.Html.Tags.Infrastructure
{
	public abstract class Tag 
		: ITag
	{
		private static readonly IStringEncoder DefaultAttributeEncoder = new AttributeEncoder();


		public string TagName { get; private set; }

		public List<IInnerHtml> Content { get; private set; }

		public IDictionary<string, string> Attributes { get; private set; }

		public abstract TagRenderMode TagRenderMode { get; }


		protected Tag(
			string tagName)
		{
			if (string.IsNullOrWhiteSpace(tagName))
				throw new ArgumentException(
					ExceptionMessages.NotNullOrWhitespace("tagName"));
			
			TagName = tagName;
			Content = new List<IInnerHtml>();
			Attributes = new SortedDictionary<string, string>(
				StringComparer.Ordinal);
		}

		
		public virtual void AddInnerHtml(
			params IInnerHtml[] html)
		{
			Content.AddRange(html);
		}

		public virtual void AddAttribute(
			string key, 
			string value = null, 
			IStringEncoder encoder = null)
		{
			if (string.IsNullOrWhiteSpace(key))
				throw new ArgumentException(
					ExceptionMessages.NotNullOrWhitespace("key"));
			
			Attributes[key] = (encoder ?? DefaultAttributeEncoder)
				.Encode(value);
		}

		public StringBuilder Render(
			StringBuilder stringBuilder)
		{
			stringBuilder
				.Append('<')
				.Append(TagName);

			foreach (var attribute in Attributes)
			{
				stringBuilder
					.Append(' ')
					.Append(attribute.Key);

				if (attribute.Value != null)
				{
					stringBuilder
						.Append("=\"")
						.Append(attribute.Value)
						.Append('"');
				}
			}
			stringBuilder.Append('>');

			if (TagRenderMode == TagRenderMode.Normal)
			{
				Content.ForEach(c => { stringBuilder = c.Render(stringBuilder); });
				stringBuilder
					.Append("</")
					.Append(TagName)
					.Append('>');
			}
			return stringBuilder;
		}

		public sealed override string ToString()
		{
			return Render(new StringBuilder()).ToString();
		}
	}
}