namespace Ccr.MaterialDesign.Infrastructure.Descriptors
{
  public interface IMaterialDescriptor
  {
    MaterialBrush GetMaterial(
      Swatch swatch);
  }
}
