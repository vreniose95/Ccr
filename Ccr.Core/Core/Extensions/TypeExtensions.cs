using System;
using System.Collections.Generic;
using System.Reflection;
using Ccr.Core.TypeSystemInfo;
using JetBrains.Annotations;

namespace Ccr.Core.Extensions
{
	public static class TypeExtensions
	{
		/// <summary>
		/// Extension method to cast an object to the specified type though the
		/// type parameter <typeparamref name="TValue"/>. This method is merely
		/// a differing syntax preference for object type casts.
		/// </summary>
		/// <typeparam name="TValue">
		/// The destination type to cast the object to.
		/// </typeparam>
		/// <param name="this">
		/// The object to cast to the type parameter <typeparamref name="TValue"/>.
		/// </param>
		/// <returns>
		/// The object that has been typecasted to the specified type.
		/// </returns>
		public static TValue IsOfType<TValue>(
			this object @this)
		{
			if (@this is TValue)
				return (TValue)@this;

			throw new InvalidCastException(
				$"Cannot cast object of type \'{@this.GetType().Name}\' " +
				$"to the type \'{typeof(TValue).Name}\'");
		}


		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="this"></param>
		/// <returns></returns>
		public static TValue As<TValue>(
			this object @this)
		{
			if (@this == null)
				return default(TValue);

			return @this.IsOfType<TValue>();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="this"></param>
		/// <returns></returns>
		public static TValue AsOrDefault<TValue>(
			this object @this)
		{
			if (@this == null)
				return default(TValue);

			return @this.As<TValue>();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="this"></param>
		/// <returns></returns>
		public static T To<T>(this object @this)
		{
			var convertedValue = Convert.ChangeType(@this, typeof(T));
			return convertedValue.As<T>();
		}

		/// <summary>
		/// Checks if the provided <paramref name="this"/> is a generic of the 
		/// <paramref name="genericType"/> 
		/// </summary>
		/// <param name="this">
		/// The instance of the <see cref="Type"/> to check
		/// </param>
		/// <param name="genericType">
		/// The 
		/// </param>
		/// <code>
		/// typeof(List{int}).IsGenericOf(typeof(List{})) -> true
		/// typeof(List{int}).IsGenericOf(typeof(Table{})) -> false
		/// </code>
		/// <example>
		/// typeof(List{int}).IsGenericOf(typeof(List{})) -> true
		/// typeof(List{int}).IsGenericOf(typeof(Table{})) -> false
		/// </example>
		/// <returns>
		/// 
		/// </returns>
		public static bool IsGenericOf(this Type @this, Type genericType)
		{
			if (!@this.IsGenericType)
				return false;

			return @this.GetGenericTypeDefinition() == genericType;
		}

		/// <summary>
		/// Checks if a PropertyInfo's PropertyType Is a generic of the given type
		/// </summary>
		/// <param name="this">
		/// the instance of the PropertyInfo to check
		/// </param>
		/// <param name="genericType">
		/// 
		/// </param>
		/// <returns></returns>
		public static bool IsPropertyTypeGenericOf(
			this PropertyInfo @this, 
			Type genericType)
		{
			return @this.PropertyType.IsGenericOf(genericType);
		}

		/// <summary>
		/// Returns the default value for the specified Type <paramref name="this"/>
		/// </summary>
		/// <param name="this">
		/// 
		/// </param>
		/// <returns></returns>
		public static object GetDefaultValue(
			[NotNull] this Type @this)
		{
			@this.IsNotNull(nameof(@this));

			if (!@this.IsValueType)
				return null;

			var nullableWrapper = typeof(Nullable<>).MakeGenericType(@this);
			var instance = Activator.CreateInstance(nullableWrapper);

			return instance;
		}


		public static bool IsIntegralType(
			this Type @this)
		{
			return IntegralTypeReference.IsIntegralType(@this);
		}


		/// <summary>
		/// a mapping of the account C#'s built in type table defined at 
		/// https://msdn.microsoft.com/en-us/library/ya5y69ds.aspx
		/// </summary>
		private static readonly Dictionary<Type, string> _specialFormats = new Dictionary<Type, string>
		{
			[typeof(bool)] = "bool",
			[typeof(byte)] = "byte",
			[typeof(sbyte)] = "sbyte",
			[typeof(char)] = "char",
			[typeof(decimal)] = "decimal",
			[typeof(double)] = "double",
			[typeof(float)] = "float",
			[typeof(int)] = "int",
			[typeof(uint)] = "uint",
			[typeof(long)] = "long",
			[typeof(ulong)] = "ulong",
			[typeof(object)] = "object",
			[typeof(short)] = "short",
			[typeof(ushort)] = "ushort",
			[typeof(string)] = "string"
		};

		/// <summary>
		/// Gets the formatted Name of the type taking into account C#'s built in type
		/// table defined at https://msdn.microsoft.com/en-us/library/ya5y69ds.aspx
		/// </summary>
		/// <param name="this">
		/// the instance of the type to format
		/// </param>
		/// <returns>
		/// The formatted Name of the type taking into account C#'s built in type table
		/// defined at https://msdn.microsoft.com/en-us/library/ya5y69ds.aspx
		/// </returns>
		public static string FormatName(
			this Type @this)
		{
			return _specialFormats.TryGetValue(@this, out var specialFormat)
				? specialFormat 
				: @this.Name;
		}
	}
}
