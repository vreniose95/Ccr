using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Ccr.Core.Extensions;
using Ccr.MaterialDesign.Infrastructure.Descriptors;
using Ccr.MaterialDesign.Markup.TypeConverters;
using Ccr.MaterialDesign.Primitives.Infrastructure;
using Ccr.PresentationCore.Helpers.DependencyHelpers;

namespace Ccr.MaterialDesign.Primitives.Textual
{
  // [130%|1.3em] [t|l|n|m|b|h] [n|o|i]
  //TODO attached property for FrameworkElements, <Label TextualAssist.Stlye={Binding xxx}/>
  //TODO auto inherit textual styles to presenters?
  [TypeConverter(typeof(TextualStyleConverter))]
  public partial class TextualStyle
    : Freezable
  {
    public static readonly DependencyProperty ForegroundDescriptorProperty = DP.Register(
      new Meta<TextualStyle, AbstractMaterialDescriptor>(Static.Descriptors.A100Descriptor));//WhiteDescriptor));

    public static readonly DependencyProperty FontFamilyProperty = TextElement.FontFamilyProperty.Add(new Meta<TextualStyle, FontFamily>(Static.Text.Fonts.Roboto));

    public static readonly DependencyProperty FontWeightProperty = TextElement.FontWeightProperty.Add(new Meta<TextualStyle, FontWeight>());

    public static readonly DependencyProperty FontStretchProperty = TextElement.FontStretchProperty.Add(new Meta<TextualStyle, FontStretch>());

    public static readonly DependencyProperty RelativeFontSizeProperty = DP.Register(new Meta<TextualStyle, double>(1d));

    public static readonly DependencyProperty FontStyleProperty = TextElement.FontStyleProperty.Add(new Meta<TextualStyle, FontStyle>());

    public static readonly DependencyProperty PaddingProperty = DP.Register(new Meta<TextualStyle, Thickness>(new Thickness(5)));

    public static readonly DependencyProperty TextRotationProperty = DP.Register(new Meta<TextualStyle, TextRotation>(TextRotation.None, CcrControl.FXR));


    public AbstractMaterialDescriptor ForegroundDescriptor
    {
      get { return (AbstractMaterialDescriptor)GetValue(ForegroundDescriptorProperty); }
      set { SetValue(ForegroundDescriptorProperty, value); }
    }
    public FontFamily FontFamily
    {
      get { return (FontFamily)GetValue(FontFamilyProperty); }
      set { SetValue(FontFamilyProperty, value); }
    }
    public FontWeight FontWeight
    {
      get { return (FontWeight)GetValue(FontWeightProperty); }
      set { SetValue(FontWeightProperty, value); }
    }
    public FontStretch FontStretch
    {
      get { return (FontStretch)GetValue(FontStretchProperty); }
      set { SetValue(FontStretchProperty, value); }
    }
    public double RelativeFontSize
    {
      get { return (double)GetValue(RelativeFontSizeProperty); }
      set { SetValue(RelativeFontSizeProperty, value); }
    }
    public FontStyle FontStyle
    {
      get { return (FontStyle)GetValue(FontStyleProperty); }
      set { SetValue(FontStyleProperty, value); }
    }
    public Thickness Padding
    {
      get { return (Thickness)GetValue(PaddingProperty); }
      set { SetValue(PaddingProperty, value); }
    }
    public TextRotation TextRotation
    {
      get { return (TextRotation)GetValue(TextRotationProperty); }
      set { SetValue(TextRotationProperty, value); }
    }



    public TextualStyle() { }

    public TextualStyle(double relativeFontSize)
    {
      RelativeFontSize = relativeFontSize;
    }


    public Size PredictRenderSizeAllocation(string text, double relativeToFontSize)
    {
      var textFontSize = relativeToFontSize * RelativeFontSize;
      if (textFontSize <= 0)
        return new Size(0, 0);

      var renderSize = RenderingExtensions.EstimateTextRenderSize(FontFamily, textFontSize, Padding, text);
      if (TextRotation == TextRotation.None)
        return renderSize;

      //var largest = renderSize.Largest();
      //return new Size(largest, largest);

      return new Size(renderSize.Height, renderSize.Width);
    }

    public override string ToString()
    {
      var formattedRelativeFontSize = $"{RelativeFontSize}em ";
      var formattedFontWeight = FontWeight == FontWeights.Normal ?
        "" : $"{FontWeight.ToString().ToLower().First()}";
      var formattedFontStyle = FontStyle == FontStyles.Normal ?
        "" : $"{FontWeight.ToString().ToLower().First()}";
      //var formattedForegroundDescriptor =

      return $"{formattedRelativeFontSize}em " +
             $"{formattedFontWeight} " +
             $"{formattedFontStyle} ";
    }

    protected override Freezable CreateInstanceCore()
    {
      return new TextualStyle();
    }
  }
}
