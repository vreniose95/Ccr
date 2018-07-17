using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;

namespace Ccr.Xaml.Infrastructure
{
  public class MarkupSingleton 
    : MarkupExtension
  {
    private static readonly Dictionary<Type, object> _cache 
      = new Dictionary<Type, object>();


    public override object ProvideValue(
      IServiceProvider serviceProvider)
    {
      var type = GetType();
      if (!_cache.ContainsKey(type))
      {
        var constructors = type.GetConstructors();
        var instance = constructors
          .First()
          .Invoke(
            null);

        _cache.Add(type, instance);
      }
      return _cache[type];
    }

    public static T GetInstance<T>()
      where T 
       : MarkupSingleton
    {
      return (T)GetInstanceImpl(
        typeof(T));
    }

    protected static object GetInstanceImpl(
      Type type)
    {
      if (!_cache.ContainsKey(type))
      {
        var constructors = type.GetConstructors();
        var instance = constructors
          .First()
          .Invoke(
            null);

        _cache.Add(
          type, 
          instance);
      }
      return _cache[type];
    }
  }
}

