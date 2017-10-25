using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;

namespace Ccr.Xaml.LogicalTree.Propogation
{
  /// <summary>
  ///   Represents the path object's Key Property
  /// </summary>
  public class ScopedResourceKey
  {
    private readonly List<ResourceScopePart> _scopeAccessors;


    private ScopedResourceKey(
      params string[] accessorKeys)
    {
      _scopeAccessors = accessorKeys
        .Select(
          t => new ResourceScopePart(t))
        .ToList();
    }


    public static ScopedResourceKey Parse(
      string fullPathName)
    {
      var componentScopeKeyStrings = fullPathName
        .Split('.')
        .ToArray();

      return new ScopedResourceKey(
        componentScopeKeyStrings);
    }


    public void AppendAccessorKeys(
      ScopedResourceKey appendAccessors)
    {
      _scopeAccessors.AddRange(appendAccessors._scopeAccessors);
    }

    public void AppendAccessorKeyNames(
      params string[] accessorNames)
    {
      var accessor = new ScopedResourceKey(accessorNames);
      AppendAccessorKeys(accessor);
    }

    public override string ToString()
    {
      return string.Join(".",
        _scopeAccessors
          .Select(
            t => $"{t}"));
    }
  }
}
