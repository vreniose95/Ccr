using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Ccr.Std.Core.Numerics.Infrastructure;
using Ccr.Std.Core.Numerics.Ranges;
using JetBrains.Annotations;
using static Ccr.Std.Core.Numerics.Infrastructure.EndpointExclusivity;
using static JetBrains.Annotations.AssertionConditionType;

// ReSharper disable BuiltInTypeReferenceStyle
namespace Ccr.Std.Core.Extensions.NumericExtensions
{
	public static class Int16Extensions
	{
		/// <summary>
		///		Extension method that uses the non-generic <see cref="IComparer"/> interface to compare the 
		///		<see cref="Int16"/> subject with the provided <paramref name="value"/> parameter, and returns 
		///		the largest numeric <see cref="Int16"/> value of the two.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="Int16"/> to perform the comparison upon.
		/// </param>
		/// <param name="value">
		///		The value of type <see cref="Int16"/> in which to perform the comparison against the extension 
		///		method's subject, the <paramref name="this"/> parameter.
		/// </param>
		/// <returns>
		///		Compares the extention method's <see cref="Int16"/> subject and the <paramref name="value"/> 
		///		parameter, and returns the largest numeric <see cref="Int16"/> value of the two. 
		/// </returns>
		public static Int16 Smallest(
			this Int16 @this,
			Int16 value)
		{
			return @this < value
				? value
				: @this;
		}

		/// <summary>
		///		Extension method that uses the non-generic <see cref="IComparer"/> interface to compare the 
		///		<see cref="Int16"/> subject with the provided <paramref name="value"/> parameter, and returns 
		///		the largest numeric <see cref="Int16"/> value of the two.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="Int16"/> to perform the comparison upon.
		/// </param>
		/// <param name="value">
		///		The value of type <see cref="Int16"/> in which to perform the comparison against the extension 
		///		method's subject, the <paramref name="this"/> parameter.
		/// </param>
		/// <returns>
		///		Compares the extention method's <see cref="Int16"/> subject and the <paramref name="value"/> 
		///		parameter, and returns the largest numeric <see cref="Int16"/> value of the two. 
		/// </returns>
		public static Int16 Largest(
			this Int16 @this,
			Int16 value)
		{
			return @this > value
				? value
				: @this;
		}

		/// <summary>
		///		Extension method that performs a transformation on the <see cref="Int16"/> subject using
		///		linear mapping to re-map from the provided initial range <paramref name="startRange"/> 
		///		to the target range <paramref name="endRange"/>.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="Int16"/> to perform the linear map range re-mapping upon.
		/// </param>
		/// <param name="startRange">
		///		An instance of the type <see cref="Int16Range"/>, describing a range of numeric values in 
		///		which the linear re-mapping uses as the inital range of the subject.
		/// </param>
		/// <param name="endRange">
		///		An instance of the type <see cref="Int16Range"/>, describing a range of numeric values in
		///		which the linear re-mapping uses as the target range of the return value.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///		Thrown when either the <paramref name="startRange"/> or the <paramref name="endRange"/> 
		///		parameters are equal to <see langword="null"/>.
		///	</exception>
		/// <returns>
		///		A <see cref="Int16"/> value that has been linearly mapped to the <paramref name="startRange"/>
		///		parameter and re-mapped to the <paramref name="endRange"/> parameter.
		/// </returns>
		public static Int16 LinearMap(
			this Int16 @this,
			[NotNull] Int16Range startRange,
			[NotNull] Int16Range endRange)
		{
			startRange.IsNotNull(nameof(startRange));
			endRange.IsNotNull(nameof(endRange));

			return (
					(@this - startRange.Minimum) *
					(endRange.Maximum - endRange.Minimum) /
					(startRange.Maximum - startRange.Minimum) +
					endRange.Minimum)
				.To<Int16>();
		}

		/// <summary>
		///		Extension method that allows for <see cref="IntegralRangeBase{TIntegralType}.IsWithin"/> 
		///		to be called on a <see cref="Int16"/> subject with the range and exclusivity passed as a 
		///		parameter, rather than on the <see cref="IntegralRangeBase{TIntegralType}"/> object 
		///		with a <see cref="Int16"/> parameter.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="Int16"/> value in which to check against the <paramref name="range"/>
		///		parameter to determine whether it is within the range, taking into account the exclusivity.
		/// </param>
		/// <param name="range">
		///		An instance of the type <see cref="Int16Range"/>, describing a range of numeric values in 
		///		which the <paramref name="this"/> subject is to be compared against.
		/// </param>
		/// <param name="exclusivity">
		///		A value indicating whether to perform the upper and lower bounds comparisons including
		///		the range's Minimum and Maximum bounds, or to exclude them. This parameter is optional,
		///		and the default value is <see cref="EndpointExclusivity.Inclusive"/>.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///		Thrown when the specified <paramref name="range"/> is <see langword="null"/>.
		///	</exception>
		/// <returns>
		///		A <see cref="bool"/> value indicating whether or not the <paramref name="this"/> subject
		///		is within the provided <paramref cref="range"/> parameter, taking into account the 
		///		<see cref="EndpointExclusivity"/> mode via the <paramref name="exclusivity"/> parameter.
		/// </returns>
		public static bool IsWithin(
			this Int16 @this,
			[NotNull] Int16Range range,
			EndpointExclusivity exclusivity = Inclusive)
		{
			range.IsNotNull(nameof(range));

			return range
				.IsWithin(
					@this,
					exclusivity);
		}

		/// <summary>
		///		Extension method that allows for <see cref="IntegralRangeBase{TIntegralType}.IsNotWithin"/> 
		///		to be called on a <see cref="Int16"/> subject with the range and exclusivity passed as a
		///		parameter, rather than on the <see cref="IntegralRangeBase{TIntegralType}"/> object 
		///		with a <see cref="Int16"/> parameter.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="Int16"/> value in which to check against the <paramref name="range"/>
		///		parameter to determine whether it is within the range, taking into account the exclusivity.
		/// </param>
		/// <param name="range">
		///		An instance of the type <see cref="Int16Range"/>, describing a range of numeric values in 
		///		which the <paramref name="this"/> subject is to be compared against.
		/// </param>
		/// <param name="exclusivity">
		///		A value indicating whether to perform the upper and lower bounds comparisons including
		///		the range's Minimum and Maximum bounds, or to exclude them. This parameter is optional,
		///		and the default value is <see cref="EndpointExclusivity.Inclusive"/>.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///		Thrown when the specified <paramref name="range"/> is <see langword="null"/>.
		///	</exception>
		/// <returns>
		///		A <see cref="Int16"/> value indicating whether or not the <paramref name="this"/> subject
		///		is within the provided <paramref cref="range"/> parameter, taking into account the 
		///		<see cref="EndpointExclusivity"/> mode via the <paramref name="exclusivity"/> parameter.
		///		This comparison is the logical inverse of the <see cref="IsNotWithin"/> extension method.
		/// </returns>
		public static bool IsNotWithin(
			this Int16 @this,
			[NotNull] Int16Range range,
			EndpointExclusivity exclusivity = Inclusive)
		{
			range.IsNotNull(nameof(range));

			return range
				.IsNotWithin(
					@this,
					exclusivity);
		}

		/// <summary>
		///		Extension method that allows for <see cref="IntegralRangeBase{TIntegralType}.Constrain"/> 
		///		to be called on a <see cref="Int16"/> subject with the range and exclusivity passed as a
		///		parameter, rather than on the <see cref="IntegralRangeBase{TIntegralType}"/> object 
		///		with a <see cref="Int16"/> parameter.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="Int16"/> value in which to check against the <paramref name="range"/>
		///		parameter to constrain a value within a range with an implicit inclusive comparison mode.
		/// </param>
		/// <param name="range">
		///		An instance of the type <see cref="Int16Range"/>, describing a range of numeric values in 
		///		which the <paramref name="this"/> subject is to be compared against.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///		Thrown when the specified <paramref name="range"/> is <see langword="null"/>.
		///	</exception>
		/// <returns>
		///		A <see cref="Int16"/> value that is the <paramref name="this"/> subject value adjusted to
		///		force the range of possible values to be within the provided <paramref cref="range"/> 
		///		parameter, using <see cref="EndpointExclusivity.Inclusive"/> as the comparison mode.
		/// </returns>
		public static Int16 Constrain(
			this Int16 @this,
			[NotNull] Int16Range range)
		{
			range.IsNotNull(nameof(range));

			return range
				.Constrain(
					@this);
		}




	  [ContractAnnotation("this:null => halt"), AssertionMethod]
	  public static void ThrowIfWithin(
	    [AssertionCondition(IS_NOT_NULL)] this Int16 @this,
	    [NotNull] Int16Range range,
	    [InvokerParameterName] string elementName,
	    EndpointExclusivity exclusivity = Inclusive,
	    [CallerMemberName] string callerMemberName = "")
	  {
	    range.IsNotNull(nameof(range));

	    if (range
	      .IsWithin(
	        @this,
	        exclusivity))
	      throw new ArgumentOutOfRangeException(
	        elementName,
	        $"Parameter {elementName.SQuote()} passed to the method {callerMemberName.SQuote()} " +
	        $"cannot be within [{range.Minimum} and {range.Maximum}], {exclusivity}ly.");
	  }

	  [ContractAnnotation("this:null => halt"), AssertionMethod]
	  public static void ThrowIfNotWithin(
	    [AssertionCondition(IS_NOT_NULL)] this Int16 @this,
	    [NotNull] Int16Range range,
	    [InvokerParameterName] string elementName,
	    EndpointExclusivity exclusivity = Inclusive,
	    [CallerMemberName] string callerMemberName = "")
	  {
	    range.IsNotNull(nameof(range));

	    if (range
	      .IsNotWithin(
	        @this,
	        exclusivity))
	      throw new ArgumentOutOfRangeException(
	        elementName,
	        $"Parameter {elementName.SQuote()} passed to the method {callerMemberName.SQuote()} " +
	        $"must be within [{range.Minimum} and {range.Maximum}], {exclusivity}ly.");
	  }
  }
}