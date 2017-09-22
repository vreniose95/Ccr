using System.ComponentModel.DataAnnotations.Schema;

namespace Ccr.Data.EntityFramework.Core
{
	public interface IHaveStaticStore
	{
		[NotMapped]
		bool IsDatabaseGeneratedValueSimulated { get; }
	}
}