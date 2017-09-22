using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Ccr.Data.Common.Domain;
using Ccr.Data.EntityFramework.Attributes;

namespace Ccr.Data.Common.EntityMaps
{
	public class StreetSuffixMap
		: EntityTypeConfiguration<StreetSuffix>
	{
		public StreetSuffixMap()
		{
			ToTable("StreetSuffixes");

			HasKey(t => t.StreetSuffixID);
			Property(t => t.StreetSuffixID)
				.HasDatabaseGeneratedOption(
					DatabaseGeneratedOption.Identity);

			Property(t => t.Abbreviation)
				.IsRequired()
				.HasMaxLength(5)
				.HasColumnAnnotation("Index",
					new IndexAnnotation(
						new UniqueNonClusteredIndexAttribute(
							"UX_StreetSuffixMap_Abbreviation")));

			Property(t => t.PrimaryName)
				.IsRequired()
				.HasMaxLength(10)
				.HasColumnAnnotation("Index",
					new IndexAnnotation(
						new UniqueNonClusteredIndexAttribute(
							"UX_StreetSuffixMap_PrimaryName")));
		}
	}
}
