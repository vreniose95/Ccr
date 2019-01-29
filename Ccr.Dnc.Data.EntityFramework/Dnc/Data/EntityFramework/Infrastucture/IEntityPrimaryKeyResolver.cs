using System;

namespace Ccr.Dnc.Data.EntityFramework.Infrastucture
{
	/// <summary>
	///   This is the base class for the generic <see cref="EntityPrimaryKeyResolver{TEntity,TKey,TContext}"/>
	///   class. This defines common abstract base methods that are implemented in the generic class.
	/// </summary>
	public interface IEntityPrimaryKeyResolver
	{
		/// <summary>
		///   Gets the <see cref="Type"/> of the entity that can be resolved by this resolver instance.
		/// </summary>
		Type EntityType { get; }


		/// <summary>
		///   Gets the primary key property value as type <see cref="IComparable"/> from the entity type
		///   instance provided by the <paramref name="entityBase"/> parameter.
		/// </summary>
		/// <param name="entityBase">
		///   The instance of the entity in which to access the primary key from.
		/// </param>
		/// <returns>
		///   The value of the entity's primary key propery value, as type <see cref="IComparable"/>.
		/// </returns>
		IComparable GetPrimaryKeyBase(
			object entityBase);
		
		/// <summary>
		///   Sets the primary key property value as type <see cref="IComparable"/> to the entity type instance
		///   provided by the <paramref name="entityBase"/> parameter.
		/// </summary>
		/// <param name="entityBase">
		///   The instance of the entity in which to set the primary key value on.
		/// </param>
		/// <param name="keyBase">
		///   The value to set the primary key property to, as the type <see cref="IComparable"/>.
		/// </param>
		void SetPrimaryKeyBase(
			object entityBase,
			IComparable keyBase);
	}


	public interface IEntityPrimaryKeyResolver<in TEntity, TKey>
		: IEntityPrimaryKeyResolver
			where TEntity
				: class
			where TKey
				: IComparable
	{
		/// <summary>
		///   Gets the primary key property value as type <typeparamref name="TKey"/> from the entity
		///		type instance, provided by the <paramref name="entity"/> parameter.
		/// </summary>
		/// <param name="entity">
		///   The instance of the entity in which to access the primary key from.
		/// </param>
		/// <returns>
		///   The value of the entity's primary key propery value, as type <paramref name="entity"/>.
		/// </returns>
		TKey GetPrimaryKeyBase(
			TEntity entity);
	
		/// <summary>
		///   Sets the primary key property value as type <typeparamref name="TKey"/> to the entity type
		///		instance provided by the <paramref name="entity"/> parameter.
		/// </summary>
		/// <param name="entity">
		///   The instance of the entity in which to set the primary key value on.
		/// </param>
		/// <param name="key">
		///   The value to set the primary key property to, as the type <see cref="TKey"/>.
		/// </param>
		void SetPrimaryKeyBase(
			TEntity entity,
			TKey key);
	}

}