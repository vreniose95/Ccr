namespace Ccr.MaterialDesign.Infrastructure.Providers
{
	public interface ISlicableMaterialProvider
		: IMaterialProvider
	{
		IMaterialProvider Slice(double offsetPercentage, double lengthPercentage);
	 
		IMaterialProvider SliceSimple(int index, SimpleSliceMode sliceMode);
	}
}