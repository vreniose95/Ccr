using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;

namespace Ccr.Xaml.Infrastructure
{
  public class MarkupSingleton : MarkupExtension
  {
    private static readonly Dictionary<Type, object> cache = new Dictionary<Type, object>();


    public override object ProvideValue(IServiceProvider serviceProvider)
    {
      var type = GetType();
      if (!cache.ContainsKey(type))
      {
        var constructors = type.GetConstructors();
        var instance = constructors.First().Invoke(null);
        cache.Add(type, instance);
      }
      return cache[type];
    }

    public static T GetInstance<T>()
      where T 
       : MarkupSingleton
    {
      return (T)GetInstanceImpl(typeof(T));
    }

    protected static object GetInstanceImpl(Type type)
    {
      if (!cache.ContainsKey(type))
      {
        var constructors = type.GetConstructors();
        var instance = constructors.First().Invoke(null);
        cache.Add(type, instance);
      }
      return cache[type];
    }
  }
}

