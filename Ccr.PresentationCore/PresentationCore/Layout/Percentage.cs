using System;

namespace Ccr.PresentationCore.Layout
{
	public class Percentage //: 
		//IComparable, 
		//IFormattable, 
		//IConvertible, 
		//IComparable<double>, 
		//IEquatable<double>,
		//IComparable<Percentage>,
		//IEquatable<Percentage>
	{
		private double _value = double.NaN;
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


		public Percentage()
		{
		}
		public Percentage(double value)
		{
			Value = value;
		}
		

		public bool Equals(Percentage obj)
		{
			if (obj == this)
				return true;

			if (IsNaN(obj))
				return IsNaN(this);

			return false;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Percentage))
				return false;

			var percentage = (Percentage)obj;
			if (percentage == this)
				return true;

			if (IsNaN(percentage))
				return IsNaN(this);

			return false;
		}

		public override int GetHashCode()
		{
			return _value.GetHashCode();
		}

		public static bool IsNaN(Percentage @this)
		{
			return double.IsNaN(@this.Value);
		}



		public static readonly Percentage MinValue = new Percentage(0d);

		public static readonly Percentage MaxValue = new Percentage(double.MaxValue);



		public static implicit operator double(Percentage @this)
		{
			return @this.Value;
		}

		public static bool operator ==(Percentage left, Percentage right)
		{
			if (left == null || right == null)
				return false;
			return left.Value.Equals(right.Value);
		}

		public static bool operator !=(Percentage left, Percentage right)
		{
			if (left == null || right == null)
				return false;
			return !left.Value.Equals(right.Value)
				;
		}

		public static bool operator <(Percentage left, Percentage right)
		{
			if (left == null || right == null)
				return false;
			return left.Value < right.Value;
		}

		public static bool operator >(Percentage left, Percentage right)
		{
			if (left == null || right == null)
				return false;
			return left.Value > right.Value;
		}

		public static bool operator <=(Percentage left, Percentage right)
		{
			if (left == null || right == null)
				return false;
			return left.Value <= right.Value;
		}
		public static bool operator >=(Percentage left, Percentage right)
		{
			if (left == null || right == null)
				return false;
			return left.Value >= right.Value;
		}
	}
}
