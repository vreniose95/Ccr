using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using Ccr.Core.Extensions;
using Ccr.PresentationCore.Helpers;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using Ccr.Std.Introspective.Extensions;
using Ccr.Std.Introspective.Infrastructure;
using JetBrains.Annotations;

namespace Ccr.MaterialDesign.Primitives.Behaviors.Services
{
  [XamlSetMarkupExtension("XamlSetMarkupExtensiom")]
  public class RippleMouseTracker
    : HostedElement<FrameworkElement>
  {
    private static readonly Type type = typeof(RippleMouseTracker);


    public static readonly DependencyProperty SourceObjectProperty = DP.Register(
      new Meta<RippleMouseTracker, object>(null, onSourceObjectChanged));

    public static readonly DependencyProperty EventNameProperty = DP.Register(
      new Meta<RippleMouseTracker, string>(null, onEventNameChanged));


    public object SourceObject
    {
      get => GetValue(SourceObjectProperty);
      set => SetValue(SourceObjectProperty, value);
    }

    public string EventName
    {
      get => (string)GetValue(EventNameProperty);
      set => SetValue(EventNameProperty, value);
    }



    private static void onSourceObjectChanged(
      RippleMouseTracker @this,
      DPChangedEventArgs<object> args)
    {
      @this.onTargetChanged();
    }

    private static void onEventNameChanged(
      RippleMouseTracker @this,
      DPChangedEventArgs<string> args)
    {
      @this.onTargetChanged();
    }


    private void onTargetChanged()
    {
      if (SourceObject == null || EventName.IsNullOrWhiteSpace())
        return;

      RegisterEventHandler(SourceObject, EventName);
    }


    private MethodInfo eventHandlerMethodInfo;

    protected void RegisterEventHandler(
      [NotNull] object sourceObject,
      [NotNull] string eventName)
    {
      sourceObject.IsNotNull(nameof(sourceObject));
      eventName.IsNotNull(nameof(eventName));

      var sourceObjectType = sourceObject.GetType();

      var eventInfo = sourceObjectType
        .GetEvent(eventName);

      if (eventInfo == null)
        throw new ArgumentException(
          $"The {nameof(RippleMouseTracker).SQuote()} cannot find an event with the name " +
          $"{eventName.Quote()} in the sourceObject type {sourceObjectType.Name.SQuote()}.",
          nameof(eventName));

      if (!IsValidEvent(eventInfo))
        throw new ArgumentException(
          $"The event that matches the specified binding constraints with the name " +
          $"{eventName.Quote()} in the sourceObject type {sourceObjectType.Name.SQuote()} " +
          $"is not a valid event.",
          nameof(eventName));

      eventHandlerMethodInfo = type.GetMethod(
        "OnEventImpl",
        BindingFlags.Instance | BindingFlags.NonPublic);

     if (eventHandlerMethodInfo == null)
       throw new InvalidOperationException(
         $"Cannot find the method ");

      var handlerDelegate = Delegate.CreateDelegate(
        eventInfo.EventHandlerType,
        this,
        eventHandlerMethodInfo);

      eventInfo.AddEventHandler(
        sourceObject,
        handlerDelegate);
    }


    private static bool IsValidEvent(
      EventInfo eventInfo)
    {
      var eventHandlerType = eventInfo.EventHandlerType;
      
      if (!typeof(Delegate).IsAssignableFrom(eventHandlerType))
        return false;

      var invokeMethod = eventHandlerType
        .GetMethod("Invoke");

      if (invokeMethod == null)
        return false;

      var parameters = invokeMethod
        .GetParameters();

      if (parameters.Length == 2)
        return typeof(EventArgs)
          .IsAssignableFrom(
            parameters[1]
              .ParameterType);

      return false;
    }



    protected void OnEventImpl(object sender, EventArgs args)
    {
      var mousePos = Mouse.GetPosition(HostElement);
      Ripple.SetMousePosition(HostElement, mousePos);
    }


    public static void XamlSetMarkupExtensiom(
      [NotNull] object targetObject,
      [NotNull] XamlSetMarkupExtensionEventArgs eventArgs)
    {
      targetObject.IsNotNull(nameof(targetObject));
      eventArgs.IsNotNull(nameof(eventArgs));
      
      var binding = eventArgs
        .Value
        .As<Binding>();

      var relativeSource = binding
        .RelativeSource;

      if(relativeSource.Mode != RelativeSourceMode.FindAncestor)
        throw new NotSupportedException(
          $"The RelativeSource Binding Mode {relativeSource.Mode.ToString().SQuote()} is not " +
          $"supported.");

      var memberInvoker = eventArgs
        .Member
        .Invoker;

      var _xamlContext = eventArgs
        .ServiceProvider
        .Reflect()
        .GetFieldValue<object>(
          MemberDescriptor.NonPublic,
          "_xamlContext");

      var grandParentInstance = _xamlContext
        .Reflect()
        .GetPropertyValue<FrameworkElement>(
          MemberDescriptor.Any,
          "GrandParentInstance");


      var ancestor = grandParentInstance.FindParent(
        relativeSource.AncestorType);

      memberInvoker.SetValue(
        targetObject,
        ancestor);

      eventArgs.Handled = true;
    }
  }
}