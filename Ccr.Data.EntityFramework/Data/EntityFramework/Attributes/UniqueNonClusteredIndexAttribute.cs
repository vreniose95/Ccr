namespace Ccr.Data.EntityFramework.Attributes
{
	public class UniqueNonClusteredIndexAttribute 
		: UniqueIndexAttribute
	{
		public sealed override bool IsClustered => false;

		public sealed override bool IsClusteredConfigured => true;


		public sealed override bool IsUnique => true;

		public sealed override bool IsUniqueConfigured => true;


		
		public UniqueNonClusteredIndexAttribute()
		{
		}
		public UniqueNonClusteredIndexAttribute(
			string name) : base(
				name)
		{
		}
		public UniqueNonClusteredIndexAttribute(
			string name, 
			int order) : base(
				name, 
				order)
		{
		}
	}
}
