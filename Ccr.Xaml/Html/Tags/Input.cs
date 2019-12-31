using Ccr.Html.Attributes;
using Ccr.Html.Attributes.Extensions;
using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Extensions;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Tags
{
	public class Input
		: Tag, 
			ISupportsAltAttribute,
			ISupportsAutocompleteAttribute,
			ISupportsAutofocusAttribute,
			ISupportsDisabledAttribute,
			ISupportsFormAttribute,
			ISupportsHeightAttribute, 
			ISupportsMaxLengthAttribute,
			ISupportsMultipleAttribute,
			ISupportsNameAttribute,
			ISupportsPlaceholderAttribute, 
			ISupportsReadonlyAttribute,
			ISupportsRequiredAttribute, 
			ISupportsSizeAttribute, 
			ISupportsSrcAttribute,
			ISupportsStringValueAttribute, 
			ISupportsWidthAttribute
	{
		private readonly InputType _inputType;


		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.SelfClosing;
		}


		public Input(
			InputType inputType)
				: base("input")
		{
			_inputType = inputType;
			AddAttribute("type", _inputType.LiteralValue());
		}


		public virtual void AddAccept(
			string fileType)
		{
			AddAttribute("accept", fileType);
		}

		public virtual void AddChecked()
		{
			switch (_inputType)
			{
				case InputType.Checkbox:
				case InputType.Radio:
					AddAttribute("checked", "checked");
					break;

				default:
					throw new InvalidAttributeException("checked", this);
			}
		}

		public virtual void AddList(
			string datalistId)
		{
			AddAttribute("list", datalistId);
		}

		public virtual void AddPattern(
			string pattern)
		{
			switch (_inputType)
			{
				case InputType.Date:
				case InputType.Email:
				case InputType.Password:
				case InputType.Search:
				case InputType.Tel:
				case InputType.Text:
				case InputType.Url:
					AddAttribute("pattern", pattern);
					break;

				default:
					throw new InvalidAttributeException("pattern", this);
			}
		}

		public virtual void AddStep(int step)
		{
			switch (_inputType)
			{
				case InputType.Date:
				case InputType.DatetimeLocal:
				case InputType.Month:
				case InputType.Number:
				case InputType.Range:
				case InputType.Time:
				case InputType.Week:
					AddAttribute("step", step.ToString());
					break;

				default:
					throw new InvalidAttributeException("step", this);
			}
		}
	}
}