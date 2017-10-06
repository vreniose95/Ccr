using System;
using System.Windows;
using System.Windows.Controls;
using Ccr.Core.Extensions;

namespace Ccr.MaterialDesign.Adapters
{
	public class TextFieldInputDataAdapter
	{
		protected IFrameworkInputElement InputElement { get; }

		public TextFieldInputDataAdapter(
			IFrameworkInputElement inputElement)
		{
			InputElement = inputElement;
		}

		public string Text
		{
			get
			{
				switch (InputElement)
				{
					case TextBox textBox:
						return textBox.Text;

					case RichTextBox richTextBox:
						return richTextBox.GetAllText();

					case PasswordBox passwordBox:
						return passwordBox.Password;

					default:
						throw new NotSupportedException(
							$"The type {InputElement.GetType().Name.SQuote()} is not supported " +
							$"by the type {nameof(TextFieldInputDataAdapter).SQuote()}."
						);
				}
			}
		}
	}
}

