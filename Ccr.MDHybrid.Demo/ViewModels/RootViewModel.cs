using System.Collections.ObjectModel;
using Caliburn.Micro;
using Ccr.MaterialDesign.Controls.Icons;
using Ccr.MaterialDesign.MVVM;
using Ccr.MDHybrid.Demo.Models;

namespace Ccr.MDHybrid.Demo.ViewModels
{
	public class RootViewModel
		: ViewModelBase
	{
		private ObservableCollection<ExpanderItemSelection> _categoriesExpanderItems;
		public ObservableCollection<ExpanderItemSelection> CategoriesExpanderItems
		{
			get => _categoriesExpanderItems;
			set
			{
				_categoriesExpanderItems = value;
				NotifyOfPropertyChange(() => CategoriesExpanderItems);
			}
		}


		public RootViewModel()
		{
			CategoriesExpanderItems = new BindableCollection<ExpanderItemSelection>
			{
				new ExpanderItemSelection(IconKind.Shovel, "Action"),
				new ExpanderItemSelection(IconKind.Netflix, "Adventure"),
				new ExpanderItemSelection(IconKind.Coffee, "Casual"),
				new ExpanderItemSelection(IconKind.ShieldOutline, "Strategy"),
				new ExpanderItemSelection(IconKind.LibraryBooks, "Intellectual"),
				new ExpanderItemSelection(IconKind.Football, "Sport"),
			};
		}
	}
}



//CardDemoView = new CardDemoViewModel();
/*
    private CardDemoViewModel cardDemoView;
    public CardDemoViewModel CardDemoView
    {
      get => cardDemoView;
      set
      {
        cardDemoView = value;
        NotifyOfPropertyChange(() => CardDemoView);
      }
    }


    private string testProperty = "Some Nonsense";
    public string TestProperty
    {
      get => testProperty;
      set
      {
        testProperty = value;
        NotifyOfPropertyChange(() => TestProperty);
      }
    }

    private Palette materialDesignPalette;
    public Palette MaterialDesignPalette
    {
      get => materialDesignPalette;
      set
      {
        materialDesignPalette = value;
        NotifyOfPropertyChange(() => MaterialDesignPalette);
      }
    }


    //private NavigationViewModel navigationView;
    //public NavigationViewModel NavigationView
    //{
    //  get => navigationView;
    //  set
    //  {
    //    navigationView = value;
    //    NotifyOfPropertyChange(() => NavigationView);
    //  }
    //}

    //public RootViewModel()
    //{
    //  NavigationView = new NavigationViewModel();
    //}

    //private Palette materialPalette;
    //public Palette MaterialPalette
    //{
    //  get => materialPalette;
    //  set
    //  {
    //    materialPalette = value;
    //    NotifyOfPropertyChange(() => MaterialPalette);
    //  }
    //}

    //public RootViewModel()
    //{
    //  MaterialPalette =
    //}

    public ICommand ChangeItCommand => new Command(
      t =>
      {
        MaterialDesignPalette = GlobalResources.Palette;
        AnalyzePalette();
      });

    private static (double actual, double modified) GetDist(double x)
    {
      if (x.IsNotWithin((0d, 1d)))
        throw new ArgumentOutOfRangeException();

      var distanceFrom1 = (1 - x).Abs();
      var distanceFrom0 = (x).Abs();

      return (actual: x, modified: distanceFrom1.Smallest(distanceFrom0));
    }

    private static double GetDistMod(double x)
    {
      if (x.IsNotWithin((0d, 1d)))
        throw new ArgumentOutOfRangeException();

      var distanceFrom1 = (1 - x).Abs();
      var distanceFrom0 = (x).Abs();

      return distanceFrom1.Smallest(distanceFrom0);
    }

    private static double GetSmallest360(double x)
    {
      if (x.IsNotWithin((0d, 360d)))
        throw new ArgumentOutOfRangeException();

      var negativeSide = x - 360d;
      var absNegativeSide = negativeSide.Abs();
      var normalSide = x;

      return absNegativeSide < normalSide
        ? negativeSide
        : normalSide;
    }

    private void AnalyzePalette()
    {
      var satmap = new double[19, 10];
      foreach (var swatch in MaterialDesignPalette)
      {
        //var hslSeries = swatch
        //  .Primaries
        //  .Select(
        //    t => t
        //      .Brush
        //      .Color
        //      .ToHslColor())
        //  .ToArray();
        var hslIdentitySeries = swatch
          .Primaries
          .Select(
            t => (identity: t.Identity,
                  hsl: t
                    .Brush
                    .Color
                    .ToHslColor()))
          .ToArray();

        int yi = 0;
        foreach (var hslIdentity in hslIdentitySeries)
        {
          var x = (int) hslIdentity.identity.SwatchClassifier;
          //var y = hslIdentity.identity.Luminosity.LuminosityIndex;
          satmap[x, yi] = GetDistMod(hslIdentity.hsl.L);

          yi++;
        }
        //


        //var hSeries = hslSeries
        // .Select(t => t.H)
        // .Select(GetDist)
        // .Select(t => t.modified)
        // .ToArray();


        //var hueSeries = swatch
        //  .Primaries
        //  .Select(
        //    t => (double)t
        //      .Brush
        //      .Color
        //      .GetHue())
        //   .Select(GetSmallest360)
        //  .ToArray();

        //var hueStats
        //  = new DescriptiveStatistics(hueSeries, true);

//        Debug.WriteLine($@"
////[swatch:{swatch.SwatchClassifier.ToString().Quote()}, channel:pureHue]
////{{
////  [mean]     = {hueStats.Mean}
////  [std-dev]  = {hueStats.StandardDeviation}
////  [variance] = {hueStats.Variance}  
////}}");
////      }


        //PrintStdDeviationStatistics(
        //  swatch.SwatchClassifier,
        //  "H => Hue",
        //  hSeries.ToDictionary(
        //    t => t.actual,
        //    t => t.modified));


        //var hSeries = hslSeries
        //  .Select(t => t.H)
        //  .Select(GetDist)
        //   .ToArray();

        //var sSeries = hslSeries
        //  .Select(t => t.S)
        //   .Select(GetDist)
        //  .ToArray();

        //var lSeries = hslSeries
        //  .Select(t => t.L)
        //  .Select(GetDist)
        //   .ToArray();

        //PrintDescriptiveStatistics(
        //  swatch.SwatchClassifier,
        //  "H => Hue",
        //  hSeries);

        //PrintDescriptiveStatistics(
        //  swatch.SwatchClassifier,
        //  "S => Saturation",
        //  sSeries);

        //PrintDescriptiveStatistics(
        //  swatch.SwatchClassifier,
        //  "L => Lightness",
        //  lSeries);


        // foreach (var brush in swatch)
        //{
        //  var hsl = brush.Brush.Color.ToHslColor();
        //   Debug.WriteLine($"{brush.Identity} -> HSL ({hsl.H}, {hsl.S}, {hsl.L})");

        //}
      }

      for (var y = 0; y < 10; y++)
      {
        for (var x = 0; x < 19; x++)
        {
          Debug.Write($"{satmap[x, y]}, ");
        }

        Debug.WriteLine("");
      }
    }

    private void PrintStdDeviationStatistics(
      SwatchClassifier classifier,
      string channelName,
      IDictionary<double, double> series)
    {
      var actualStats
        = new DescriptiveStatistics(series.Keys, true);

      var modifiedStats
        = new DescriptiveStatistics(series.Values, true);

      Debug.WriteLine($@"
[swatch:{classifier.ToString().Quote()}, channel:{channelName.Quote()}]
{{
  [mean]     = {modifiedStats.Mean}
  [std-dev]  = {modifiedStats.StandardDeviation}
  [variance] = {modifiedStats.Variance}  
}}");
    }

    private void PrintDescriptiveStatistics(
      SwatchClassifier classifier,
      string channelName,
      double[] series)
    {
      var lStats
        = new DescriptiveStatistics(series, true);

      Debug.WriteLine($@"
[DescriptiveStatistics(swatch:{classifier.ToString().Quote()}, channel:{channelName.Quote()}]
{{
  [count]      = {lStats.Count}
  [kurtosis]   = {lStats.Kurtosis}
  [mean]       = {lStats.Mean}
  [min, max]   = [{lStats.Minimum}, {lStats.Maximum}]
  {{
    [skewness] = {lStats.Skewness}
    [std-dev]  = {lStats.StandardDeviation}
    [variance] = {lStats.Variance}
  }}
}}");
    }
  }
}


//var colorConverter = new ColorConverter();

//Color FromHex(string hex)
//{
//  var converted = colorConverter.ConvertFrom(hex);
//  if (!(converted is Color color))
//    throw new FormatException();
//  return color;
//}

//var result = FromHex("#0000FF")
//  .ContrastRatio(FromHex("#FFFFFF")); // 8.59 : 1

//var result2 = FromHex("#0080C0")
//  .ContrastRatio(FromHex("#FF0080")); // 1.15 : 1

//var result3 = FromHex("#FF0000")
//  .ContrastRatio(FromHex("#00FF40")); // 2.93 : 1

//var result4 = FromHex("#C0C0C0")
//  .ContrastRatio(FromHex("#FFFFFF")); // 1.82 : 1


//var resulta = FromHex("#0000FF")
//  .LuminosityContrast(FromHex("#FFFFFF")); // 8.59 : 1

//var resultb = FromHex("#0080C0")
//  .LuminosityContrast(FromHex("#FF0080")); // 1.15 : 1

//var resultc = FromHex("#FF0000")
//  .LuminosityContrast(FromHex("#00FF40")); // 2.93 : 1

//var resultd = FromHex("#C0C0C0")
//  .LuminosityContrast(FromHex("#FFFFFF")); // 1.82 : 1


  */
