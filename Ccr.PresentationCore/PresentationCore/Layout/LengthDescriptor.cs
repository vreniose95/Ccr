using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				
				_value = value;
			}
		}
	}
}
