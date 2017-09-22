using System.Collections.Generic;
using System.Threading.Tasks;
using Ccr.Geocoding.Google;

namespace Ccr.Geocoding
{
	public interface IGeocoderAsync
	{
		Task<IEnumerable<GoogleAddress>> GeocodeAsync(
			string address);

		Task<IEnumerable<GoogleAddress>> GeocodeAsync(
			string street, 
			string city, 
			string state, 
			string postalCode, 
			string country);

		Task<IEnumerable<GoogleAddress>> ReverseGeocodeAsync(
			Location location);

		Task<IEnumerable<GoogleAddress>> ReverseGeocodeAsync(
			double latitude, 
			double longitude);
	}
}
