using System;
using System.Globalization;
using System.Windows.Data;
using Ccr.Xaml.Markup.Extensions;

namespace Ccr.Xaml.Markup.Converters.Infrastructure
{
  public abstract class XamlConverter<
      T1, T2, T3,
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

	    var param = ConvertParam(parameter, cultureInfo);

      return Convert(
        arg1,
        arg2,
        arg3,
        (TParam)param);
    }

    public abstract TResult Convert(
      T1 arg1,
      T2 arg2,
      T3 arg3,
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
