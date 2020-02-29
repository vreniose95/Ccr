using System.Windows.Media;

namespace Ccr.MaterialDesign.Infrastructure.Descriptors
{
	public interface IMaterialDescriptor
	{
		SolidColorBrush GetMaterial(
			Swatch swatch);
	}
}
