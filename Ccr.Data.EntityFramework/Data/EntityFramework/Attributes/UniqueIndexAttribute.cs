using System.ComponentModel.DataAnnotations.Schema;

namespace Ccr.Data.EntityFramework.Attributes
{
	public class UniqueIndexAttribute
		: IndexAttribute
	{
		public override bool IsUnique => true;

		public override bool IsUniqueConfigured => true;



		public UniqueIndexAttribute()
		{
		}
		public UniqueIndexAttribute(
			string name) : base(
				name)
		{
		}
		public UniqueIndexAttribute(
			string name, 
			int order) : base(
				name, 
				order)
		{
		}
	}
}
