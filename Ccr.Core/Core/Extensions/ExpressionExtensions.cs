using System;
using System.Linq.Expressions;
using System.Reflection;
using JetBrains.Annotations;

namespace Ccr.Core.Extensions
{
	/// <summary>
	/// Extension methods for <see cref="Expression"/> subjects.
	/// </summary>
	public static class ExpressionExtensions
	{
		/// <summary>
		/// Converts an <see cref="Expression"/> into a <see cref="MemberInfo"/> 
		/// </summary>
		/// <param name="this">
		/// The expression to convert. This value should be assignable to <see cref="LambdaExpression"/>
		/// </param>
		/// <returns>
		/// A <see cref="MemberInfo"/> object derived from the provided parameter <paramref name="this"/> 
		/// </returns>
		public static MemberInfo GetMemberInfo(
			[NotNull] this Expression @this)
		{
			@this.IsNotNull(nameof(@this));

			var lambdaExpression = @this as LambdaExpression;
			if (lambdaExpression == null)
				throw new ArgumentException(
					$"The expression value {@this.Type.Name.SQuote()} is not valid for the" +
					$"parameter \'@this\' because it is not assignable to type \'LambdaExpression\'.");

			return lambdaExpression
				.GetEmbodiedMemberExpression()
				.Member;
		}
		/// <summary>
		/// Gets the deconstructed embodied <see cref="MemberExpression"/> of the subject <paramref name="this"/>'s
		/// <see cref="LambdaExpression.Body"/> property.
		/// </summary> 
		/// <param name="this">
		/// The <see cref="LambdaExpression"/> object that provides the Body in which to extract a 
		/// <see cref="MemberExpression"/> from.
		/// </param>
		/// <remarks>
		/// The subject's <see cref="LambdaExpression.Body"/> property must be assignable to either
		/// the type <see cref="MemberExpression"/> or <see cref="UnaryExpression"/> for use in this method.
		/// </remarks> 
		/// <returns>
		/// Returns the <see cref="MemberExpression"/> object of the Embodied targeteted <see cref="MemberExpression"/> 
		/// represented by the <see cref="LambdaExpression"/> subject.
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
						.IsOfType<MemberExpression>();
					
				default:
					throw new NotSupportedException(
						$"The LambdaExpression \'@this\' parameter's \'Body\' property type " +
						$"{@this.Body.Type.Name.SQuote()} is not supported for conversion to type " +
						$"\'MemberExpression\'. The Body Expression type should either be a \'MemberExpression\'" +
						$"or a \'UnaryExpression\' to be used with this conversion method.");
			}
		}
	}
}
