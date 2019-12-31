using System.Windows;
using Ccr.PresentationCore.Helpers.DependencyHelpers;

namespace Ccr.MaterialDesign.Validation
{
	public abstract class StringValidator
		: DependencyObject,
			IStringValidator
	{
		public static StringValidator Empty
		{
			get => new EmptyStringValidator();
		}

		public virtual ValidatorMode ValidatorMode
		{
			get => ValidatorMode.Passive;
		}


		public abstract bool Validate(string value);


		public static readonly DependencyProperty MessageProperty = DP.Register(
			new Meta<StringValidator, string>());

		public string Message
		{
			get { return (string)GetValue(MessageProperty); }
			set { SetValue(MessageProperty, value); }
		}


		protected class EmptyStringValidator 
			: StringValidator
		{
			public override bool Validate(
				string value)
			{
				return true;
			}
		}
	}
}