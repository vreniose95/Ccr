using System.Windows;
using Ccr.Introspective.Extensions;
using Ccr.Introspective.Infrastructure;

namespace Ccr.Core.Extensions
{
	public static class ControlExtensions
	{
		public static void OverrideStyleKey<TOwner>()
		{
			var defaultStyleKeyDependencyProperty = 
				typeof(FrameworkElement)
					.Reflect()
					.GetFieldValue<DependencyProperty>(
						MemberDescriptor.NonPublicStatic,
						"DefaultStyleKeyProperty");

			defaultStyleKeyDependencyProperty
				.OverrideMetadata(
					typeof(TOwner), 
					new FrameworkPropertyMetadata(
						typeof(TOwner)));
		}
	}
}
/*	var defaultStyleKey = @this.GetValue(defaultStyleKeyDependencyProperty);
			*/
