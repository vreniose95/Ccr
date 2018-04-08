namespace Ccr.MaterialDesign.Infrastructure.Descriptors
{
	public class LiteralMaterialDescriptor
    : IMaterialDescriptor
	{
    public MaterialBrush LiteralBrush { get; set; }


	  public MaterialBrush GetMaterial(
      Swatch swatch)
	  {
	    return LiteralBrush;
	  }

	  public LiteralMaterialDescriptor(MaterialBrush brush)
	  {
	    LiteralBrush = brush;
	  }
  }
}
//private double _opacity = 1d;
//public double Opacity
//{
//	get => _opacity;
//	set
//	{
//		if (value.IsNotWithin((0, 1)))
//			throw new ArgumentOutOfRangeException(
//				nameof(value),
//				$"The value {value.ToString().SQuote()} ");
//	}
//}