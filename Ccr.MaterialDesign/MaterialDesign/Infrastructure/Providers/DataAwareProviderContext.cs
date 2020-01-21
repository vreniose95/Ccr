namespace Ccr.MaterialDesign.Infrastructure.Providers
{
	public class DataAwareProviderContext
		: ProviderContext
	{
		public double DataMin { get; }

		public double DataMax { get; }


		public DataAwareProviderContext(
			int cycleLength, 
			double dataMin, 
			double dataMax) 
				: base(cycleLength)
		{
			DataMin = dataMin;
			DataMax = dataMax;
		}
	}
}
