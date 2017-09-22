using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ccr.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Geocoding
{
	public class Bounds
	{
		public Location SouthWest { get; }

		public Location NorthEast { get; }


		public Bounds(
			double southWestLatitude,
			double southWestLongitude,
			double northEastLatitude,
			double northEastLongitude) : this(
			new Location(
				southWestLatitude,
				southWestLongitude),
			new Location(
				northEastLatitude,
				northEastLongitude))
		{
		}

		public Bounds(
			[NotNull] Location southWest,
			[NotNull] Location northEast)
		{
			southWest.IsNotNull(nameof(southWest));
			northEast.IsNotNull(nameof(northEast));

			if (southWest.Latitude > northEast.Latitude)
				throw new ArgumentException(
					"SouthWest Latitude cannot be greater than NorthEast Latitude",
					nameof(southWest));

			SouthWest = southWest;
			NorthEast = northEast;
		}


		public override bool Equals(object obj)
		{
			return Equals(obj as Bounds);
		}

		public bool Equals(Bounds bounds)
		{
			if (bounds == null)
				return false;

			return SouthWest.Equals(bounds.SouthWest)
			       && NorthEast.Equals(bounds.NorthEast);
		}


		public override int GetHashCode()
		{
			return SouthWest.GetHashCode() ^ NorthEast.GetHashCode();
		}

		public override string ToString()
		{
			return $"{SouthWest} | {NorthEast}";
		}
	}
}
