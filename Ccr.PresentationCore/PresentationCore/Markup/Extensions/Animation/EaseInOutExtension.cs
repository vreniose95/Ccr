using System.Windows.Media.Animation;

namespace Ccr.PresentationCore.Markup.Extensions.Animation
{
	public class EaseInOutExtension : EaseExtensionBase
	{
		protected override EasingMode EasingMode => EasingMode.EaseOut;


		public EaseInOutExtension(EasingType easingType)
		{
			EasingType = easingType;
		}
		public EaseInOutExtension(EasingType easingType, params object[] arguments)
			: this(easingType)
		{
			Arguments = arguments;
		}
	}
}