using System.Windows;
using System.Windows.Input;
using Ccr.Std.Core.Extensions;

namespace Ccr.MaterialDesign.Primitives.Behaviors.Services
{
	public class UserInputNuanceProviderService
		: HostedElement<FrameworkElement>
	{
		protected override void OnHostAttached(DependencyObject host)
		{
			var frameworkElement = host.As<FrameworkElement>();

			frameworkElement.MouseMove += OnHostMouseMove;
			frameworkElement.IsMouseDirectlyOverChanged += OnIsMouseDirectlyOverHostChanged;

			frameworkElement.GotFocus += OnHostGotFocus;
			frameworkElement.LostFocus += OnHostLostFocus;

			frameworkElement.GotKeyboardFocus += OnHostGotKeyboardFocus;
			frameworkElement.LostKeyboardFocus += OnHostLostKeyboardFocus;

			frameworkElement.GotStylusCapture += OnHostGotStylusCapture;
			frameworkElement.LostStylusCapture += OnHostLostStylusCapture;

			frameworkElement.GotTouchCapture += OnHostGotTouchCapture;
			frameworkElement.LostTouchCapture += OnHostLostTouchCapture;

			frameworkElement.ManipulationStarting += OnHostManipulationStarting;
			frameworkElement.ManipulationStarted += OnHostManipulationStarted;
			frameworkElement.ManipulationInertiaStarting += OnHostManipulationInertiaStarting;
			frameworkElement.ManipulationDelta += OnHostManipulationDelta;
			frameworkElement.ManipulationBoundaryFeedback += OnHostManipulationBoundaryFeedback;
			frameworkElement.ManipulationCompleted += OnHostManipulationCompleted;

			base.OnHostAttached(host);
		}

		private void OnHostManipulationDelta(object sender, ManipulationDeltaEventArgs args)
		{
		}

		private void OnHostManipulationInertiaStarting(object sender, ManipulationInertiaStartingEventArgs args)
		{
		}

		private void OnHostManipulationStarted(object sender, ManipulationStartedEventArgs args)
		{
		}

		private void OnHostManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs args)
		{
		}

		private void OnHostManipulationCompleted(object sender, ManipulationCompletedEventArgs args)
		{
		}

		private void OnHostManipulationStarting(object sender, ManipulationStartingEventArgs args)
		{
		}

		private void OnHostGotFocus(object sender, RoutedEventArgs args)
		{
		}

		private void OnHostLostFocus(object sender, RoutedEventArgs args)
		{
		}

		private void OnIsMouseDirectlyOverHostChanged(object sender, DependencyPropertyChangedEventArgs args)
		{
		}

		private void OnHostMouseMove(object sender, MouseEventArgs args)
		{
		}

		private void OnHostGotStylusCapture(object sender, StylusEventArgs args)
		{
		}

		private void OnHostLostStylusCapture(object sender, StylusEventArgs args)
		{
		}

		private void OnHostGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs args)
		{
		}

		private void OnHostLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs args)
		{
		}

		private void OnHostGotTouchCapture(object sender, TouchEventArgs args)
		{
		}

		private void OnHostLostTouchCapture(object sender, TouchEventArgs args)
		{
		}
	}
}
