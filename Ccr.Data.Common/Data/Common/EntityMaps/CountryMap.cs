using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Ccr.Data.Common.Domain;
using Ccr.Data.EntityFramework.Attributes;

namespace Ccr.Data.Common.EntityMaps
{
	public class CountryMap
		: EntityTypeConfiguration<Country>
	{
		public CountryMap()
		{
			ToTable("Countries");

			HasKey(t => t.CountryID);
			Property(t => t.CountryID)
				.HasDatabaseGeneratedOption(
					DatabaseGeneratedOption.Identity);

			Property(t => t.CountryName)
				.IsRequired()
				.HasMaxLength(50)
				.HasColumnAnnotation("Index",
					new IndexAnnotation(
						new UniqueNonClusteredIndexAttribute(
							"UX_Country_CountryID")));
		}
	}
}
