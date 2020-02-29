using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;

namespace Ccr.MaterialDesign.Validation
{
	[ContentProperty(nameof(Validators))]
	public class AnyValidator 
		: StringValidator
	{
		private List<IStringValidator> _validators = new List<IStringValidator>();


		public override ValidatorMode ValidatorMode
		{
			get => ValidatorMode.Passive;
		}

		public List<IStringValidator> Validators
		{
			get => _validators;
			set => _validators = value;
		}

		public override bool Validate(string value)
		{
			return Validators
				.Any(t => t.Validate(value));
		}
	}
}