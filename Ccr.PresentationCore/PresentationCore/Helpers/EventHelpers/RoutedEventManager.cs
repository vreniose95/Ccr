using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Ccr.Std.Extensions;
using Ccr.Std.Introspective.Extensions;
using Ccr.Std.Introspective.Infrastructure;

namespace Ccr.PresentationCore.Helpers.EventHelpers
{
	public static class EventRouteExtensions
	{
		public static RoutedEvent GetReflectedRoutedEvent(
			this EventRoute @this)
		{
			return @this
				.Reflect()
				.GetPropertyValue<RoutedEvent>(
					MemberDescriptor.NonPublic,
					"RoutedEvent");
		}

		public static void SetReflectedRoutedEvent(
			this EventRoute @this,
			RoutedEvent value)
		{
			@this
				.Reflect()
				.SetPropertyValue(
					MemberDescriptor.NonPublic,
					"RoutedEvent",
					value);
		}

		public static void ClearRefl(
			this EventRoute @this)
		{
			@this
				.Reflect()
				.InvokeMethod(
					MemberDescriptor.NonPublic,
					"Clear");
		}
	}

	internal static class EventRouteFactory
	{
		private static object _synchronized = new object();
		private static EventRoute[] _eventRouteStack;
		private static int _stackTop;


		internal static EventRoute FetchObject(
			RoutedEvent routedEvent)
		{
			var eventRoute = Pop();
			if (eventRoute == null)
				eventRoute = new EventRoute(routedEvent);
			else
				eventRoute.SetReflectedRoutedEvent(routedEvent);
			return eventRoute;
		}

		internal static void RecycleObject(
			EventRoute eventRoute)
		{
			eventRoute.ClearRefl();
			Push(eventRoute);
		}

		private static void Push(EventRoute eventRoute)
		{
			lock (_synchronized)
			{
				if (_eventRouteStack == null)
				{
					_eventRouteStack = new EventRoute[2];
					_stackTop = 0;
				}
				if (_stackTop >= 2)
					return;
				_eventRouteStack[_stackTop++] = eventRoute;
			}
		}

		private static EventRoute Pop()
		{
			lock (_synchronized)
			{
				if (_stackTop > 0)
				{
					var eventRoute = _eventRouteStack[--_stackTop];
					_eventRouteStack[_stackTop] = null;
					return eventRoute;
				}
			}
			return null;
		}
	}


	//public static class RoutedEventManager
	//{
	//	private static readonly IReadOnlyDictionary<MouseButton, Dictionary<RoutedEvent, RoutedEvent>> _mouseEventMap
	//		= new Dictionary<MouseButton, Dictionary<RoutedEvent, RoutedEvent>>
	//		{
	//			[MouseButton.Left] = new Dictionary<RoutedEvent, RoutedEvent>
	//			{
	//				[Mouse.MouseDownEvent] = UIElement.MouseLeftButtonDownEvent,
	//				[Mouse.MouseUpEvent] = UIElement.MouseLeftButtonUpEvent,
	//				[Mouse.PreviewMouseDownEvent] = UIElement.PreviewMouseLeftButtonDownEvent,
	//				[Mouse.PreviewMouseUpEvent] = UIElement.MouseLeftButtonDownEvent
	//			},
	//			[MouseButton.Right] = new Dictionary<RoutedEvent, RoutedEvent>
	//			{
	//				[Mouse.MouseDownEvent] = UIElement.MouseRightButtonDownEvent,
	//				[Mouse.MouseUpEvent] = UIElement.MouseRightButtonUpEvent,
	//				[Mouse.PreviewMouseDownEvent] = UIElement.PreviewMouseRightButtonDownEvent,
	//				[Mouse.PreviewMouseUpEvent] = UIElement.MouseRightButtonDownEvent
	//			},
	//		};


	//	public static RoutedEvent CrackMouseButtonEvent(
	//		MouseButtonEventArgs args)
	//	{
	//		if(!_mouseEventMap.TryGetValue(args.ChangedButton, out var routedEventMap))
	//			throw new KeyNotFoundException();

	//		if(!routedEventMap.TryGetValue(args.RoutedEvent, out var routedEvent))
	//			throw new KeyNotFoundException();

	//		return routedEvent;
	//	}


	//	public static void CrackMouseButtonEventAndReRaiseEvent(
	//		DependencyObject sender, 
	//		MouseButtonEventArgs args)
	//	{
	//		var newEvent = CrackMouseButtonEvent(args);
	//		if (newEvent == null)
	//			return;

	//		ReRaiseEventAs(sender, args, newEvent);
	//	}

	//	public static void ReRaiseEventAs(DependencyObject sender, RoutedEventArgs args, RoutedEvent newEvent)
	//	{
	//		var routedEvent = args.RoutedEvent;
	//		args.OverrideRoutedEvent(newEvent);
	//		object source = args.Source;
	//		EventRoute eventRoute = EventRouteFactory.FetchObject(args.RoutedEvent);
	//		if (TraceRoutedEvent.IsEnabled)
	//			TraceRoutedEvent.Trace(TraceEventType.Start, TraceRoutedEvent.ReRaiseEventAs, (object)args.RoutedEvent, (object)sender, (object)args, (object)args.Handled);
	//		try
	//		{
	//			UIElement.BuildRouteHelper(sender, eventRoute, args);
	//			eventRoute.ReInvokeHandlers((object)sender, args);
	//			args.OverrideSource(source);
	//			args.OverrideRoutedEvent(routedEvent);
	//		}
	//		finally
	//		{
	//			if (TraceRoutedEvent.IsEnabled)
	//				TraceRoutedEvent.Trace(TraceEventType.Stop, TraceRoutedEvent.ReRaiseEventAs, (object)args.RoutedEvent, (object)sender, (object)args, (object)args.Handled);
	//		}
	//		EventRouteFactory.RecycleObject(eventRoute);
	//	}

	//	public static void RaiseEventImpl(DependencyObject sender, RoutedEventArgs args)
	//	{
	//		EventRoute eventRoute = EventRouteFactory.FetchObject(args.RoutedEvent);
	//		if (TraceRoutedEvent.IsEnabled)
	//			TraceRoutedEvent.Trace(TraceEventType.Start, TraceRoutedEvent.RaiseEvent, (object)args.RoutedEvent, (object)sender, (object)args, (object)args.Handled);
	//		try
	//		{
	//			args.Source = (object)sender;
	//			UIElement.BuildRouteHelper(sender, eventRoute, args);
	//			eventRoute.InvokeHandlers((object)sender, args);
	//			args.Source = args.OriginalSource;
	//		}
	//		finally
	//		{
	//			if (TraceRoutedEvent.IsEnabled)
	//				TraceRoutedEvent.Trace(TraceEventType.Stop, TraceRoutedEvent.RaiseEvent, (object)args.RoutedEvent, (object)sender, (object)args, (object)args.Handled);
	//		}
	//		EventRouteFactory.RecycleObject(eventRoute);
	//	}
	}
