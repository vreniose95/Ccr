using System.Windows.Media.Animation;

namespace Ccr.PresentationCore.Markup.Extensions.Animation
{
	public class EaseOutExtension : EaseExtensionBase
	{
		protected override EasingMode EasingMode => EasingMode.EaseOut;


		public EaseOutExtension(EasingType easingType)
		{
			EasingType = easingType;
		}
		public EaseOutExtension(EasingType easingType, params object[] arguments)
			: this(easingType)
		{
			Arguments = arguments;
		}
	}
}