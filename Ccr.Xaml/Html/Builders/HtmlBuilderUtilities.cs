using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Builders
{
	public static class HtmlBuilderUtilities
	{
		// Todo: implement restrictions in tag usages
		public static HtmlBuilder<T, HtmlBuilder<X, Y>> AddTagIfAllowed<T, X, Y>(
			this HtmlBuilder<X, Y> builder, 
			T tagToAdd)
				where T : Tag
				where X : Tag
				where Y : HtmlBuilder
		{
			if (builder.CurrentTag == null)
				return StoreTag(builder, tagToAdd);
			
			//if tag is inside something
			return StoreTag(builder, tagToAdd);
		}

		private static HtmlBuilder<T, HtmlBuilder<X, Y>> StoreTag<T, X, Y>(
			HtmlBuilder<X, Y> builder, 
			T tagToAdd)
				where T : Tag
				where X : Tag
				where Y : HtmlBuilder
		{
			return builder.StoreTag(tagToAdd);
		}
	}
}