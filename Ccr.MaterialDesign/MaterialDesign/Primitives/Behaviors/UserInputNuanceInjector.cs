using System;
using System.Windows;
using Ccr.MaterialDesign.Primitives.Behaviors.Services;
using Ccr.PresentationCore.Helpers.DependencyHelpers;

namespace Ccr.MaterialDesign.Primitives.Behaviors
{
	public static class UserInputNuanceInjector
	{
		private static readonly Type type = typeof(UserInputNuanceInjector);


		public static readonly DependencyProperty NuanceProviderServiceProperty = DP.Attach(type,
			new MetaBase<UserInputNuanceProviderService>(OnProviderServiceChanged));


		public static UserInputNuanceProviderService GetNuanceProviderService(
			DependencyObject @this)
		{
			return @this.Get<UserInputNuanceProviderService>(NuanceProviderServiceProperty);
		}
		public static void SetNuanceProviderService(
			DependencyObject @this,
			UserInputNuanceProviderService value)
		{
			@this.Set(NuanceProviderServiceProperty, value);
		}


		private static void OnProviderServiceChanged(
			DependencyObject @this, 
			DPChangedEventArgs<UserInputNuanceProviderService> args)
		{
			if (!(@this is FrameworkElement frameworkElement))
				throw new NotSupportedException(
					$"The \'UserInputNuanceInjector.NuanceProviderService\' property cannot be set on the " +
					$"element type \'{@this.GetType().Name}\' because \'HostedElement<TElement>\'-based " +
					$"services require the host element to derive from \'FrameworkElement\'.");

			var newService = args.NewValue;
			var oldService = args.OldValue;

			newService?.DetachHost();
			oldService?.AttachHost(frameworkElement);
		}
	}
}
