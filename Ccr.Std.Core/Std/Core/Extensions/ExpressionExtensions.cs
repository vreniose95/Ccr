using System;
using System.Linq.Expressions;
using System.Reflection;
using JetBrains.Annotations;

namespace Ccr.Std.Core.Extensions
{
  /// <summary>
  ///   Extension methods for <see cref="Expression"/> subjects.
  /// </summary>
  public static class ExpressionExtensions
  {
    /// <summary>
    ///   Converts an <see cref="Expression"/> object into a <see cref="MemberInfo"/> object.
    /// </summary>
    /// <param name="this">
    ///   The <see cref="Expression"/> in which to convert. This value should be of the type 
    ///   <see cref="LambdaExpression"/>.
    /// </param>
    /// <returns>
    ///   Returns a <see cref="MemberInfo"/> object that describes the property target embodied 
    ///   in the <see cref="LambdaExpression"/> provided by the <paramref name="this"/>.
    /// </returns>
    public static MemberInfo GetMemberInfo(
      [NotNull] this Expression @this)
    {
      @this.IsNotNull(nameof(@this));

      var lambdaExpression = @this.AsOrDefault<LambdaExpression>();
      if (lambdaExpression == null)
        throw new ArgumentException(
          $"The Expression value {@this.Type.Name.SQuote()} is not valid for the parameter " +
          $"{nameof(@this).SQuote()} as it is not of type {nameof(LambdaExpression).SQuote()}.");

      return lambdaExpression
        .GetEmbodiedMemberExpression()
        .Member;
    }

    /// <summary>
    ///   Gets the deconstructed embodied <see cref="MemberExpression"/> of the subject 
    ///   <see cref="LambdaExpression"/> provided by the parameter <paramref name="this"/>'s 
    ///   <see cref="LambdaExpression.Body"/> property.
    /// </summary> 
    /// <param name="this">
    ///   The <see cref="LambdaExpression"/> object that provides the Body in which to extract 
    ///   a <see cref="MemberExpression"/> from.
    /// </param>
    /// <remarks>
    ///   The subject's <see cref="LambdaExpression.Body"/> property must be either of type 
    ///   <see cref="MemberExpression"/> or <see cref="UnaryExpression"/> for use in this method.
    /// </remarks> 
    /// <returns>
    ///   Returns a <see cref="MemberExpression"/> object that describes the embodied targeteted 
    ///   <see cref="MemberExpression"/> represented by the <see cref="LambdaExpression"/> subject.
    /// </returns>
    [NotNull]
    public static MemberExpression GetEmbodiedMemberExpression(
      [NotNull] this LambdaExpression @this)
    {
      @this.IsNotNull(nameof(@this));

      switch (@this.Body)
      {
        case MemberExpression memberExpression:
          return memberExpression;

        case UnaryExpression unaryExpression:
          return unaryExpression
            .Operand
            .As<MemberExpression>();

        default:
          throw new NotSupportedException(
            $"The parameter {nameof(@this).SQuote()} 's {nameof(LambdaExpression.Body).SQuote()} " +
            $"property value is of type {@this.Body.Type.Name.SQuote()}, and is not supported " +
            $"for conversion to type {nameof(MemberExpression).SQuote()}. The Body Expression " +
            $"type should either be a {nameof(MemberExpression).SQuote()}, or be of type " +
            $"{nameof(UnaryExpression).SQuote()} with the Operand property as the type " +
            $"{nameof(MemberExpression).SQuote()} to be used with this method.");
      }
    }
  }
}
