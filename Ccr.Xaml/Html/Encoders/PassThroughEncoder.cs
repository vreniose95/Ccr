namespace Ccr.Html.Encoders
{
	public class PassThroughEncoder : IStringEncoder
	{
		public string Encode(string original)
		{
			return original;
		}
	}
}