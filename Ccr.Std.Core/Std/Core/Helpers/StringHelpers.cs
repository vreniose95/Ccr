using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ccr.Std.Core.Helpers
{
	public static class StringHelpers
	{
		internal static readonly ReadOnlyDictionary<StringComparison, StringComparer> ComparisonMap
			= new ReadOnlyDictionary<StringComparison, StringComparer>(
					new Dictionary<StringComparison, StringComparer>
					{
						[StringComparison.CurrentCulture] = StringComparer.Ordinal,
						[StringComparison.CurrentCultureIgnoreCase] = StringComparer.Ordinal,
						[StringComparison.InvariantCulture] = StringComparer.InvariantCulture,
						[StringComparison.InvariantCultureIgnoreCase] = StringComparer.InvariantCultureIgnoreCase,
						[StringComparison.Ordinal] = StringComparer.Ordinal,
						[StringComparison.OrdinalIgnoreCase] = StringComparer.OrdinalIgnoreCase
					});


		private static StringComparison _getStringComparison(
			bool ignoreCase,
			ComparisonType comparisonType)
		{
			var typeIndex = (int)comparisonType;
			var caseSensitivityIndex = ignoreCase ? 1 : 0;
			var comparisonIndex = typeIndex * 2 + caseSensitivityIndex;
			var stringComparison = (StringComparison)comparisonIndex;

			return stringComparison;
		}

		
		public static StringComparison GetStringComparison(
			bool ignoreCase = false,
			ComparisonType comparisonType = ComparisonType.Current)
		{
			return _getStringComparison(
				ignoreCase,
				comparisonType);
		}
	}
}