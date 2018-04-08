using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using Ccr.Core.Extensions;
using Ccr.MaterialDesign.Infrastructure.Descriptors;
using Ccr.MaterialDesign.Markup.ValueConverters;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using Ccr.Xaml.Infrastructure;
using Ccr.Xaml.Markup.Extensions;
using HighContrastDescriptorToBrushConverter = Ccr.MaterialDesign.Markup.ValueConverters.HighContrastDescriptorToBrushConverter;

namespace Ccr.MaterialDesign.Primitives.Textual
{
  //TODO could this recievemarkupextension/typeconverter to extract BindingRelativeSource by default on bind?
  //TODO something is not right with how Padding is handled. Should all bound FE's padding be set to 0?
  //TODO Horiz/Vert Content Alignment control capability! How to handle this with non-control frameworkelements like TextBlock?
  public partial class TextualStyle
  {
    protected static Type _type = typeof(TextualStyle);


    private static readonly RelativeSource _defaultBindingRelativeSource
      = new RelativeSource(RelativeSourceMode.TemplatedParent);


    public static readonly DependencyProperty BindingRelativeSourceProperty = DP.Attach(_type, 
      new MetaBase<RelativeSource>(_defaultBindingRelativeSource, 
                                   (@this, args) => onDependentPropertyChanged(@this, args)));

    
    //TODO change name, just source not relativesource?
    public static readonly DependencyProperty ForegroundMaterialSetRelativeSourceProperty = DP.Attach(_type, 
      new MetaBase<DependencyObject>(null, 
                                     (@this, args) => onDependentPropertyChanged(@this, args)));

    public static readonly DependencyProperty BindStyleProperty = DP.Attach(_type, 
      new MetaBase<TextualStyle>(
        new TextualStyle(),
        (@this, args) => onDependentPropertyChanged(@this, args)));

    public static readonly DependencyProperty IsHighContrastBindingProperty = DP.Attach(_type,
      new MetaBase<bool>(false,
                         (@this, args) => onDependentPropertyChanged(@this, args)));

    public static readonly DependencyProperty HighContrastBindingContextProperty = DP.Attach(_type,
      new MetaBase<SolidColorBrush>(null,
                                    (@this, args) => onDependentPropertyChanged(@this, args)));

    //public static readonly DependencyProperty HighContrastBindingThresholdProperty =
    //	DP.Attach<double>(type, new FrameworkPropertyMetadata(.3));



    public static RelativeSource GetBindingRelativeSource(DependencyObject obj)
    {
      return obj.Get<RelativeSource>(BindingRelativeSourceProperty);
    }
    public static void SetBindingRelativeSource(DependencyObject obj, RelativeSource value)
    {
      obj.Set(BindingRelativeSourceProperty, value);
    }

    public static DependencyObject GetForegroundMaterialSetRelativeSource(DependencyObject obj)
    {
      return obj.Get<DependencyObject>(ForegroundMaterialSetRelativeSourceProperty);
    }
    public static void SetForegroundMaterialSetRelativeSource(DependencyObject obj, DependencyObject value)
    {
      obj.Set(ForegroundMaterialSetRelativeSourceProperty, value);
    }

    public static TextualStyle GetBindStyle(DependencyObject obj)
    {
      return obj.Get<TextualStyle>(BindStyleProperty);
    }
    public static void SetBindStyle(DependencyObject obj, TextualStyle value)
    {
      obj.Set(BindStyleProperty, value);
    }

    public static bool GetIsHighContrastBinding(DependencyObject obj)
    {
      return obj.Get<bool>(IsHighContrastBindingProperty);
    }
    public static void SetIsHighContrastBinding(DependencyObject obj, bool value)
    {
      obj.Set(IsHighContrastBindingProperty, value);
    }

    public static SolidColorBrush GetHighContrastBindingContext(DependencyObject obj)
    {
      return obj.Get<SolidColorBrush>(HighContrastBindingContextProperty);
    }

    public static void SetHighContrastBindingContext(DependencyObject obj, SolidColorBrush value)
    {
      obj.Set(HighContrastBindingContextProperty, value);
    }

    //public static double GetHighContrastBindingThreshold(DependencyObject i) => i.Get<double>(HighContrastBindingThresholdProperty);
    //public static void SetHighContrastBindingThreshold(DependencyObject i, double v) => i.Set(HighContrastBindingThresholdProperty, v);


      
    private static void onDependentPropertyChanged(
      DependencyObject @this, 
      DependencyPropertyChangedEventArgs args)
    {
      if (!(@this is FrameworkElement frameworkElement))
        throw new InvalidCastException(
          "BindingRelativeSource target object must be a FrameworkElement.");

      //var relativeSource = e.NewValue as RelativeSource;
      //if (relativeSource == null)
      //	throw new InvalidCastException("BindingRelativeSource value must be a RelativeSource.");

      var textualStyle = GetBindStyle(@this);
      var relativeSource = GetBindingRelativeSource(@this);
      var foregroundMaterialSetRelativeSource = GetForegroundMaterialSetRelativeSource(@this);
      var isHighContrastBinding = GetIsHighContrastBinding(@this);
      var highContrastBindingContext = GetHighContrastBindingContext(@this);
      //var highContrastBindingThreshold = GetHighContrastBindingThreshold(@this);

      bindTextualStyleImpl(
        frameworkElement,
        textualStyle, 
        relativeSource, 
        foregroundMaterialSetRelativeSource,
        isHighContrastBinding,
        highContrastBindingContext); //, highContrastBindingThreshold);
    }
    //private static void onForegroundMaterialSetRelativeSourceChanged(DependencyObject @this, DependencyPropertyChangedEventArgs e)
    //{
    //	var control = @this as FrameworkElement;
    //	if (control == null)
    //		throw new InvalidCastException("ForegroundMaterialSetRelativeSource target object must be a FrameworkElement.");

    //	var relativeSource = e.NewValue as DependencyObject;
    //	if (relativeSource == null)
    //		throw new InvalidCastException("ForegroundMaterialSetRelativeSource value must be a DependencyObject.");

    //	var bindingRelativeSource = GetBindingRelativeSource(@this);
    //	var textualStyle = GetBindStyle(@this);
    //	var isHighContrastBinding = GetIsHighContrastBinding(@this);
    //	var highContrastBindingContext = GetHighContrastBindingContext(@this);

    //	bindTextualStyleImpl(control, textualStyle, relativeSource, foregroundMaterialSetRelativeSource, isHighContrastBinding, highContrastBindingContext);
    //}
    //private static void onBindStyleChanged(DependencyObject @this, DependencyPropertyChangedEventArgs e)
    //{
    //	var control = @this as FrameworkElement;
    //	if (control == null)
    //		throw new InvalidCastException("BindStyle target object must be a FrameworkElement.");

    //	var textualStyle = e.NewValue as TextualStyle;
    //	if (textualStyle == null)
    //		throw new InvalidCastException("BindStyle value must be a TextualStyle.");

    //	var relativeSource = GetBindingRelativeSource(@this);
    //	var foregroundMaterialSetRelativeSource = GetForegroundMaterialSetRelativeSource(@this);
    //	var isHighContrastBinding = GetIsHighContrastBinding(@this);
    //	var highContrastBindingContext = GetHighContrastBindingContext(@this);

    //	bindTextualStyleImpl(control, textualStyle, relativeSource, foregroundMaterialSetRelativeSource, isHighContrastBinding, highContrastBindingContext);
    //}

    //private static void onIsHighContrastBindingChanged(DependencyObject @this, DependencyPropertyChangedEventArgs e)
    //{
    //	var control = @this as FrameworkElement;
    //	if (control == null)
    //		throw new InvalidCastException("BindStyle target object must be a FrameworkElement.");

    //	var textualStyle = e.NewValue as TextualStyle;
    //	if (textualStyle == null)
    //		throw new InvalidCastException("BindStyle value must be a TextualStyle.");

    //	var relativeSource = GetBindingRelativeSource(@this);
    //	var foregroundMaterialSetRelativeSource = GetForegroundMaterialSetRelativeSource(@this);
    //	var isHighContrastBinding = GetIsHighContrastBinding(@this);
    //	var highContrastBindingContext = GetHighContrastBindingContext(@this);

    //	bindTextualStyleImpl(control, textualStyle, relativeSource, foregroundMaterialSetRelativeSource, isHighContrastBinding, highContrastBindingContext);
    //}

    //private static void onHighContrastBindingContextChanged(DependencyObject @this, DependencyPropertyChangedEventArgs e)
    //{
    //	var control = @this as FrameworkElement;
    //	if (control == null)
    //		throw new InvalidCastException("BindStyle target object must be a FrameworkElement.");

    //	var textualStyle = e.NewValue as TextualStyle;
    //	if (textualStyle == null)
    //		throw new InvalidCastException("BindStyle value must be a TextualStyle.");

    //	var relativeSource = GetBindingRelativeSource(@this);
    //	var foregroundMaterialSetRelativeSource = GetForegroundMaterialSetRelativeSource(@this);
    //	var isHighContrastBinding = GetIsHighContrastBinding(@this);
    //	var highContrastBindingContext = GetHighContrastBindingContext(@this);

    //	bindTextualStyleImpl(control, textualStyle, relativeSource, foregroundMaterialSetRelativeSource, isHighContrastBinding, highContrastBindingContext);
    //}


    private static void bindTextualStyleImpl(
      FrameworkElement @this,
      TextualStyle textualStyle,
      RelativeSource relativeSource,
      DependencyObject foregroundMaterialSetRelativeSource,
      bool isHighContrastBinding,
      SolidColorBrush highContrastBindingContext)
    //double highContrastBindingThreshold)
    {
      BindingOperations.SetBinding(@this, TextElement.FontFamilyProperty, new Binding(FontFamilyProperty.Name) { Source = textualStyle });
      BindingOperations.SetBinding(@this, TextElement.FontStyleProperty, new Binding(FontStyleProperty.Name) { Source = textualStyle });
      BindingOperations.SetBinding(@this, TextElement.FontWeightProperty, new Binding(FontWeightProperty.Name) { Source = textualStyle });
      BindingOperations.SetBinding(@this, TextElement.FontStretchProperty, new Binding(FontStretchProperty.Name) { Source = textualStyle });
      //BindingOperations.SetBinding(@this, Control.PaddingProperty, new Binding(PaddingProperty.Name) { Source = textualStyle });
      BindingOperations.SetBinding(@this, TextElement.FontSizeProperty, new MultiBinding
      {
        Converter = new MultiplyMultiConverter(),
        Bindings =
          {
            new Binding
            {
              RelativeSource = relativeSource,
              Path = new PropertyPath("FontSize")
            },
            new Binding
            {
              Source = textualStyle,
              Path = new PropertyPath("RelativeFontSize")
            },
          }
      });
      if (foregroundMaterialSetRelativeSource == null)
      {
        if (isHighContrastBinding)
        {
          BindingOperations.SetBinding(@this, TextElement.ForegroundProperty,
            new MultiBinding
            {
              Converter = new HighContrastDescriptorToBrushConverter(),
              Bindings =
              {
                new Binding
                {
                  RelativeSource = relativeSource,
                  Path = new PropertyPath("FallbackMaterialSet")
                },
                new Binding
                {
                  Source = textualStyle,
                  Path = new PropertyPath("ForegroundDescriptor")
                },
                new Binding
                {
                  RelativeSource = relativeSource,
                  Path = new PropertyPath("IsHighContrastOverlayedTextEnabled")
                },
                new Binding
                {
                  Source = highContrastBindingContext
                },
                new Binding
                {
                  RelativeSource = relativeSource,
                  Path = new PropertyPath("HighContrastBindingThreshold")
                }
              }
            });
        }
        else
        {
          BindingOperations.SetBinding(@this, TextElement.ForegroundProperty,
            new MultiBinding
            {
              Converter = new DescriptorToBrushConverter(),
              Bindings =
              {
                new Binding
                {
                  RelativeSource = relativeSource,
                  Path = new PropertyPath("FallbackMaterialSet")
                },
                new Binding
                {
                  Source = textualStyle,
                  Path = new PropertyPath("ForegroundDescriptor")
                }
              }
            });
        }
      }
      else
      {
        if (isHighContrastBinding)
        {
          BindingOperations.SetBinding(@this, TextElement.ForegroundProperty,
            new MultiBinding
            {
              Converter = new HighContrastDescriptorToBrushConverter(),//MarkupSingleton.GetInstance<>(),
              Bindings =
              {
                new Binding
                {
                  Source = foregroundMaterialSetRelativeSource
                },
                new Binding
                {
                  Source = textualStyle,
                  Path = new PropertyPath("ForegroundDescriptor")
                },
                new Binding
                {
                  RelativeSource = relativeSource,
                  Path = new PropertyPath("IsHighContrastOverlayedTextEnabled")
                },
                new Binding
                {
                  Source = highContrastBindingContext
                },
                new Binding
                {
                  RelativeSource = relativeSource,
                  Path = new PropertyPath("HighContrastBindingThreshold")
                }
              }
            });
        }
        else
        {
          BindingOperations.SetBinding(@this, TextElement.ForegroundProperty,
            new MultiBinding
            {
              Converter = new DescriptorToBrushConverter(), //TODO use getinstance<> for all these, stop creating instances
              Bindings =
              {
                new Binding
                {
                  Source = foregroundMaterialSetRelativeSource
                },
                new Binding
                {
                  Source = textualStyle,
                  Path = new PropertyPath("ForegroundDescriptor")
                }
              }
            });
        }
      }

      //@this.RenderTransformOrigin = new Point(.5, .5);
      double angle;
      switch (textualStyle.TextRotation)
      {
        case TextRotation.None:
          angle = 0;
          break;
        case TextRotation.Left:
          angle = -90;
          break;
        case TextRotation.Right:
          angle = 90;
          break;
        default:
          throw new InvalidEnumArgumentException(nameof(textualStyle.TextRotation), (int)textualStyle.TextRotation, typeof(TextRotation));
      }
      @this.LayoutTransform = new RotateTransform(angle, .5, .5);
    }



  }
}

//BindingOperations.SetBinding(@this.RenderTransform, RotateTransform.AngleProperty,
//	new Binding(TextRotationProperty.Name)
//	{
//		Converter = new TextRotationToAngleConverter(),
//		Source = textualStyle
//	});

//var border = new Border();
//@this.Bind(TextElement.FontFamilyProperty).To(FontFamilyProperty, textualStyle);
//@this.Bind(TextElement.FontStyleProperty).To("FontStyle", Find.AncestorAt<AbstractMVVMFlexChart>());
//@this.Bind(o => o.FontFamily).To2(border, o => o.Background.Opacity);
