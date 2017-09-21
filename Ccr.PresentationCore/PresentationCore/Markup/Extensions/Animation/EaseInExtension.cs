using System.Windows.Media.Animation;

namespace Ccr.PresentationCore.Markup.Extensions.Animation
{
	public class EaseInExtension : EaseExtensionBase
	{
		protected override EasingMode EasingMode => EasingMode.EaseIn;


		public EaseInExtension(EasingType easingType)
		{
			EasingType = easingType;
		}
		public EaseInExtension(EasingType easingType, params object[] arguments)
			: this(easingType)
		{
			Arguments = arguments;
		}
	}
}
