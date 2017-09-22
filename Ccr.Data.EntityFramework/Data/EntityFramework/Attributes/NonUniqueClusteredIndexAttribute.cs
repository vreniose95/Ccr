using System.ComponentModel.DataAnnotations.Schema;

namespace Ccr.Data.EntityFramework.Attributes
{
	public class NonUniqueClusteredIndexAttribute
		: IndexAttribute
	{
		public sealed override bool IsUnique => false;

		public sealed override bool IsUniqueConfigured => true;


		public sealed override bool IsClustered => true;

		public sealed override bool IsClusteredConfigured => true;



		public NonUniqueClusteredIndexAttribute()
		{
		}
		public NonUniqueClusteredIndexAttribute(
			string name) : base(
				name)
		{
		}
		public NonUniqueClusteredIndexAttribute(
			string name, 
			int order) : base(
				name, 
				order)
		{
		}
	}
}
