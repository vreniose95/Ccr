using System;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace Ccr.PresentationCore.Markup.Extensions.Animation
{
	public abstract class EaseExtensionBase
		: MarkupExtension
	{
		protected abstract EasingMode EasingMode { get; }

		protected EasingType EasingType { get; set; }

		protected object[] Arguments { get; set; } = { };


		public override object ProvideValue(
			IServiceProvider serviceProvider)
		{
			return EasingFunctionFactory.CreateEasingFunction(
				EasingType, 
				Arguments);
		}
	}
}
