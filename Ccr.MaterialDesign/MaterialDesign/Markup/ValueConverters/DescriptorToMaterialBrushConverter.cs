using Ccr.MaterialDesign.Infrastructure.Descriptors;
using Ccr.Xaml.Markup.Converters.Infrastructure;

namespace Ccr.MaterialDesign.Markup.ValueConverters
{
  public class DescriptorToMaterialBrushConverter 
    : XamlConverter<
        Swatch,
        IMaterialDescriptor, 
        NullParam, 
        MaterialBrush>
  {
    public override MaterialBrush Convert(
      Swatch swatch, 
      IMaterialDescriptor descriptor,
      NullParam param)
    {
      //TODO dont return red. use transparent MaterialSet as default 
      if (swatch == null || descriptor == null)
        return null;

      return descriptor.GetMaterial(swatch);
    }
  }
}
