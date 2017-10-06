using System;
using System.Windows;
using Ccr.PresentationCore.Helpers.DependencyHelpers;

namespace Ccr.MaterialDesign.Primitives.Behaviors
{
	public static class Shadow
	{
		private static readonly Type _type = typeof(Shadow);

		public static readonly DependencyProperty LevelProperty = DP.Attach(
			_type, new MetaBase<double?>(null, onShadowLevelChanged), shadowLevelPropertyValidator);

		private static bool shadowLevelPropertyValidator(
			double? value)
		{
			if (!value.HasValue)
				return true;

			throw new NotImplementedException();
		}

		private static double? onShadowLevelChanged(
			DependencyObject @this, 
			double? BaseValue)
		{
			throw new NotImplementedException();
		}

		public static double GetLevel(DependencyObject i) => i.Get<double>(LevelProperty);
		public static void SetLevel(DependencyObject i, double v) => i.Set(LevelProperty, v);
		

	}
}
