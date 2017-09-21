using System;
using System.Windows;
using System.Windows.Media;
using Ccr.MaterialDesign.Primitives.Behaviors.Services;
using Ccr.PresentationCore.Helpers.DependencyHelpers;

namespace Ccr.MaterialDesign.Primitives.Behaviors
{
	public static class Ripple
	{
		private static readonly Type type = typeof(Ripple);


		public static readonly DependencyProperty TrackingServiceProperty = DP.Attach(type, 
			new MetaBase<RippleMouseTracker>(onTrackingServiceChanged));

		public static readonly DependencyProperty MousePositionProperty = DP.Attach(type,
			new MetaBase<Point>(new Point(0, 0)));

		public static readonly DependencyProperty PlacementProperty = DP.Attach(type,
			new MetaBase<Point>(new Point(0, 0), onPlacementChanged));



		public static RippleMouseTracker GetTrackingService(
			DependencyObject @this)
		{
			return @this.Get<RippleMouseTracker>(TrackingServiceProperty);
		}
		public static void SetTrackingService(
			DependencyObject @this,
			RippleMouseTracker value)
		{
			@this.Set(TrackingServiceProperty, value);
		}
		
		public static Point GetMousePosition(
			DependencyObject @this)
		{
			return @this.Get<Point>(MousePositionProperty);
		}
		public static void SetMousePosition(
			DependencyObject @this,
			Point value)
		{
			@this.Set(MousePositionProperty, value);
		}

		public static Point GetPlacement(
			DependencyObject @this)
		{
			return @this.Get<Point>(PlacementProperty);
		}
		public static void SetPlacement(
			DependencyObject @this,
			Point value)
		{
			@this.Set(PlacementProperty, value);
		}
		
		

		private static void onTrackingServiceChanged(
			DependencyObject @this,
			DPChangedEventArgs<RippleMouseTracker> args)
		{
			var frameworkElement = @this as FrameworkElement;
			if (frameworkElement == null)
				throw new NotSupportedException(
					$"The \'RippleAssist.InputTrackingService\' property cannot be set on the " +
					$"element type \'{@this.GetType().Name}\' because \'HostedElement<TElement>\'-based" +
					$"services require the host element to derive from \'FrameworkElement\'.");

			var newTrackingService = args.NewValue;
			var oldTrackingService = args.OldValue;

			oldTrackingService?.DetachHost();
			newTrackingService?.AttachHost(frameworkElement);
		}
		private static void onPlacementChanged(
			DependencyObject @this, 
			DPChangedEventArgs<Point> args)
		{
			var translateTransform = @this as TranslateTransform;
			if (translateTransform == null)
				return;

			translateTransform.X = args.NewValue.X;
			translateTransform.Y = args.NewValue.Y;
		}
	}
}
