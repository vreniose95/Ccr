using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Ccr.Data.EntityFramework.Conventions
{
  public class DataTypePropertyAttributeConvention
    : PrimitivePropertyAttributeConfigurationConvention<
      DataTypeAttribute>
  {
    public override void Apply(
      ConventionPrimitivePropertyConfiguration config, 
      DataTypeAttribute attr)
    {
      if (attr.DataType == DataType.Date)
      {
        config.HasColumnType("Date");
      }
    }
  }
}
