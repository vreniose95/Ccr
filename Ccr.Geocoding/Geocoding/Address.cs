using Ccr.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Geocoding
{
	public abstract class Address
	{
		private string _formattedAddress;
		private Location _coordinates;
		private string _provider;


		protected Address(
			string formattedAddress,
			Location coordinates,
			string provider)
		{
			_formattedAddress = formattedAddress;
			_coordinates = coordinates;
			_provider = provider;
		}


		public virtual string FormattedAddress
		{
			get => _formattedAddress;
			[NotNull]
			set
			{
				value.IsNotNullOrWhiteSpace(nameof(value));
				_formattedAddress = value.Trim();
			}
		}

		public virtual Location Coordinates
		{
			get => _coordinates;
			[NotNull]
			set
			{
				value.IsNotNull(nameof(value));
				_coordinates = value;
			}
		}

		public virtual string Provider
		{
			get => _provider;
			[NotNull]
			protected set
			{
				value.IsNotNullOrWhiteSpace(nameof(value));
				_provider = value;
			}
		}


		public virtual Distance DistanceBetween(
			Address address)
		{
			return Coordinates.DistanceBetween(
				address.Coordinates);
		}

		public virtual Distance DistanceBetween(
			Address address,
			DistanceUnits units)
		{
			return Coordinates.DistanceBetween(
				address.Coordinates,
				units);
		}

		public virtual bool IsInVacinity(
			Address comparisonAddress,
			Distance vacinitySize)
		{
			var location = comparisonAddress.Coordinates;
			var distance = Coordinates
				.DistanceBetween(
					location);
			
			return distance <= vacinitySize;
		}


		public override string ToString()
		{
			return FormattedAddress;
		}
	}
}
