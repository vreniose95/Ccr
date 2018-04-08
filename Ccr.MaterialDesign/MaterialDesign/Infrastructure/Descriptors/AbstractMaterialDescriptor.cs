using System.ComponentModel;
using System.Windows.Media;

namespace Ccr.MaterialDesign.Infrastructure.Descriptors
{
	[TypeConverter(typeof(DescriptorConverter))]
	public abstract class AbstractMaterialDescriptor
	{
		public double Opacity { get; set; } = 1.0;

		public abstract SolidColorBrush GetMaterial(Swatch materialSet);
	}
}
