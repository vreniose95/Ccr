using Ccr.PresentationCore.Helpers.DependencyHelpers;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ccr.MaterialDesign.Primitives.Behaviors
{
	public static class TextAssist
	{
		private static readonly Type _type = typeof(TextAssist);


		public static readonly DependencyProperty ForceCapitalizeTextProperty = DP.Attach(
			_type, new MetaBase<bool>(false, onForceCapitalizeTextChanged));


		public static bool GetForceCapitalizeText(DependencyObject @this)
		{
			return @this.Get<bool>(ForceCapitalizeTextProperty);
		}
		public static void SetForceCapitalizeText(DependencyObject @this, bool value)
		{
			@this.Set(ForceCapitalizeTextProperty, value);
		}


		private static void onForceCapitalizeTextChanged(
			DependencyObject @this,
			DPChangedEventArgs<bool> args)
		{
			if (args.NewValue)
			{
				switch (@this)
				{
					case TextBlock textBlock:
						textBlock.TextInput += onTextInput;
						break;

					case TextBox textbox:
						textbox.TextInput += onTextInput;
						textbox.TextChanged += onTextChanged;
						break;

					case Button button:
					{
						var descriptor = DependencyPropertyDescriptor
							.FromProperty(
								ContentControl.ContentProperty,
								typeof(Button));

						descriptor?.AddValueChanged(
							button, onButtonContentChanged);
						break;
					}
					case Label label:
					{
						var descriptor = DependencyPropertyDescriptor
							.FromProperty(
								ContentControl.ContentProperty,
								typeof(Label));

						descriptor?.AddValueChanged(label, onLabelContentChanged);
						break;
					}
				}
			}
			else
			{
				switch (@this)
				{
					case TextBlock textBlock:
						textBlock.TextInput -= onTextInput;
						break;

					case TextBox textbox:
						textbox.TextInput -= onTextInput;
						textbox.TextChanged -= onTextChanged;
						break;

					case Button button:
					{
						var descriptor = DependencyPropertyDescriptor
							.FromProperty(
								ContentControl.ContentProperty,
								typeof(Button));

						descriptor?.RemoveValueChanged(
							button, onButtonContentChanged);
						break;
					}
					case Label label:
					{
						var descriptor = DependencyPropertyDescriptor
							.FromProperty(
								ContentControl.ContentProperty,
								typeof(Label));

						descriptor?.RemoveValueChanged(
							label, onLabelContentChanged);
						break;
					}
				}
			}
		}

		private static void onButtonContentChanged(
			object sender, EventArgs args)
		{
			if (!(sender is Button button))
				return;

			var descriptor = DependencyPropertyDescriptor
				.FromProperty(ContentControl.ContentProperty, typeof(Button));

			descriptor?.RemoveValueChanged(button, onButtonContentChanged);

			var initialContent = button.Content.ToString();
			var newContent = initialContent.ToUpper();
			button.Content = newContent;

			descriptor?.AddValueChanged(
				button, onButtonContentChanged);
		}

		private static void onLabelContentChanged(
			object sender, EventArgs args)
		{
			if (!(sender is Label label))
				return;

			var descriptor = DependencyPropertyDescriptor
				.FromProperty(ContentControl.ContentProperty,
					typeof(Label));

			descriptor?.RemoveValueChanged(label, onLabelContentChanged);

			var initialContent = label.Content.ToString();
			var newContent = initialContent.ToUpper();
			label.Content = newContent;

			descriptor?.AddValueChanged(
				label, onLabelContentChanged);
		}

		private static void onTextInput(
			object sender,
			TextCompositionEventArgs args)
		{
			var text = args.Text.ToUpper();

			switch (args.Source)
			{
				case TextBlock textBlock:
					textBlock.TextInput -= onTextInput;
					textBlock.Text = text;
					textBlock.TextInput += onTextInput;
					break;

				case TextBox textbox:
					textbox.TextInput -= onTextInput;
					textbox.TextChanged -= onTextChanged;
					textbox.Text = text;
					textbox.TextInput += onTextInput;
					textbox.TextChanged += onTextChanged;
					break;
			}
		}

		private static void onTextChanged(
			object sender,
			TextChangedEventArgs args)
		{
		}
	}
}
