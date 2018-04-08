using Ccr.Core.Extensions;

namespace Ccr.MaterialDesign.Infrastructure.Descriptors
{
	public class LiteralMaterialDescriptor
    : AbstractMaterialDescriptor
	{
    public MaterialBrush LiteralBrush { get; }


	  public LiteralMaterialDescriptor(
	    MaterialBrush brush)
	  {
	    LiteralBrush = brush;
	  }

    public LiteralMaterialDescriptor(
	    MaterialBrush brush,
	    double opacity) : this(
        brush.WithOpacity(
          opacity))
    {
      Opacity = opacity;
    }


	  public override MaterialBrush GetMaterial(
	    Swatch swatch)
	  {
	    return LiteralBrush;
	  }
  }
}