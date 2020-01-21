namespace Ccr.MaterialDesign.Infrastructure.Providers
{
	public interface IDataAwareMaterialProvider 
		: IMaterialProvider
	{
		Swatch ProvideNextDataAware(DataAwareProviderContext context, double dataPoint);
	}
}
