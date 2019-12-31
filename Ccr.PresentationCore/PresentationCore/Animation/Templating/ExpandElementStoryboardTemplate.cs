using System.Windows.Media.Animation;
using Ccr.Core.Extensions;
using Core.Extensions;

namespace Ccr.PresentationCore.Animation.Templating
{
	public class ExpandElementStoryboardTemplate
		: StoryboardTemplate
	{
		private const string targetTransformGroup = "(UIElement.RenderTransform).(TransformGroup.Children)";
		private const string scaleTransformTarget = targetTransformGroup + "[0]";
		private const string scaleXTarget = scaleTransformTarget + ".(ScaleTransform.ScaleX)";
		private const string scaleYTarget = scaleTransformTarget + ".(ScaleTransform.ScaleY)";
		private const string translateTransformTarget = targetTransformGroup + "[1]";
		private const string translateYTarget = translateTransformTarget + ".(TranslateTransform.Y)";


		protected override Storyboard GenerateStoryboardTreeImpl()
		{
			return new ScopedStoryboard
			{
				BeginTime = 400.MillisecondsT(),
				Duration = 250.MillisecondsD(),
				Children = new TimelineCollection
				{
					new DoubleAnimation
					{
						To = 1,
						EasingFunction = new CubicEase
						{
							EasingMode = EasingMode.EaseOut
						}
					}.XamlSet(TargetPropertyProperty, scaleXTarget),
					new DoubleAnimation
					{
						To = 1,
						EasingFunction = new CubicEase
						{
							EasingMode = EasingMode.EaseOut
						}
					}.XamlSet(TargetPropertyProperty, scaleYTarget),
					new DoubleAnimation
					{
						To = 0,
						EasingFunction = new QuadraticEase
						{
							EasingMode = EasingMode.EaseIn
						}
					}.XamlSet(TargetPropertyProperty, translateYTarget),
					new DoubleAnimation
					{
						To = 1,
						EasingFunction = new QuadraticEase
						{
							EasingMode = EasingMode.EaseIn
						}
					}.XamlSet(TargetPropertyProperty, "Opacity"),
					new ObjectAnimationUsingKeyFrames
					{
						Duration = 0.MillisecondsD(),
						KeyFrames = new ObjectKeyFrameCollection
						{
							new DiscreteObjectKeyFrame(true, 0.MillisecondsK())
						}
					}.XamlSet(TargetPropertyProperty, "IsHitTestVisible")
				}
			}.XamlSet(TargetPropertyProperty, GetTargetName(this));
		}
	}


	public class SimpleExpandElementStoryboardTemplate : StoryboardTemplate
	{
		protected override Storyboard GenerateStoryboardTreeImpl()
		{
			return new ScopedStoryboard
			{
				BeginTime = 400.MillisecondsT(),
				Duration = 250.MillisecondsD(),
				Children = new TimelineCollection
				{
					new DoubleAnimation
					{
						To = 1,
						EasingFunction = new QuadraticEase
						{
							EasingMode = EasingMode.EaseIn
						}
					}.XamlSet(TargetPropertyProperty, "Opacity"),
					new ObjectAnimationUsingKeyFrames
					{
						Duration = 0.MillisecondsD(),
						KeyFrames = new ObjectKeyFrameCollection
						{
							new DiscreteObjectKeyFrame(true, 0.MillisecondsK())
						}
					}.XamlSet(TargetPropertyProperty, "IsHitTestVisible")
				}
			}.XamlSet(TargetPropertyProperty, GetTargetName(this));
		}
	}
}
