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
	/// An wrapper for both the <see cref="System.Windows.Media.Color"/> struct as well as an 
	/// opaque instance of the <see cref="SolidColorBrush"/> class.
	/// </summary>
	[DictionaryKeyProperty(nameof(Identity))]
	public class MaterialBrush
		: HostedElement<Swatch>
	{
		public static readonly DependencyProperty IdentityProperty = DP.Register(
			new Meta<MaterialBrush, MaterialIdentity>());

		public static readonly DependencyProperty ColorProperty = DP.Register(
			new Meta<MaterialBrush, Color>(Colors.Transparent));


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
		public byte RgbR
		{
			get
			{
				return Color.R;
			}
		}

		public byte RgbG
		{
			get
			{
				return Color.G;;
			}
		}

		public byte RgbB
		{
			get
			{
				return Color.B;
			}
		}

		
		public double HslH
		{
			get
			{
				return HslColor.H;
			}
		}
		public double HslS
		{
			get
			{
				return HslColor.S;
			}
		}
		public double HslL
		{
			get
			{
				return HslColor.L;
			}
		}



		public double HsvH
		{
			get
			{
				return HsvColor.H;
			}
		}
		public double HsvS
		{
			get
			{
				return HsvColor.S;
			}
		}
		public double HsvV
		{
			get
			{
				return HsvColor.V;
			}
		}

		//public static bool TryParseFromHex(
		//	string hexString,
		//	out Material material)
		//{

		//}

		public MaterialBrush()
		{

		}
	}
}
