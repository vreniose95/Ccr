using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Markup;
using System.Windows.Media;
using Ccr.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.MaterialDesign.Markup.Extensions
{
	//[MarkupExtensionReturnType(typeof(SolidColorBrush))]
  //public partial class MDH
  //  : MarkupExtension,
  //    INotifyPropertyChanged
  //{
  //  private SwatchClassifier swatch;
  //  public SwatchClassifier Swatch
  //  {
  //    private get => swatch;
  //    set
  //    {
  //      swatch = value;
  //      OnPropertyChanged();
  //    }
  //  }
    

  //  private int lum;
  //  public int Lum
  //  {
  //    private get => lum;
  //    set
  //    {
  //      lum = value;
  //      OnPropertyChanged();
  //    }
  //  }


  //  private bool a;
  //  public bool A
  //  {
  //    private get => a;
  //    set
  //    {
  //      a = value;
  //      OnPropertyChanged();
  //    }
  //  }

    

  //  public override object ProvideValue(
  //    IServiceProvider serviceProvider)
  //  {
  //    try
  //    {
  //      var _swatch = PaletteMock
  //        .Palette
  //        .GetSwatch(Swatch);

  //      var _luminosity = new Luminosity(Lum, A);

  //      var material = _swatch.GetMaterial(_luminosity);

  //      using (var sw = File.AppendText(
  //        Environment.GetFolderPath(
  //          Environment.SpecialFolder.Desktop) + "/ccrlog.txt"))
  //      {
  //        var identity = material.GetIdentity();

  //        sw.WriteLine($"GOOD: {material} | " +
  //                     $"{identity.SwatchClassifier} | " +
  //                     $"{identity.Luminosity.LuminosityIndex} | " +
  //                     $"{identity.IsAccent}");
  //      }

  //      return material;
  //    } 
  //    catch (Exception ex)
  //    {
  //      using (StreamWriter sw = File.AppendText(
  //        Environment.GetFolderPath(
  //          Environment.SpecialFolder.Desktop) + "/ccrlog.txt"))
  //      {
  //        sw.WriteLine($"EXC: {ex}");
  //      }

  //      return Brushes.Orange;
  //    }
  //  }



  //  public event PropertyChangedEventHandler PropertyChanged;

  //  [NotifyPropertyChangedInvocator]
  //  protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
  //  {
  //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
  //  }
  //}
}
