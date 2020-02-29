using System;
using System.Windows;
using System.Windows.Input;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using Ccr.Std.Core.Extensions;

namespace Ccr.MaterialDesign.Primitives.Behaviors.Services
{
	public static class MaterialWindowAssist
	{
		private static readonly Type _type = typeof(MaterialWindowAssist);


		public static readonly DependencyProperty AttachProperty = DP.Attach(
			_type, new MetaBase<bool>(false, onAttachPropertyChanged));


		public static bool GetAttach(DependencyObject @this)
		{
			return @this.Get<bool>(AttachProperty);
		}
		public static void SetAttach(DependencyObject @this, bool value)
		{
			@this.Set(AttachProperty, value);
		}


		private static void onAttachPropertyChanged(
			DependencyObject @this,
			DPChangedEventArgs<bool> args)
		{
			var window = @this.AsOrDefault<Window>();
			if (window == null)
				throw new NotSupportedException(
					$"The {nameof(AttachProperty).SQuote()} attached property can only be used on the " +
					$"type {nameof(Window).SQuote()}.");

			if (args.NewValue)
			{
				window
					.CommandBindings
					.Add(
						new CommandBinding(
							SystemCommands.CloseWindowCommand,
							OnCloseWindow));

				window
					.CommandBindings
					.Add(
						new CommandBinding(
							SystemCommands.MaximizeWindowCommand,
							OnMaximizeWindow,
							OnCanResizeWindow));

				window
					.CommandBindings
					.Add(
						new CommandBinding(
							SystemCommands.MinimizeWindowCommand,
							OnMinimizeWindow,
							OnCanMinimizeWindow));

				window
					.CommandBindings
					.Add(
						new CommandBinding(
							SystemCommands.RestoreWindowCommand,
							OnRestoreWindow,
							OnCanResizeWindow));
			}
		}

		public static void OnCanResizeWindow(
			object sender,
			CanExecuteRoutedEventArgs args)
		{
			var window = (Window)sender;
			args.CanExecute
				= window.ResizeMode == ResizeMode.CanResize
				|| window.ResizeMode == ResizeMode.CanResizeWithGrip;
		}

		public static void OnCanMinimizeWindow(
			object sender,
			CanExecuteRoutedEventArgs args)
		{
			var window = (Window)sender;
			args.CanExecute = window.ResizeMode != ResizeMode.NoResize;
		}

		public static void OnCloseWindow(
			object target,
			ExecutedRoutedEventArgs args)
		{
			var window = (Window)target;
			SystemCommands.CloseWindow(window);
		}

		public static void OnMaximizeWindow(
			object target,
			ExecutedRoutedEventArgs args)
		{
			var window = (Window)target;
			SystemCommands.MaximizeWindow(window);
		}

		public static void OnMinimizeWindow(
			object target,
			ExecutedRoutedEventArgs args)
		{
			var window = (Window)target;
			SystemCommands.MinimizeWindow(window);
		}

		public static void OnRestoreWindow(
			object target,
			ExecutedRoutedEventArgs args)
		{
			var window = (Window)target;
			SystemCommands.RestoreWindow(window);
		}

	}
}
