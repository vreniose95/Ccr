using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Ccr.Std.Core.Extensions;

namespace Ccr.Dnc.Data.EntityFramework
{
	public abstract class StaticEntityStoreBase
	{
		/// <summary>
		///   The <see cref="BindingFlags"/> required for discovering public static members
		///   declared in implementation classes
		/// </summary>
		protected const BindingFlags _discoveryFlags =
			BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly;

		/// <summary>
		///   The backing value field for the <see cref="EnumerationCache"/> static property.
		/// </summary>
		private static readonly Dictionary<Type, object[]> _enumerationCache
      = new Dictionary<Type, object[]>();

	  /// <summary>
	  ///   A static map of Entity types and their member declarations as arrays discovered 
	  ///   initially through <see cref="System.Reflection"/>
	  /// </summary>
	  protected static IReadOnlyDictionary<Type, object[]> EnumerationCache
	  {
	    get => _enumerationCache;
	  }

    
    /// <summary>
    ///   Gets an array of statically defined <typeparam name="TEntity"/> instances defined for
    ///   the provided Entity type <paramref name="type"/>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="type"></param>
    /// <returns></returns>
		public static TEntity[] GetEntityDefinitions<TEntity>(
      Type type)
		{
			if (!typeof(TEntity).IsAssignableFrom(type))
				throw new ArgumentException(
					$"Cannot enumerate the type {type.Name.SQuote()} because it does not " +
					$"implement {typeof(TEntity).Name.SQuote()}.");
      
			if (EnumerationCache.TryGetValue(type, out var arrayBoxed))
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

			_enumerationCache.Add(
			  type, 
			  boxedEnumerationCache);

			return reflectedEnumeration;
		}

		public static TEntity FromValue<TEntity>(
			Expression<Func<TEntity, object>> propertyEqualitySelector, 
			object value)
				where TEntity
          : class
		{
			var compiled = propertyEqualitySelector.Compile();

			var matchingValues = GetEntityDefinitions<TEntity>(
			    typeof(TEntity))
				.Where(
			    t => compiled(t)
			      .Equals(
			        value))
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
	}


	public abstract class StaticEntityStore<TEntity>
		: StaticEntityStoreBase
			where TEntity
       : class
	{
    public TEntity this[int index]
	  {
	    get => GetEntityDefinitions<TEntity>(
        typeof(TEntity))[index]; 
	  }
	}
}
