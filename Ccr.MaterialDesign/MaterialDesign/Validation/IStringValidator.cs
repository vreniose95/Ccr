namespace Ccr.MaterialDesign.Validation
{
	public interface IStringValidator
  {
    ValidatorMode ValidatorMode { get; }

    string Message { get; set; }

    bool Validate(string value);
  }
}
