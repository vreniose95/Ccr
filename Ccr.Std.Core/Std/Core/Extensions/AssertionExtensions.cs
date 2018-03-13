using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using static JetBrains.Annotations.AssertionConditionType;

namespace Ccr.Std.Core.Extensions
{
  public static class AssertionExtensions
  {
    [ContractAnnotation("this:null => halt"), AssertionMethod]
    public static void IsNotNull<TValue>(
      [AssertionCondition(IS_NOT_NULL), NotNull] this TValue @this,
      [InvokerParameterName] string elementName, 
      [CallerMemberName] string callerMemberName = "") 
        where TValue
          : class
    {
      if (@this == null)
        throw new NullReferenceException(
          $"The element {elementName.SQuote()} passed to the " +
          $"method {callerMemberName.SQuote()} cannot be null.");
    }

    [ContractAnnotation("this:null => halt"), AssertionMethod]
    public static void IsNotNull<TValue>(
      [AssertionCondition(IS_NOT_NULL), NotNull] this TValue? @this,
      [InvokerParameterName] string elementName,
      [CallerMemberName] string callerMemberName = "")
        where TValue
          : struct
    {
      if (@this == null)
        throw new NullReferenceException(
          $"The element {elementName.SQuote()} passed to the " +
          $"method {callerMemberName.SQuote()} cannot be null.");
    }


    [ContractAnnotation("this:null => halt"), AssertionMethod]
    public static void ArgIsNotNull(
      [AssertionCondition(IS_NOT_NULL), NotNull] this object @this,
      [InvokerParameterName] string elementName,
      [CallerMemberName] string callerMemberName = "")
    {
      if (@this == null)
        throw new NullReferenceException(
          $"The element {elementName.SQuote()} passed to the " +
          $"method {callerMemberName.SQuote()} cannot be null.");
    }



  }
}
