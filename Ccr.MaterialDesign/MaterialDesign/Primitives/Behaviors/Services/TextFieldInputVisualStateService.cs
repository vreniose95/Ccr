using System;
using System.Windows;
using System.Windows.Input;
using Ccr.Core.Extensions;
using Ccr.MaterialDesign.Adapters;
using Ccr.MaterialDesign.Validation;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.MaterialDesign.Primitives.Behaviors.Services
{
	public class TextFieldInputVisualStateService
		: AbstractElementProxyService<IFrameworkInputElement>
	{
		protected static class HintVisualStates
		{
			private const string prefix = "Hint";

			public const string Visible = prefix + nameof(Visible);
			public const string Small = prefix + nameof(Small);
			public const string Invisible = prefix + nameof(Invisible);
		}
		
		protected static class ValidationVisualStates
		{
			private const string prefix = "Validation";

			public const string None = "No" + prefix;
			public const string Failed = prefix + nameof(Failed);
			public const string Passed = prefix + nameof(Passed);
		}


		protected override void OnElementAttaching(
			IFrameworkInputElement element)
		{
			var frameworkElement = element.AsOrDefault<FrameworkElement>();
			if (frameworkElement == null)
				throw new NotSupportedException(
					$"Cannot host a {nameof(TextFieldInputVisualStateService).SQuote()} on the type " +
					$"{element.GetType().Name.SQuote()} because it must be assignable to the type " +
					$"{nameof(FrameworkElement).SQuote()}.");

			HintAssist.SetInputDataAdapter(frameworkElement, new TextFieldInputDataAdapter(element));

			frameworkElement.Loaded += OnLoaded;

			element.GotKeyboardFocus += OnGotKeyboardFocus;
			element.LostKeyboardFocus += OnLostKeyboardFocus;
			element.PreviewTextInput += OnPreviewTextInput;
		}

		protected override void OnElementDetaching(
			IFrameworkInputElement element)
		{
			var frameworkElement = element.As<FrameworkElement>();

			HintAssist.SetInputDataAdapter(frameworkElement, null);

			frameworkElement.Loaded -= OnLoaded;

			element.GotKeyboardFocus -= OnGotKeyboardFocus;
			element.LostKeyboardFocus -= OnLostKeyboardFocus;
			element.PreviewTextInput -= OnPreviewTextInput;
		}

		
		private static void OnLoaded(object sender, RoutedEventArgs args)
		{
			var frameworkElement = args.Source.As<FrameworkElement>();

			if (frameworkElement.IsKeyboardFocused)
				frameworkElement.GoToVisualState(HintVisualStates.Small);

			var inputDataAdapter = frameworkElement.GetInputDataAdapter();

			if (!inputDataAdapter.Text.IsNullOrEmptyEx())
				frameworkElement.GoToVisualState(HintVisualStates.Small);
		}


		private static void OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs args)
		{
			var frameworkElement = args.Source.As<FrameworkElement>();

			frameworkElement.GoToVisualState(HintVisualStates.Small);
		}

		private void OnLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs args)
		{
			OnLossOfFocus(sender, args);
		}

		private void OnLossOfFocus(object sender, RoutedEventArgs args)
		{
			var isValidationResolved = false;

			var frameworkElement = args.Source.As<FrameworkElement>();

			var isRequiredField = frameworkElement.GetIsRequiredField();
			var effectiveText = frameworkElement.GetEffectiveText();

			if (isRequiredField)
			{
				if (effectiveText.IsNullOrEmptyEx())
				{
					var validator = frameworkElement.GetValidator();
					if (validator != null)
					{
						frameworkElement.GoToVisualState("ValidationFailed");
						validator.Message = "this field is required";
					}
					isValidationResolved = true;
				}
			}

			frameworkElement.GoToVisualState(
				effectiveText.IsNullOrEmptyEx()
					? HintVisualStates.Visible
					: HintVisualStates.Small);

			if (!isValidationResolved)
				EvaluateValidationState(frameworkElement);
		}
		
		private void OnPreviewTextInput(object sender, TextCompositionEventArgs args)
		{
			var frameworkElement = args.Source.As<FrameworkElement>();

			var validator = frameworkElement.GetValidator();
			if (validator?.ValidatorMode == ValidatorMode.Aggressive)
			{
				EvaluateValidationState(frameworkElement, args);
			}
		}

		public void EvaluateValidationState(
			FrameworkElement frameworkElement,
			[CanBeNull] TextCompositionEventArgs aggressiveValidationArgs = null)
		{
			string targetState;

			var validator = frameworkElement.GetValidator();
			if (validator == null)
			{
				targetState = ValidationVisualStates.None;
			}
			else
			{
				var effectiveText = frameworkElement.GetEffectiveText(aggressiveValidationArgs);

				var validationResult = validator.Validate(effectiveText);

				targetState = validationResult
				  ? ValidationVisualStates.Passed
				  : ValidationVisualStates.Failed;
			}
			frameworkElement.GoToVisualState(targetState);
		}
	}
}
