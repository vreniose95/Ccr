using System.Windows.Media;

namespace Ccr.MaterialDesign.Static
{
	internal static class BrushBuilder
	{
		internal static SolidColorBrush FromGreyScale(byte level)
		{
			return new SolidColorBrush(
				Color.FromRgb(
					level,
					level,
					level));
		}
	}
}