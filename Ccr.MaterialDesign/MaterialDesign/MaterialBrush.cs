using System;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using Ccr.Core.Extensions;
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
	[DictionaryKeyProperty(nameof(KeyPath))]
  public class MaterialBrush
		: HostedElement<Swatch>
	{
	  public static readonly DependencyProperty KeyPathProperty = DP.Register(
	    new Meta<MaterialBrush, string>(null, onKeyPathChanged));
    
	  private static readonly DependencyPropertyKey IdentityPropertyKey = DP.RegisterReadOnly(
      new Meta<MaterialBrush, MaterialIdentity>());
    public static readonly DependencyProperty IdentityProperty = IdentityPropertyKey.DependencyProperty;

    public static readonly DependencyProperty ColorProperty = DP.Register(
			new Meta<MaterialBrush, Color>(Colors.Transparent));



    public string KeyPath
	  {
	    get => (string)GetValue(KeyPathProperty);
	    set => SetValue(KeyPathProperty, value);
	  }
    public MaterialIdentity Identity
		{
			get { return (MaterialIdentity)GetValue(IdentityProperty);}
	    protected set { SetValue(IdentityPropertyKey, value); }
		}
		public Color Color
		{
			get { return (Color)GetValue(ColorProperty); }
			set { SetValue(ColorProperty, value); }
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

    private SolidColorBrush _brush;
	  public SolidColorBrush Brush
	  {
	    get
	    {
	      if (_brush == null)
	        _brush = new SolidColorBrush(Color);

	      return _brush;
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

    public static implicit operator SolidColorBrush(
      MaterialBrush @this)
	  {
	    return @this.Brush;
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

	  public static implicit operator Brush(MaterialBrush @this)
	  {
	    return @this.Brush;
	  }

	  private static void onKeyPathChanged(
	    MaterialBrush @this,
	    DPChangedEventArgs<string> args)
	  {


	  }
  }
}
