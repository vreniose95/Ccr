using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Ccr.Data.Common.Domain;
using Ccr.Data.EntityFramework.Attributes;

namespace Ccr.Data.Common.EntityMaps
{
	public class StreetSuffixVariantMap
		: EntityTypeConfiguration<StreetSuffixVariant>
	{
		public StreetSuffixVariantMap()
		{
			ToTable("StreetSuffixVariants");

			HasKey(t => t.StreetSuffixVariantID);
			Property(t => t.StreetSuffixVariantID)
				.HasDatabaseGeneratedOption(
					DatabaseGeneratedOption.Identity);

			Property(t => t.VariantName)
				.IsRequired()
				.HasMaxLength(10)
				.HasColumnAnnotation("Index",
					new IndexAnnotation(
						new UniqueNonClusteredIndexAttribute(
							"UX_StreetSuffixVariant_VariantName")));
		}
	}
}
