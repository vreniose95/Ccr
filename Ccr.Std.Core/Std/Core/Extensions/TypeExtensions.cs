using System;
using System.Linq;
using JetBrains.Annotations;

namespace Ccr.Std.Core.Extensions
{
  /// <summary>
  /// [null].Cast{TStruct}    ->    throw
  /// [null].Cast{TClass}     ->    return null
  /// 
  /// [TStruct].Cast{TStruct} ->    cast if valid, throw if not
  /// [TStruct].Cast{TClass}  ->    cast if valid, throw if not
  /// 
  /// [TClass].Cast{TStruct}  ->    cast if valid, throw if not
  /// [TClass].Cast{TClass}   ->    cast if valid, throw if not
  /// 
  /// 
  /// [null].As{TStruct}      ->    +return unset TStruct?
  /// [null].As{TClass}       ->    +return null
  /// 
  /// [TStruct].As{TStruct}   ->    +cast if valid, return as TStruct?, return unset TStruct? else
  /// [TStruct].As{TClass}    ->    +cast if valid, return null if else
  /// 
  /// [TClass].As{TStruct]    ->    +cast if valid, return unset TStruct? if else
  /// [TClass].As{TClass]     ->    +cast if valid, return null if else
  /// </summary>
  public static class TypeExtensions
  {
    /// <summary>
    ///   Extension method to cast an <see cref="object"/> to the specified 
    ///   type provided though the type parameter <typeparamref name="TValue"/>.
    ///   If the type <typeparamref name="TValue"/> is a nullable value type
    ///   and the value provided by <paramref name="@this"/> is null, an instance
    ///   of the <see cref="Nullable{T}"/> struct will be returned without having
    ///   been provided an inner value, causing <see cref="Nullable{T}.HasValue"/>
    ///   to return false. The <see cref="Nullable{T}.Equals(object)"/> method 
    ///   is overriden to allow nullable object instances that have not been 
    ///   assigned a valid inner value to return true when being compared to  
    /// </summary>
    /// <typeparam name="TValue">
    ///   The destination type to cast the object <paramref name="this"/> to.
    /// </typeparam>
    /// <param name="this">
    ///   The object being casted to type <typeparamref name="TValue"/>.
    /// </param>
    /// <param name="value">
    /// 
    /// </param>
    /// <remarks>
    ///   This method is merely a differing syntax preference for object type casts.
    /// </remarks>
    /// <returns>
    ///   An object that has been cast to type <typeparamref name="TValue"/>.
    /// </returns>
    private static bool TryCast<TValue>(
      this object @this,
      out TValue value)
    {
      if (@this == null)
      {
        value = default(TValue);
        return false;
      }
      if (@this is TValue _value)
      {
        value = _value;
        return true;
      }

      value = default(TValue);
      return false;
    }


    public static TStruct? CastOrDefault<TStruct>(
      this object @this)
        where TStruct
          : struct
    {
      if (@this == null)
        return new TStruct?();

      var type = @this.GetType();

      if (type.IsValueType)
      {
        return !@this.TryCast<TStruct>(out var value)
          ? new TStruct?()
          : value;
      }
      if (type.IsClass || type.IsInterface)
      {
        return !@this.TryCast<TStruct>(out var value)
          ? new TStruct?()
          : value;
      }
      throw new NotSupportedException();
    }


    public static TClass AsOrDefault<TClass>(
      this object @this)
        where TClass
          : class
    {
      if (@this == null)
        return null;

      var type = @this.GetType();

      if (type.IsValueType)
      {
        return !@this.TryCast<TClass>(out var value)
          ? null
          : value;
      }
      if (type.IsClass || type.IsInterface)
      {
        return !@this.TryCast<TClass>(out var value)
          ? null
          : value;
      }
      throw new NotSupportedException();
    }

    public static TStruct Cast<TStruct>(
      this object @this)
        where TStruct
          : struct
    {
      if (@this == null)
        throw new InvalidCastException(
          $"");

      var type = @this.GetType();

      if (type.IsValueType)
      {
        if (!@this.TryCast<TStruct>(out var value))
          throw new InvalidCastException(
            $"");

        return value;
      }
      if (type.IsClass || type.IsInterface)
      {
        if (!@this.TryCast<TStruct>(out var value))
          throw new InvalidCastException(
            $"");

        return value;
      }
      throw new NotSupportedException();
    }


    public static TClass As<TClass>(
      this object @this)
        where TClass
          : class
    {
      if (@this == null)
        return null;

      var type = @this.GetType();

      if (type.IsValueType)
      {
        if (!@this.TryCast<TClass>(out var value))
          throw new InvalidCastException(
            $"");

        return value;
      }
      if (type.IsClass || type.IsInterface)
      {
        if (!@this.TryCast<TClass>(out var value))
          throw new InvalidCastException(
            $"");

        return value;
      }
      throw new NotSupportedException();
    }

    [ContractAnnotation("=> halt")]
    private static void ThrowUnhandledTypeCategorizationException<TValue>(
      object @this)
    {
      throw new NotSupportedException();
    }


    public static bool IsGenericOf(
      [NotNull] this Type @this,
      [NotNull] Type genericType)
    {
      @this.IsNotNull(nameof(@this));
      genericType.IsNotNull(nameof(genericType)); 

      if (!@this.IsGenericType)
        return false;

      return @this.GetGenericTypeDefinition() == genericType;
    }

  }
}
/*
    private static bool TryCast<TValue>(
      this object @this,
      out TValue value)
    {
      if (typeof(TValue).IsValueType)
      {
        var wrapperType = @this.GetType();

        if (wrapperType.IsGenericType)
        {
          if (wrapperType.IsGenericOf(typeof(Nullable<>)))
          {
            var rootValueType = typeof(TValue)
                                .GetGenericArguments()
                                .Single();

            if (rootValueType.IsInstanceOfType(@this)
                || wrapperType.IsInstanceOfType(@this))
            {
              var nullableWrapper = NullableObjectFactory
                .BuildNullableBase(
                  rootValueType,
                  @this);

              value = (TValue)nullableWrapper;
              return true;
            }
          }
        }
      }
      else
      {
        if (@this == null)
        {
          value = default(TValue);
          return true;
        }

        if (@this is TValue)
        {
          value = (TValue)@this;
          return true;
        }
      }
      
      value = default(TValue);
      return false;
    }


      
    internal class NullableObjectFactory
    {
      // ReSharper disable ConvertNullableToShortForm
      // ReSharper disable RedundantExplicitNullableCreation
      // ReSharper disable ConvertNullableToShortForm
      public static Nullable<TInner> BuildNullable<TInner>(
        TInner value)
        where TInner
        : struct
      {
        return new Nullable<TInner>(value);
      }

      public static Nullable<TInner> BuildNullable<TInner>()
        where TInner
        : struct
      {
        return new Nullable<TInner>();
      }


      public static object BuildNullableBase(
        Type innerType)
      {
        var nullableType = typeof(Nullable<>)
          .MakeGenericType(innerType);

        var constructor = nullableType
          .GetConstructor(new Type[] { });

        var value = constructor.Invoke(
          new object[]{ });

        return value;
      }

      public static object BuildNullableBase(
        Type innerType,
        object innerValue)
      {
        var nullableType = typeof(Nullable<>)
          .MakeGenericType(innerType);

        var constructor = nullableType
          .GetConstructor(new[] { innerType });

        var convertedInnerValue = Convert.ChangeType(
          innerValue,
          innerType);

        var value = constructor.Invoke(
          new[] { convertedInnerValue });

        return value;
      }
      // ReSharper restore ConvertNullableToShortForm
      // ReSharper restore RedundantExplicitNullableCreation
      // ReSharper restore ConvertNullableToShortForm
    }


    public static TValue As<TValue>(
      [NotNull] this object @this)
    {
      @this.IsNotNull(nameof(@this));

      if (!@this.TryCast<TValue>(out var _value))
        throw new InvalidCastException(
          $"Unable to perform the typecast operation. The value of parameter " +
          $"ref={nameof(@this).Quote()} is of the type {@this.GetType().Name.Quote()}, " +
          $"and there is no valid typecast defined to the type {typeof(TValue).Name.SQuote()}," +
          $"passed by the typeparameter ref={nameof(TValue).Quote()}.");

      return _value;
    }


    //public static TStruct To<TStruct>(
    //  [NotNull] this object @this)
    //    where TStruct
    //      : struct
    //{
    //  var convertedValue = Convert.ChangeType(
    //    @this,
    //    typeof(TStruct));

    //  return convertedValue.As<TStruct>();

    //}

    public static TClass To<TClass>(
      [NotNull] this object @this)
    {
      var convertedValue = Convert.ChangeType(
        @this,
        typeof(TClass));

      if (!convertedValue.TryCast<TClass>(out var value))
        throw new InvalidCastException(
          $"Unable to perform the typecast operation. The value of parameter " +
          $"ref={nameof(@this).Quote()} is of the type {@this.GetType().Name.Quote()}, " +
          $"and there is no valid typecast defined to the type {typeof(TClass).Name.SQuote()}," +
          $"passed by the typeparameter ref={nameof(TClass).Quote()}.");

      return value;

    }

    [CanBeNull]
    public static TValue AsOrDefault<TValue>(
      [NotNull] this object @this)
    {
      @this.IsNotNull(nameof(@this));

      if (@this.GetType().IsValueType)
      {
        if (@this.Equals(default(TValue)))
        {
          if (!@this.TryCast<TValue>(out var value))
            throw new InvalidCastException(
              $"Unable to perform the typecast operation. The value of parameter " +
              $"ref={nameof(@this).Quote()} is of the type {@this.GetType().Name.Quote()}, " +
              $"and there is no valid typecast defined to the type {typeof(TValue).Name.SQuote()}," +
              $"passed by the typeparameter ref={nameof(TValue).Quote()}.");

          return value;
        }
      }

    }


    [CanBeNull]
    private static object AsNullableStructOrDefault(
      [NotNull] this object @this,
      Type targetType)
    {
      @this.IsNotNull(nameof(@this));

      var type = @this.GetType();

      var effectiveType = resolveTypeOrNullableRootType(
        type);

      if (targetType.IsValueType)
      {
        return NullableObjectFactory.BuildNullableBase(targetType);
      }

      if (!@this.TryCast<TValue>(out var _value))
        return default(TValue);

      return _value;
    }

    private static Type resolveTypeOrNullableRootType(
      Type type)
    {
      if (!type.IsValueType || !type.IsGenericType)
        return type;

      if (type.IsGenericOf(typeof(Nullable<>)))
      {
        return type
            .GetGenericArguments()
            .Single();
      }
      return type;
    }

    [CanBeNull]
    public static TValue AsOrDefault<TValue>(
      [NotNull] this object @this)
      where TValue
      : class
    {
      @this.IsNotNull(nameof(@this));

      if (!@this.TryCast<TValue>(out var _value))
        return default(TValue);

      return _value;
    }*/
