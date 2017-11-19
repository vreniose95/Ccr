using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using Ccr.Core.Extensions;
using Ccr.MaterialDesign.Markup.TypeConverters;
using Ccr.MaterialDesign.Primitives.Behaviors.Services;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using Ccr.PresentationCore.Media;

// ReSharper disable ArrangeAccessorOwnerBody
namespace Ccr.MaterialDesign
{
	/// <summary>
	/// A wrapper for both the <see cref="System.Windows.Media.Color"/> struct as well as an 
	/// opaque instance of the <see cref="SolidColorBrush"/> class.
	/// </summary>
	[DictionaryKeyProperty(nameof(Identity))]
  [TypeConverter(typeof(MaterialBrushConverter))]
  public class MaterialBrush
		: HostedElement<Swatch>
	{
    public static readonly DependencyProperty IdentityProperty = DP.Register(
      new Meta<MaterialBrush, MaterialIdentity>());

	  public static readonly DependencyProperty ColorProperty = DP.Register(
			new Meta<MaterialBrush, Color>(Colors.Transparent, onColorChanged));

	  protected static readonly DependencyPropertyKey BrushPropertyKey = DP.RegisterReadOnly(
	    new Meta<MaterialBrush, SolidColorBrush>());
	  public static readonly DependencyProperty BrushProperty = BrushPropertyKey.DependencyProperty;

    

    public MaterialIdentity Identity
		{
			get { return (MaterialIdentity)GetValue(IdentityProperty);}
	    set { SetValue(IdentityProperty, value); }
		}
		public Color Color
		{
			get { return (Color)GetValue(ColorProperty); }
			set { SetValue(ColorProperty, value); }
		}
	  public SolidColorBrush Brush
	  {
	    get => (SolidColorBrush)GetValue(BrushProperty);
	    protected set => SetValue(BrushPropertyKey, value);
	  }

    public string Hex
		{
			get
			{
				return Color.ToString();
			}
			set
			{
				Color = ColorConverter.ConvertFromString(value).As<Color>();
			}
		}

    private HslColor? _hslColor;
		protected HslColor HslColor
		{
			get
			{
				if (_hslColor == null)
					_hslColor = HslColor.FromColor(Color);

				return _hslColor.Value;
			}
		}

		private HsvColor? _hsvColor;
		protected HsvColor HsvColor
		{
			get
			{
				if (_hsvColor == null)
					_hsvColor = HsvColor.FromColor(Color);

				return _hsvColor.Value;
			}
		}
    
	  private MaterialBrush _invert;
	  protected MaterialBrush Invert
	  {
	    get
	    {
	      if (_invert == null)
	        _invert = new MaterialBrush
	        {
	          Color = Color.Invert()
	        };

	      return _invert;
	    }
	  }

	  private static void onColorChanged(
	    MaterialBrush @this,
	    DPChangedEventArgs<Color> args)
	  {
	    @this.Brush = new SolidColorBrush(args.NewValue);
	  }

    public static implicit operator SolidColorBrush(
      MaterialBrush @this)
	  {
	    return @this.Brush;
	  }
	  public static implicit operator Brush(
	    MaterialBrush @this)
	  {
	    return @this.Brush;
	  }
	  public static implicit operator Color(
	    MaterialBrush @this)
	  {
	    return @this.Color;
	  }
    public static implicit operator HslColor(
	    MaterialBrush @this)
	  {
	    return @this.HslColor;
	  }
	  public static implicit operator HsvColor(
	    MaterialBrush @this)
	  {
	    return @this.HsvColor;
	  }



	  private static void onKeyPathChanged(
	    MaterialBrush @this,
	    DPChangedEventArgs<object> args)
	  {


	  }


    


  }
}
