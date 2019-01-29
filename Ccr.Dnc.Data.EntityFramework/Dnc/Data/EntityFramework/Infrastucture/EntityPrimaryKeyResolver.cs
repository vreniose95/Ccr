using System;
using System.Linq;
using System.Linq.Expressions;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

// ReSharper disable ArrangeAccessorOwnerBody
#pragma warning disable IDE1006 // Naming Styles

namespace Ccr.Dnc.Data.EntityFramework.Infrastucture
{
	/// <summary>
	///   The purpose of this type is to efficiently resolve the entity type <typeparamref name="TEntity"/>'s
	///   primary key property getter and setter through Expression building and runtime Expression compilation.
	///   Instances of this type serve as a cached adapter for get/set calls to the primary key property.
	/// </summary>
	/// <typeparam name="TEntity">
	///   The entity type in which to create a single-pass resolve cached primary key resolver for.
	/// </typeparam>
	/// <typeparam name="TKey">
	///   The type of the entity type <typeparamref name="TEntity"/>'s primary key property, usually in the
	///   format '$entityType$ID'. This type must implement <see cref="IComparable"/>.
	/// </typeparam>
	/// <typeparam name="TContext">
	///   The type of the Entity Framework Core 2.0 context type. This type must inherit <see cref="DbContext"/>
	/// </typeparam>
	internal class EntityPrimaryKeyResolver<TEntity, TKey, TContext>
    : IEntityPrimaryKeyResolver<TEntity, TKey> 
			where TEntity
        : class
      where TKey
        : IComparable
      where TContext
        : DbContext
  {
    #region Fields
    /// <summary>
    ///   The <see cref="string"/> property name of the <typeparamref name="TEntity"/>'s primary key property.
    /// </summary>
    private readonly string _primaryKeyPropertyName;

    #endregion


    #region Properties
	  /// <inheritdoc/>
	  /// <summary>
	  ///   Returns the typeof <typeparamref name="TEntity"/>.
	  /// </summary>
	  public Type EntityType
	  {
			get => typeof(TEntity);
		}
		
    /// <summary>
    ///   Backing field for the <see cref="PrimaryKeyGetterExpression"/> property.
    /// </summary>
    private Expression<Func<TEntity, TKey>> _primaryKeyGetterExpression;
    /// <summary>
    ///   First-pass expression builder with singleton-style value caching.
    /// </summary>
    public Expression<Func<TEntity, TKey>> PrimaryKeyGetterExpression
    {
      get => _primaryKeyGetterExpression ??
             (_primaryKeyGetterExpression = buildPrimaryKeyGetterExpression(_primaryKeyPropertyName));
    }

    /// <summary>
    ///   Backing field for the <see cref="PrimaryKeySetterExpression"/> property.
    /// </summary>
    private Expression<Action<TEntity, TKey>> _primaryKeySetterExpression;
    /// <summary>
    ///   First-pass expression builder with singleton-style value caching.
    /// </summary>
    public Expression<Action<TEntity, TKey>> PrimaryKeySetterExpression
    {
      get => _primaryKeySetterExpression ??
             (_primaryKeySetterExpression = buildPrimaryKeySetterExpression(_primaryKeyPropertyName));
    }


    /// <summary>
    ///   Backing field for the <see cref="PrimaryKeyGetterCompiledDelegate"/> property.
    /// </summary>
    private Func<TEntity, TKey> _primaryKeyGetterCompiledDelegate;
    /// <summary>
    ///   First-pass expression builder with singleton-style value caching.
    /// </summary>
    public Func<TEntity, TKey> PrimaryKeyGetterCompiledDelegate
    {
      get => _primaryKeyGetterCompiledDelegate ??
             (_primaryKeyGetterCompiledDelegate = PrimaryKeyGetterExpression.Compile());
    }

    /// <summary>
    ///   Backing field for the <see cref="PrimaryKeySetterCompiledDelegate"/> property.
    /// </summary>
    private Action<TEntity, TKey> _primaryKeySetterCompiledDelegate;
    /// <summary>
    ///   First-pass expression builder with singleton-style value caching.
    /// </summary>
    public Action<TEntity, TKey> PrimaryKeySetterCompiledDelegate
    {
      get => _primaryKeySetterCompiledDelegate ??
             (_primaryKeySetterCompiledDelegate = PrimaryKeySetterExpression.Compile());
    }

    #endregion


    #region Constructors
    /// <summary>
    ///   Creates an instance of the <see cref="EntityPrimaryKeyResolver{TEntity,TKey,TContext}"/> type,
    ///   associated with the <typeparamref name="TContext"/> type, which inherits the Entity Framework 
    ///   base type <see cref="DbContext"/>.
    /// </summary>
    /// <param name="context">
    ///   The instance of the <typeparamref name="TContext"/> Entity Framework type <see cref="DbContext"/> 
    ///   in which to associate the instance's primary key resolver with.
    /// </param>
    public EntityPrimaryKeyResolver(
      TContext context)
    {
      var entityType = context
        .Model
        .FindEntityType(typeof(TEntity));

      var primaryKey = entityType
        .FindPrimaryKey();

      var property = primaryKey
        .Properties
        .Select(t => t.Name);

      var keyName = property
        .Single();

      _primaryKeyPropertyName = keyName;

      #region Old EF6 implementation
      //var objectContext = ((IObjectContextAdapter)context)
      //	.ObjectContext;

      //var set = objectContext.CreateObjectSet<TEntity>();

      //var keyNames = set.EntitySet.ElementType
      //														.KeyMembers
      //														.Select(k => k.Name)
      //														.ToArray();
      //if (keyNames.Length != 1)
      //	throw new NotSupportedException();

      //_primaryKeyPropertyName = keyNames[0];
      #endregion
    }

    #endregion


    #region Methods
    /// <summary>
    ///   Dynamically builds a lambda expression expecting a <typeparamref name="TEntity"/> 
    ///   parameter, and returns a <typeparamref name="TKey"/> indicating the primary key 
    ///   property where the provided <typeparamref name="TEntity"/> must be a reference type (class),
    ///		and the <typeparamref name="TKey"/> type must implement the interface 
    ///		<see cref="IComparable"/>.
    /// </summary>
    /// <param name="propertyName">
    ///   The <see cref="string"/> name of the property for the <typeparamref name="TEntity"/>
    ///   type's primary key property type. 
    /// </param>
    /// <returns>
    ///   Returns a dynamically built lambda expression accepting a <typeparamref name="TEntity"/>
    ///   parameter, and returning a <typeparamref name="TKey"/> target, indicating the primary key
    ///   property of the provided entity instance.
    /// </returns>
    protected static Expression<Func<TEntity, TKey>> buildPrimaryKeyGetterExpression(
      string propertyName)
    {
      var lambdaArgument = Expression.Parameter(
        typeof(TEntity), "t");

      var memberExpression = Expression.Property(
        lambdaArgument,
        propertyName);

      var lambdaExpression = Expression
        .Lambda<Func<TEntity, TKey>>(
          memberExpression,
          lambdaArgument);

      return lambdaExpression;
    }

    /// <summary>
    ///   Dynamically builds a lambda expression expecting a <typeparamref name="TEntity"/> and a 
    ///   <typeparamref name="TKey"/> parameter, and returning void.
    /// </summary>
    /// <param name="propertyName">
    ///   The <see cref="string"/> name of the property for the <typeparamref name="TEntity"/>
    ///   type's primary key property type. 
    /// </param>
    /// <returns>
    ///   Returns a dynamically built lambda expression accepting a <typeparamref name="TEntity"/>
    ///   and a <typeparamref name="TKey"/> parameter, and returning void, building a lambda 
    ///   expression whose body is a value assignment expression to set the primary key property 
    ///   of the provided entity instance.
    /// </returns>
    protected static Expression<Action<TEntity, TKey>> buildPrimaryKeySetterExpression(
      string propertyName)
    {
      var targetLambdaArgument = Expression.Parameter(
        typeof(TEntity), "t");

      var valueLambdaArgument = Expression.Parameter(
        typeof(TKey), "v");

      var memberExpression = Expression.Property(
        targetLambdaArgument,
        propertyName);

      var assignExpression = Expression.Assign(
        memberExpression,
        valueLambdaArgument);

      var lambdaExpression = Expression
        .Lambda<Action<TEntity, TKey>>(
          assignExpression,
          targetLambdaArgument,
          valueLambdaArgument);

      return lambdaExpression;
    }


		/// <inheritdoc/>
		/// <summary>
		///   Provides an explicit interface implementation for the
		///		<see cref="IEntityPrimaryKeyResolver{TEntity,TKey}"/> base getter method to provide access
		///		to the entity type's primary key property value.    
		/// </summary>
		/// <param name="entity">
		///   The instance of the entity, which must be a reference type (class), in which to access the
		///   primary key property value upon. This value must be of type <typeparamref name="TEntity"/>.
		/// </param>
		/// <exception cref="InvalidOperationException">
		///   Throws when the parameter <paramref name="entity"/> is not of the type or implicitly 
		///   convertable to the type <typeparamref name="TEntity"/>.
		/// </exception>
		/// <returns>
		///   Returns the primary key property value of the entity instance <paramref name="entity"/>
		///   as the base primary key type <typeparamref name="TKey"/> boxed in a <see cref="IComparable"/>.
		/// </returns>
		TKey IEntityPrimaryKeyResolver<TEntity, TKey>.GetPrimaryKeyBase(
	    [NotNull] TEntity entity)
    {
	    entity.IsNotNull(nameof(entity));

      return GetPrimaryKey(
        entity);
    }

		///  <inheritdoc/>
		///  <summary>
		///    Provides an explicit interface implementation for the
		/// 		<see cref="IEntityPrimaryKeyResolver{TEntity,TKey}"/> base setter method to allow set
		/// 		access on the entity type's primary key property value.    
		///  </summary>
		///  <param name="entity">
		///    The instance of the entity, which must be a reference type (class), in which to set the
		///    primary key property value upon. This value must be of type <typeparamref name="TEntity"/>.
		///  </param>
		/// <param name="key">
		///		The value in which to set the primary key property value on the <paramref name="entity"/>
		///   instance. This value must be of type <typeparamref name="TKey"/>.
		/// </param>
		/// <exception cref="InvalidOperationException">
		///    Throws when the parameter <paramref name="entity"/> is not of the type or implicitly 
		///    convertable to the type <typeparamref name="TEntity"/>.
		///  </exception>
		///  <returns>
		///    Returns the primary key property value of the entity instance <paramref name="entity"/>
		///    as the base primary key type <typeparamref name="TKey"/> boxed in a <see cref="IComparable"/>.
		///  </returns>
		void IEntityPrimaryKeyResolver<TEntity, TKey>.SetPrimaryKeyBase(
		  [NotNull] TEntity entity, 
		  TKey key)
	  {
			entity.IsNotNull(nameof(entity));

		  SetPrimaryKey(
			  entity,
			  key);
		}
		

	  /// <inheritdoc/>
	  /// <summary>
	  ///   Provides an explicit interface implementation for the <see cref="IEntityPrimaryKeyResolver"/> 
	  ///   base getter method to provide access to the entity type's primary key property value in a
	  ///		base context, as a <see cref="IComparable"/>. 
	  /// </summary>
	  /// <param name="entityBase">
	  ///   The instance of the entity from a base context, which must be a reference type (class), in
	  ///		which to access the primary key property value upon. This value must be of type
	  ///		<typeparamref name="TEntity"/>.
	  /// </param>
	  /// <exception cref="InvalidOperationException">
	  ///   Throws when the parameter <paramref name="entityBase"/> is not of the type or explicitly 
	  ///   convertable to the type <typeparamref name="TEntity"/>.
	  /// </exception>
	  /// <returns>
	  ///   Returns the primary key property value of the entity instance <paramref name="entityBase"/>
	  ///   as the base primary key type <see cref="TKey"/>, boxed in a <see cref="IComparable"/>.
	  /// </returns>
		IComparable IEntityPrimaryKeyResolver.GetPrimaryKeyBase(
		  object entityBase)
	  {
		  if (!(entityBase is TEntity entity))
			  throw new InvalidOperationException(
				  $"The type {entityBase.GetType().Name.SQuote()} is not supported from the base primary key " +
				  $"getter method. The 'entityBase' parameter must be of type {typeof(TEntity).Name.SQuote()}.");

		  return GetPrimaryKey(
			  entity);
		}


		/// <inheritdoc/>
		/// <summary>
		///   Provides an explicit interface implementation for the <see cref="IEntityPrimaryKeyResolver"/> 
		///   base setter method to provide access to the entity type's primary key property value.
		/// </summary>
		/// <param name="entityBase">
		///   The instance of the entity, which must be a reference type (class), in which to set the
		///   primary key property value on. This value must be of type <cref langword="class"/>.
		/// </param>
		/// <param name="keyBase">
		///   The value in which to set the primary key property value on the <paramref name="entityBase"/>
		///   instance. This value must be of type <cref name="IComparable"/>.
		/// </param>
		/// <exception cref="InvalidOperationException">
		///   Throws when the parameter <paramref name="entityBase"/> is not of the type or implicitly 
		///   convertable to the type <typeparamref name="TEntity"/>.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		///   Throws when the parameter <paramref name="keyBase"/> is not of the type or implicitly 
		///   convertable to the type <typeparamref name="TKey"/>.
		/// </exception>
		void IEntityPrimaryKeyResolver.SetPrimaryKeyBase(
      object entityBase,
      IComparable keyBase)
    {
      if (!(entityBase is TEntity entity))
        throw new InvalidOperationException(
          $"The type {entityBase.GetType().Name.SQuote()} is not supported from the base primary key " +
          $"getter method. The 'entityBase' parameter must be of type {typeof(TEntity).Name.SQuote()}.");

      if (!(keyBase is TKey key))
        throw new InvalidOperationException(
          $"The type {keyBase.GetType().Name.SQuote()} is not supported from the base primary key " +
          $"setter method. The 'keyBase' parameter must be of type {typeof(TKey).Name.SQuote()}.");
			
      SetPrimaryKey(
        entity,
        key);
    }


    /// <summary>
    ///   Gets the primary key property value from the entity instance provided by the parameter 
    ///   <paramref name="entity"/>.
    /// </summary>
    /// <param name="entity">
    ///   The instance of the entity as the type <typeparamref name="TEntity"/>.
    /// </param>
    /// <returns>
    ///   Returns the primary key property value as the type <typeparamref name="TKey"/> from the entity 
    ///   instance provided by the parameter <paramref name="entity"/>.
    /// </returns>
    public TKey GetPrimaryKey(
      TEntity entity)
    {
      return PrimaryKeyGetterCompiledDelegate(
        entity);
    }

    /// <summary>
    ///   Sets the primary key property value of the entity instance specified by the <paramref 
    ///   name="entity"/> parameter to the value provided by the <paramref name="value"/> parameter.
    /// </summary>
    /// <param name="entity">
    ///   The instance of the type <typeparamref name="TEntity"/> in which to access to the primary
    ///		key property value upon. 
    /// </param>
    /// <param name="value">
    ///   The value in which to set the primary key property value on the <paramref name="entity"/> 
    ///   instance.
    /// </param>
    public void SetPrimaryKey(
      TEntity entity,
      TKey value)
    {
      PrimaryKeySetterCompiledDelegate(
        entity,
        value);
    }
    

    /// <summary>
    ///   Dynamically builds a lambda expression expecting a <typeparamref name="TEntity"/> parameter
    ///   and returning <see cref="bool"/>.
    /// </summary>
    /// <param name="keyValue">
    ///   The primary key property value in which to create a value equality predicate expression with.
    /// </param>
    /// <returns>
    ///   Returns a dynamically built lambda expression accepting a <typeparamref name="TEntity"/> 
    ///   parameter and returning <see cref="bool"/>, whose body is a value equality predicate expression.
    /// </returns>
    public Expression<Func<TEntity, bool>> CreatePrimaryKeyExpressionPredicate(
      TKey keyValue)
    {
      var lambdaArgument = Expression.Parameter(
        typeof(TEntity),
        typeof(TEntity).Name);

      var binaryExpr = Expression.Equal(
        Expression.Property(lambdaArgument, _primaryKeyPropertyName),
        Expression.Constant(keyValue));

      var lambdaExpr = Expression.Lambda<Func<TEntity, bool>>(
        binaryExpr,
        lambdaArgument);

      return lambdaExpr;
    }

   
    /// <summary>
    ///   Dynamically builds a lambda expression expecting a <typeparamref name="TEntity"/> parameter
    ///   and returning <see cref="bool"/>.
    /// </summary>
    /// <param name="keyValue">
    ///   The primary key property value in which to create a value equality predicate expression with.
    /// </param>
    /// <returns>
    ///   Returns a dynamically built lambda expression accepting a <typeparamref name="TEntity"/> 
    ///   parameter and returning <see cref="bool"/>, whose body is a value equality predicate expression.
    /// </returns>
    public Expression<Func<TEntity, bool>> CreatePrimaryKeyExpressionPredicateBase(
      IComparable keyValue)
    {
      var lambdaArgument = Expression.Parameter(
        typeof(TEntity),
        typeof(TEntity).Name);

      var binaryExpr = Expression.Equal(
        Expression.Property(lambdaArgument, _primaryKeyPropertyName),
        Expression.Constant(keyValue));

      var lambdaExpr = Expression.Lambda<Func<TEntity, bool>>(
        binaryExpr,
        lambdaArgument);

      return lambdaExpr;
    }
		
    #endregion
  }
}
#pragma warning restore IDE1006 // Naming Styles