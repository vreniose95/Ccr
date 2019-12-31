using System.Text.RegularExpressions;

namespace Ccr.MaterialDesign.Validation
{
	public class EmailValidator
		: StringValidator
	{
		private static readonly Regex _emailRegex = new Regex(
			@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");


		public override ValidatorMode ValidatorMode
		{
			get => ValidatorMode.Aggressive;
		}

		public override bool Validate(string value)
		{
			var isEmail = _emailRegex.IsMatch(value);

			Message = isEmail 
				? "good" 
				: "invalid email";

			return isEmail;
		}
	}


	public class UsernameValidator
		: StringValidator
	{
		private static readonly Regex _validUserNameRegex = new Regex(
			@"([A-z]{1}[A-z0-9_]*)");


		public override ValidatorMode ValidatorMode
		{
			get => ValidatorMode.Aggressive;
		}

		public override bool Validate(string value)
		{
			var isValidUsername = _validUserNameRegex.IsMatch(value);

			Message = isValidUsername
				? "good"
				: "invalid username";

			return isValidUsername;
		}
	}
}