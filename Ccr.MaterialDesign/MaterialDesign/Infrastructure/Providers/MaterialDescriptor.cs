using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ccr.Core.Extensions;
using Ccr.Core.Extensions.NumericExtensions;
using Ccr.Core.Numerics;

namespace Ccr.MaterialDesign.Infrastructure.Providers
{
	public abstract class MaterialDescriptor
	{
		private double _opacity = 1d;
		public double Opacity
		{
			get => _opacity;
			set
			{
				if (value.IsNotWithin((0, 1)))
					throw new ArgumentOutOfRangeException(
						nameof(value),
						$"The value {value.ToString().SQuote()} ");
			}

		}
	}
}
