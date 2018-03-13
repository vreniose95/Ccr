using System;
using System.Linq;
using JetBrains.Annotations;

namespace Ccr.Std.Core.Extensions
{
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

            value = (TValue) nullableWrapper;
            return true;
          }
        }
      }

      if (@this is TValue)
      {
        value = (TValue)@this;
        return true;
      }

      value = default(TValue);
      return false;
      //throw new InvalidCastException(
      //  $"Cannot cast object of type \'{@this.GetType().Name}\' " +
      //  $"to the type \'{typeof(TValue).Name}\'");
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


    //private static TValue Cast<TValue>(
    //  this object @this)
    //    where TValue
    //    : struct
    //{

    //}


    public static TStruct As<TStruct>(
      [NotNull] this object @this)
        where TStruct
          : struct
    {
      @this.IsNotNull(nameof(@this));

      if (!@this.TryCast<TStruct>(out var _value))
        throw new InvalidCastException(
          $"Unable to perform the typecast operation. The value of parameter " +
          $"ref={nameof(@this).Quote()} is of the type {@this.GetType().Name.Quote()}, " +
          $"and there is no valid typecast defined to the type {typeof(TStruct).Name.SQuote()}," +
          $"passed by the typeparameter ref={nameof(TStruct).Quote()}.");

      return _value;
    }


    public static TStruct To<TStruct>(
      [NotNull] this object @this)
        where TStruct
          : struct
    {
      var convertedValue = Convert.ChangeType(
        @this,
        typeof(TStruct));

      return convertedValue.As<TStruct>();

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
