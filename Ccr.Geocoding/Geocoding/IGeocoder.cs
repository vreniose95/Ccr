using System.Collections.Generic;
using Ccr.Geocoding.Google;

namespace Ccr.Geocoding
{
	public interface IGeocoder
	{
		IEnumerable<GoogleAddress> Geocode(
			string address);

		IEnumerable<GoogleAddress> Geocode(
			string street,
			string city,
			string state,
			string postalCode,
			string country);

		IEnumerable<GoogleAddress> ReverseGeocode(
			Location location);

		IEnumerable<GoogleAddress> ReverseGeocode(
			double latitude,
			double longitude);
	}
}
