namespace Ccr.MaterialDesign.Infrastructure.Providers
{
	public interface IMaterialProviderProvider
	{
		IMaterialProvider ProvideNext(ProviderContext context);

		void Reset(ProviderContext context);
	}
}
