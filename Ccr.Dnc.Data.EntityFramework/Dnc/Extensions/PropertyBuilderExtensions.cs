using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ccr.Dnc.Extensions
{
  public static class PropertyBuilderExtensions
  {
    public static PropertyBuilder<TProperty> IsOptional<TProperty>(
      this PropertyBuilder<TProperty> @this,
      bool isOptional = true)
    {
      return @this.IsRequired(
        !isOptional);
    }
  }
}
