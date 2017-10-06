using System.Collections.Generic;
using System.Linq;

namespace Ccr.Core.Assurance
{
	public class StringComparatorContains
		: EqualityComparer<string>
	{
		public override bool Equals(string x, string y)
		{
			return x.Contains(y);
		}

		public override int GetHashCode(string obj)
		{
			throw new System.NotImplementedException();
		}
	}
	public class Text
	{
		public void test()
		{
			var x = new List<string>()
			{
				"all",
				"that",
				"shite"
			};
			x.Contains("a", new StringComparatorContains());
		}

	}
}
