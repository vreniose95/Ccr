using NUnit.Framework;

namespace Ccr.Algorithms.Tests
{
	[TestFixture]
	public class StringAlgorithmTests
	{
		[Test]
		[TestCase("Appended Characters", "Appended Characte.r.s", 2)]
		[TestCase("Differing", "Information", 7)]
		[TestCase("The Same", "The Same", 6)]
		[TestCase("CASING test", "casing test", 6)]
		[TestCase("abcd efgh", "bcde fghi", 4)]
		[TestCase("swapped characters", "sawpped chraacters", 4)]
		public void LevenshteinDistanceTests(
			string string1, 
			string string2, 
			int expected)
		{
			var distance = 
				StringAlgorithms.LevenshteinDistance(
					string1, string2);

			Assert.AreEqual(distance, expected);
		}

		[Test]
		[TestCase("Appended Characters", "Appended Characte.r.s", 2)]
		[TestCase("Differing", "Information", 7)]
		[TestCase("The Same", "The Same", 6)]
		[TestCase("CASING test", "casing test", 6)]
		[TestCase("abcd efgh", "bcde fghi", 4)]
		[TestCase("swapped characters", "sawpped chraacters", 4)]
		public void LevenshteinDistanceVersion2Tests(
			string string1,
			string string2,
			int expected)
		{
			var distance =
				StringAlgorithms.LevenshteinDistanceVersion2(
					string1, string2);

			Assert.AreEqual(distance, expected);
		}


		[Test]
		[TestCase("Appended Characters", "Appended Characte.r.s", 2)]
		[TestCase("Differing", "Information", 7)]
		[TestCase("The Same", "The Same", 6)]
		[TestCase("CASING test", "casing test", 6)]
		[TestCase("abcd efgh", "bcde fghi", 4)]
		[TestCase("swapped characters", "sawpped chraacters", 4)]
		public void DamerauLevenshteinDistanceTests(
			string string1,
			string string2,
			int expected)
		{
			var distance =
				StringAlgorithms.DamerauLevenshteinDistance(
					string1, string2);

			Assert.AreEqual(distance, expected);
		}

	}
}
