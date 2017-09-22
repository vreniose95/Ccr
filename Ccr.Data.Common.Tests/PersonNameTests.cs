using Ccr.Data.Common.Constructs;
using NUnit.Framework;

namespace Ccr.Data.Common.Tests
{
	[TestFixture]
	public class PersonNameTests
	{
		//[Test]
		//[TestCase("Prof. Jordan B. Peterson, PhD.", "HP. Fn M. Ln, P.")]
		//public void ParseExactTests(
		//	string str,
		//	string format)
		//{
			
		//}
		[Test]
		[TestCase("HP. Fn M. Ln, P.")]
		[TestCase("Ln, F. Mn")]
		[TestCase("Ln, Fn M.")]
		public void ParseCustomFormatTests(
			string format)
		{
			var pnString = PersonName
				.__PNString.Parse(format);

			foreach (var token in pnString.Tokens)
			{
				
			}

		}


	}
}
