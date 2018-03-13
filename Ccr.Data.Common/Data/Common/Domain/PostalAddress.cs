using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Ccr.Core.Extensions;
using Ccr.Data.Common.Context;
using Ccr.Data.Common.EntityMaps;
using Ccr.Data.Common.Repositories;
using Ccr.Data.EntityFramework.Attributes;
using Ccr.Data.EntityFramework.Core;
using Ccr.Geocoding;
using JetBrains.Annotations;

namespace Ccr.Data.Common.Domain
{
	[EntityConfigurationMap(typeof(PostalAddressMap))]
	public class PostalAddress
	{
		public int PostalAddressID { get; set; }

		public int BuildingNumber { get; set; }

		public int PredirectionalID { get; set; }
		[ForeignKey("PredirectionalID")]
		public virtual Predirectional Predirectional { get; set; }

		public string StreetName { get; set; }

		public int StreetSuffixID { get; set; }
		[ForeignKey("StreetSuffixID")]
		public virtual StreetSuffix StreetSuffix { get; set; }

		public string AddressLine2 { get; set; }

		public int CityID { get; set; }
		[ForeignKey("CityID")]
		public virtual City City { get; set; }

		public int StateID { get; set; }
		[ForeignKey("StateID")]
		public virtual State State { get; set; }

		public int ZipCode { get; set; }

		public int? ZipCodeSuffix { get; set; }

		public int CountryID { get; set; }
		[ForeignKey("CountryID")]
		public virtual Country Country { get; set; }




		private const string _apiKey = "AIzaSyDfgHD5nn_qH7t_rfyIYSwylObxpG_uEOQ";

		private static Geocoder _geocoder;
		protected internal static Geocoder Geocoder
		{
			get => _geocoder ?? (_geocoder = new Geocoder(_apiKey));
		}

		//[NotMapped]
		//private static readonly Lazy<GoogleGeocoder> _geocoder = new Lazy<GoogleGeocoder>(
		//	() => new GoogleGeocoder(AppConfig.Geocoding.APIKey));


		private PostalAddress() { }

		public PostalAddress(
			int buildingNumber,
			[CanBeNull] Predirectional predirectional,
			[NotNull] string streetName,
			[NotNull] StreetSuffix streetSuffix,
			[CanBeNull] string addressLine2,
			[NotNull] City city,
			[NotNull] State state,
			int zipCode,
			[CanBeNull] int? zipCodeSuffix,
			[NotNull] Country country) : this()
		{
			streetName.IsNotNull(nameof(streetName));
			streetSuffix.IsNotNull(nameof(streetSuffix));
			city.IsNotNull(nameof(city));
			state.IsNotNull(nameof(state));
			country.IsNotNull(nameof(CountryID));
			
			BuildingNumber = buildingNumber;
			//TODO should i be setting the entity fk mapped or the ID?
			if (predirectional != null)
				PredirectionalID = predirectional.PredirectionalID;
			
			StreetName = streetName;
			StreetSuffixID = streetSuffix.StreetSuffixID;

			if (!addressLine2.IsNullOrEmptyEx())
				AddressLine2 = addressLine2;
			
			CityID = city.CityID;
			
			StateID = state.StateID;

			ZipCode = zipCode;
			ZipCodeSuffix = zipCodeSuffix;
			
			CountryID = country.CountryID;
		}


		public static PostalAddress ParseUsingGeocodingServices(
			string address)
		{
			var parsedAddressQuery = Geocoder.Geocode(address);
			var parsedAddress = parsedAddressQuery.First();

			parsedAddress.IsNotNull(nameof(parsedAddress));

			var _buildingNumber = parsedAddress.GetComponent(
				AddressType.StreetNumber);

			var _streetNumber = int.Parse(_buildingNumber.LongName);

			var _streetName = parsedAddress.GetComponent(
				AddressType.Route);

			var _cityComponent = parsedAddress.GetComponent(
				AddressType.Locality,
				AddressType.Political);

			var _stateComponent = parsedAddress.GetComponent(
				AddressType.AdministrativeAreaLevel2,
				AddressType.Political);


			var _zipCodeComponent = parsedAddress.GetComponent(
				AddressType.PostalCode);

			var _zipCodeSuffixComponent = parsedAddress.GetComponent(
				AddressType.PostalCodeSuffix);

			var _countryComponent = parsedAddress.GetComponent(
				AddressType.AdministrativeAreaLevel3,
				AddressType.Political);


			using (var UoW = new UnitOfWork<CommonContext>())
			{
				UoW.BeginTransaction();

				var _countryRepository = UoW.GetRepository<Country, int>();

				var _country = _countryRepository.FetchSingle(
					t => t.CountryName == _countryComponent.LongName);


				var _stateRepository = UoW.GetCustomRepository<StateRepository, State>();

				var _state = _stateRepository.FetchStateByName(
					_stateComponent.LongName);

				if (_state == null)
					throw new NullReferenceException(
						$"Cannot parse a State entity from the Name " +
						$"{_stateComponent.LongName.Quote()}.");

				var _cityRepository = UoW.GetCustomRepository<CityRepository, City>();
				var _city = _cityRepository.FetchCityByNameAndState(
					_cityComponent.LongName, _state);


				if (_city == null)
					throw new NullReferenceException(
						$"Cannot find a City entity from the Name " +
						$"{_cityComponent.LongName.Quote()} in the state {_state.StateName.SQuote()}.");


				var _zipCode = int.Parse(_zipCodeComponent.LongName);
				var _zipCodeSuffix = _zipCodeSuffixComponent == null
					? null
					: (int?)int.Parse(
						_zipCodeSuffixComponent.LongName);
					

				return new PostalAddress(
					_streetNumber,
					null,
					_streetName.LongName,
					StreetSuffix.LANE,
					null,
					_city,
					_state,
					_zipCode,
					_zipCodeSuffix,
					_country);
			}

		}
	}
}
