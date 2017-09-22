using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Ccr.Data.Common.Domain;
using Ccr.Data.EntityFramework.Attributes;

namespace Ccr.Data.Common.EntityMaps
{
	public class CityMap
		: EntityTypeConfiguration<City>
	{
		public CityMap()
		{
			ToTable("Cities");

			HasKey(t => t.CityID);
			Property(t => t.CityID)
				.HasDatabaseGeneratedOption(
					DatabaseGeneratedOption.Identity);

			Property(t => t.CityName)
				.IsRequired()
				.HasMaxLength(30)
				.HasColumnAnnotation("Index",
					new IndexAnnotation(
						new UniqueNonClusteredIndexAttribute(
							"UX_City_CityName")));
			
			Property(t => t.StateID)
				.IsRequired();
			
			Property(t => t.CountryID)
				.IsRequired();
		}
	}
}
