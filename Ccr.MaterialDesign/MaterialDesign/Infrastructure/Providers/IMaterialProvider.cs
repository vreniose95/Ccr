namespace Ccr.MaterialDesign.Infrastructure.Providers
{
	public interface IMaterialProvider
  {
    Swatch ProvideNext(ProviderContext context);

    void Reset(ProviderContext context);
  }
}
