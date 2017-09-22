using System;
namespace Core.Data.EntityFramework.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	public class EntityConfigurationMapAttribute
		: Attribute
	{
		public Type ConfigurationType { get; }

		public EntityConfigurationMapAttribute(
			Type configurationType)
		{
			ConfigurationType = configurationType;
		}
	}
}
