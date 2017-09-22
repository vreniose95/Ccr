using System.ComponentModel.DataAnnotations.Schema;

namespace Ccr.Data.EntityFramework.Attributes
{
	public class UniqueClusteredIndexAttribute
		: IndexAttribute
	{
		public sealed override bool IsUnique => true;

		public sealed override bool IsUniqueConfigured => true;


		public sealed override bool IsClustered => true;

		public sealed override bool IsClusteredConfigured => true;



		public UniqueClusteredIndexAttribute()
		{
		}
		public UniqueClusteredIndexAttribute(
			string name) : base(
				name)
		{
		}
		public UniqueClusteredIndexAttribute(
			string name, 
			int order) : base(
				name,
				order)
		{
		}
	}
}
