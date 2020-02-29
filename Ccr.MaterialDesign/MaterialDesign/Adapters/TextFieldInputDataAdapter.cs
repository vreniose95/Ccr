using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Ccr.Core.Extensions;
using Ccr.PresentationCore.Helpers.DependencyHelpers;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.MaterialDesign.Adapters
{
	/// <summary>
	/// Establishes a unifying adapter for the common properties and events for basic text 
	/// input and processing controls in WPF. This data adapter supports usage with controls 
	/// that implement the <see cref="IFrameworkInputElement"/> interface. These controls 
	/// are <see cref="TextBox"/>, <see cref="RichTextBox"/>, and <see cref="PasswordBox"/>.
	/// </summary>
	public class TextFieldInputDataAdapter
		: DependencyObject
	{
		internal abstract class InputElementMonitor
		{
			protected internal abstract Func<IFrameworkInputElement, string> InputElementTextGetterBase { get; }

			internal abstract Type ElementType { get; }

			internal RoutedEvent RoutedEvent { get; }


			protected InputElementMonitor(
			  RoutedEvent routedEvent)
			{
				RoutedEvent = routedEvent;
			}
		}


		internal class InputElementMonitor<TElement>
			: InputElementMonitor
				where TElement : IFrameworkInputElement
		{
			public Func<TElement, string> InputElementTextGetter { get; }

			internal override Type ElementType
			{
				get => typeof(TElement);
			}

			protected internal override Func<IFrameworkInputElement, string> InputElementTextGetterBase
			{
				get => fie => InputElementTextGetter(fie.As<TElement>());
			}


			public InputElementMonitor(
				RoutedEvent routedEvent,
				Func<TElement, string> inputElementTextGetter)
					: base(routedEvent)
			{
				InputElementTextGetter = inputElementTextGetter;
			}
		}


		/// <summary>
		/// This public, get-only property of type <see cref="IFrameworkInputElement"/> holds 
		/// a reference to the target <see cref="Control"/> in which the adapter is attached to.
		/// </summary>
		public static readonly DependencyProperty FrameworkInputElementProperty = DP.Register(
			new Meta<TextFieldInputDataAdapter, IFrameworkInputElement>(
				null, OnFrameworkInputElementPropertyChange));

		internal static readonly IList<InputElementMonitor> InputElementMonitors
			= new List<InputElementMonitor>
			{
				new InputElementMonitor<TextBox>(
					TextBoxBase.TextChangedEvent,
					t => t.Text),
				
				new InputElementMonitor<RichTextBox>(
					TextBoxBase.TextChangedEvent,
					t => t.GetAllText()),
				
				new InputElementMonitor<PasswordBox>(
					PasswordBox.PasswordChangedEvent,
					t => t.Password)
			};


		/// <summary>
		/// Provides the simple, stripped textual content representation of any of the supported 
		/// supported types (<see cref="TextBox"/>, <see cref="RichTextBox"/>, and 
		/// <see cref="PasswordBox"/>) as the type <see cref="string"/>.
		/// </summary>
		public string Text
		{
			get
			{
				switch (FrameworkInputElement)
				{
					case TextBox textBox:
						return textBox.Text;

					case RichTextBox richTextBox:
						return richTextBox.GetAllText();

					case PasswordBox passwordBox:
						return passwordBox.Password;

					default:
						throw new NotSupportedException(
							$"The type {FrameworkInputElement.GetType().Name.SQuote()} is not supported for " +
							$"use in the adapter type {nameof(TextFieldInputDataAdapter).SQuote()}.");
				}
			}
		}

		public IFrameworkInputElement FrameworkInputElement
		{
			get => (IFrameworkInputElement)GetValue(FrameworkInputElementProperty);
			set => SetValue(FrameworkInputElementProperty, value);
		}


		/// <summary>
		/// Public constructor for the <see cref="TextFieldInputDataAdapter"/> class, which takes 
		/// a parameter of the control instance in which the data adapter will interface with. 
		/// </summary>
		/// <param name="frameworkInputElement">
		/// The <paramref name="frameworkInputElement"/> is an instance that provides a reference to the 
		/// instance to the basic WPF text control that this data adapter will monitor and 
		/// interact with. These include <see cref="TextBox"/>, <see cref="RichTextBox"/>, and 
		/// <see cref="PasswordBox"/>.
		/// </param>
		public TextFieldInputDataAdapter(
			[NotNull] IFrameworkInputElement frameworkInputElement)
		{
			frameworkInputElement.IsNotNull(nameof(frameworkInputElement));
			FrameworkInputElement = frameworkInputElement;
		}

		

		private static void OnFrameworkInputElementPropertyChange(
			[NotNull] TextFieldInputDataAdapter @this,
			DPChangedEventArgs<IFrameworkInputElement> args)
		{
			var frameworkInputElement = args.NewValue;
			//frameworkInputElement.
		}
	}
}

