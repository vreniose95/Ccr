using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using Ccr.Core.Extensions;
using Ccr.Extensions;
using JetBrains.Annotations;

namespace Ccr.Geocoding.Google
{
	/// <remarks>
	/// http://code.google.com/apis/maps/documentation/geocoding/
	/// </remarks>
	public class GoogleGeocoder
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

		public IList<GoogleComponentFilter> ComponentFilters { get; set; }


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
							ComponentFilters.Select(x => x.ComponentFilter)));
				}

				return builder.ToString();
			}
		}

		#endregion

		#region Constructors
		private GoogleGeocoder()
		{
		}
		public GoogleGeocoder(
			BusinessKey businessKey) : this()
		{
			BusinessKey = businessKey;
		}
		public GoogleGeocoder(
			string apiKey) : this()
		{
			ApiKey = apiKey;
		}

		#endregion

		#region Methods

		#region Methods - Synchronous
		IEnumerable<GoogleAddress> IGeocoder.Geocode(
			string address)
		{
			return Geocode(address);
		}
		IEnumerable<GoogleAddress> IGeocoder.Geocode(
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


		IEnumerable<GoogleAddress> IGeocoder.ReverseGeocode(
			Location location)
		{
			return ReverseGeocode(location);
		}

		IEnumerable<GoogleAddress> IGeocoder.ReverseGeocode(
			double latitude,
			double longitude)
		{
			return ReverseGeocode(latitude, longitude);
		}


		public IEnumerable<GoogleAddress> Geocode(
			[NotNull] string address)
		{
			address.IsNotNull(nameof(address));

			var request = BuildWebRequest(
				"address",
				WebUtility.UrlEncode(address));

			return ProcessRequest(request);
		}

		public IEnumerable<GoogleAddress> ReverseGeocode(
			[NotNull] Location location)
		{
			location.IsNotNull(nameof(location));

			return ReverseGeocode(
				location.Latitude,
				location.Longitude);
		}

		public IEnumerable<GoogleAddress> ReverseGeocode(
			double latitude,
			double longitude)
		{
			var request = BuildWebRequest(
				"latlng",
				buildGeolocation(latitude, longitude));

			return ProcessRequest(request);
		}

		private IEnumerable<GoogleAddress> ProcessRequest(
			HttpRequestMessage request)
		{
			try
			{
				using (var client = buildClient())
				{
					var result = client.SendAsync(request).Result;
					return ProcessWebResponse(
						result);
				}
			}
			catch (GoogleGeocodingException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new GoogleGeocodingException(ex);
			}
		}


		private IEnumerable<GoogleAddress> ProcessWebResponse(
			HttpResponseMessage response)
		{
			var xmlDoc = LoadXmlResponse(response);

			var nav = xmlDoc.CreateNavigator();

			var status = evaluateStatus(
				nav.Extract<string>("string(/GeocodeResponse/status)"));

			if (status != GoogleStatus.Ok
			    && status != GoogleStatus.ZeroResults)
				throw new GoogleGeocodingException(status);

			if (status == GoogleStatus.Ok)
				return ParseAddresses(
						nav.Select("/GeocodeResponse/result"))
					.ToArray();

			return new GoogleAddress[0];
		}

		private static XPathDocument LoadXmlResponse(
			HttpResponseMessage response)
		{
			using (var stream = response.Content.ReadAsStreamAsync().Result)
			{
				var doc = new XPathDocument(stream);
				return doc;
			}
		}

		#endregion

		#region Methods - Async
		async Task<IEnumerable<GoogleAddress>> IGeocoderAsync.GeocodeAsync(
			string address)
		{
			return await GeocodeAsync(address)
				.ConfigureAwait(false);
		}
		async Task<IEnumerable<GoogleAddress>> IGeocoderAsync.GeocodeAsync(
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


		async Task<IEnumerable<GoogleAddress>> IGeocoderAsync.ReverseGeocodeAsync(
			Location location)
		{
			return await ReverseGeocodeAsync(location)
				.ConfigureAwait(false);
		}

		async Task<IEnumerable<GoogleAddress>> IGeocoderAsync.ReverseGeocodeAsync(
			double latitude,
			double longitude)
		{
			return await ReverseGeocodeAsync(latitude, longitude)
				.ConfigureAwait(false);
		}



		public async Task<IEnumerable<GoogleAddress>> GeocodeAsync(
			[NotNull] string address)
		{
			address.IsNotNull(nameof(address));

			var request = BuildWebRequest(
				"address",
				WebUtility.UrlEncode(address));

			return await ProcessRequestAsync(request)
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<GoogleAddress>> ReverseGeocodeAsync(
			[NotNull] Location location)
		{
			location.IsNotNull(nameof(location));

			return await ReverseGeocodeAsync(
					location.Latitude,
					location.Longitude)
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<GoogleAddress>> ReverseGeocodeAsync(
			double latitude,
			double longitude)
		{
			var request = BuildWebRequest(
				"latlng",
				buildGeolocation(latitude, longitude));

			return await ProcessRequestAsync(request)
				.ConfigureAwait(false);
		}

		private async Task<IEnumerable<GoogleAddress>> ProcessRequestAsync(
			HttpRequestMessage request)
		{
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
			catch (GoogleGeocodingException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new GoogleGeocodingException(ex);
			}
		}


		private async Task<IEnumerable<GoogleAddress>> ProcessWebResponseAsync(
			HttpResponseMessage response)
		{
			var xmlDoc = await LoadXmlResponseAsync(response)
				.ConfigureAwait(false);

			var nav = xmlDoc.CreateNavigator();

			var status = evaluateStatus(
				nav.Extract<string>("string(/GeocodeResponse/status)"));

			if (status != GoogleStatus.Ok
			    && status != GoogleStatus.ZeroResults)
				throw new GoogleGeocodingException(status);

			if (status == GoogleStatus.Ok)
				return ParseAddresses(
						nav.Select("/GeocodeResponse/result"))
					.ToArray();

			return new GoogleAddress[0];
		}

		private static async Task<XPathDocument> LoadXmlResponseAsync(
			HttpResponseMessage response)
		{
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


		private static IEnumerable<GoogleAddress> ParseAddresses(
			XPathNodeIterator nodes)
		{
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


				var viewport = new GoogleViewport
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

				yield return new GoogleAddress(
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

		private static IEnumerable<GoogleAddressComponent> ParseComponents(
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
					yield return new GoogleAddressComponent(
						types,
						longName,
						shortName);
			}
		}

		private static IEnumerable<GoogleAddressType> ParseComponentTypes(
			XPathNodeIterator nodes)
		{
			while (nodes.MoveNext())
				yield return evaluateType(
					nodes.Current.InnerXml);
		}



		/// <remarks>
		/// http://code.google.com/apis/maps/documentation/geocoding/#StatusCodes
		/// </remarks>
		private static GoogleStatus evaluateStatus(
			string status)
		{
			switch (status)
			{
				case "OK":
					return GoogleStatus.Ok;
				case "ZERO_RESULTS":
					return GoogleStatus.ZeroResults;
				case "OVER_QUERY_LIMIT":
					return GoogleStatus.OverQueryLimit;
				case "REQUEST_DENIED":
					return GoogleStatus.RequestDenied;
				case "INVALID_REQUEST":
					return GoogleStatus.InvalidRequest;
				default:
					return GoogleStatus.Error;
			}
		}

		/// <remarks>
		/// http://code.google.com/apis/maps/documentation/geocoding/#Types
		/// </remarks>
		private static GoogleAddressType evaluateType(
			string type)
		{
			switch (type)
			{
				case "street_address":
					return GoogleAddressType.StreetAddress;
				case "route":
					return GoogleAddressType.Route;
				case "intersection":
					return GoogleAddressType.Intersection;
				case "political":
					return GoogleAddressType.Political;
				case "country":
					return GoogleAddressType.Country;
				case "administrative_area_level_1":
					return GoogleAddressType.AdministrativeAreaLevel1;
				case "administrative_area_level_2":
					return GoogleAddressType.AdministrativeAreaLevel2;
				case "administrative_area_level_3":
					return GoogleAddressType.AdministrativeAreaLevel3;
				case "colloquial_area":
					return GoogleAddressType.ColloquialArea;
				case "locality":
					return GoogleAddressType.Locality;
				case "sublocality":
					return GoogleAddressType.SubLocality;
				case "neighborhood":
					return GoogleAddressType.Neighborhood;
				case "premise":
					return GoogleAddressType.Premise;
				case "subpremise":
					return GoogleAddressType.Subpremise;
				case "postal_code":
					return GoogleAddressType.PostalCode;
				case "natural_feature":
					return GoogleAddressType.NaturalFeature;
				case "airport":
					return GoogleAddressType.Airport;
				case "park":
					return GoogleAddressType.Park;
				case "point_of_interest":
					return GoogleAddressType.PointOfInterest;
				case "post_box":
					return GoogleAddressType.PostBox;
				case "street_number":
					return GoogleAddressType.StreetNumber;
				case "floor":
					return GoogleAddressType.Floor;
				case "room":
					return GoogleAddressType.Room;
				case "postal_town":
					return GoogleAddressType.PostalTown;
				case "establishment":
					return GoogleAddressType.Establishment;
				case "sublocality_level_1":
					return GoogleAddressType.SubLocalityLevel1;
				case "sublocality_level_2":
					return GoogleAddressType.SubLocalityLevel2;
				case "sublocality_level_3":
					return GoogleAddressType.SubLocalityLevel3;
				case "sublocality_level_4":
					return GoogleAddressType.SubLocalityLevel4;
				case "sublocality_level_5":
					return GoogleAddressType.SubLocalityLevel5;
				case "postal_code_suffix":
					return GoogleAddressType.PostalCodeSuffix;
				default:
					return GoogleAddressType.Unknown;
			}
		}

		/// <remarks>
		/// https://developers.google.com/maps/documentation/geocoding/?csw=1#Results
		/// </remarks>
		private static GoogleLocationType evaluateLocationType(
			string type)
		{
			switch (type)
			{
				case "ROOFTOP":
					return GoogleLocationType.Rooftop;
				case "RANGE_INTERPOLATED":
					return GoogleLocationType.RangeInterpolated;
				case "GEOMETRIC_CENTER":
					return GoogleLocationType.GeometricCenter;
				case "APPROXIMATE":
					return GoogleLocationType.Approximate;
				default:
					return GoogleLocationType.Unknown;
			}
		}
		#endregion

		#endregion
	}
}