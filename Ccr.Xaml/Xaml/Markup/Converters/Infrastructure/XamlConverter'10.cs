using System;
using System.Globalization;
using System.Windows.Data;
using Ccr.Xaml.Markup.Extensions;

namespace Ccr.Xaml.Markup.Converters.Infrastructure
{
  public abstract class XamlConverter<
      T1, 
      T2, 
      T3, 
      T4, 
      T5, 
      T6, 
      T7, 
      T8, 
      T9,
      T10,
      TParam, TResult>
    : MarkupExtensionAbstractSingletonFactory,
      IMultiValueConverter
    where TParam
    : ConverterParam
  {
	  protected virtual T1 ConvertArg1(object arg)
	  {
		  return XamlUtilities.Convert<T1>(arg, this);
	  }

	  protected virtual T2 ConvertArg2(object arg)
	  {
		  return XamlUtilities.Convert<T2>(arg, this);
	  }

	  protected virtual T3 ConvertArg3(object arg)
	  {
		  return XamlUtilities.Convert<T3>(arg, this);
	  }

	  protected virtual T4 ConvertArg4(object arg)
	  {
		  return XamlUtilities.Convert<T4>(arg, this);
	  }

	  protected virtual T5 ConvertArg5(object arg)
	  {
		  return XamlUtilities.Convert<T5>(arg, this);
	  }

	  protected virtual T6 ConvertArg6(object arg)
	  {
		  return XamlUtilities.Convert<T6>(arg, this);
	  }

	  protected virtual T7 ConvertArg7(object arg)
	  {
		  return XamlUtilities.Convert<T7>(arg, this);
	  }

	  protected virtual T8 ConvertArg8(object arg)
	  {
		  return XamlUtilities.Convert<T8>(arg, this);
	  }

    protected virtual T9 ConvertArg9(object arg)
	  {
		  return XamlUtilities.Convert<T9>(arg, this);
	  }

    protected virtual T10 ConvertArg10(object arg)
    {
	    return XamlUtilities.Convert<T10>(arg, this);
    }
    
    protected virtual ConverterParam ConvertParam(object param, CultureInfo cultureInfo)
	  {
		  return XamlUtilities.ConvertParam<TParam>(param, cultureInfo, this);
	  }


    object IMultiValueConverter.Convert(
      object[] values,
      Type targetType,
      object parameter,
      CultureInfo cultureInfo)
    {
	    var arg1 = ConvertArg1(values[0]);
	    var arg2 = ConvertArg2(values[1]);
	    var arg3 = ConvertArg3(values[2]);
	    var arg4 = ConvertArg4(values[3]);
	    var arg5 = ConvertArg5(values[4]);
	    var arg6 = ConvertArg6(values[5]);
	    var arg7 = ConvertArg7(values[6]);
	    var arg8 = ConvertArg8(values[7]);
	    var arg9 = ConvertArg9(values[8]);
	    var arg10 = ConvertArg10(values[9]);

      var param = ConvertParam(parameter, cultureInfo);

      return Convert(
        arg1, 
        arg2, 
        arg3, 
        arg4, 
        arg5, 
        arg6,
        arg7,
        arg8,
        arg9,
        arg10,
        (TParam)param);
    }

    public abstract TResult Convert(
      T1 arg1, 
      T2 arg2, 
      T3 arg3, 
      T4 arg4, 
      T5 arg5, 
      T6 arg6,
      T7 arg7,
      T8 arg8,
      T9 arg9,
      T10 arg10,
      TParam param);

    public object[] ConvertBack(
      object value,
      Type[] targetTypes,
      object parameter,
      CultureInfo cultureInfo)
    {
      throw new NotImplementedException();
    }
  }
}
