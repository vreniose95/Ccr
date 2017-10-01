using System;
using System.Windows;
using System.Windows.Media.Animation;
using Ccr.Core.Extensions;

namespace Ccr.PresentationCore.Animation.Timelines 
{
	public abstract class CornerAnimationBase
		: AnimationTimeline
	{
		public sealed override Type TargetPropertyType
		{
			get
			{
				ReadPreamble();
				return typeof(CornerRadius);
			}
		}

		public new CornerAnimationBase Clone()
		{
			return (CornerAnimationBase)base.Clone();
		}

		public sealed override object GetCurrentValue(
			object defaultOriginValue, 
			object defaultDestinationValue, 
			AnimationClock animationClock)
		{
			defaultOriginValue.IsNotNull(nameof(defaultOriginValue));
			defaultDestinationValue.IsNotNull(nameof(defaultDestinationValue));

			return GetCurrentValue(
				(CornerRadius)defaultOriginValue, 
				(CornerRadius)defaultDestinationValue, 
				animationClock);
		}

		public CornerRadius GetCurrentValue(
			CornerRadius defaultOriginValue,
			CornerRadius defaultDestinationValue,
			AnimationClock animationClock)
		{
			ReadPreamble();

			animationClock.IsNotNull(nameof(animationClock));
			if (animationClock == null)
				throw new ArgumentNullException(nameof(animationClock));
			if (animationClock.CurrentState == ClockState.Stopped)
				return defaultDestinationValue;
			return GetCurrentValueCore(defaultOriginValue, defaultDestinationValue, animationClock);
		}

		protected abstract CornerRadius GetCurrentValueCore(CornerRadius defaultOriginValue, CornerRadius defaultDestinationValue, AnimationClock animationClock);
	}
}
