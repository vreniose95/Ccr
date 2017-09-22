using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Ccr.Geocoding
{
	[DebuggerDisplay("{Latitude}° N, {Longitude}° W}")]
	public class Location
	{
		private double latitude;
		private double longitude;


		[JsonProperty("lat")]
		public virtual double Latitude
		{
			get => latitude;
			set
			{
				if (value < -90 || value > 90)
					throw new ArgumentOutOfRangeException(
						nameof(Latitude),
						value,
						"Value must be between -90 and 90 inclusive.");

				if (double.IsNaN(value))
					throw new ArgumentException(
						"Latitude must be a valid number.",
						nameof(Latitude));

				latitude = value;
			}
		}

		[JsonProperty("lng")]
		public virtual double Longitude
		{
			get => longitude;
			set
			{
				if (value < -180 || value > 180)
					throw new ArgumentOutOfRangeException(
						nameof(Longitude),
						value,
						"Value must be between -180 and 180 inclusive.");

				if (double.IsNaN(value))
					throw new ArgumentException(
						"Longitude must be a valid number.",
						nameof(Longitude));

				longitude = value;
			}
		}


		protected Location()
			: this(0, 0)
		{
		}
		public Location(
			double latitude,
			double longitude)
		{
			Latitude = latitude;
			Longitude = longitude;
		}


		protected virtual double ToRadian(double val)
		{
			return Math.PI / 180.0 * val;
		}


		public virtual Distance DistanceBetween(
			Location location)
		{
			return DistanceBetween(
				location,
				DistanceUnits.Miles);
		}

		public virtual Distance DistanceBetween(
			Location location,
			DistanceUnits units)
		{
			var earthRadius = units == DistanceUnits.Miles
				? Distance.EarthRadiusInMiles
				: Distance.EarthRadiusInKilometers;

			var latRadian = ToRadian(location.Latitude - Latitude);
			var longRadian = ToRadian(location.Longitude - Longitude);

			var a =
				Math.Pow(
					Math.Sin(latRadian / 2.0), 2) +
				Math.Cos(
					ToRadian(Latitude)) *
				Math.Cos(
					ToRadian(location.Latitude)) *
				Math.Pow(
					Math.Sin(longRadian / 2.0), 2);

			var c = 2.0 *
				Math.Asin(
					Math.Min(
						1,
						Math.Sqrt(a)));

			var distance = earthRadius * c;
			return new Distance(
				distance,
				units);

		}


		public virtual bool IsInVacinity(
			Location comparisonLocation,
			Distance vacinitySize)
		{
			var distance = DistanceBetween(comparisonLocation);
			return distance <= vacinitySize;
		}



		public override bool Equals(
				object obj)
		{
			return Equals(obj as Location);
		}

		public bool Equals(
			Location coor)
		{
			if (coor == null)
				return false;

			return (Latitude == coor.Latitude && Longitude == coor.Longitude);
		}


		public override int GetHashCode()
		{
			return Latitude.GetHashCode() ^ Latitude.GetHashCode();
		}

		public override string ToString()
		{
			return $"{latitude}, {longitude}";
		}
	}
}
