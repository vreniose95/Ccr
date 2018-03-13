using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Ccr.Data.EntityFramework.Core
{
	public abstract class StaticEntityStoreBase
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
		private static readonly Dictionary<Type, object[]> enumerationCache = new Dictionary<Type, object[]>();
		/// <summary>
		/// A singleton map of Entity types and their member declarations as arrays discovered initially 
		/// through <see cref="System.Reflection"/>
		/// </summary>
		protected static IReadOnlyDictionary<Type, object[]> EnumerationCache => enumerationCache;


		/// <summary>
		/// Enumerates the ValueEnum
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <returns></returns>
		public static IEnumerable<TEntity> Enumerate<TEntity>()
			where TEntity : class
		{
			return ToArray<TEntity>();
		}

		/// <summary>
		/// Converts the <see cref="StaticEntityStore{TEntity}"/> to an array
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <returns></returns>
		public static TEntity[] ToArray<TEntity>()
			where TEntity : class
		{
			return ToArrayBase<TEntity>(typeof(TEntity))
				.ToArray();
		}
		/// <summary>
		/// Converts the ValueEnum to a List of <typeparamref name="TEntity"/>
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <returns></returns>
		public static IList<TEntity> ToList<TEntity>()
			where TEntity : class
		{
			return ToArray<TEntity>()
				.ToList();
		}

		public static TEntity[] ToArrayBase<TEntity>(Type type)
		{
			if (!typeof(TEntity).IsAssignableFrom(type))
				throw new ArgumentException(
					$"Cannot enumerate the type \'{type.Name}\' because it does not implement \'TEntity\'.");

			object[] arrayBoxed;
			if (EnumerationCache.TryGetValue(type, out arrayBoxed))
				return arrayBoxed
					.Cast<TEntity>()
					.ToArray();

			var reflectedEnumeration = type
				.GetFields(_discoveryFlags)
				.Select(f => f.GetValue(null))
				.Cast<TEntity>()
				.ToArray();

			var boxedEnumerationCache = reflectedEnumeration
				.Cast<object>()
				.ToArray();

			enumerationCache.Add(type, boxedEnumerationCache);

			return reflectedEnumeration;
		}

		public static TEntity FromValue<TEntity>(
			Expression<Func<TEntity, object>> propertyEqualitySelector, 
			object value)
				where TEntity : class
		{
			var compiled = propertyEqualitySelector.Compile();

			var matchingValues = ToArray<TEntity>()
				.Where(t => compiled(t).Equals(value))
				.ToArray();

			if (matchingValues.Length == 0)
				throw new ArgumentException(
					$"No static \'TEntity\' field values found from the base value \'{value}\' " +
					$"in the type \'{typeof(TEntity).Name}\'.");

			if (matchingValues.Length >= 2)
				throw new ArgumentException(
					$"Multiple static \'TEntity\' field values found with the base value \'{value}\' " +
					$"in the type \'{typeof(TEntity).Name}\'.");

			return matchingValues[0];
		}

		//public static TEntity FromName<TEntity>(
		//	string name,
		//	bool ignoreCase = false)
		//		where TEntity : class
		//{
		//	return Parse(typeof(TEntity), name, ignoreCase).As<TEnum>();
		//}

		//public static string[] GetNames<TEntity>()
		//	where TEntity : class
		//{
		//	return ToArray<TEntity>()
		//		.Select(t => t.Name)
		//		.ToArray();
		//}
		//public static TValue[] GetValues<TEnum, TValue>()
		//	where TEnum : ValueEnum<TValue>
		//{
		//	return ToArray<TEnum>()
		//		.Select(t => t.Value)
		//		.ToArray();
		//}

	}
	public abstract class StaticEntityStore<TEntity>
		: StaticEntityStoreBase
			where TEntity : class
	{
    /// <summary>
		/// Converts the <see cref="StaticEntityStore{TEntity}"/> to an array
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <returns></returns>
		public static TEntity[] ToArray()
		{
			return ToArrayBase<TEntity>(typeof(TEntity))
				.ToArray();
		}
		/// <summary>
		/// Converts the ValueEnum to a List of <typeparamref name="TEntity"/>
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <returns></returns>
		public static IList<TEntity> ToList()
		{
			return ToArray<TEntity>()
				.ToList();
		}
	}

}
