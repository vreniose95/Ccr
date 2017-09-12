using System;
using System.Linq.Expressions;
using System.Reflection;
using JetBrains.Annotations;

namespace Ccr.Core.Extensions
{
	/// <summary>
	/// Extension methods for <see cref="T:Expression"/> subjects.
	/// </summary>
	public static class ExpressionExtensions
	{
		/// <summary>
		/// Converts an <see cref="T:Expression"/> into a <see cref="T:MemberInfo"/> 
		/// </summary>
		/// <param name="this">
		/// The expression to convert. This value should be assignable to <see cref="T:LambdaExpression"/>
		/// </param>
		/// <returns>
		/// A <see cref="T:MemberInfo"/> object derived from the provided parameter 
		/// <paramref name="this"/> 
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


			return (!(lambdaExpression.Body is UnaryExpression) ? (MemberExpression)lambdaExpression.Body : (MemberExpression)((UnaryExpression)lambdaExpression.Body).Operand).Member;
		}
	}
}
