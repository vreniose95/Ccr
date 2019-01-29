using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using Ccr.Core.Extensions;
using Ccr.Core.Helpers;
using JetBrains.Annotations;

namespace Ccr.PresentationCore.Collections
{
  //-------------------------------------------------------------------------------------------
  //TODO BUG MAJOR STACK OVERFLOW EXCEPTION GOING ON WITH CIRCULAR EQUALITY ==/EQUALS WITH NULL
  //-------------------------------------------------------------------------------------------

  /// <summary>
  ///   Base class for <see cref="ValueEnum{TValue}"/>, a method of creating strongly typed 
  ///   sets of named values of types, not limited to integral data types. 
  /// </summary>
  /// <remarks>
  ///   You cannot create instance of this type because it is <see langword="abstract"/>. On 
  ///   the implementation class, use the derived class <see cref="ValueEnum{TValue}"/> class
  ///   to directly implement from.
  /// </remarks>
  public abstract class ValueEnum
  {
    #region Consts

    /// <summary>
    ///   The <see cref="BindingFlags"/> required for discovering public static members 
    ///   declared in implementation classes.
    /// </summary>
    protected const BindingFlags _discoveryFlags =
      BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly;

    #endregion


    #region Fields

    /// <summary>
    ///   The backing value for the <see cref="EnumerationCache"/> singleton-style property. 
    /// </summary>
    private static readonly Dictionary<Type, ValueEnum[]> enumerationCache
      = new Dictionary<Type, ValueEnum[]>();

    /// <summary>
    ///   A singleton map of <see cref="ValueEnum{TValue}"/> types and their member declaration 
    ///   as arrays discovered through a first-pass-only <see cref="System.Reflection"/> scan.
    /// </summary>
    protected static IReadOnlyDictionary<Type, ValueEnum[]> EnumerationCache
    {
      // ReSharper disable once ArrangeAccessorOwnerBody
      get => enumerationCache;
    }

    #endregion


    #region Properies

    /// <summary>
    ///   The boxed value of the <see cref="ValueEnum"/> member declaration, as protected.
    /// </summary>
    [NotNull]
    protected object ValueBase { get; }

    /// <summary>
    ///   The string name of the <see cref="ValueEnum"/> member declaration. This value is auto
    ///   provided to the constructor through the constructor parameter argument attribute <see 
    ///   cref="CallerMemberNameAttribute"/>.
    /// </summary>
    [NotNull]
    public string Name { get; }

    /// <summary>
    ///   The line number of the <see cref="ValueEnum"/> member declaration. This value is auto
    ///   provided to the constructor through the constructor parameter argument attribute <see
    ///   cref="CallerLineNumberAttribute"/>
    /// </summary>
    public int LineNumber { get; }

    /// <summary>
    ///   The value type of the <see cref="ValueEnum"/> member declaration.
    /// </summary>
    [NotNull]
    public abstract Type ValueType { get; }

    #endregion


    #region Constructors
    /// <summary>
    ///   Creates an instance of a <see cref="ValueEnum"/> member declaration. 
    /// </summary>
    /// <param name="value">
    ///   The backing value of the member declaration boxed in an <see cref="object"/>
    /// </param>
    /// <param name="name">
    ///   The string name of the <see cref="ValueEnum"/> member declaration. This value is 
    ///   provided to the constructor automatically through the CompilerService attribute 
    ///   <see cref="CallerMemberNameAttribute"/>.
    /// </param>
    /// <param name="lineNumber">
    ///   The line number of the <see cref="ValueEnum"/> member declaration. This value is 
    ///   provided to the constructor automatically through the CompilerService attribute 
    ///   <see cref="CallerLineNumberAttribute"/>.
    /// </param>
    /// <remarks>
    ///   This is a protected constructor and should be called through a chained constructor.
    /// </remarks>
    protected ValueEnum(
      [NotNull] object value,
      [NotNull] string name,
      int lineNumber)
    {
      value.IsNotNull(nameof(value));
      value.IsNotNull(nameof(name));

      ValueBase = value;
      Name = name;
      LineNumber = lineNumber;
    }

    #endregion


    #region Methods
    /// <summary>
    ///   Checks if the provided <paramref name="type"/> is a <see cref="ValueEnum{TValue}"/>
    ///   <see cref="Type"/> contains a defined <see cref="ValueEnum"/> member declaration with
    ///   the name provided by the <paramref name="name"/> argument.    
    /// </summary>
    /// <param name="type">
    ///   The <see cref="Type"/> of the <see cref="ValueEnum{TValue}"/> container class.
    /// </param>
    /// <param name="name">
    ///   The <see cref="ValueEnum{TValue}"/> declaration member name to search for.
    /// </param>
    /// <param name="ignoreCase">
    ///   An optional parameter that if set to <set langword="true"/>, will use a case-
    ///   insensitive <see cref="StringComparison"/> as the comparator against the <see 
    ///   cref="ValueEnum"/> member identifiers.
    /// </param>
    /// <returns>
    ///   A <see langword="bool"/> value indicating whether or not the class deriving from <see
    ///   cref="ValueEnum{TValue}"/> has an <see cref="ValueEnum"/> member identifier matching 
    ///   the provided <paramref name="name"/>, taking into account the optional <paramref 
    ///   name="ignoreCase"/> case sensitivity option.
    /// </returns>
    public static bool IsDefined(
      [NotNull] Type type,
      [NotNull] string name,
      bool ignoreCase = false)
    {
      type.IsNotNull(nameof(type));
      name.IsNotNull(nameof(name));

      var stringComparison = ignoreCase
        ? StringComparison.CurrentCulture
        : StringComparison.CurrentCultureIgnoreCase;

      return ToArrayBase(type)
        .Any(t => t.Name.Equals(name, stringComparison));
    }


    /// <summary>
    ///   Checks if the a <see cref="ValueEnum{TValue}"/> container class contained a 
    ///   <typeparamref name="TEnum"/> declaration contains a defined <see cref="ValueEnum"/> 
    ///   member declaration with the name specified by the <paramref name="name"/> argument.   
    /// </summary>
    /// <typeparam name="TEnum">
    ///   The <typeparamref name="TEnum"/> class reference.
    /// </typeparam>
    /// <param name="name">
    ///   The <see cref="ValueEnum"/> member declaration member identifier to search for.
    /// </param>
    /// <param name="ignoreCase">
    ///   An optional parameter that if set to <see langword="true"/>, will use a case-
    ///   insensitive <see cref="StringComparison"/> as a comparator against the <see 
    ///   cref="ValueEnum"/> container member identifiers.
    /// </param>
    /// <returns>
    ///   A <see langword="bool"/> value indicating whether or not the class deriving from <see
    ///   cref="ValueEnum{TValue}"/> has an <see cref="ValueEnum"/> member identifier matching 
    ///   the provided <paramref name="name"/>, taking into account the optional <paramref 
    ///   name="ignoreCase"/> case sensitivity option.
    /// </returns>
    public static bool IsDefined<TEnum>(
      [NotNull] string name,
      bool ignoreCase = false)
      where TEnum
      : ValueEnum
    {
      name.IsNotNull(nameof(name));

      return IsDefined(
        typeof(TEnum),
        name,
        ignoreCase);
    }


    /// <summary>
    ///   Attempts to convert the <see cref="string"/> identifier of the <see cref="ValueEnum"/> 
    ///   to the instance of the member declaration. The return value indicates whether the 
    ///   conversion succeeded. The <paramref name="valueEnumInstance"/>, if successful, will 
    ///   contain the boxed value of the <see cref="ValueEnum{TValue}"/> parent class.
    /// </summary>
    /// <param name="valueEnumType">
    ///   The <see cref="Type"/> of the <see cref="ValueEnum{TValue}"/> declaration.
    /// </param>
    /// <param name="name">
    ///   The <see cref="ValueEnum{TValue}"/> member declaration member identifier to parse.
    /// </param>
    /// <param name="valueEnumInstance">
    ///   The returned instance of the member with the provided identifier name.
    /// </param>
    /// <returns>
    ///   A <see cref="bool"/> value indicating whether the conversion succeeded.
    /// </returns>
    public static bool TryParse(
      [NotNull] Type valueEnumType,
      [NotNull] string name,
      out ValueEnum valueEnumInstance)
    {
      valueEnumType.IsNotNull(nameof(valueEnumType));
      name.IsNotNull(nameof(name));

      return TryParse(
        valueEnumType,
        name,
        false,
        out valueEnumInstance);
    }
    
    /// <summary>
    ///   Attempts to convert the <see cref="string"/> name of the <see cref="ValueEnum"/> 
    ///   to the instance of the member declaration. The return value indicates whether the 
    ///   conversion succeeded. The <paramref name="valueEnumInstance"/>, if successful, will 
    ///   contain the boxed value of the <see cref="ValueEnum{TValue}"/> parent class.
    /// </summary>
    /// <param name="valueEnumType">
    ///   The <see cref="Type"/> of the <see cref="ValueEnum{TValue}"/> declaration.
    /// </param>
    /// <param name="name">
    ///   The <see cref="ValueEnum{TValue}"/> member declaration member identifier to parse.
    /// </param>
    /// <param name="ignoreCase">
    ///   An <see cref="bool"/> parameter that if set to <see langword="true"/>, will use a 
    ///   case-insensitive <see cref="StringComparison"/> as a comparator against the <see 
    ///   cref="ValueEnum"/> container member identifiers. This is not an optional property.
    /// </param>
    /// <param name="valueEnumInstance">
    ///   The returned instance of the member with the provided identifier name.
    /// </param>
    /// <returns>
    ///   A <see cref="bool"/> value indicating whether the conversion succeeded.
    /// </returns>
    public static bool TryParse(
      [NotNull] Type valueEnumType,
      [NotNull] string name,
      bool ignoreCase,
      out ValueEnum valueEnumInstance)
    {
      valueEnumType.IsNotNull(nameof(valueEnumType));
      name.IsNotNull(nameof(name));

      try
      {
        valueEnumInstance = Parse(valueEnumType, name, ignoreCase);
        return true;
      }
      catch (Exception ex)
        when (
          ex is ArgumentNullException ||
          ex is ArgumentException)
      {
        valueEnumInstance = default(ValueEnum);
        return false;
      }
    }


    /// <summary>
    ///   Gets the <see cref="ValueEnum"/> member declaration that matches the name specified 
    ///   by the <paramref name="name"/> argument provided by <see cref="ValueEnum{TValue}"/> 
    ///   in the inherited container class.
    /// </summary>
    /// <param name="valueEnumType">
    ///   The <see cref="Type"/> of the <see cref="ValueEnum{TValue}"/> declaration.
    /// </param>
    /// <param name="name">
    ///   The <see cref="ValueEnum{TValue}"/> member declaration member identifier to parse.
    /// </param>
    /// <param name="ignoreCase">
    ///   An <see cref="bool"/> parameter that if set to <see langword="true"/>, will use a 
    ///   case-insensitive <see cref="StringComparison"/> as a comparator against the <see 
    ///   cref="ValueEnum"/> container member identifiers. This is not an optional property.
    /// </param>
    /// <returns>
    ///   The <see cref="ValueEnum"/> member declaration instance associated with the provided 
    ///   identifier name. 
    /// </returns>
    public static ValueEnum Parse(
      [NotNull] Type valueEnumType,
      [NotNull] string name,
      bool ignoreCase = false)
    {
      valueEnumType.IsNotNull(nameof(valueEnumType));
      name.IsNotNull(nameof(name));

      //if (!typeof(ValueEnum<>).IsAssignableFrom(valueEnumType))
      if (valueEnumType.BaseType == null || !valueEnumType.BaseType.IsGenericOf(typeof(ValueEnum<>)))
        throw new ArgumentException(
          $"The specified {nameof(valueEnumType).SQuote()} parameter is invalid because it " +
          $"is not of the type {typeof(ValueEnum<>).FormatName().SQuote()}.",
          nameof(valueEnumType));

      var stringComparison = ignoreCase
        ? StringComparison.CurrentCulture
        : StringComparison.CurrentCultureIgnoreCase;

      var matchingValues = ToArrayBase(valueEnumType)
        .Where(t => t.Name.Equals(name, stringComparison))
        .ToArray();

      if (matchingValues.Length == 0)
        throw new ArgumentException(
          $"No {typeof(ValueEnum<>).FormatName().SQuote()} member declaration value could be " +
          $"found with the identifier name {name.SQuote()} in the type '{valueEnumType.Name}'.",
          nameof(name));

      if (matchingValues.Length >= 2)
        throw new ArgumentException(
          $"Multiple {typeof(ValueEnum<>).FormatName().SQuote()} member declared values were " +
          $"found with the identifier name {name.SQuote()} in the type '{valueEnumType.Name}'.",
          nameof(name));

      return matchingValues[0];
    }

    // TODO make sure this is not messed up
    /// <summary>
    ///   Gets the <see cref="ValueEnum"/> member declaration that matches the name specified 
    ///   by the <paramref name="name"/> argument provided by <see cref="ValueEnum{TValue}"/> 
    ///   in the inherited container class.
    /// </summary>
    /// <param name="propertySelector">
    ///   The <see cref="Type"/> of the <see cref="ValueEnum{TValue}"/> declaration.
    /// </param>
    /// <param name="value">
    ///   The <see cref="ValueEnum{TValue}"/> member declaration member identifier to parse.
    /// </param>
    /// <param name="ignoreCase">
    ///   An <see cref="bool"/> parameter that if set to <see langword="true"/>, will use a 
    ///   case-insensitive <see cref="StringComparison"/> as a comparator against the <see 
    ///   cref="ValueEnum"/> container member identifiers. This is not an optional property.
    /// </param>
    /// <returns>
    ///   The <see cref="ValueEnum"/> member declaration instance associated with the provided 
    ///   identifier name. 
    /// </returns>
    public static TValueEnum ParseSelect<TValueEnum, TProperty>(
      Expression<Func<TValueEnum, TProperty>> propertySelector,
      [NotNull] TProperty value,
      bool ignoreCase = false)
        where TValueEnum
          : ValueEnum
    {
      var valueEnumType = typeof(TValueEnum);

      valueEnumType.IsNotNull(nameof(valueEnumType));
      value.IsNotNull(nameof(value));

      //if (!typeof(ValueEnum<>).IsAssignableFrom(valueEnumType))
      if (valueEnumType.BaseType == null || !valueEnumType.BaseType.IsGenericOf(typeof(ValueEnum<>)))
        throw new ArgumentException(
          $"The specified {nameof(valueEnumType).SQuote()} parameter is invalid because it " +
          $"is not of the type {typeof(ValueEnum<>).FormatName().SQuote()}.",
          nameof(valueEnumType));

      //if (name.IsValidCSharpIdentifier())
      //  throw new ArgumentException(
      //    $"The specified {nameof(name).SQuote()} parameter is invalid because it does not " +
      //    $"constitute a valid identifier by C#'s language specifications on member identifier " +
      //    $"naming conventions.",
      //    nameof(name));

      TValueEnum[] matchingValues;

      if (typeof(TProperty) == typeof(string))
      {
        var stringComparison = ignoreCase
          ? StringComparison.CurrentCulture
          : StringComparison.CurrentCultureIgnoreCase;

        var func = propertySelector.Compile();

        matchingValues = ToArrayBase(valueEnumType)
          .Cast<TValueEnum>()
          .Where(
            t => EqualityComparer<string>.Default
              .Equals(
                func.Invoke(t).ToString().ToLower(),
                value.ToString().ToLower()))
          .ToArray();
      }
      else
      {
        var func = propertySelector.Compile();

        matchingValues = ToArrayBase(valueEnumType)
          .Cast<TValueEnum>()
          .Where(t => func.Invoke(t).Equals(value))
          .ToArray();
      }

      if (matchingValues.Length == 0)
        throw new ArgumentException(
          $"No {typeof(ValueEnum<>).FormatName().SQuote()} member declaration value could be " +
          $"found with the identifier value {value.ToString().SQuote()} in the type '{valueEnumType.Name}'.",
          nameof(value));

      if (matchingValues.Length >= 2)
        throw new ArgumentException(
          $"Multiple {typeof(ValueEnum<>).FormatName().SQuote()} member declared values were " +
          $"found with the identifier name {value.ToString().SQuote()} in the type '{valueEnumType.Name}'.",
          nameof(value));

      return matchingValues[0];
    }


    /// <summary>
    ///   Enumerates the <see cref="ValueEnum{TValue}"/> members of the type provided by the 
    ///   <typeparamref name="TEnum"/>, the container class inheriting the base type <see 
    ///   cref="ValueEnum{TValue}"/>.
    /// </summary>
    /// <typeparam name="TEnum">
    ///   The <see cref="Type"/> of the associated value of the <see cref="ValueEnum{TValue}"/>.
    /// </typeparam>
    /// <returns>
    ///   An IEnumerable of the <see langword="public"/> <see langword="static"/> defined fields
    ///   of the <see cref="ValueEnum{TEnum}"/> instances defined in the container enumeration 
    ///   class.
    /// </returns>
    public static IEnumerable<TEnum> Enumerate<TEnum>()
      where TEnum
        : ValueEnum
    {
      return ToArray<TEnum>();
    }


    /// <summary>
    ///   Converts the <see cref="ValueEnum{TValue}"/> container class specified by the 
    ///   <typeparamref name="TEnum"/>'s public, static declarations into to an Array of 
    ///   <typeparamref name="TEnum"/> object.
    /// </summary>
    /// <typeparam name="TEnum">
    ///   The <see cref="Type"/> of the array in which to enumerate.
    /// </typeparam>
    /// <returns>
    ///   Returns an array array of <see cref="TEnum"/> objects defined statically in the final 
    ///   implementation of the <see cref="ValueEnum{TValue}"/> container class.
    /// </returns>
    public static TEnum[] ToArray<TEnum>()
      where TEnum
      : ValueEnum
    {
      return ToArrayBase(typeof(TEnum))
        .Cast<TEnum>()
        .ToArray();
    }


    /// <summary>
    ///   Converts the <see cref="ValueEnum{TValue}"/> to a <see cref="IList{TEnum}"/>.
    /// </summary>
    /// <typeparam name="TEnum">
    ///   The <see cref="Type"/> of the array in which to enumerate. The <typeparamref 
    ///   name="TEnum"/> must implement <see cref="ValueEnum{TEnum}"/>.
    /// </typeparam>
    /// <returns>
    ///   Returns an <see cref="IList{TEnum}"/> of <see cref="TEnum"/> objects defined as
    ///   public static fields in the final implementation of the <see
    ///   cref="ValueEnum{TValue}"/> container class.
    /// </returns>
    public static IList<TEnum> ToList<TEnum>()
      where TEnum
      : ValueEnum
    {
      return ToArray<TEnum>()
        .ToList();
    }


    /// <summary>
    ///   The base method of <see cref="ToArray{TEnum}"/> in which the value of the <see 
    ///   cref="ValueEnum{TValue}"/> generic parameter is provided non-generically through the
    ///   <paramref name="type"/> parameter.
    /// </summary>
    /// <param name="type">
    ///   The <see cref="Type"/> in which the value of the super-class's <see 
    ///   cref="ValueEnum{TValue}"/>'s generic parameter is provided non-generically through the 
    ///   <paramref name="type"/> through a standard <see cref="Type"/> object.
    /// </param>
    /// <returns>
    ///   Returns the Array of the defined public static field definitions of the <see 
    ///   cref="ValueEnum{TValue}"/> boxed non-generically.
    /// </returns>
    public static ValueEnum[] ToArrayBase(
      [NotNull] Type type)
    {
      type.IsNotNull(nameof(type));

      if (!typeof(ValueEnum).IsAssignableFrom(type))
        throw new ArgumentException(
          $"Cannot enumerate the type {type.Name.SQuote()} because it does not implement " +
          $"the {typeof(ValueEnum).Name.SQuote()}.");

      if (EnumerationCache.TryGetValue(type, out var arrayBoxed))
        return arrayBoxed;

      var reflectedEnumeration
        = type
          .GetFields(_discoveryFlags)
          .Select(f => f.GetValue(null))
          .Cast<ValueEnum>()
          .ToArray();

      enumerationCache.Add(
        type,
        reflectedEnumeration);

      return reflectedEnumeration;
    }


    /// <summary>
    ///   Finds the <typeparamref name="TEnum"/> value with the matching associated value.
    /// </summary>
    /// <typeparam name="TEnum">
    ///   The <see cref="Type"/> of the array in which to enumerate. The <typeparamref 
    ///   name="TEnum"/> must implement <see cref="ValueEnum{TEnum}"/>.
    /// </typeparam>
    /// <param name="value">
    ///   The value in which to search the inner cached collection for.
    /// </param>
    /// <returns>
    ///   The <typeparamref name="TEnum"/> value definition with a matching provided <paramref 
    ///   name="value"/>
    /// </returns>
    public static TEnum FromValue<TEnum>(
      object value)
      where TEnum
        : ValueEnum
    {
      var matchingValues
        = ToArray<TEnum>()
          .Where(t => t.ValueBase.Equals(value))
          .ToArray();

      if (matchingValues.Length == 0)
        throw new ArgumentException(
          $"No public static {typeof(TEnum).Name.SQuote()} field values found from the base " +
          $"value {value.ToString().SQuote()} in the type \'{typeof(TEnum).Name}\'.");

      if (matchingValues.Length >= 2)
        throw new ArgumentException(
          $"Multiple public static {typeof(TEnum).Name.SQuote()} field values found with the " +
          $"base value {value.ToString().SQuote()} in the type \'{typeof(TEnum).Name}\'.");

      return matchingValues[0];
    }


    /// <summary>
    ///   Finds the <typeparamref name="TEnum"/> value with the matching associated name.
    /// </summary>
    /// <typeparam name="TEnum">
    ///   The <see cref="Type"/> of the array in which to enumerate. The <typeparamref 
    ///   name="TEnum"/> must implement <see cref="ValueEnum{TEnum}"/>.
    /// </typeparam>
    /// <param name="name">
    ///   The name of the member in which to search the inner cached collection for.
    /// </param>
    /// <param name="ignoreCase">
    ///   An <see cref="bool"/> parameter that if set to <see langword="true"/>, will use a 
    ///   case-insensitive <see cref="StringComparison"/> as a comparator against the <see 
    ///   cref="ValueEnum"/> container member identifiers. This is an optional property.
    /// </param>
    /// <returns>
    ///   The <typeparamref name="TEnum"/> name definition with a matching provided <paramref 
    ///   name="name"/>
    /// </returns>
    public static TEnum FromName<TEnum>(
      [NotNull] string name,
      bool ignoreCase = false)
        where TEnum
          : ValueEnum
    {
      name.IsNotNull(nameof(name));

      return Parse(
          typeof(TEnum),
          name,
          ignoreCase)
        .As<TEnum>();
    }


    /// <summary>
    ///   Enumerates the names of the <typeparamref name="TEnum"/> collection class members' 
    ///   string names.
    /// </summary>
    /// <typeparam name="TEnum">
    ///   The <see cref="Type"/> of the array in which to enumerate. The <typeparamref 
    ///   name="TEnum"/> must implement <see cref="ValueEnum{TEnum}"/>.
    /// </typeparam>
    /// <returns>
    ///   An enumeration of the <see cref="string"/> names of the <typeparamref name="TEnum"/>
    ///   collection class members' string names.
    /// </returns>
    public static IEnumerable<string> EnumerateNames<TEnum>()
      where TEnum
        : ValueEnum
    {
      return ToArray<TEnum>()
        .Select(t => t.Name);
    }


    /// <summary>
    ///   Retrieves an array of <see cref="string"/> names of the <typeparamref name="TEnum"/> 
    ///   collection class members' using the lazy <see cref="EnumerateNames{TEnum}"/> method 
    ///   before converting it to an Array of <see cref="string"/>.
    /// </summary>
    /// <typeparam name="TEnum">
    ///   The <see cref="Type"/> of the array in which to enumerate. The <typeparamref 
    ///   name="TEnum"/> must implement <see cref="ValueEnum{TEnum}"/>.
    /// </typeparam>
    /// <returns>
    ///   An enumerated array of the <see cref="string"/> names of the <typeparamref 
    ///   name="TEnum"/> collection class members' string names.
    /// </returns>
    public static string[] GetNames<TEnum>()
      where TEnum
      : ValueEnum
    {
      return EnumerateNames<TEnum>()
        .ToArray();
    }


    /// <summary>
    ///   Enumerates the inner values of the <typeparamref name="TEnum"/> collection class 
    ///   members.
    /// </summary>
    /// <typeparam name="TEnum">
    ///   The <see cref="Type"/> of the array in which to enumerate. The <typeparamref 
    ///   name="TEnum"/> must implement <see cref="ValueEnum{TEnum}"/>.
    /// </typeparam>
    /// <typeparam name="TValue">
    ///   The inner value type of the <see cref="ValueEnum"/>.
    /// </typeparam>
    /// <returns>
    ///   An enumeration of the inner <typeparamref name="TValue"/>'s of the <typeparamref 
    ///   name="TEnum"/>  collection class members' inner value.
    /// </returns>
    public static IEnumerable<TValue> EnumerateValues<TEnum, TValue>()
      where TEnum
      : ValueEnum<TValue>
    {
      return ToArray<TEnum>()
        .Select(t => t.Value);
    }


    /// <summary>
    ///   Retrieves an array of <see cref="TValue"/> inner associated values of the 
    ///   <typeparamref name="TEnum"/> collection class members using the lazy <see 
    ///   cref="EnumerateValues{TEnum, TValue}"/> method before converting it to an Array of 
    ///   <see cref="TValue"/>.
    /// </summary>
    /// <typeparam name="TEnum">
    ///   The <see cref="Type"/> of the array in which to enumerate. The <typeparamref 
    ///   name="TEnum"/> must implement <see cref="ValueEnum{TEnum}"/>.
    /// </typeparam>
    /// <typeparam name="TValue">
    ///   The inner value type of the <see cref="ValueEnum"/>.
    /// </typeparam>
    /// <returns>
    ///   An enumerated array of the <typeparamref name="TValue"/> values of the <typeparamref 
    ///   name="TEnum"/> collection class members' inner values.
    /// </returns>
    public static TValue[] GetValues<TEnum, TValue>()
      where TEnum
      : ValueEnum<TValue>
    {
      return EnumerateValues<TEnum, TValue>()
        .ToArray();
    }


    // todo bug: there is a problem with the logic with my comparison and equality methods... 
    // todo bug: causing a major bug.

    #region Problematic
    public int CompareTo(object obj)
    {
      return string.Compare(
        Name,
        obj.As<ValueEnum>().Name,
        StringComparison.CurrentCulture);
    }


    public static bool operator >(ValueEnum left, ValueEnum right)
    {
      return left.LineNumber > right.LineNumber;
    }

    public static bool operator <(ValueEnum left, ValueEnum right)
    {
      return left.LineNumber < right.LineNumber;
    }


    public static bool operator ==(ValueEnum left, ValueEnum right)
    {
      if (left == null)
        return right == null;

      return left.Equals(right);
    }

    public static bool operator !=(ValueEnum left, ValueEnum right)
    {
      if (left == null)
        return right != null;

      return left.Equals(right);
    }


    public override int GetHashCode()
    {
      unchecked
      {
        return (GetType().GetHashCode() * 397) ^ (ValueBase?.GetHashCode() ?? 0);
      }
    }

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;

      return GetHashCode() == obj.GetHashCode();
    }

    #endregion

    #endregion
  }


  public abstract class ValueEnum<TValue>
    : ValueEnum,
      IComparable,
      IComparable<
        ValueEnum<TValue>>
  {
    [NotNull]
    public TValue Value
    {
      get => (TValue) ValueBase;
    }

    public override Type ValueType
    {
      get => typeof(TValue);
    }


    protected ValueEnum(
      [NotNull] TValue value,
      [NotNull, UsedImplicitly] string fieldName = "",
      int line = 0) 
        : base(
          value,
          fieldName,
          line)
    {
    }


    public static TEnum FromValue<TEnum>(TValue value)
      where TEnum
        : ValueEnum<TValue>
    {
      var matchingValues = ToArray<TEnum>()
        .Where(t => t.Value.Equals(value))
        .ToArray();

      if (matchingValues.Length == 0)
        throw new ArgumentException(
          $"No static \'ValueEnum<TValue>\' field values found from the base value " +
          $"{value.ToString().SQuote()} in the type {typeof(TEnum).Name.SQuote()}.");

      if (matchingValues.Length >= 2)
        throw new ArgumentException(
          $"Multiple static \'ValueEnum<TValue>\' field values found with the base value " +
          $"{value.ToString().SQuote()} in the type {typeof(TEnum).Name.SQuote()}.");

      return matchingValues[0];
    }


    public new static TEnum FromName<TEnum>(
      string name,
      bool ignoreCase = false)
      where TEnum
        : ValueEnum
    {
      return Parse(typeof(TEnum), name, ignoreCase)
        .As<TEnum>();
    }

    public new static string[] GetNames<TEnum>()
      where TEnum
        : ValueEnum<TValue>
    {
      return ToArray<TEnum>()
        .Select(t => t.Name)
        .ToArray();
    }

    public static TValue[] GetValues<TEnum>()
      where TEnum
        : ValueEnum<TValue>
    {
      return ToArray<TEnum>()
        .Select(t => t.Value)
        .ToArray();
    }


    public int CompareTo(
      ValueEnum<TValue> obj)
    {
      return LineNumber
        .CompareTo(
          obj.LineNumber);
    }
  

    public override string ToString()
    {
      return Name;
    }

    public static implicit operator TValue(
      ValueEnum<TValue> @this)
    {
      return @this.Value;
    }

    public override bool Equals(object obj)
    {
      var enumeration = obj as ValueEnum<TValue>;
      if (enumeration == null)
        return false;

      return Equals(enumeration);
    }

    protected bool Equals(
      ValueEnum<TValue> other)
    {
      return GetType() == other.GetType()
             && Value.Equals(other.Value);
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }
  }
}