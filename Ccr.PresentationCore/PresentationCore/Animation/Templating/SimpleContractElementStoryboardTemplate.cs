using System.Windows.Media.Animation;
using Ccr.Core.Extensions;
using Core.Extensions;

namespace Ccr.PresentationCore.Animation.Templating
{
	public class SimpleContractElementStoryboardTemplate
		: StoryboardTemplate
	{
		protected override Storyboard GenerateStoryboardTreeImpl()
		{
			return new ScopedStoryboard
			{
				Duration = 250.MillisecondsD(),
				Children = new TimelineCollection
				{
					new DoubleAnimation
					{
						To = 0,
						EasingFunction = new QuadraticEase
						{
							EasingMode = EasingMode.EaseIn
						}
					}.XamlSet(TargetPropertyProperty, "Opacity"),
					new ObjectAnimationUsingKeyFrames
					{
						Duration = 200.MillisecondsD(),
						KeyFrames = new ObjectKeyFrameCollection
						{
							new DiscreteObjectKeyFrame(false, 0.MillisecondsK())
						}
					}.XamlSet(TargetPropertyProperty, "IsHitTestVisible")
				}
			}.XamlSet(TargetPropertyProperty, GetTargetName(this));
		}
	}
}