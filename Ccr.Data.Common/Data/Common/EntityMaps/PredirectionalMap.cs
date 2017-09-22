using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Ccr.Data.Common.Domain;
using Ccr.Data.EntityFramework.Attributes;

namespace Ccr.Data.Common.EntityMaps
{
	public class PredirectionalMap 
		: EntityTypeConfiguration<Predirectional>
	{
		public PredirectionalMap()
		{
			ToTable("Predirectionals");

			HasKey(t => t.PredirectionalID);
			Property(t => t.PredirectionalID)
				.HasDatabaseGeneratedOption(
					DatabaseGeneratedOption.Identity);
			
			Property(t => t.Abbreviation)
				.IsRequired()
				.HasMaxLength(5)
				.HasColumnAnnotation("Index",
					new IndexAnnotation(
						new UniqueNonClusteredIndexAttribute(
							"UX_Predirectional_Abbreviation")));

			Property(t => t.PredirectionalName)
				.IsRequired()
				.HasMaxLength(30)
				.HasColumnAnnotation("Index",
					new IndexAnnotation(
						new UniqueNonClusteredIndexAttribute(
							"UX_Predirectional_PredirectionalName")));

			Property(t => t.DirectionTypeID)
				.IsRequired();
		}
	}
}
