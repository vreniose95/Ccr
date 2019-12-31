using Ccr.Html.Tags;
using System;
using System.Collections.Generic;
using System.Text;
using Ccr.Html.Attributes.Extensions;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Builders
{
	public abstract class HtmlBuilder
	{
		private readonly List<Tag> _storedTags;


		public static HtmlBuilder<Tag, HtmlBuilder> Tag
		{
			get => new HtmlBuilder<Tag, HtmlBuilder>(null, null);
		}

		protected HtmlBuilder()
		{
			_storedTags = new List<Tag>();
		}


		protected void StoreTag(Tag tag)
		{
			_storedTags.Add(tag);
		}

		public sealed override string ToString()
		{
			var sb = new StringBuilder();
			_storedTags.ForEach(t => sb = t.Render(sb));
			return sb.ToString();
		}
	}


	public class HtmlBuilder<CurrentTagType, ParentBuilderType>
		: HtmlBuilder
			where CurrentTagType 
				: Tag
			where ParentBuilderType 
				: HtmlBuilder
	{
		private readonly ParentBuilderType _parentTag;


		public CurrentTagType CurrentTag { get; }


		internal HtmlBuilder(
			CurrentTagType currentTag, 
			ParentBuilderType parentTag) 
		{
			CurrentTag = currentTag;
			_parentTag = parentTag;
		}


		public virtual HtmlBuilder<T, 
			HtmlBuilder<CurrentTagType, ParentBuilderType>> StoreTag<T>(T tag) 
				where T
					: Tag
		{
			base.StoreTag(tag);

			if (_parentTag != null)
				CurrentTag.AddInnerHtml(tag);

			return new HtmlBuilder<T,
				HtmlBuilder<CurrentTagType, ParentBuilderType>>(tag, this);
		}

		public virtual ParentBuilderType End()
		{
			if (_parentTag == null)
				throw new NullReferenceException();

			return _parentTag;
		}

		public virtual HtmlBuilder<Tag, HtmlBuilder> EndAll()
		{
			// hack to avoid generic types checking
			dynamic x = _parentTag;
			while (x != null)
			{
				x = x.End();
			}
			return x;
		}

		public virtual HtmlBuilder<CurrentTagType, ParentBuilderType> InnerHTML(
			params Tag[] innerHtml)
		{
			CurrentTag.AddInnerHtml(innerHtml);
			return this;
		}

		public virtual HtmlBuilder<CurrentTagType, ParentBuilderType> InnerText(
			string text)
		{
			CurrentTag.AddInnerHtml(new Text(text));
			return this;
		}

		public virtual HtmlBuilder<CurrentTagType, ParentBuilderType> Class(
			params string[] classes)
		{
			CurrentTag.AddClasses(classes);
			return this;
		}

		public virtual HtmlBuilder<CurrentTagType, ParentBuilderType> Id(
			string id)
		{
			CurrentTag.AddId(id);
			return this;
		}

		public virtual HtmlBuilder<CurrentTagType, ParentBuilderType> Data(
			string key, string value)
		{
			CurrentTag.AddData(key, value);
			return this;
		}

		public virtual HtmlBuilder<CurrentTagType, ParentBuilderType> Title(
			string title)
		{
			CurrentTag.AddTitle(title);
			return this;
		}
	}
}
