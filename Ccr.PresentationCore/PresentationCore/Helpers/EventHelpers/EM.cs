using System;
using System.Runtime.CompilerServices;
using System.Windows;
using Ccr.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.PresentationCore.Helpers.EventHelpers
{
	//public static class EMX
	//{
	//	public const RoutingStrategy BUBBLE = RoutingStrategy.Bubble;
	//	public const RoutingStrategy DIRECT = RoutingStrategy.Direct;
	//	public const RoutingStrategy TUNNEL = RoutingStrategy.Tunnel;

	//	public static RoutedEvent Register<D, H>(RoutingStrategy rs, [CallerMemberName] string afn = null)
	//		where H : class where D : UIElement
	//	{
	//		if (!typeof(H).IsSubclassOf(typeof(Delegate)))
	//			throw new InvalidOperationException($"{typeof(H).Name} is not a delegate type.");
	//		return EventManager.RegisterRoutedEvent(GetEventName(afn), rs, typeof(H), typeof(D));
	//	}

	//	internal static string GetEventName(string autoFieldName)
	//	{
	//		if (autoFieldName == null)
	//			throw new Exception(FSR.DP.AutoCallerNameNotAssigned());
	//		if (!autoFieldName.EndsWith("Event"))
	//			throw new Exception(FSR.DP.AutoCallerNameNotValid(autoFieldName));
	//		return autoFieldName.Replace("Event", string.Empty);
	//	}
	//}

	public static class EM
	{
		public const RoutingStrategy BUBBLE = RoutingStrategy.Bubble;
		public const RoutingStrategy DIRECT = RoutingStrategy.Direct;
		public const RoutingStrategy TUNNEL = RoutingStrategy.Tunnel;


		private const string RoutedEventFieldSuffix = "Event";


		public static RoutedEvent Register<TOwner, TCallback>(
			RoutingStrategy routingStrategy,
			[CallerMemberName, UsedImplicitly, NotNull] string callerMemberName = "")
				where TOwner : UIElement
				where TCallback : class
		{
			if (!typeof(TCallback).IsSubclassOf(typeof(Delegate)))
				throw new InvalidOperationException(
					$"\'{typeof(TCallback).Name}\' is not a delegate type.");

			return EventManager.RegisterRoutedEvent(
				GetEventName(callerMemberName),
				routingStrategy,
				typeof(TCallback),
				typeof(TOwner));
		}


		public static void RegisterClassHandler<TOwner, TCallback>(
			[NotNull] RoutedEvent routedEvent,
			TCallback callback,
			bool handlesEventsToo = false)
				where TOwner : UIElement
				where TCallback : class
		{
			if (!typeof(TCallback).IsSubclassOf(typeof(Delegate)))
				throw new InvalidOperationException(
					$"\'{typeof(TCallback).Name}\' is not a delegate type.");

			EventManager.RegisterClassHandler(
				typeof(TOwner),
				routedEvent,
				callback.As<Delegate>(),
				handlesEventsToo);
		}


		internal static string GetEventName(
			[NotNull] string callerMemberName)
		{
			if (callerMemberName == null)
				throw new ArgumentNullException(
					nameof(callerMemberName),
					"The parameter callerMemberName cannot be null.");

			if (!callerMemberName.EndsWith(RoutedEventFieldSuffix))
				throw new ArgumentException(
					nameof(callerMemberName),
					$"The caller member name \"{callerMemberName}\" is not a valid event name.");

			if (callerMemberName.IsNullOrWhiteSpace())
				throw new ArgumentException(
					nameof(callerMemberName),
					$"The caller member name \"{callerMemberName}\" is not provided.");

			var eventNameLength = callerMemberName.Length - RoutedEventFieldSuffix.Length;
			var eventName = callerMemberName.Substring(0, eventNameLength);
			return eventName;
		}
	}
}
