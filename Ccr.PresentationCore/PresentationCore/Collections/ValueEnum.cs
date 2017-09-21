using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Ccr.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.PresentationCore.Collections
{
	/// <summary>
	/// Base class for <see cref="ValueEnum{TValue}"/>, a method of creating strongly typed sets 
	/// of named values of types, not limited to integral data types. 
	/// </summary>
	public abstract class ValueEnum
	{
		/// <summary>
		/// The <see cref="BindingFlags"/> required for discovering public static members
		/// declared in implementation classes
		/// </summary>
		protected const BindingFlags _discoveryFlags =
			BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly;

		/// <summary>
		/// The backing value field for the <see cref="EnumerationCache"/> singleton property.
		/// </summary>
		private static readonly Dictionary<Type, ValueEnum[]> enumerationCache = new Dictionary<Type, ValueEnum[]>();
		/// <summary>
		/// A singleton map of <see cref="ValueEnum{TValue}"/> types and their member declarations 
		/// as arrays discovered through <see cref="System.Reflection"/>
		/// </summary>
		protected static IReadOnlyDictionary<Type, ValueEnum[]> EnumerationCache => enumerationCache;

		/// <summary>
		/// The boxed value of the <see cref="ValueEnum"/> member declaration
		/// </summary>
		[NotNull]
		public object ValueBase { get; }
		/// <summary>
		/// The string name of the <see cref="ValueEnum"/> member declaration. This value is provided to the 
		/// constructor automatically through the CompilerService <see cref="CallerMemberNameAttribute"/>
		/// </summary>
		[NotNull]
		public string Name { get; }
		/// <summary>
		/// The line number of the <see cref="ValueEnum"/> member declaration. This value is provided to the 
		/// constructor automatically through the CompilerService <see cref="CallerLineNumberAttribute"/>
		/// </summary>
		public int LineNumber { get; }
		/// <summary>
		/// The Type of the <see cref="ValueEnum"/> member declaration
		/// </summary>
		[NotNull]
		public abstract Type ValueType { get; }


		/// <summary>
		/// Creates an instance of a <see cref="ValueEnum"/> member declaration 
		/// </summary>
		/// <param name="value">
		/// The backing value of the member declaration boxed in an <see cref="object"/>
		/// </param>
		/// <param name="name">
		/// The string name of the <see cref="ValueEnum"/> member declaration. This value is provided to the 
		/// constructor automatically through the CompilerService <see cref="CallerMemberNameAttribute"/>
		/// </param>
		/// <param name="lineNumber">
		/// The line number of the <see cref="ValueEnum"/> member declaration. This value is provided to the 
		/// constructor automatically through the CompilerService <see cref="CallerLineNumberAttribute"/>
		/// </param>
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

		/// <summary>
		/// Checks if the provided ValueEnum{TValue} Type contains a defined ValueEnum member 
		/// declaration with the name specified by the <paramref name="name"/> argument.   
		/// </summary>
		/// <param name="type">
		/// The Type of the ValueEnum{TValue} container class
		/// </param>
		/// <param name="name">
		/// The ValueEnum member declaration member name to search for.
		/// </param>
		/// <param name="ignoreCase">
		/// An optional parameter that if set to true will use a case-insensitive 
		/// <see cref="StringComparison"/> as a comparator against the ValueEnum member identifiers.
		/// </param>
		/// <returns>
		/// A <see cref="bool"/> value indicating whether or not a ValueEnum{TValue} has an
		/// ValueEnum member identifier matching the provided <paramref name="name"/>, taking into
		/// account the optional <paramref name="ignoreCase"/> case sensitivity option.
		/// </returns>
		public static bool IsDefined(
			Type type,
			string name,
			bool ignoreCase = false)
		{
			var stringComparison = ignoreCase ?
				StringComparison.CurrentCulture :
				StringComparison.CurrentCultureIgnoreCase;

			return ToArrayBase(type)
				.Any(t => t.Name.Equals(name, stringComparison));
		}

		/// <summary>
		/// Checks if the TEnum declaration contains a defined ValueEnum member 
		/// declaration with the name specified by the <paramref name="name"/> argument.   
		/// </summary>
		/// <typeparam name="TEnum">
		/// The Enum class reference
		/// </typeparam>
		/// <param name="name">
		/// The ValueEnum member declaration member identifier to search for.
		/// </param>
		/// <param name="ignoreCase">
		/// An optional parameter that if set to true will use a case-insensitive 
		/// <see cref="StringComparison"/> as a comparator against the ValueEnum member identifiers.
		/// </param>
		/// <returns>
		/// A <see cref="bool"/> value indicating whether or not a ValueEnum{TValue} has an
		/// ValueEnum member identifier matching the provided <paramref name="name"/>, taking into
		/// account the optional <paramref name="ignoreCase"/> case sensitivity option.
		/// </returns>
		public static bool IsDefined<TEnum>(
				string name,
				bool ignoreCase = false)
					where TEnum : ValueEnum
		{
			return IsDefined(typeof(TEnum), name, ignoreCase);
		}

		/// <summary>
		/// Attempts to convert the string identifier of the <see cref="ValueEnum{TValue}"/> 
		/// to the instance of the member declaration. The return value indicates whether 
		/// the conversion succeeded.
		/// </summary>
		/// <param name="valueEnumType">
		/// The Type of the <see cref="ValueEnum{TValue}"/> declaration.
		/// </param>
		/// <param name="name">
		/// The <see cref="ValueEnum{TValue}"/> member declaration member identifier to parse.</param>
		/// <param name="valueEnumInstance">
		/// The returned instance of the member with the provided identifier name.
		/// </param>
		/// <returns>
		/// A boolean value indicating whether the conversion succeeded.
		/// </returns>
		public static bool TryParse(
			Type valueEnumType,
			string name,
			out ValueEnum valueEnumInstance)
		{
			return TryParse(
				valueEnumType,
				name,
				false,
				out valueEnumInstance);
		}

		/// <summary>
		/// Attempts to convert the string identifier of the <see cref="ValueEnum{TValue}"/> 
		/// to the instance of the member declaration. The return value indicates whether 
		/// the conversion succeeded.
		/// </summary>
		/// <param name="valueEnumType">
		/// The Type of the <see cref="ValueEnum{TValue}"/> declaration.
		/// </param>
		/// <param name="name">
		/// The <see cref="ValueEnum{TValue}"/> member declaration member identifier to parse.</param>
		/// <param name="ignoreCase">
		/// A boolean parameter that if set to true will use a case-insensitive <see cref="StringComparison"/> 
		/// as a comparator against the ValueEnum member identifiers. This is not an optional property.
		/// </param>
		/// <param name="valueEnumInstance">
		/// The returned instance of the member with the provided identifier name.
		/// </param>
		/// <returns>
		/// A boolean value indicating whether the conversion succeeded.
		/// </returns>
		public static bool TryParse(
			Type valueEnumType,
			string name,
			bool ignoreCase,
			out ValueEnum valueEnumInstance)
		{
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
		/// Gets the <see cref="ValueEnum"/> member declaration that matches the name 
		/// specified by the <paramref name="name"/> argument defined in the provided
		/// <see cref="ValueEnum{TValue}"/> declaration class.
		/// </summary>
		/// <param name="valueEnumType">
		/// The Type of the <see cref="ValueEnum{TValue}"/> declaration.
		/// </param>
		/// <param name="name">
		/// The <see cref="ValueEnum{TValue}"/> member declaration member identifier to parse.
		/// </param>
		/// <param name="ignoreCase">
		/// An optional parameter that if set to true will use a case-insensitive 
		/// <see cref="StringComparison"/> as a comparator against the ValueEnum member identifiers.
		/// </param>
		/// <returns>
		/// The <see cref="ValueEnum{TValue}"/> member declaration instance associated with the
		/// provided identifier name. 
		/// </returns>
		public static ValueEnum Parse(
			Type valueEnumType,
			string name,
			bool ignoreCase = false)
		{
			if (valueEnumType == null)
				throw new ArgumentNullException(nameof(valueEnumType));

			if (!typeof(ValueEnum<>).IsAssignableFrom(valueEnumType))
				throw new ArgumentException(
					$"The specified \'valueEnumType\' parameter is invalid because it is not of the " +
					$"type \'ValueEnum<TValue>\'.",
					nameof(valueEnumType));

			if (name.IsValidCSharpIdentifier())
				throw new ArgumentException(
					$"The specified \'name\' parameter is invalid because it does not consitute a valid " +
					$"identifier by C#'s language specifications on member identifier naming conventions",
					nameof(name));

			var stringComparison = ignoreCase ?
				StringComparison.CurrentCulture :
				StringComparison.CurrentCultureIgnoreCase;

			var matchingValues = ToArrayBase(valueEnumType)
				.Where(t => t.Name.Equals(name, stringComparison))
				.ToArray();

			if (matchingValues.Length == 0)
				throw new ArgumentException(
					$"No ValueEnum<TValue> member declaration value could be found with the identifier name \'{name}\' " +
					$"in the type \'{valueEnumType.Name}\'.",
					nameof(name));

			if (matchingValues.Length >= 2)
				throw new ArgumentException(
					$"Multiple ValueEnum<TValue> member declared values were found with the name \'{name}\' " +
					$"in the type \'{valueEnumType.Name}\'.",
					nameof(name));

			return matchingValues[0];
		}


		/// <summary>
		/// Enumerates the ValueEnum
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <returns></returns>
		public static IEnumerable<TEnum> Enumerate<TEnum>()
			where TEnum : ValueEnum
		{
			return ToArray<TEnum>();
		}

		/// <summary>
		/// Converts the ValueEnum to an array
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <returns></returns>
		public static TEnum[] ToArray<TEnum>()
			where TEnum : ValueEnum
		{
			return ToArrayBase(typeof(TEnum))
				.Cast<TEnum>()
				.ToArray();
		}
		/// <summary>
		/// Converts the ValueEnum to a List of <typeparamref name="TEnum"/>
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <returns></returns>
		public static IList<TEnum> ToList<TEnum>()
			where TEnum : ValueEnum
		{
			return ToArray<TEnum>()
				.ToList();
		}

		public static ValueEnum[] ToArrayBase(Type type)
		{
			if (!typeof(ValueEnum).IsAssignableFrom(type))
				throw new ArgumentException(
					$"Cannot enumerate the type \'{type.Name}\' because it does not implement \'ValueEnum\'.");

			ValueEnum[] arrayBoxed;
			if (EnumerationCache.TryGetValue(type, out arrayBoxed))
				return arrayBoxed;

			var reflectedEnumeration = type
				.GetFields(_discoveryFlags)
				.Select(f => f.GetValue(null))
				.Cast<ValueEnum>()
				.ToArray();

			enumerationCache.Add(type, reflectedEnumeration);

			return reflectedEnumeration;
		}

		public static TEnum FromValue<TEnum>(object value)
			where TEnum : ValueEnum
		{
			var matchingValues = ToArray<TEnum>()
				.Where(t => t.ValueBase.Equals(value))
				.ToArray();

			if (matchingValues.Length == 0)
				throw new ArgumentException(
					$"No static \'ValueEnum<TValue>\' field values found from the base value \'{value}\' " +
					$"in the type \'{typeof(TEnum).Name}\'.");

			if (matchingValues.Length >= 2)
				throw new ArgumentException(
					$"Multiple static \'ValueEnum<TValue>\' field values found with the base value \'{value}\' " +
					$"in the type \'{typeof(TEnum).Name}\'.");

			return matchingValues[0];
		}

		public static TEnum FromName<TEnum>(
			string name,
			bool ignoreCase = false)
				where TEnum : ValueEnum
		{
			return Parse(typeof(TEnum), name, ignoreCase).As<TEnum>();
		}

		public static string[] GetNames<TEnum>()
			where TEnum : ValueEnum
		{
			return ToArray<TEnum>()
				.Select(t => t.Name)
				.ToArray();
		}
		public static TValue[] GetValues<TEnum, TValue>()
			where TEnum : ValueEnum<TValue>
		{
			return ToArray<TEnum>()
				.Select(t => t.Value)
				.ToArray();
		}


		public int CompareTo(object obj)
		{
			return string.Compare(Name, ((ValueEnum)obj).Name, StringComparison.CurrentCulture);
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
	}


	public abstract class ValueEnum<TValue> :
		ValueEnum,
		IComparable,
		IComparable<ValueEnum<TValue>>
	{
		[NotNull]
		public TValue Value => (TValue)ValueBase;

		public override Type ValueType => typeof(TValue);


		protected ValueEnum(
			[NotNull] TValue value,
			[NotNull, UsedImplicitly] string fieldName = "",
			int line = 0) : base(
				value,
				fieldName,
				line)
		{
		}


		public static TEnum FromValue<TEnum>(TValue value)
			where TEnum : ValueEnum<TValue>
		{
			var matchingValues = ToArray<TEnum>()
				.Where(t => t.Value.Equals(value))
				.ToArray();

			if (matchingValues.Length == 0)
				throw new ArgumentException(
					$"No static \'ValueEnum<TValue>\' field values found from the base value {value.ToString().SQuote()} " +
					$"in the type {typeof(TEnum).Name.SQuote()}.");

			if (matchingValues.Length >= 2)
				throw new ArgumentException(
					$"Multiple static \'ValueEnum<TValue>\' field values found with the base value {value.ToString().SQuote()} " +
					$"in the type {typeof(TEnum).Name.SQuote()}.");

			return matchingValues[0];
		}

		public new static TEnum FromName<TEnum>(string name, bool ignoreCase = false)
			where TEnum : ValueEnum
		{
			return Parse(typeof(TEnum), name, ignoreCase).As<TEnum>();
		}

		public new static string[] GetNames<TEnum>()
			where TEnum : ValueEnum<TValue>
		{
			return ToArray<TEnum>()
				.Select(t => t.Name)
				.ToArray();
		}

		public static TValue[] GetValues<TEnum>()
			where TEnum : ValueEnum<TValue>
		{
			return ToArray<TEnum>()
				.Select(t => t.Value)
				.ToArray();
		}


		public int CompareTo(ValueEnum<TValue> obj)
		{
			return LineNumber.CompareTo(obj.LineNumber);
		}

		public override string ToString()
		{
			return Name;
		}

		public static implicit operator TValue(ValueEnum<TValue> @this)
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

		protected bool Equals(ValueEnum<TValue> other)
		{
			return GetType() == other.GetType() && Value.Equals(other.Value);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}

}
