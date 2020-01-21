using System;
using System.Windows;
using System.Windows.Input;
using Ccr.MaterialDesign.Adapters;
using Ccr.MaterialDesign.Primitives.Behaviors.Services;
using Ccr.MaterialDesign.Validation;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Core.Extensions
{
	public static class HintAssistExtensions
	{
		[NotNull]
		public static TextFieldInputDataAdapter GetInputDataAdapter(
			[NotNull] this FrameworkElement @this)
		{
			@this.IsNotNull(nameof(@this));

			var inputDataAdapter = HintAssist.GetInputDataAdapter(@this);
			if (inputDataAdapter == null)
				throw new InvalidOperationException(
					$"The \'HintAssist.InputDataAdapter\' attached property has not been set.");

			return inputDataAdapter;
		}

		[CanBeNull]
		public static bool GetIsRequiredField(
			[NotNull] this FrameworkElement @this)
		{
			@this.IsNotNull(nameof(@this));

			return HintAssist.GetIsRequiredField(@this);
		}
		
		[CanBeNull]
		public static IStringValidator GetValidator(
			[NotNull] this FrameworkElement @this)
		{
			@this.IsNotNull(nameof(@this));

			return HintAssist.GetValidator(@this);
		}

		[NotNull]
		public static string GetEffectiveText(
			[NotNull] this FrameworkElement @this,
			TextCompositionEventArgs aggressiveValidationArgs = null)
		{
			@this.IsNotNull(nameof(@this));

			var inputDataAdapter = @this.GetInputDataAdapter();

			var effectiveText = inputDataAdapter.Text;
			if (aggressiveValidationArgs != null)
			{
				effectiveText += aggressiveValidationArgs.Text;
			}
			return effectiveText;
		}

		[CanBeNull]
		public static TextFieldInputVisualStateService GetTextFieldInputVisualStateService(
			[NotNull] this FrameworkElement @this)
		{
			@this.IsNotNull(nameof(@this));
			return HintAssist.GetTextFieldInputVisualStateService(@this);
		}
	}
}