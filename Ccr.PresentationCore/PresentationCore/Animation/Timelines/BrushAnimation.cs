using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Ccr.PresentationCore.Helpers.DependencyHelpers;

namespace Ccr.PresentationCore.Animation.Timelines
{
	public class BrushAnimation : AnimationTimeline
	{
		public override Type TargetPropertyType => typeof(Brush);

		public static readonly DependencyProperty FromProperty = DP.Register(
			new Meta<BrushAnimation, Brush>());

		public static readonly DependencyProperty ToProperty = DP.Register(
			new Meta<BrushAnimation, Brush>());
		


		public Brush From
		{
			get => (Brush)GetValue(FromProperty);
			set => SetValue(FromProperty, value);
		}
		public Brush To
		{
			get => (Brush)GetValue(ToProperty);
			set => SetValue(ToProperty, value);
		}




		public override object GetCurrentValue(
			object defaultOriginValue, 
			object defaultDestinationValue,
			AnimationClock animationClock)
		{
			return GetCurrentValue(
				defaultOriginValue as Brush,
				defaultDestinationValue as Brush,
				animationClock);

		}
		public object GetCurrentValue(Brush defaultOriginValue, Brush defaultDestinationValue, AnimationClock animationClock)
		{
			if (!animationClock.CurrentProgress.HasValue)
				return Brushes.Transparent;

			defaultOriginValue = From ?? defaultOriginValue;
			defaultDestinationValue = To ?? defaultDestinationValue;

			if (animationClock.CurrentProgress.Value == 0)
				return defaultOriginValue;

			if (animationClock.CurrentProgress.Value == 1)
				return defaultDestinationValue;

			return new VisualBrush(new Border
			{
				Width = 1,
				Height = 1,
				Background = defaultOriginValue,
				Child = new Border
				{
					Background = defaultDestinationValue,
					Opacity = animationClock.CurrentProgress.Value
				}
			});
		}

		protected override Freezable CreateInstanceCore()
		{
			return new BrushAnimation();
		}


	}
}
