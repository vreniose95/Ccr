using System;
using System.Diagnostics;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Ccr.Geocoding
{
	[DebuggerDisplay("{Latitude}° N, {Longitude}° W}")]
	public class Location
	{
		private double latitude;
		private double longitude;


		[JsonProperty("lat")]
		public double Latitude
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
		public double Longitude
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


		protected double ToRadian(double val)
		{
			return Math.PI / 180.0 * val;
		}


		public Distance DistanceBetween(
			[NotNull] Location location)
		{
			return DistanceBetween(
				location,
				DistanceUnits.Miles);
		}

		public Distance DistanceBetween(
		  [NotNull] Location location,
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


		public bool IsInVacinity(
			[NotNull] Location comparisonLocation,
			Distance vacinitySize)
		{
			var distance = DistanceBetween(comparisonLocation);
			return distance <= vacinitySize;
		}



		public bool Equals(
				object obj)
		{
		  var location = obj as Location;
		  if (location == null)
		    return false;

			return Equals(location);
		}

		public bool Equals(
			[NotNull] Location location)
		{
		  location.IsNotNull(nameof(location));

			return Latitude == location.Latitude
        && Longitude == location.Longitude;
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
