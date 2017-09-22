using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Ccr.Data.EntityFramework.Attributes;
using Gender = Ccr.Data.Common.Domain.Gender;

namespace Ccr.Data.Common.EntityMaps
{
  public class GenderMap
      : EntityTypeConfiguration<Gender>
  {
    public GenderMap()
    {
      ToTable("Genders");

      HasKey(t => t.GenderID);
      Property(t => t.GenderID)
        .HasDatabaseGeneratedOption(
          DatabaseGeneratedOption.Identity);

      Property(t => t.Abbreviation)
        .IsRequired()
        .HasMaxLength(1)
        .HasColumnAnnotation("Index",
          new IndexAnnotation(
            new UniqueNonClusteredIndexAttribute(
              "UX_Gender_Abbreviation")));

      Property(t => t.GenderName)
        .IsRequired()
        .HasMaxLength(10)
        .HasColumnAnnotation("Index",
          new IndexAnnotation(
            new UniqueNonClusteredIndexAttribute(
              "UX_Gender_GenderName")));
    }
  }
}
