using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Ccr.Core.Extensions;
using Ccr.MaterialDesign.Primitives.Behaviors;
using Ccr.MaterialDesign.Primitives.Behaviors.Services;
using Ccr.MaterialDesign.Static;
using Ccr.PresentationCore.Media;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;
// ReSharper disable ConvertToAutoPropertyWhenPossible
// ReSharper disable ArrangeAccessorOwnerBody

namespace Ccr.MaterialDesign
{
	public class MaterialBrush
		: HostedElement<Swatch>
	{
		[NotNull]
		private readonly SolidColorBrush _brush;
		[NotNull]
		private readonly MaterialIdentity _identity;
		[CanBeNull]
		private HslColor? _hslColor;
		[CanBeNull]
		private HsvColor? _hsvColor;
		[CanBeNull]
		private MaterialBrush _foregroundMaterial;


		private static readonly IReadOnlyList<MaterialBrush> _foregroundMaterialBrushCandidates
			= new List<MaterialBrush>
			{
				GlobalResources.Palette.GetSwatch(SwatchClassifier.Grey).P050,
				GlobalResources.Palette.GetSwatch(SwatchClassifier.Grey).P050.WithOpacity(.86),
				GlobalResources.Palette.GetSwatch(SwatchClassifier.Grey).P900.WithOpacity(.86),
				GlobalResources.Palette.GetSwatch(SwatchClassifier.Grey).P900
			};

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

		[NotNull]
		public MaterialBrush ForegroundMaterial
		{
			get => _foregroundMaterial ??
				(_foregroundMaterial = _computeForegroundMaterial());
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


		//public static bool TryCreateFromBrushAndIdentity(
		//	//[NotNull] SolidColorBrush brush,
		//	SwatchClassifier classifier,
		//	Luminosity luminosity,
		//	out MaterialBrush materialBrush)
		//{
		//	//brush.IsNotNull(nameof(brush));

		//	var materialIdentity = new MaterialIdentity(classifier, luminosity);

		//	//var identity = brush.GetValue(MDH.IdentityProperty);
		//	//var materialIdentity = identity as MaterialIdentity;

		//	if (materialIdentity == null
		//		|| materialIdentity == DependencyProperty.UnsetValue
		//		|| materialIdentity == null)
		//	{
		//		materialBrush = null;
		//		return false;
		//	}

		//	materialBrush = new MaterialBrush(
		//		brush,
		//		materialIdentity);

		//	return true;
		//}
		

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


		private MaterialBrush _computeForegroundMaterial()
		{
			var resolvedForeground = _foregroundMaterialBrushCandidates
				.Select(
					t =>
					{
						var constrast = Color.ContrastRatio(t.Color);
						return (material: t, contrast: constrast);
					})
				.OrderByDescending(
					t => t.contrast)
				.First();

			return resolvedForeground.material;
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