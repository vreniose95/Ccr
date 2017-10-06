using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Ccr.Core.Extensions
{
	public static class LinqExtensions
	{
		public static void ForEach<TValue>(
			[NotNull] this IEnumerable<TValue> @this,
			[NotNull] Action<TValue> action)
		{
			@this.IsNotNull(nameof(@this));
			action.IsNotNull(nameof(action));

			foreach (var item in @this)
				action(item);
		}
	}
}
