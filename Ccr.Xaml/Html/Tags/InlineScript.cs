using Ccr.Html.Encoders;

namespace Ccr.Html.Tags
{
	public class InlineScript 
		: Script
	{
		public InlineScript(
			string script) 
			: base()
		{
			Content.Add(
				new Text(script, new PassThroughEncoder()));
		}
	}
}