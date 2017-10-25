using System;
using System.ComponentModel;

namespace Ccr.PresentationCore.Layout
{
  public class LengthDescriptor
	{
	  private double _value;
	  public double Value
	  {
	    get => _value;
	    set
	    {
	      if (value < 0)
	        throw new ArgumentOutOfRangeException(
            nameof(value), 
            value,
            "Value must be greater than or equal to 0.");

	      _value = value;
	    }
	  }
    
    private LengthMode _lengthMode;
    public LengthMode LengthMode
    {
      get => _lengthMode;
      set
      {
        if (!Enum.IsDefined(typeof(LengthMode), value))
          throw new InvalidEnumArgumentException(
            $"The value \'{value}\' is not a valid member " +
            $"for the enumeration type \'LengthMode\'.");

        _lengthMode = value;
      }
    }


	  private LengthDescriptor() { }

	  public LengthDescriptor(
      double value, 
      LengthMode lengthMode) : this()
	  {
	    Value = value;
	    LengthMode = lengthMode;
	  }


	  public double ResolvePixelLengthWithinContainer(
      double containerLength)
	  {
	    if (LengthMode == LengthMode.Pixels)
	      return Value;

	    if (containerLength <= 0)
	      return 0;

	    return containerLength * (Value / 100d);
	  }
  }
}
