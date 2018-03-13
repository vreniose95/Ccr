using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ccr.Data.EntityFramework.Functions.Sql
{
  public class GlobalFunction<TParam, TReturn>
  {
    public GlobalFunction(Expression<Func<TParam, TReturn>> expr)
    {

    }

    public static GlobalFunction<string, string> ToUpper = new GlobalFunction<string, string>(t => t.ToUpper());
  }
}
