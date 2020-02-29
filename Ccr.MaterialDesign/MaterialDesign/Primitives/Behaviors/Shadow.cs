using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using Ccr.Std.Core.Extensions;

namespace Ccr.MaterialDesign.Primitives.Behaviors
{
	public static class Shadow
	{
		public static class ShadowInterpolator
		{
			private const double opacity = .42;
			private static readonly Color shadowColor = Colors.Black;

			private static readonly SortedDictionary<double, DropShadowEffect> _cachedShadowEffectMap
				= new SortedDictionary<double, DropShadowEffect>();


			public static DropShadowEffect Interpolate(double level)
			{
				if (_cachedShadowEffectMap.TryGetValue(level, out var cachedDropShadow))
					return cachedDropShadow;

				var blur = calculateBlur(level);
				var depth = calculateDepth(level);

				var interpolatedDropShadow = new DropShadowEffect
				{
					BlurRadius = blur,
					ShadowDepth = depth,
					Direction = 270,
					Color = shadowColor,
					Opacity = opacity
				};

				_cachedShadowEffectMap.Add(level, interpolatedDropShadow);

				return interpolatedDropShadow;
			}

			private static double calculateDepth(double x)
			{
				const double a = .124;
				const double b = -1.5833333333;
				const double c = 7.625;
				const double d = -13.166666667;
				const double e = 8;

				return a * x.Power(4) + b * x.Power(3) + c * x.Power(2) + d * x + e;
			}

			private static double calculateBlur(double x)
			{
				const double a = -.333333333;
				const double b = 4.357142857;
				const double c = -8.30952381;
				const double d = 9.4;

				return a * x.Power(3) + b * x.Power(2) + c * x + d;
			}
		}


		private static readonly Type _type = typeof(Shadow);
		private static readonly BitmapCache _defaultShadowCache = new BitmapCache
		{
			EnableClearType = true,
			SnapsToDevicePixels = true
		};
		
		
		public static readonly DependencyProperty LevelProperty = DP.Attach(
			_type, new MetaBase<double?>(null, onShadowLevelChanged));
		
		public static readonly DependencyProperty ShouldRenderProperty = DP.Attach(
		  _type, new MetaBase<bool>(true, onShouldRenderChanged));

		public static readonly DependencyProperty ShadowCacheModeProperty = DP.Attach(
		  _type, new MetaBase<CacheMode>(_defaultShadowCache, FrameworkPropertyMetadataOptions.Inherits));
		


		public static double? GetLevel(DependencyObject @this)
		{
			return @this.Get<double?>(LevelProperty);
		}
		public static void SetLevel(DependencyObject @this, double? value)
		{
			@this.Set(LevelProperty, value);
		}

		public static bool GetShouldRender(DependencyObject @this)
		{
			return @this.Get<bool>(ShouldRenderProperty);
		}
		public static void SetShouldRender(DependencyObject @this, bool value)
		{
			@this.Set(ShouldRenderProperty, value);
		}

		public static CacheMode GetShadowCacheMode(DependencyObject @this)
		{
			return @this.Get<CacheMode>(ShadowCacheModeProperty);
		}
		public static void SetShadowCacheMode(DependencyObject @this, CacheMode value)
		{
			@this.Set(ShadowCacheModeProperty, value);
		}


		private static void onShadowLevelChanged(
			DependencyObject @this,
			DPChangedEventArgs<double?> args)
		{
			if (@this is UIElement uiElement)
			{
				if (args.NewValue.HasValue)
				{
					var shouldRender = GetShouldRender(uiElement);
					if (!shouldRender || Math.Abs(args.NewValue.Value) < 0.001)
					{
						uiElement.Effect = null;
					}
					else
					{
						var shadow = ShadowInterpolator.Interpolate(args.NewValue.Value);
						uiElement.Effect = shadow;
					}
				}
				else
				{
					uiElement.Effect = null;
				}
			}
		}

		private static void onShouldRenderChanged(
			DependencyObject @this,
			DPChangedEventArgs<bool> args)
		{
			if (@this is UIElement uiElement)
			{
				if (args.NewValue && !args.OldValue)
				{
					var shadowLevel = GetLevel(uiElement);
					if (!shadowLevel.HasValue)
					{
						uiElement.Effect = null;
					}
					else
					{
						var shadowEffect = ShadowInterpolator.Interpolate(shadowLevel.Value);
						uiElement.Effect = shadowEffect;
					}
				}
				else if (!args.NewValue && args.OldValue)
				{
					uiElement.Effect = null;
				}
				else
				{
				}
			}
		}
	}
}
