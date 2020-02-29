using System.Windows.Media;
using Ccr.Xaml.Markup.Converters.Infrastructure;

namespace Ccr.MaterialDesign.Infrastructure.Descriptors
{
	public class DescriptorToBrushConverter
		: XamlConverter<
			Swatch,
			AbstractMaterialDescriptor,
			NullParam,
			Brush>
	{
		public override Brush Convert(
			Swatch materialSet,
			AbstractMaterialDescriptor descriptor,
			NullParam param)
		{
			//TODO dont return red. use transparent MaterialSet as default 
			if (materialSet == null || descriptor == null)
				return Brushes.Red;

			return descriptor.GetMaterial(materialSet);
		}
	}
}
