using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Ccr.Std.Core.TypeSystemInfo.IntegralTypes;

// ReSharper disable ArrangeAccessorOwnerBody

namespace Ccr.Std.Core.TypeSystemInfo
{
  //public class TypeInfoContext<TValueType>
  //{
  //  public TypeInfoContext(
  //    TValueType[])
  //}
  //public class NamedGroup<TValue>
  //  : IGrouping<string, TValue>,
  //    IList<TValue>
  //{
  //  public string Key
  //  {
  //    get => Key;
  //  }

  //  public Tf


  //  public IEnumerator<TValue> GetEnumerator()
  //  {
  //    return this.AsEnumerable().GetEnumerator();
  //  }

  //  IEnumerator IEnumerable.GetEnumerator()
  //  {
  //    return GetEnumerator();
  //  }


  //}
  public class TypeReference
  {
    //internal static IEnumerable<Type> Types =
    //{

    //};

    private static readonly Type[] _unsortedTypesArray =
    {
      typeof(bool),
      typeof(char),
      typeof(string)
    };

    internal static readonly Type[] _integralTypesArray =
    {
      typeof(sbyte),
      typeof(byte),
      typeof(short),
      typeof(ushort),
      typeof(int),
      typeof(uint),
      typeof(long),
      typeof(ulong)
    };

    internal static readonly Type[] _nonIntegralTypesArray =
    {
      typeof(float),
      typeof(double),
      typeof(decimal)
    };


    public static bool IsIntegralType(
      Type type)
    {
      return _integralTypesArray
        .Contains(type);
    }
    public static bool IsNonIntegralType(
      Type type)
    {
      return _nonIntegralTypesArray
        .Contains(type);
    }



    private static ReadOnlyCollection<Type> _unsortedTypes;
    public static IReadOnlyCollection<Type> UnsortedTypes
    {
      get => _unsortedTypes ?? (
               _unsortedTypes
                 = new ReadOnlyCollection<Type>(
                   _unsortedTypesArray));
    }


    private static ReadOnlyCollection<Type> _integralTypes;
    public static IReadOnlyCollection<Type> IntegralTypes
    {
      get => _integralTypes ?? (
               _integralTypes
                 = new ReadOnlyCollection<Type>(
                   _integralTypesArray));
    }

    private static ReadOnlyCollection<Type> _nonIntegralTypes;
    public static IReadOnlyCollection<Type> NonIntegralTypes
    {
      get => _nonIntegralTypes ?? (
               _nonIntegralTypes
                 = new ReadOnlyCollection<Type>(
                   _integralTypesArray));
    }

    private static ReadOnlyCollection<Type> _builtInTypes;
    public static IReadOnlyCollection<Type> BuiltInTypes
    {
      get => _builtInTypes ?? (
               _builtInTypes
                 = new ReadOnlyCollection<Type>(
                   _unsortedTypesArray
                     .Concat(
                       _integralTypesArray)
                     .Concat(
                       _nonIntegralTypesArray)
                     .ToArray()));
    }


    private static ReadOnlyCollection<IntegralTypeInfo> _referenceTypeInfos;
    public static IReadOnlyCollection<IntegralTypeInfo> ReferenceTypeInfos
    {
      get => _referenceTypeInfos ?? (
               _referenceTypeInfos
                 = new ReadOnlyCollection<IntegralTypeInfo>(
                   IntegralTypes
                     .Select(IntegralTypeBuilder.Build)
                     .ToArray()));
    }


    private static ReadOnlyCollection<IntegralTypeInfo> _integralTypeInfos;
    public static IReadOnlyCollection<IntegralTypeInfo> IntegralTypeInfos
    {
      get => _integralTypeInfos ?? (
               _integralTypeInfos
                 = new ReadOnlyCollection<IntegralTypeInfo>(
                   IntegralTypes
                     .Select(IntegralTypeBuilder.Build)
                     .ToArray()));
    }


    public static BuiltInTypeInfo GetBuiltInTypeInfo()
    {
     
      throw new NotImplementedException();
    }

}
}
