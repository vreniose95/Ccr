using System;

namespace Ccr.MaterialDesign.Infrastructure.Providers
{
	public class MaterialProviderKey
	{
		public Guid Key { get; }


		public MaterialProviderKey()
		{
			Key = Guid.NewGuid();
		}
	}
}
