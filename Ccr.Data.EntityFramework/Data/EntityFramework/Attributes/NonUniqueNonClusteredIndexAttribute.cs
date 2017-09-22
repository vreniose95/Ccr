using System.ComponentModel.DataAnnotations.Schema;

namespace Ccr.Data.EntityFramework.Attributes
{
	public class NonUniqueNonClusteredIndexAttribute 
		: IndexAttribute
	{
		public sealed override bool IsUnique => false;

		public sealed override bool IsUniqueConfigured => true;


		public sealed override bool IsClustered => false;

		public sealed override bool IsClusteredConfigured => true;
		


		public NonUniqueNonClusteredIndexAttribute()
		{
		}
		public NonUniqueNonClusteredIndexAttribute(
			string name) : base(
				name)
		{
		}
		public NonUniqueNonClusteredIndexAttribute(
			string name,
			int order) : base(
				name, 
				order)
		{
		}
	}
}
