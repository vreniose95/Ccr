using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using Ccr.Core.Extensions;
using Ccr.MaterialDesign.Primitives.Behaviors.Services;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using Ccr.PresentationCore.Helpers.EventHelpers;

namespace Ccr.MaterialDesign.Primitives.Behaviors
{
	public partial class RippleSurface : ContentControl
	{
		public enum CommonStates
		{
			TemplateStateNormal,
			TemplateStateMousePressed,
			TemplateStateMouseOut
		}

		private static readonly HashSet<RippleSurface> _activeInstanceCache
			= new HashSet<RippleSurface>();


		public static readonly DependencyProperty FeedbackProperty = DP.Register(
			new Meta<RippleSurface, Material>());

		public static readonly DependencyProperty RecognizesAccessKeyProperty = DP.Register(
			new Meta<RippleSurface, bool>());
		
		private static readonly DependencyPropertyKey RippleSizePropertyKey = DP
			.RegisterReadOnly(new Meta<RippleSurface, double>());
		public static readonly DependencyProperty RippleSizeProperty
			= RippleSizePropertyKey.DependencyProperty;

		private static readonly DependencyPropertyKey RippleXPropertyKey = DP
			.RegisterReadOnly(new Meta<RippleSurface, double>());
		public static readonly DependencyProperty RippleXProperty
			= RippleXPropertyKey.DependencyProperty;

		private static readonly DependencyPropertyKey RippleYPropertyKey = DP
			.RegisterReadOnly(new Meta<RippleSurface, double>());
		public static readonly DependencyProperty RippleYProperty
			= RippleYPropertyKey.DependencyProperty;



		public double RippleSize
		{
			get => (double) GetValue(RippleSizeProperty);
			protected set => SetValue(RippleSizePropertyKey, value);
		}
		public double RippleX
		{
			get => (double) GetValue(RippleXProperty);
			protected set => SetValue(RippleXPropertyKey, value);
		}
		public double RippleY
		{
			get => (double) GetValue(RippleYProperty);
			protected set => SetValue(RippleYPropertyKey, value);
		}
		public Material Feedback
		{
			get => (Material) GetValue(FeedbackProperty);
			set => SetValue(FeedbackProperty, value);
		}
		public bool RecognizesAccessKey
		{
			get => (bool) GetValue(RecognizesAccessKeyProperty);
			set => SetValue(RecognizesAccessKeyProperty, value);
		}



		static RippleSurface()
		{
			ControlExtensions.OverrideStyleKey<RippleSurface>();
			
			EM.RegisterClassHandler<ContentControl, MouseButtonEventHandler>(
				Mouse.PreviewMouseUpEvent, MouseButtonEventHandler, true);

			EM.RegisterClassHandler<ContentControl, MouseEventHandler>(
				Mouse.MouseMoveEvent, MouseMoveEventHandler, true);

			EM.RegisterClassHandler<Popup, MouseButtonEventHandler>(
				Mouse.PreviewMouseUpEvent, MouseButtonEventHandler, true);

			EM.RegisterClassHandler<Popup, MouseEventHandler>(
				Mouse.MouseMoveEvent, MouseMoveEventHandler, true);
		}

		public RippleSurface()
		{
			SizeChanged += OnSizeChanged;
		}


		private static void MouseButtonEventHandler(
			object sender,
			MouseButtonEventArgs args)
		{
			foreach (var ripple in _activeInstanceCache)
			{
				var scaleTrans = ripple
					.Template
					.FindName("ScaleTransform", ripple) as ScaleTransform;
				if (scaleTrans != null)
				{
					var currentScale = scaleTrans.ScaleX;
					var newTime = TimeSpan.FromMilliseconds(
						300 * (1d - currentScale));

					var scaleXKeyFrame = ripple
							.Template
							.FindName("MousePressedToNormalScaleXKeyFrame", ripple)
						as EasingDoubleKeyFrame;

					if (scaleXKeyFrame != null)
					{
						scaleXKeyFrame.KeyTime = KeyTime.FromTimeSpan(newTime);
					}

					var scaleYKeyFrame = ripple
							.Template
							.FindName("MousePressedToNormalScaleYKeyFrame", ripple)
						as EasingDoubleKeyFrame;

					if (scaleYKeyFrame != null)
					{
						scaleYKeyFrame.KeyTime = KeyTime.FromTimeSpan(newTime);
					}
				}
				VisualStateManager.GoToState(
					ripple,
					CommonStates.TemplateStateNormal.ToString(),
					true);
			}
			_activeInstanceCache.Clear();
		}

		private static void MouseMoveEventHandler(
			object sender,
			MouseEventArgs args)
		{
			foreach (var ripple in _activeInstanceCache)
			{
				var relativePosition = Mouse.GetPosition(ripple);
				if (relativePosition.X < 0
				    || relativePosition.Y < 0
				    || relativePosition.X >= ripple.ActualWidth
				    || relativePosition.Y >= ripple.ActualHeight)
				{
					VisualStateManager.GoToState(
						ripple,
						CommonStates.TemplateStateMouseOut.ToString(),
						true);

					_activeInstanceCache.Remove(ripple);
				}
			}
		}

		protected override void OnPreviewMouseLeftButtonDown(
			MouseButtonEventArgs args)
		{
			var point = args.GetPosition(this);

			if (RippleAssist.GetIsCentered(this))
			{
				var innerContent = Content as FrameworkElement;

				if (innerContent != null)
				{
					var position = innerContent.TransformToAncestor(this)
						.Transform(new Point(0, 0));

					RippleX = position.X + innerContent.ActualWidth / 2 - RippleSize / 2;
					RippleY = position.Y + innerContent.ActualHeight / 2 - RippleSize / 2;
				}
				else
				{
					RippleX = ActualWidth / 2 - RippleSize / 2;
					RippleY = ActualHeight / 2 - RippleSize / 2;
				}
			}
			else
			{
				RippleX = point.X - RippleSize / 2;
				RippleY = point.Y - RippleSize / 2;
			}

			if (!RippleAssist.GetIsDisabled(this))
			{
				VisualStateManager.GoToState(
					this,
					CommonStates.TemplateStateNormal.ToString(),
					false);

				VisualStateManager.GoToState(
					this,
					CommonStates.TemplateStateMousePressed.ToString(),
					true);

				_activeInstanceCache.Add(this);
			}
			base.OnPreviewMouseLeftButtonDown(args);
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			VisualStateManager.GoToState(
				this,
				CommonStates.TemplateStateNormal.ToString(),
				false);
		}

		private void OnSizeChanged(
			object sender,
			SizeChangedEventArgs args)
		{
			var innerContent = Content as FrameworkElement;

			double width, height;

			if (RippleAssist.GetIsCentered(this) && innerContent != null)
			{
				width = innerContent.ActualWidth;
				height = innerContent.ActualHeight;
			}
			else
			{
				width = args.NewSize.Width;
				height = args.NewSize.Height;
			}

			var radius = Math.Sqrt(Math.Pow(width, 2) + Math.Pow(height, 2));

			RippleSize = 2 * radius * RippleAssist.GetRippleSizeMultiplier(this);
		}
	}
}