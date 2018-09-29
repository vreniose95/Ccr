using System;
using Ccr.Std.Core.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Ccr.Dnc.Data.EntityFramework.Attributes
{
  public class ConfiguresEntityAttribute
    : Attribute
  {
    private static readonly Type expectedParamterImpl
      = typeof(IEntityTypeConfiguration<>);

    public Type EntityConfigurationType { get; }


    public ConfiguresEntityAttribute(
      Type entityConfigurationType)
    {
      if (!expectedParamterImpl.IsInstanceOfType(entityConfigurationType))
        throw new InvalidOperationException(
          $"{entityConfigurationType.Name.SQuote()} is not valid for use on this type. " +
          $"Must be instance of type {entityConfigurationType.Name.SQuote()}.");

      EntityConfigurationType = entityConfigurationType;
    }
  }
}
