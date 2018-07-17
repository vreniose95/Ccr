using System.Windows;
using Ccr.Introspective.Extensions;
using Ccr.Introspective.Infrastructure;

namespace Ccr.Core.Extensions
{
  /// <summary>
  ///   Control Extensions and Helper Methods
  /// </summary>
  public static class ControlExtensions
  {
    /// <summary>
    ///   Overrides the <see cref="DependencyProperty.DefaultMetadata"/> for the type
    ///   <typeparamref name="TOwner"/> using the DependencyProperty metadata system.
    /// </summary>
    /// <typeparam name="TOwner">
    ///   The type of the <see cref="FrameworkElement"/> to override for.
    /// </typeparam>
    public static void OverrideStyleKey<TOwner>()
      where TOwner
      : FrameworkElement
    {
      var defaultStyleKeyDependencyProperty =
        typeof(FrameworkElement)
          .Reflect()
          .GetFieldValue<DependencyProperty>(
            MemberDescriptor.NonPublicStatic,
            "DefaultStyleKeyProperty");

      defaultStyleKeyDependencyProperty
        .OverrideMetadata(
          typeof(TOwner),
          new FrameworkPropertyMetadata(
            typeof(TOwner)));
    }


    public static void GoToVisualState(
      this FrameworkElement @this, 
      string state,
      bool withTransitions = true)
    {
      VisualStateManager.GoToState(
        @this, 
        state,
        withTransitions);
    }
  }
}