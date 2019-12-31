using System;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Xaml.LogicalTree.Propogation
{
  /// <summary>
  ///   Represents one Dictionry Scope's node name within the context of 
  ///   a <see cref="ScopedResourceKey"/> object
  /// </summary>
  public class ResourceScopePart
  {
    [NotNull]
    private readonly string _scopeAccessorKey;

    /// <summary>
    ///   Creates a new instance of the <see cref="ResourceScopePart"/>
    ///   with the specified <paramref name="scopeAccessorKey"/> designating 
    ///   a string path segment that can be used to resolve the deferred 
    ///   inner layer context objects recursively.
    /// </summary>
    /// <param name="scopeAccessorKey">
    ///   The string path segment that can be used to resolve the deferred
    ///   inner layer context objects recursively. This value cannot be null.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///   Throws when <paramref name="scopeAccessorKey"/> is <see langword="null"/>
    /// </exception>
    /// <exception cref="ArgumentException">
    ///   Throws when <paramref name="scopeAccessorKey"/> trimmed of all leading and 
    ///   trailing whitespace characters, and converted to pascal case (using
    ///   the <see cref="StringExtensions.ToPascalCase"/> entension method) 
    ///   returns <see langword="null"/> or a whitespace character.
    /// </exception>
    public ResourceScopePart(
      [NotNull] string scopeAccessorKey)
    {
      scopeAccessorKey.IsNotNull(nameof(scopeAccessorKey));

      scopeAccessorKey = scopeAccessorKey
        .Trim()
        .ToPascalCase();

      if (scopeAccessorKey.IsNullOrWhiteSpace())
        throw new ArgumentException(
          $"The parameter \'{nameof(scopeAccessorKey)}\' is not " +
          $"valid, as it cannot be \'null\' or whitespace.");

      _scopeAccessorKey = scopeAccessorKey;
    }

    /// <summary>
    ///   Returns the name of the Scope Accessor Key as a <see cref="string"/>.
    /// </summary>
    /// <returns>
    ///   The name of the Scope Accessor Key as a <see cref="string"/>.
    /// </returns>
    public override string ToString()
    {
      return _scopeAccessorKey;
    }
  }
}