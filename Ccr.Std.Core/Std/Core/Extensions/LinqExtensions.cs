using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Ccr.Std.Core.Extensions
{
  /// <summary>
  ///   Extension methods for Linq, having <see cref="IEnumerable{T}"/> subjects.
  /// </summary>
  public static class LinqExtensions
  {
    /// <summary>
    ///   Iterates over the <paramref name="this"/> <see cref="IEnumerable{TValue}"/> object's 
    ///   members, preforming the <see cref="Action{TValue}"/> action provided by the 
    ///   <paramref name="action"/> parameter on each element.
    /// </summary>
    /// <typeparam name="TValue">
    ///   The member type of the <see cref="IEnumerable{TValue}"/> subject.
    /// </typeparam>
    /// <param name="this">
    ///   The <see cref="IEnumerable{TValue}"/> subject instance in which to perform the iteration 
    ///   and provided <paramref name="action"/> upon.
    /// </param>
    /// <param name="action">
    ///   The <see cref="Action{TValue}"/> action in which to execute on each of the 
    ///   <paramref name="this"/> subject instance's members.
    /// </param>
    public static void ForEach<TValue>(
      [NotNull] this IEnumerable<TValue> @this,
      [NotNull] Action<TValue> action)
    {
      @this.IsNotNull(nameof(@this));
      action.IsNotNull(nameof(action));

      foreach (var item in @this)
      {
        action(item);
      }
    }

  }
}
