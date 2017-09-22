using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Ccr.Data.Common.Domain;

namespace Ccr.Data.Common.EntityMaps
{
	public class PostalAddressMap
		: EntityTypeConfiguration<PostalAddress>
	{
		public PostalAddressMap()
		{
			ToTable("PostalAddresses");

			HasKey(t => t.PostalAddressID);
			Property(t => t.PostalAddressID)
				.HasDatabaseGeneratedOption(
					DatabaseGeneratedOption.Identity);

			Property(t => t.BuildingNumber)
				.IsRequired();

			Property(t => t.PredirectionalID)
				.IsOptional();

			Property(t => t.StreetName)
				.IsRequired()
				.HasMaxLength(30);

			Property(t => t.StreetSuffixID)
				.IsRequired();

			Property(t => t.AddressLine2)
				.IsOptional();

			Property(t => t.CityID)
				.IsRequired();

			Property(t => t.StateID)
				.IsRequired();

			Property(t => t.ZipCode)
				.IsRequired();

			Property(t => t.ZipCodeSuffix)
				.IsOptional();

			Property(t => t.CountryID)
				.IsRequired();

		}
	}
}
