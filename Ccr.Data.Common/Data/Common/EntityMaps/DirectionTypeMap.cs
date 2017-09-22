using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Ccr.Data.Common.Domain;
using Ccr.Data.EntityFramework.Attributes;

namespace Ccr.Data.Common.EntityMaps
{
	public class DirectionTypeMap
		: EntityTypeConfiguration<DirectionType>
	{
		public DirectionTypeMap()
		{
			ToTable("DirectionTypes");

			HasKey(t => t.DirectionTypeID);
			Property(t => t.DirectionTypeID)
				.HasDatabaseGeneratedOption(
					DatabaseGeneratedOption.Identity);

			Property(t => t.DirectionTypeName)
				.IsRequired()
				.HasMaxLength(15)
				.HasColumnAnnotation("Index",
					new IndexAnnotation(
						new UniqueNonClusteredIndexAttribute(
							"UX_DirectionType_DirectionTypeName")));
		}
	}
}
