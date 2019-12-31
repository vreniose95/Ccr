using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using Ccr.Extensions;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Geocoding
{
	/// <remarks>
	/// http://code.google.com/apis/maps/documentation/geocoding/
	/// </remarks>
	public class Geocoder
		: IGeocoder,
			IGeocoderAsync
	{
		#region Fields
		private string apiKey;
		private BusinessKey businessKey;

		#endregion

		#region Constants
		private const string keyMessage =
			"Only one of BusinessKey or ApiKey should be set on the GoogleGeocoder.";

		#endregion

		#region Properties
		public string ApiKey
		{
			get { return apiKey; }
			[NotNull]
			set
			{
				if (businessKey != null)
					throw new InvalidOperationException(keyMessage);

				value.IsNotNullOrWhiteSpace(nameof(value));

				apiKey = value;
			}
		}

		public BusinessKey BusinessKey
		{
			get { return businessKey; }
			[NotNull]
			set
			{
				if (!string.IsNullOrEmpty(apiKey))
					throw new InvalidOperationException(keyMessage);

				value.IsNotNull(nameof(value));

				businessKey = value;
			}
		}


		public IWebProxy Proxy { get; set; }

		public string Language { get; set; }

		public string RegionBias { get; set; }

		public Bounds BoundsBias { get; set; }

		public IList<ComponentFilter> ComponentFilters { get; set; }


		public string ServiceUrl
		{
			get
			{
				var builder = new StringBuilder();
				builder.Append(
					"https://maps.googleapis.com/maps/api/geocode/xml?{0}={1}&sensor=false");

				if (!string.IsNullOrEmpty(Language))
				{
					builder.Append("&language=");
					builder.Append(WebUtility.UrlEncode(Language));
				}

				if (!string.IsNullOrEmpty(RegionBias))
				{
					builder.Append("&region=");
					builder.Append(WebUtility.UrlEncode(RegionBias));
				}

				if (!string.IsNullOrEmpty(ApiKey))
				{
					builder.Append("&key=");
					builder.Append(WebUtility.UrlEncode(ApiKey));
				}

				if (BusinessKey != null)
				{
					builder.Append("&client=");
					builder.Append(WebUtility.UrlEncode(BusinessKey.ClientId));
					if (BusinessKey.HasChannel)
					{
						builder.Append("&channel=");
						builder.Append(WebUtility.UrlEncode(BusinessKey.Channel));
					}
          
				}

				if (BoundsBias != null)
				{
					builder.Append("&bounds=");

					builder.Append(BoundsBias
						.SouthWest
						.Latitude
						.ToString(CultureInfo.InvariantCulture));

					builder.Append(",");

					builder.Append(BoundsBias
						.SouthWest
						.Longitude
						.ToString(CultureInfo.InvariantCulture));

					builder.Append("|");

					builder.Append(BoundsBias
						.NorthEast
						.Latitude
						.ToString(CultureInfo.InvariantCulture));

					builder.Append(",");

					builder.Append(BoundsBias
						.NorthEast
						.Longitude
						.ToString(CultureInfo.InvariantCulture));
				}

				if (ComponentFilters != null)
				{
					builder.Append("&components=");
					builder.Append(
						string.Join("|",
							ComponentFilters.Select(x => x.Filter)));
				}

				return builder.ToString();
			}
		}

		#endregion

		#region Constructors
		private Geocoder()
		{
		}

		public Geocoder(
			BusinessKey businessKey) : this()
		{
			BusinessKey = businessKey;
		}

		public Geocoder(
			string apiKey) : this()
		{
			ApiKey = apiKey;
		}

		#endregion

		#region Methods

		#region Methods - Synchronous
		IEnumerable<Address> IGeocoder.Geocode(
			string address)
		{
			return Geocode(address);
		}
		IEnumerable<Address> IGeocoder.Geocode(
			string street,
			string city,
			string state,
			string postalCode,
			string country)
		{
			return Geocode(
				buildAddress(
					street,
					city,
					state,
					postalCode,
					country));
		}


		IEnumerable<Address> IGeocoder.ReverseGeocode(
			[NotNull] Location location)
		{
      location.IsNotNull(nameof(location));

			return ReverseGeocode(location);
		}

		IEnumerable<Address> IGeocoder.ReverseGeocode(
			double latitude,
			double longitude)
		{
			return ReverseGeocode(latitude, longitude);
		}


		public IEnumerable<Address> Geocode(
			[NotNull] string address)
		{
			address.IsNotNull(nameof(address));

			var request = BuildWebRequest(
				"address",
				WebUtility.UrlEncode(address));

			return ProcessRequest(request);
		}

		public IEnumerable<Address> ReverseGeocode(
			[NotNull] Location location)
		{
			location.IsNotNull(nameof(location));

			return ReverseGeocode(
				location.Latitude,
				location.Longitude);
		}

		public IEnumerable<Address> ReverseGeocode(
			double latitude,
			double longitude)
		{
			var request = BuildWebRequest(
				"latlng",
				buildGeolocation(latitude, longitude));

			return ProcessRequest(request);
		}

		private IEnumerable<Address> ProcessRequest(
			[NotNull] HttpRequestMessage request)
		{
      request.IsNotNull(nameof(request));
			try
			{
				using (var client = buildClient())
				{
					var result = client.SendAsync(request).Result;
					return ProcessWebResponse(
						result);
				}
			}
			catch (GeocodingException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new GeocodingException(ex);
			}
		}


		private IEnumerable<Address> ProcessWebResponse(
			[NotNull] HttpResponseMessage response)
		{
      response.IsNotNull(nameof(response));

			var xmlDoc = LoadXmlResponse(response);
      var nav = xmlDoc.CreateNavigator();

			var status = evaluateStatus(
				nav.Extract<string>("string(/GeocodeResponse/status)"));

			if (status != GeocodingStatus.Ok
			    && status != GeocodingStatus.ZeroResults)
				throw new GeocodingException(status);

			if (status == GeocodingStatus.Ok)
				return ParseAddresses(
						nav.Select("/GeocodeResponse/result"))
					.ToArray();

			return new Address[0];
		}

		private static XPathDocument LoadXmlResponse(
			[NotNull] HttpResponseMessage response)
		{
      response.IsNotNull(nameof(response));

			using (var stream = response.Content.ReadAsStreamAsync().Result)
			{
				var doc = new XPathDocument(stream);
				return doc;
			}
		}

		#endregion

		#region Methods - Async
		async Task<IEnumerable<Address>> IGeocoderAsync.GeocodeAsync(
			[NotNull] string address)
		{
      address.IsNotNull(nameof(address));

			return await GeocodeAsync(address)
				.ConfigureAwait(false);
		}
		async Task<IEnumerable<Address>> IGeocoderAsync.GeocodeAsync(
			string street,
			string city,
			string state,
			string postalCode,
			string country)
		{
			return await GeocodeAsync(
					buildAddress(
						street,
						city,
						state,
						postalCode,
						country))
				.ConfigureAwait(false);
		}


		async Task<IEnumerable<Address>> IGeocoderAsync.ReverseGeocodeAsync(
		  [NotNull] Location location)
		{
		  location.IsNotNull(nameof(location));

      return await ReverseGeocodeAsync(location)
				.ConfigureAwait(false);
		}

		async Task<IEnumerable<Address>> IGeocoderAsync.ReverseGeocodeAsync(
			double latitude,
			double longitude)
		{
			return await ReverseGeocodeAsync(latitude, longitude)
				.ConfigureAwait(false);
		}



		public async Task<IEnumerable<Address>> GeocodeAsync(
			[NotNull] string address)
		{
			address.IsNotNull(nameof(address));

			var request = BuildWebRequest(
				"address",
				WebUtility.UrlEncode(address));

			return await ProcessRequestAsync(request)
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<Address>> ReverseGeocodeAsync(
			[NotNull] Location location)
		{
			location.IsNotNull(nameof(location));

			return await ReverseGeocodeAsync(
					location.Latitude,
					location.Longitude)
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<Address>> ReverseGeocodeAsync(
			double latitude,
			double longitude)
		{
			var request = BuildWebRequest(
				"latlng",
				buildGeolocation(latitude, longitude));

			return await ProcessRequestAsync(request)
				.ConfigureAwait(false);
		}

		private async Task<IEnumerable<Address>> ProcessRequestAsync(
			[NotNull] HttpRequestMessage request)
		{
      request.IsNotNull(nameof(request));

			try
			{
				using (var client = buildClient())
				{
					return await ProcessWebResponseAsync(
							await client.SendAsync(request)
								.ConfigureAwait(false))
						.ConfigureAwait(false);
				}
			}
			catch (GeocodingException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new GeocodingException(ex);
			}
		}


		private async Task<IEnumerable<Address>> ProcessWebResponseAsync(
			[NotNull] HttpResponseMessage response)
		{
		  response.IsNotNull(nameof(response));

      var xmlDoc = await LoadXmlResponseAsync(response)
				.ConfigureAwait(false);
      var nav = xmlDoc.CreateNavigator();

			var status = evaluateStatus(
				nav.Extract<string>("string(/GeocodeResponse/status)"));

			if (status != GeocodingStatus.Ok
			    && status != GeocodingStatus.ZeroResults)
				throw new GeocodingException(status);

			if (status == GeocodingStatus.Ok)
				return ParseAddresses(
						nav.Select("/GeocodeResponse/result"))
					.ToArray();

			return new Address[0];
		}

		private static async Task<XPathDocument> LoadXmlResponseAsync(
			[NotNull] HttpResponseMessage response)
		{
      response.IsNotNull(nameof(response));

			using (var stream = await response.Content.ReadAsStreamAsync()
				.ConfigureAwait(false))
			{
				var doc = new XPathDocument(stream);
				return doc;
			}
		}

		#endregion

		#region Private Methods
		private static string buildAddress(
			string street,
			string city,
			string state,
			string postalCode,
			string country)
		{
			return $"{street} {city}, {state} {postalCode}, {country}";
		}

		private static string buildGeolocation(
			double latitude,
			double longitude)
		{
			return $"{latitude},{longitude}";
		}

		private HttpClient buildClient()
		{
			if (Proxy == null)
				return new HttpClient();

			var handler = new HttpClientHandler
			{
				Proxy = Proxy
			};
			return new HttpClient(handler);
		}

		private HttpRequestMessage BuildWebRequest(
			string type,
			string value)
		{
			var url = string.Format(ServiceUrl, type, value);

			if (BusinessKey != null)
				url = BusinessKey.GenerateSignature(url);

			return new HttpRequestMessage(
				HttpMethod.Get,
				url);
		}


		private static IEnumerable<Address> ParseAddresses(
			[NotNull] XPathNodeIterator nodes)
		{
      nodes.IsNotNull(nameof(nodes));

			while (nodes.MoveNext())
			{
				var nav = nodes.Current;

				var type = evaluateType(
					nav.Extract<string>(
						"string(type)"));

				var placeId = nav.Extract<string>(
					"string(place_id)");

				var formattedAddress = nav.Extract<string>(
					"string(formatted_address)");

				var components = ParseComponents(
						nav.Select("address_component"))
					.ToArray();


				var latitude = nav.Extract<double>(
					"number(geometry/location/lat)");

				var longitude = nav.Extract<double>(
					"number(geometry/location/lng)");

				var coordinates = new Location(
					latitude,
					longitude);


				var northEastLatitude = nav.Extract<double>(
					"number(geometry/viewport/northeast/lat)");

				var northEastLongitude = nav.Extract<double>(
					"number(geometry/viewport/northeast/lng)");

				var northEastCoordinates = new Location(
					northEastLatitude,
					northEastLongitude);


				var southWestLatitude = nav.Extract<double>(
					"number(geometry/viewport/southwest/lat)");

				var southWestLongitude = nav.Extract<double>(
					"number(geometry/viewport/southwest/lng)");

				var southWestCoordinates = new Location(
					southWestLatitude,
					southWestLongitude);


				var viewport = new Viewport
				{
					Northeast = northEastCoordinates,
					Southwest = southWestCoordinates
				};

				var locationType = evaluateLocationType(
					nav.Extract<string>("string(geometry/location_type)"));

				Bounds bounds = null;
				if (nav.SelectSingleNode("geometry/bounds") != null)
				{
					var northEastBoundsLatitude = nav.Extract<double>(
						"number(geometry/bounds/northeast/lat)");

					var northEastBoundsLongitude = nav.Extract<double>(
						"number(geometry/bounds/northeast/lng)");

					var northEastBoundsCoordinates = new Location(
						northEastBoundsLatitude,
						northEastBoundsLongitude);


					var southWestBoundsLatitude = nav.Extract<double>(
						"number(geometry/bounds/southwest/lat)");

					var southWestBoundsLongitude = nav.Extract<double>(
						"number(geometry/bounds/southwest/lng)");

					var southWestBoundsCoordinates = new Location(
						southWestBoundsLatitude,
						southWestBoundsLongitude);

					bounds = new Bounds(
						southWestBoundsCoordinates,
						northEastBoundsCoordinates);
				}

				bool isPartialMatch;

				bool.TryParse(
					nav.Extract<string>("string(partial_match)"),
					out isPartialMatch);

				yield return new Address(
					type,
					formattedAddress,
					components,
					coordinates,
					viewport,
					bounds,
					isPartialMatch,
					locationType,
					placeId);
			}
		}

		private static IEnumerable<AddressComponent> ParseComponents(
			XPathNodeIterator nodes)
		{
			while (nodes.MoveNext())
			{
				var nav = nodes.Current;

				var longName = nav.Extract<string>(
					"string(long_name)");

				var shortName = nav.Extract<string>(
					"string(short_name)");

				var types = ParseComponentTypes(
						nav.Select("type"))
					.ToArray();

				if (types.Any())
					yield return new AddressComponent(
						types,
						longName,
						shortName);
			}
		}

		private static IEnumerable<AddressType> ParseComponentTypes(
			XPathNodeIterator nodes)
		{
			while (nodes.MoveNext())
				yield return evaluateType(
					nodes.Current.InnerXml);
		}



		/// <remarks>
		/// http://code.google.com/apis/maps/documentation/geocoding/#StatusCodes
		/// </remarks>
		private static GeocodingStatus evaluateStatus(
			string status)
		{
			switch (status)
			{
				case "OK":
					return GeocodingStatus.Ok;
				case "ZERO_RESULTS":
					return GeocodingStatus.ZeroResults;
				case "OVER_QUERY_LIMIT":
					return GeocodingStatus.OverQueryLimit;
				case "REQUEST_DENIED":
					return GeocodingStatus.RequestDenied;
				case "INVALID_REQUEST":
					return GeocodingStatus.InvalidRequest;
				default:
					return GeocodingStatus.Error;
			}
		}

		/// <remarks>
		/// http://code.google.com/apis/maps/documentation/geocoding/#Types
		/// </remarks>
		private static AddressType evaluateType(
			string type)
		{
			switch (type)
			{
				case "street_address":
					return AddressType.StreetAddress;
				case "route":
					return AddressType.Route;
				case "intersection":
					return AddressType.Intersection;
				case "political":
					return AddressType.Political;
				case "country":
					return AddressType.Country;
				case "administrative_area_level_1":
					return AddressType.AdministrativeAreaLevel1;
				case "administrative_area_level_2":
					return AddressType.AdministrativeAreaLevel2;
				case "administrative_area_level_3":
					return AddressType.AdministrativeAreaLevel3;
				case "colloquial_area":
					return AddressType.ColloquialArea;
				case "locality":
					return AddressType.Locality;
				case "sublocality":
					return AddressType.SubLocality;
				case "neighborhood":
					return AddressType.Neighborhood;
				case "premise":
					return AddressType.Premise;
				case "subpremise":
					return AddressType.Subpremise;
				case "postal_code":
					return AddressType.PostalCode;
				case "natural_feature":
					return AddressType.NaturalFeature;
				case "airport":
					return AddressType.Airport;
				case "park":
					return AddressType.Park;
				case "point_of_interest":
					return AddressType.PointOfInterest;
				case "post_box":
					return AddressType.PostBox;
				case "street_number":
					return AddressType.StreetNumber;
				case "floor":
					return AddressType.Floor;
				case "room":
					return AddressType.Room;
				case "postal_town":
					return AddressType.PostalTown;
				case "establishment":
					return AddressType.Establishment;
				case "sublocality_level_1":
					return AddressType.SubLocalityLevel1;
				case "sublocality_level_2":
					return AddressType.SubLocalityLevel2;
				case "sublocality_level_3":
					return AddressType.SubLocalityLevel3;
				case "sublocality_level_4":
					return AddressType.SubLocalityLevel4;
				case "sublocality_level_5":
					return AddressType.SubLocalityLevel5;
				case "postal_code_suffix":
					return AddressType.PostalCodeSuffix;
				default:
					return AddressType.Unknown;
			}
		}

		/// <remarks>
		/// https://developers.google.com/maps/documentation/geocoding/?csw=1#Results
		/// </remarks>
		private static LocationType evaluateLocationType(
			string type)
		{
			switch (type)
			{
				case "ROOFTOP":
					return LocationType.Rooftop;
				case "RANGE_INTERPOLATED":
					return LocationType.RangeInterpolated;
				case "GEOMETRIC_CENTER":
					return LocationType.GeometricCenter;
				case "APPROXIMATE":
					return LocationType.Approximate;
				default:
					return LocationType.Unknown;
			}
		}
		#endregion

		#endregion
	}
}