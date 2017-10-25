using System.Windows.Controls;
using Ccr.Core.Extensions;
using Ccr.MaterialDesign.Controls.Icons;

namespace Ccr.MaterialDesign.Controls
{
	public class Icon
			: IconBase<IconKind>
	{
		static Icon()
		{
			ControlExtensions.OverrideStyleKey<Icon>();
		}

		public Icon() : base(
			() => IconDataFactory.Create)
		{
		}
	}
}
