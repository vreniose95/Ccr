using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace Ccr.Std.Core.Extensions
{
  public static class NullableExtensions
  {
    private static readonly IDictionary<Type, object> _defaultTypeInstanceMap
      = new Dictionary<Type, object>
      {
        // ReSharper disable BuiltInTypeReferenceStyle
        [typeof(Boolean)] = default(Boolean),
        [typeof(Decimal)] = default(Decimal),
        [typeof(Double)] = default(Double),
        [typeof(Int16)] = default(Int16),
        [typeof(Int32)] = default(Int32),
        [typeof(Int64)] = default(Int64),
        [typeof(SByte)] = default(SByte),
        [typeof(Single)] = default(Single),
        [typeof(UInt16)] = default(UInt16),
        [typeof(UInt32)] = default(UInt32),
        [typeof(UInt64)] = default(UInt64)
        // ReSharper restore BuiltInTypeReferenceStyle
      };

    //public static object CreateDefaultForType(
    //  this Type @this)
    //{
    //  if (@this.IsGenericOf(typeof(Nullable<>)))
    //  {
    //    @this = @this
    //            .GetGenericArguments()
    //            .Single();
    //  }

    //  if (!_defaultTypeInstanceMap.TryGetValue(
    //    @this,
    //    out var typeInstance))
    //  {
    //    return typeInstance;
    //  }

    //  var _default = @this.GetDefaultValue();
    //  _defaultTypeInstanceMap.Add(
    //    @this,
    //    _default);

    //  return _default;
    //}
    public static object CreateDefaultValue(
      [NotNull] this Type @this)
    {
      @this.IsNotNull(nameof(@this));

      if (!@this.IsValueType)
        return null;

      return Activator.CreateInstance(@this);
    }
  }
}
