using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Ccr.Std.Core.Extensions.Templates
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
    ///   ReSharper standard <see cref="DependencyProperty"/> ependency property registration and accessor template using the Ccr library
    ///   Generic Dependency Property Registration system 
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

    [SourceTemplate]
    public static void att(
      this Type containerType,
      Type type,
      string name)
    {
      /*$public static readonly DependencyProperty $name$Property = DP.Attach(_type, 
        new MetaBase<$type$>());

      public static $type$ Get$name$(
        DependencyObject @this)
      {
        return @this.Get<$type$>($name$Property);
      }
      public static void Set$name$(
        DependencyObject @this,
        $type$ value)
      {
        @this.Set($name$Property, value);
      }
       */
    }
  }
}