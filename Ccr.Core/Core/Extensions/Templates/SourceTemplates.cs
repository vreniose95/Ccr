using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Ccr.Core.Extensions.Templates
{

  public static class SourceTemplates
  {

    [SourceTemplate]
    public static void forEachM<T>(this IEnumerable<T> @this)
    {
      foreach (var item in @this)
      {
        //$ $END$
      }
    }
   
    /// <summary>
    ///   ReSharper dependency property registration and accessor template using the
    ///   
    /// </summary>
    /// <param name="name"></param>
    /// <param name="type"></param>
    /// <param name="containingTypeName"></param>
    [SourceTemplate]
    public static void dprop(
      this string name,
      [Macro(Expression = "suggestVariableType()", Editable = 0)] Type type,
      [Macro(Expression = "typeName()", Editable = -1)] string containingTypeName)
    {
      /*$public static readonly DependencyProperty $name$Property = DP.Register(
          new Meta<$containingTypeName$, $type$>());
        public $type$ $name$
        {
          get => ($type$)GetValue($name$Property);
          set => SetValue($name$Property, value);
        } */
    }

  }
}