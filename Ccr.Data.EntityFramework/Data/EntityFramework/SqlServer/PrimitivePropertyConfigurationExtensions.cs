using System.Data.Entity.ModelConfiguration.Configuration;

namespace Ccr.Data.EntityFramework.SqlServer
{
	public static class PrimitivePropertyConfigurationExtensions
	{
		public static PrimitivePropertyConfiguration HasIdentityConfiguration(
			this PrimitivePropertyConfiguration @this,
			int seedValue = 1)
		{
			//@this.HasDatabaseGeneratedOption(
			//		DatabaseGeneratedOption.Identity)
			//		.HasColumnAnnotation("");

			//var configuration = @this
			//	.HasDatabaseGeneratedOption(
			//		DatabaseGeneratedOption.Identity)
			//		.Reflect()
			//		.GetPropertyValue<object>(
			//			ReflectionVisibility.InstanceNonPublic, "Configuration");

			//var annotations = configuration
			//	.Reflect()
			//	.GetPropertyValue<IDictionary<string, object>>(
			//		ReflectionVisibility.InstanceNonPublic, "Annotations");
			

			return @this;
	}
		}
}
