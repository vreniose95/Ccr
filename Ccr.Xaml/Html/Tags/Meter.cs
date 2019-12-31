using Ccr.Html.Attributes.Traits.Interfaces;
using Ccr.Html.Tags.Infrastructure;
using System;

namespace Ccr.Html.Tags
{
	public class Meter
		: Tag,
			ISupportsFormAttribute
	{
		private double? _min;
		private double? _max;
		private double? _high;
		private double? _low;


		public override TagRenderMode TagRenderMode
		{
			get => TagRenderMode.Normal;
		}


		public Meter(
			double value)
			: base("meter")
		{
			AddAttribute("value", value.ToString());
		}


		public void AddMin(
			double value)
		{
			if (value > _low || value > _high || value > _max)
				throw new ArgumentException();

			_min = value;
			AddAttribute("min", _min.Value.ToString());
		}

		public void AddMax(
			double value)
		{
			if (value < _min || value < _low || value < _high)
				throw new ArgumentException();

			_max = value;
			AddAttribute("max", _max.Value.ToString());
		}

		public void AddLow(
			double value)
		{
			if (value < _min || value > _high || value > _max)
				throw new ArgumentException();

			_low = value;
			AddAttribute("low", _low.Value.ToString());
		}

		public void AddHigh(
			double value)
		{
			if (value < _min || value < _low || value > _max)
				throw new ArgumentException();

			_high = value;
			AddAttribute("high", _high.Value.ToString());
		}

		public void AddOptimum(
			double value)
		{
			AddAttribute("optimum", value.ToString());
		}
	}
}