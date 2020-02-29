using System;
using System.Windows;
using System.Windows.Media;
using Ccr.Core.Extensions;
using Ccr.MaterialDesign.Adapters;
using Ccr.MaterialDesign.Validation;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using Ccr.Std.Core.Extensions;
using static Ccr.MaterialDesign.Primitives.Infrastructure.CcrControl;

namespace Ccr.MaterialDesign.Primitives.Behaviors.Services
{
	public static class HintAssist
	{
		public static Type _type = typeof(HintAssist);

		/// <summary>
		/// Declares an attached <see cref="DependencyProperty"/> property that has a value type
		/// of <see cref="object"/> to the static <see cref="HintAssist"/> class. The getter and 
		/// setter of this attached dependency property can be accessed and manipulated using the 
		/// <see cref="GetHint"/> and <see cref="SetHint"/> methods.
		/// </summary>
		public static readonly DependencyProperty HintProperty = DP.Attach(
			_type, new MetaBase<object>(null, FXR));

		public static readonly DependencyProperty HintOpacityProperty = DP.Attach(
			_type, new MetaBase<double>(0.56d, FXR));

		public static readonly DependencyProperty HintForegroundProperty = DP.Attach(
			_type, new MetaBase<Brush>(Brushes.White));

		public static readonly DependencyProperty ValidatorProperty = DP.Attach(
			_type, new MetaBase<IStringValidator>(null, onValidatorChanged));

		public static readonly DependencyProperty IsRequiredFieldProperty = DP.Attach(
			_type, new MetaBase<bool>());

		public static readonly DependencyProperty InputDataAdapterProperty = DP.Attach(
			_type, new MetaBase<TextFieldInputDataAdapter>());

		public static readonly DependencyProperty TextFieldInputVisualStateServiceProperty = DP.Attach(
			_type, new MetaBase<TextFieldInputVisualStateService>(null, onTextFieldInputVisualStateServiceChanged));

		public static readonly DependencyProperty HelpTextProperty = DP.Attach(
			_type, new MetaBase<string>());



		public static object GetHint(DependencyObject @this)
		{
			return @this.Get<object>(HintProperty);
		}
		public static void SetHint(DependencyObject @this, object value)
		{
			@this.Set(HintProperty, value);
		}

		public static double GetHintOpacity(DependencyObject @this)
		{
			return @this.Get<double>(HintOpacityProperty);
		}
		public static void SetHintOpacity(DependencyObject @this, double value)
		{
			@this.Set(HintOpacityProperty, value);
		}

		public static Brush GetHintForeground(DependencyObject @this)
		{
			return @this.Get<Brush>(HintForegroundProperty);
		}
		public static void SetHintForeground(DependencyObject @this, Brush value)
		{
			@this.Set(HintForegroundProperty, value);
		}

		public static IStringValidator GetValidator(DependencyObject @this)
		{
			return @this.Get<IStringValidator>(ValidatorProperty);
		}
		public static void SetValidator(DependencyObject @this, IStringValidator value)
		{
			@this.Set(ValidatorProperty, value);
		}

		public static bool GetIsRequiredField(DependencyObject @this)
		{
			return @this.Get<bool>(IsRequiredFieldProperty);
		}
		public static void SetIsRequiredField(DependencyObject @this, bool value)
		{
			@this.Set(IsRequiredFieldProperty, value);
		}

		public static TextFieldInputDataAdapter GetInputDataAdapter(DependencyObject @this)
		{
			return @this.Get<TextFieldInputDataAdapter>(InputDataAdapterProperty);
		}
		public static void SetInputDataAdapter(DependencyObject @this, TextFieldInputDataAdapter value)
		{
			@this.Set(InputDataAdapterProperty, value);
		}

		public static TextFieldInputVisualStateService GetTextFieldInputVisualStateService(
		  DependencyObject @this)
		{
			return @this.Get<TextFieldInputVisualStateService>(TextFieldInputVisualStateServiceProperty);
		}
		public static void SetTextFieldInputVisualStateService(DependencyObject @this, TextFieldInputVisualStateService value)
		{
			@this.Set(TextFieldInputVisualStateServiceProperty, value);
		}

		public static string GetHelpText(DependencyObject @this)
		{
			return @this.Get<string>(HelpTextProperty);
		}
		public static void SetHelpText(DependencyObject @this, string value)
		{
			@this.Set(HelpTextProperty, value);
		}

		private static void onValidatorChanged(
			DependencyObject @this,
			DPChangedEventArgs<IStringValidator> args)
		{
			var frameworkElement = @this.AsOrDefault<FrameworkElement>();
			if (frameworkElement == null)
				throw new ArgumentException(
					$"The service \'HintAssist.Validator\' can only be used with elements that inherit " +
					$"from the \'FrameworkElement\' type.");

			var managerService = frameworkElement.GetTextFieldInputVisualStateService();
			managerService?.EvaluateValidationState(frameworkElement);
		}

		private static void onTextFieldInputVisualStateServiceChanged(
			DependencyObject @this,
			DPChangedEventArgs<TextFieldInputVisualStateService> args)
		{
			var visualStateManagerService = args.NewValue;

			var frameworkInputElement = @this.AsOrDefault<IFrameworkInputElement>();
			if (frameworkInputElement == null)
				throw new ArgumentException(
					$"The service \'HintAssist.TextFieldInputVisualStateService\' can only be used " +
					$"with elements that implement the \'IFrameworkInputElement\' interface.");

			visualStateManagerService.AttachElement(frameworkInputElement);
		}
	}
}
