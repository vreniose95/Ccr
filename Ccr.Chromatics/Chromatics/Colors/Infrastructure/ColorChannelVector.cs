using System.Collections;
using System.Collections.Generic;
// ReSharper disable ArrangeAccessorOwnerBody

namespace Ccr.Chromatics.Colors.Infrastructure
{
	public class ColorChannelVector
		: IReadOnlyList<double>
	{
		private readonly double[] _channelValues;


		public int Count
		{
			get => _channelValues.Length;
		}

		public double this[int index]
		{
			get => _channelValues[index];
		}


		public ColorChannelVector(
			params double[] channelValues)
		{
			_channelValues = channelValues;
		}


		public IEnumerator<double> GetEnumerator()
		{
			return (IEnumerator<double>)_channelValues.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
