using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using Ccr.Core.Extensions;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using JetBrains.Annotations;

namespace Ccr.MaterialDesign.Primitives.Behaviors.Services
{
	public class RippleMouseTracker :
		HostedElement<FrameworkElement>
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
			sourceObject.IsNotNull("sourceObject");
			eventName.IsNotNull("eventName");

			var eventInfo = sourceObject.GetType()
				.GetEvent(eventName);

			if (eventInfo == null)
				throw new ArgumentException(
					$"RippleMouseTracker cannot find event with the name \"{eventName}\" " +
					$"in the source object of type \'{sourceObject.GetType().Name}\'.");
			
			if (!IsValidEvent(eventInfo))
				throw new ArgumentException(
					$"The event that matches the specified binding constraints with the name " +
					$"\"{eventName}\" in the source object of type \'{sourceObject.GetType().Name}\'" +
					$"is not a valid event.");

			eventHandlerMethodInfo = type.GetMethod(
				"OnEventImpl", 
				BindingFlags.Instance | BindingFlags.NonPublic);

			var handlerDelegate = Delegate.CreateDelegate(
				eventInfo.EventHandlerType,
				this,
				eventHandlerMethodInfo);

			eventInfo.AddEventHandler(
				sourceObject,
				handlerDelegate);
		}
		

		private static bool IsValidEvent(EventInfo eventInfo)
		{
			var eventHandlerType = eventInfo.EventHandlerType;
			if (!typeof(Delegate).IsAssignableFrom(eventHandlerType))
				return false;

			var parameters = eventHandlerType
				.GetMethod("Invoke")
				.GetParameters();

			if (parameters.Length == 2)
				return typeof(EventArgs).IsAssignableFrom(
					parameters[1].ParameterType);
			return false;
		}



		protected void OnEventImpl(object sender, EventArgs args)
		{
			var mousePos = Mouse.GetPosition(HostElement);
			Ripple.SetMousePosition(HostElement, mousePos);
		}
	}
}
