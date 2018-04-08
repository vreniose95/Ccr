using System;
using System.Collections.Generic;
using System.Linq;
using Ccr.Core.Extensions;

namespace Ccr.Core.Helpers
{
	public class StringComparisonSet
	{
		private readonly StringComparison _caseSensitiveComparison;
		private readonly StringComparison _caseInsensitiveComparison;


		public ComparisonType ComparisonType { get; }

		public StringComparison CaseSensitiveComparison
		{
			get => _caseSensitiveComparison;
		}

		public StringComparison CaseInsensitiveComparison
		{
			get => _caseInsensitiveComparison;
		}



		private static IReadOnlyDictionary<ComparisonType, StringComparisonSet> _comparisonSets;

		public static IReadOnlyDictionary<ComparisonType, StringComparisonSet> ComparisonSets
		{
			get
			{
				if (_comparisonSets == null)
				{
					var comparisonSetTypes = EnumExtensions.GetValues<ComparisonType>();
					_comparisonSets = comparisonSetTypes
						.ToDictionary(
							comparisonType => comparisonType,
							comparisonType => new StringComparisonSet(comparisonType));
				}
				return _comparisonSets;
			}
		}


		public StringComparisonSet(
			ComparisonType comparisonType)
		{
			ComparisonType = comparisonType;

			getStringComparisonsForType(
				comparisonType,
				out _caseSensitiveComparison,
				out _caseInsensitiveComparison);
		}


		public StringComparison GetComparisonOption(
			bool _isCaseSensitive)
		{
			return _isCaseSensitive
				? _caseSensitiveComparison
				: _caseInsensitiveComparison;
		}



		private static void getStringComparisonsForType(
			ComparisonType comparisonType,
			out StringComparison caseSensitiveComparison,
			out StringComparison caseInsensitiveComparison)
		{
			var comparisonIndex = (int)comparisonType * 2;

			caseSensitiveComparison = (StringComparison)comparisonIndex;
			caseInsensitiveComparison = (StringComparison)comparisonIndex + 1;
		}




	}
}