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
	public static class SingleExtensions
	{
		/// <summary>
		///		Extension method that uses the non-generic <see cref="IComparer"/> interface to compare the 
		///		<see cref="Single"/> subject with the provided <paramref name="value"/> parameter, and returns 
		///		the largest numeric <see cref="Single"/> value of the two.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="Single"/> to perform the comparison upon.
		/// </param>
		/// <param name="value">
		///		The value of type <see cref="Single"/> in which to perform the comparison against the extension 
		///		method's subject, the <paramref name="this"/> parameter.
		/// </param>
		/// <returns>
		///		Compares the extention method's <see cref="Single"/> subject and the <paramref name="value"/> 
		///		parameter, and returns the largest numeric <see cref="Single"/> value of the two. 
		/// </returns>
		public static Single Smallest(
			this Single @this,
			Single value)
		{
			return @this < value
				? value
				: @this;
		}

		/// <summary>
		///		Extension method that uses the non-generic <see cref="IComparer"/> interface to compare the 
		///		<see cref="Single"/> subject with the provided <paramref name="value"/> parameter, and returns 
		///		the largest numeric <see cref="Single"/> value of the two.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="Single"/> to perform the comparison upon.
		/// </param>
		/// <param name="value">
		///		The value of type <see cref="Single"/> in which to perform the comparison against the extension 
		///		method's subject, the <paramref name="this"/> parameter.
		/// </param>
		/// <returns>
		///		Compares the extention method's <see cref="Single"/> subject and the <paramref name="value"/> 
		///		parameter, and returns the largest numeric <see cref="Single"/> value of the two. 
		/// </returns>
		public static Single Largest(
			this Single @this,
			Single value)
		{
			return @this > value
				? value
				: @this;
		}

		/// <summary>
		///		Extension method that performs a transformation on the <see cref="Single"/> subject using
		///		linear mapping to re-map from the provided initial range <paramref name="startRange"/> 
		///		to the target range <paramref name="endRange"/>.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="Single"/> to perform the linear map range re-mapping upon.
		/// </param>
		/// <param name="startRange">
		///		An instance of the type <see cref="SingleRange"/>, describing a range of numeric values in 
		///		which the linear re-mapping uses as the inital range of the subject.
		/// </param>
		/// <param name="endRange">
		///		An instance of the type <see cref="SingleRange"/>, describing a range of numeric values in
		///		which the linear re-mapping uses as the target range of the return value.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///		Thrown when either the <paramref name="startRange"/> or the <paramref name="endRange"/> 
		///		parameters are equal to <see langword="null"/>.
		///	</exception>
		/// <returns>
		///		A <see cref="Single"/> value that has been linearly mapped to the <paramref name="startRange"/>
		///		parameter and re-mapped to the <paramref name="endRange"/> parameter.
		/// </returns>
		public static Single LinearMap(
			this Single @this,
			[NotNull] SingleRange startRange,
			[NotNull] SingleRange endRange)
		{
			startRange.IsNotNull(nameof(startRange));
			endRange.IsNotNull(nameof(endRange));

			return (
					(@this - startRange.Minimum) *
					(endRange.Maximum - endRange.Minimum) /
					(startRange.Maximum - startRange.Minimum) +
					endRange.Minimum)
				.To<Single>();
		}

		/// <summary>
		///		Extension method that allows for <see cref="NonIntegralRangeBase{TNonIntegralType}.IsWithin"/> 
		///		to be called on a <see cref="Single"/> subject with the range and exclusivity passed as a 
		///		parameter, rather than on the <see cref="NonIntegralRangeBase{TIntegralType}"/> object 
		///		with a <see cref="Single"/> parameter.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="Single"/> value in which to check against the <paramref name="range"/>
		///		parameter to determine whether it is within the range, taking into account the exclusivity.
		/// </param>
		/// <param name="range">
		///		An instance of the type <see cref="SingleRange"/>, describing a range of numeric values in 
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
			this Single @this,
			[NotNull] SingleRange range,
			EndpointExclusivity exclusivity = Inclusive)
		{
			range.IsNotNull(nameof(range));

			return range
				.IsWithin(
					@this,
					exclusivity);
		}

		/// <summary>
		///		Extension method that allows for <see cref="NonIntegralRangeBase{TIntegralType}.IsNotWithin"/> 
		///		to be called on a <see cref="Single"/> subject with the range and exclusivity passed as a
		///		parameter, rather than on the <see cref="NonIntegralRangeBase{TIntegralType}"/> object 
		///		with a <see cref="Single"/> parameter.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="Single"/> value in which to check against the <paramref name="range"/>
		///		parameter to determine whether it is within the range, taking into account the exclusivity.
		/// </param>
		/// <param name="range">
		///		An instance of the type <see cref="SingleRange"/>, describing a range of numeric values in 
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
		///		A <see cref="Single"/> value indicating whether or not the <paramref name="this"/> subject
		///		is within the provided <paramref cref="range"/> parameter, taking into account the 
		///		<see cref="EndpointExclusivity"/> mode via the <paramref name="exclusivity"/> parameter.
		///		This comparison is the logical inverse of the <see cref="IsNotWithin"/> extension method.
		/// </returns>
		public static bool IsNotWithin(
			this Single @this,
			[NotNull] SingleRange range,
			EndpointExclusivity exclusivity = Inclusive)
		{
			range.IsNotNull(nameof(range));

			return range
				.IsNotWithin(
					@this,
					exclusivity);
		}

		/// <summary>
		///		Extension method that allows for <see cref="NonIntegralRangeBase{TIntegralType}.Constrain"/> 
		///		to be called on a <see cref="Single"/> subject with the range and exclusivity passed as a
		///		parameter, rather than on the <see cref="NonIntegralRangeBase{TIntegralType}"/> object 
		///		with a <see cref="Single"/> parameter.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="Single"/> value in which to check against the <paramref name="range"/>
		///		parameter to constrain a value within a range with an implicit inclusive comparison mode.
		/// </param>
		/// <param name="range">
		///		An instance of the type <see cref="SingleRange"/>, describing a range of numeric values in 
		///		which the <paramref name="this"/> subject is to be compared against.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///		Thrown when the specified <paramref name="range"/> is <see langword="null"/>.
		///	</exception>
		/// <returns>
		///		A <see cref="Single"/> value that is the <paramref name="this"/> subject value adjusted to
		///		force the range of possible values to be within the provided <paramref cref="range"/> 
		///		parameter, using <see cref="EndpointExclusivity.Inclusive"/> as the comparison mode.
		/// </returns>
		public static Single Constrain(
			this Single @this,
			[NotNull] SingleRange range)
		{
			range.IsNotNull(nameof(range));

			return range
				.Constrain(
					@this);
		}

	  [ContractAnnotation("this:null => halt"), AssertionMethod]
	  public static void ThrowIfWithin(
	    [AssertionCondition(IS_NOT_NULL)] this Single @this,
	    [NotNull] SingleRange range,
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
	    [AssertionCondition(IS_NOT_NULL)] this Single @this,
	    [NotNull] SingleRange range,
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



    public static Single Power(
	    this Single @this,
      Single exponent)
	  {
	    return (Single) Math.Pow(
        @this,
        exponent);
	  }


  }
}