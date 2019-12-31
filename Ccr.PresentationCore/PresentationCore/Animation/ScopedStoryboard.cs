using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Animation;
using Ccr.Std.Core.Extensions;

namespace Ccr.PresentationCore.Animation
{
	public class ScopedStoryboard 
		: Storyboard
	{
		static ScopedStoryboard()
		{
			var windowsBase = Assembly.LoadFile(
				@"C:\Windows\Microsoft.NET\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll");

			var type = windowsBase
				.DefinedTypes
				.Single(
					t => t.Name == "FreezableDefaultValueFactory");

			var ctors = type
				.GetConstructors(
					BindingFlags.NonPublic | BindingFlags.Instance);

			var paramPropertyReference = typeof(TimelineCollection)
				.GetProperty("Empty",
					BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.NonPublic);

			var propertyValue = paramPropertyReference?.GetValue(null).As<TimelineCollection>();

			var defaultValue = ctors.First()
				.Invoke(
					new[] { (Freezable)propertyValue });

			ChildrenProperty
				.OverrideMetadata(
					typeof(ScopedStoryboard),
					new FrameworkPropertyMetadata(
						defaultValue, 
						onChildrenPropertyChanged));
		}

		private static void onChildrenPropertyChanged(
			DependencyObject o,
			DependencyPropertyChangedEventArgs e)
		{
			var scopedStorybaord = o.As<ScopedStoryboard>();
			scopedStorybaord.onChildrenChanged(o, EventArgs.Empty);
			scopedStorybaord.Children.Changed += scopedStorybaord.onChildrenChanged;
		}


		public ScopedStoryboard()
		{
			Children.Changed += onChildrenChanged;
		}


		private void onChildrenChanged(object s, EventArgs e)
		{
			var groupTargetName = GetTargetName(this);
			if (groupTargetName != null)
			{
				foreach (var animation in Children)
				{
					var targetName = GetTargetName(animation);
					if (targetName == null)
					{
						SetTargetName(animation, groupTargetName);
					}
				}
			}
			if (Duration != Duration.Automatic)
			{
				foreach (var animation in Children)
				{
					if (animation.Duration == Duration.Automatic)
					{
						animation.Duration = Duration;
					}
				}
			}
		}
	}
}
