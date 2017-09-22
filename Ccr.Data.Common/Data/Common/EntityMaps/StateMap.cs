using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Ccr.Data.Common.Domain;
using Ccr.Data.EntityFramework.Attributes;

namespace Ccr.Data.Common.EntityMaps
{
	public class StateMap
		: EntityTypeConfiguration<State>
	{
		public StateMap()
		{
			ToTable("States");

			HasKey(t => t.StateID);
			Property(t => t.StateID)
				.HasDatabaseGeneratedOption(
					DatabaseGeneratedOption.Identity);

			Property(t => t.Abbreviation)
				.IsRequired()
				.HasMaxLength(2)
				.HasColumnAnnotation("Index",
					new IndexAnnotation(
						new UniqueNonClusteredIndexAttribute(
							"UX_State_Abbreviation")));

			Property(t => t.StateName)
				.IsRequired()
				.HasMaxLength(40)
				.HasColumnAnnotation("Index",
					new IndexAnnotation(
						new UniqueNonClusteredIndexAttribute(
							"UX_State_StateName")));
		}
	}
}
