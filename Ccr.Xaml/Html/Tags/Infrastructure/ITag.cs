using System.Collections.Generic;
using Ccr.Html.Encoders;

namespace Ccr.Html.Tags.Infrastructure
{
	public interface ITag : IInnerHtml
	{
		string TagName { get; }

		List<IInnerHtml> Content { get; }

		IDictionary<string, string> Attributes { get; }

		TagRenderMode TagRenderMode { get; }


		void AddAttribute(
			string key, 
			string value = null, 
			IStringEncoder encoder = null);
	}
}