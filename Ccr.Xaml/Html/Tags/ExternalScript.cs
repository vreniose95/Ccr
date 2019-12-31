using Ccr.Html.Attributes;
using Ccr.Html.Attributes.Traits.Interfaces;
using System;

namespace Ccr.Html.Tags
{
	public class ExternalScript 
		: Script,
			ISupportsCharsetAttribute
	{
		public ExternalScript(
			string src)
		{
			if (string.IsNullOrWhiteSpace(src))
				throw new ArgumentException(); 

			AddAttribute("src", src);
		}

		
		public void AddExecution(
			Execution execution)
		{
			switch (execution)
			{
				case Execution.Async:
					AddAttribute("async", "async");
					break;

				case Execution.Defer:
					AddAttribute("defer", "defer");
					break;
			}
		}
	}
}