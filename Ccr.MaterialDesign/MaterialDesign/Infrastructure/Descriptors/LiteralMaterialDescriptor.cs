using System.Windows.Media;
using Ccr.Core.Extensions;

namespace Ccr.MaterialDesign.Infrastructure.Descriptors
{
	public class LiteralMaterialDescriptor
    : AbstractMaterialDescriptor
	{
    public SolidColorBrush LiteralBrush { get; }


	  public LiteralMaterialDescriptor(
	    SolidColorBrush brush)
	  {
	    LiteralBrush = brush;
	  }

    //TODO fix withOpacity
    public LiteralMaterialDescriptor(
      SolidColorBrush brush,
      double opacity) : this(
        brush.Color.WithOpacity(
          opacity).ToSCB())
    {
      Opacity = opacity;
    }


    public override SolidColorBrush GetMaterial(
	    Swatch swatch)
	  {
	    return LiteralBrush;
	  }
  }
}