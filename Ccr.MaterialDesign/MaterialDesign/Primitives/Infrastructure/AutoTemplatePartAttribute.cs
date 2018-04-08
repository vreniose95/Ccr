using System;
using JetBrains.Annotations;

namespace Ccr.MaterialDesign.Primitives.Infrastructure
{
  [MeansImplicitUse(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Itself)]
  [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
  public class AutoTemplatePartAttribute
    : Attribute
  {
  }
}
