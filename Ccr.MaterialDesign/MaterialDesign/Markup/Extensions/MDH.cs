using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Markup;
using System.Windows.Media;
using Ccr.MaterialDesign.Static;
using JetBrains.Annotations;

namespace Ccr.MaterialDesign.Markup.Extensions
{
  [MarkupExtensionReturnType(typeof(SolidColorBrush))]
  public class MDH
    : MarkupExtension,
      INotifyPropertyChanged
  {
    private SwatchClassifier swatch;
    public SwatchClassifier Swatch
    {
      private get { return swatch; }
      set
      {
        swatch = value;
        OnPropertyChanged();
      }
    }

    private int luminosity;
    public int Luminosity
    {
      private get { return luminosity; }
      set
      {
        luminosity = value;
        OnPropertyChanged();
      }
    }

    private bool isAccent;
    public bool IsAccent
    {
      get => isAccent;
      set
      {
        isAccent = value;
        OnPropertyChanged();
      }
    }


    public override object ProvideValue(
      IServiceProvider serviceProvider)
    {
      try
      {
        var _swatch = GlobalResources
          .MaterialDesignPalette
          .GetSwatch(Swatch);

        var _luminosity = new Luminosity(Luminosity, IsAccent);

        var material = _swatch.GetMaterial(_luminosity);
        
        return material.Brush;
      }
      catch (Exception ex)
      {
        return Brushes.Yellow;
      }


    }

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
    }
  }
}
