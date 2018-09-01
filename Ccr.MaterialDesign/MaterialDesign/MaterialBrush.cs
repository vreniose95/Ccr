using System;
using System.Windows;
using System.Windows.Media;
using Ccr.Core.Extensions;
using Ccr.MaterialDesign.Primitives.Behaviors;
using Ccr.MaterialDesign.Primitives.Behaviors.Services;
using Ccr.PresentationCore.Media;
using JetBrains.Annotations;
// ReSharper disable ConvertToAutoPropertyWhenPossible

// ReSharper disable ArrangeAccessorOwnerBody
namespace Ccr.MaterialDesign
{
  public class MaterialBrush
    : HostedElement<
      Swatch>
  {
    #region Fields
    [NotNull]
    private readonly SolidColorBrush _brush;
    [NotNull]
    private readonly MaterialIdentity _identity;
    [CanBeNull]
    private HslColor? _hslColor;
    [CanBeNull]
    private HsvColor? _hsvColor;

    #endregion


    #region Properties
    public Color Color
    {
      get => _brush.Color;
    }

    [NotNull]
    public SolidColorBrush Brush
    {
      get => _brush;
    }

    [NotNull]
    public MaterialIdentity Identity
    {
      get => _identity;
    }

    public HslColor HslColor
    {
      get => _hslColor ??
             (_hslColor = Color.ToHslColor()).Value;
    }

    public HsvColor HsvColor
    {
      get => _hsvColor ??
             (_hsvColor = Color.ToHsvColor()).Value;
    }

    #endregion


    #region Constructors
    internal MaterialBrush(
      [NotNull] SolidColorBrush brush,
      [NotNull] MaterialIdentity identity)
    {
      brush.IsNotNull(nameof(brush));
      identity.IsNotNull(nameof(identity));

      _brush = brush;
      _identity = identity;

      _brush.SetIdentity(_identity);
    }

    #endregion


    public static bool TryCreateFromBrush(
      [NotNull] SolidColorBrush brush,
      out MaterialBrush materialBrush)
    {
      brush.IsNotNull(nameof(brush));

      var identity = brush.GetValue(MDH.IdentityProperty);
      var materialIdentity = identity as MaterialIdentity;

      if (identity == null
          || identity == DependencyProperty.UnsetValue
          || materialIdentity == null)
      {
        materialBrush = null;
        return false;
      }

      materialBrush = new MaterialBrush(
        brush,
        materialIdentity);

      return true;
    }


    public static implicit operator MaterialBrush(
      [NotNull] SolidColorBrush @this)
    {
      @this.IsNotNull(nameof(@this));

      if (!TryCreateFromBrush(@this, out var _materialBrush))
        throw new InvalidOperationException(
          $"Cannot create a {nameof(MaterialBrush).Quote()} from the provided {nameof(@this).SQuote()}" +
          $"argument {nameof(SolidColorBrush).Quote()} because the attached dependency property " +
          $"\'MDH.IdentityProperty\' has not been set on the {nameof(SolidColorBrush).Quote()}.");

      return _materialBrush;
    }

    public static implicit operator SolidColorBrush(
      [NotNull] MaterialBrush @this)
    {
      @this.IsNotNull(nameof(@this));

      return @this.Brush;
    }
  }
}

///// <summary>
///// A wrapper for both the <see cref="System.Windows.Media.Color"/> struct as well as an 
///// opaque instance of the <see cref="SolidColorBrush"/> class.
///// </summary>
//[DictionaryKeyProperty(nameof(Identity))]
// [TypeConverter(typeof(MaterialBrushConverter))]
// public class MaterialBrush
//	: HostedElement<Swatch>
//{
//   public static readonly DependencyProperty IdentityProperty = DP.Register(
//     new Meta<MaterialBrush, MaterialIdentity>());

//  public static readonly DependencyProperty ColorProperty = DP.Register(
//		new Meta<MaterialBrush, Color>(Colors.Transparent, onColorChanged));

//  protected static readonly DependencyPropertyKey BrushPropertyKey = DP.RegisterReadOnly(
//    new Meta<MaterialBrush, SolidColorBrush>());
//  public static readonly DependencyProperty BrushProperty = BrushPropertyKey.DependencyProperty;



//   public MaterialIdentity Identity
//	{
//		get { return (MaterialIdentity)GetValue(IdentityProperty);}
//    set { SetValue(IdentityProperty, value); }
//	}
//	public Color Color
//	{
//		get { return (Color)GetValue(ColorProperty); }
//		set { SetValue(ColorProperty, value); }
//	}
//  public SolidColorBrush Brush
//  {
//    get => (SolidColorBrush)GetValue(BrushProperty);
//    protected set => SetValue(BrushPropertyKey, value);
//  }

//   public string Hex
//	{
//		get
//		{
//			return Color.ToString();
//		}
//		set
//		{
//			Color = ColorConverter.ConvertFromString(value).As<Color>();
//		}
//	}

//   private HslColor? _hslColor;
//	protected HslColor HslColor
//	{
//		get
//		{
//       if (_hslColor == null)
//				_hslColor = HslColor.FromColor(Color);

//			return _hslColor.Value;
//		}
//	}

//	private HsvColor? _hsvColor;
//	protected HsvColor HsvColor
//	{
//		get
//		{
//			if (_hsvColor == null)
//				_hsvColor = HsvColor.FromColor(Color);

//			return _hsvColor.Value;
//		}
//	}

//  private MaterialBrush _invert;
//  protected MaterialBrush Invert
//  {
//    get
//    {
//      if (_invert == null)
//        _invert = new MaterialBrush
//        {
//          Color = Color.Invert()
//        };

//      return _invert;
//    }
//  }

//  private static void onColorChanged(
//    MaterialBrush @this,
//    DPChangedEventArgs<Color> args)
//  {
//    @this.Brush = new SolidColorBrush(args.NewValue);
//  }

//   public static implicit operator SolidColorBrush(
//     MaterialBrush @this)
//  {
//    return @this.Brush;
//  }
//  public static implicit operator Brush(
//    MaterialBrush @this)
//  {
//    return @this.Brush;
//  }
//  public static implicit operator Color(
//    MaterialBrush @this)
//  {
//    return @this.Color;
//  }
//   public static implicit operator HslColor(
//    MaterialBrush @this)
//  {
//    return @this.HslColor;
//  }
//  public static implicit operator HsvColor(
//    MaterialBrush @this)
//  {
//    return @this.HsvColor;
//  }


//  public static MaterialBrush Create(
//     Color color,
//    [CallerMemberName] string memberName = "")
//  {
//    var parts = memberName.Split('_');

//     var swatchName = parts[0];
//    var luminosityStr = parts[1];

//     if (!Enum.TryParse<SwatchClassifier>(swatchName, out var _classifier))
//      throw new InvalidEnumArgumentException();

//     var luminosity = Luminosity.Parse(luminosityStr);

//    var identity = new MaterialIdentity(_classifier, luminosity.IsAccent, luminosity);

//     return new MaterialBrush
//    {
//       Identity = identity,
//       Color = color
//    };
//  }

//  internal static MaterialBrush Create(
//    Color color,
//    MaterialIdentity materialIdentity)
//  {
//    return new MaterialBrush
//    {
//      Identity = materialIdentity,
//      Color = color
//    };
//  }
// }
