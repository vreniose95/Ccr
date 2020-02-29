using System.Linq;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Geocoding
{
	public class Address
	{
		private string _formattedAddress;
		private Location _coordinates;


		public AddressType Type { get; }

		public LocationType LocationType { get; }

		public AddressComponent[] Components { get; }

		public bool IsPartialMatch { get; }

		public Viewport Viewport { get; }

		public Bounds Bounds { get; }

		public string PlaceId { get; }


		public Address(
			AddressType type,
			string formattedAddress,
			[NotNull, ItemNotNull] AddressComponent[] components,
			[NotNull] Location coordinates,
			[NotNull] Viewport viewport,
			[CanBeNull] Bounds bounds,
			bool isPartialMatch,
			LocationType locationType,
			string placeId)
		{
			components.IsNotNull(nameof(components));
			coordinates.IsNotNull(nameof(coordinates));
			viewport.IsNotNull(nameof(viewport));

			_formattedAddress = formattedAddress;
			_coordinates = coordinates;

			Type = type;
			Components = components;
			IsPartialMatch = isPartialMatch;
			Viewport = viewport;
			Bounds = bounds;
			LocationType = locationType;
			PlaceId = placeId;
		}


		public AddressComponent this[AddressType type]
		{
			get
			{
				return Components
					.FirstOrDefault(c => c.Types.Contains(type));
			}
		}

		public AddressComponent GetComponent(
			[NotNull] params AddressType[] types)
		{
			return Components
				.SingleOrDefault(c => c.Types.SequenceEqual(types));
		}

		public string FormattedAddress
		{
			get => _formattedAddress;
			[NotNull] set
			{
				value.IsNotNullOrWhiteSpace(nameof(value));
				_formattedAddress = value.Trim();
			}
		}

		public Location Coordinates
		{
			get => _coordinates;
			[NotNull] set
			{
				value.IsNotNull(nameof(value));
				_coordinates = value;
			}
		}

		public Distance DistanceBetween(
			[NotNull] Address address)
		{
			address.IsNotNull(nameof(address));
			
			return Coordinates.DistanceBetween(
				address.Coordinates);
		}

		public Distance DistanceBetween(
			[NotNull] Address address,
			DistanceUnits units)
		{
			address.IsNotNull(nameof(address));

			return Coordinates.DistanceBetween(
				address.Coordinates,
				units);
		}

		public bool IsInVacinity(
			[NotNull] Address comparisonAddress,
			Distance vacinitySize)
		{
			comparisonAddress.IsNotNull(nameof(comparisonAddress));

			var location = comparisonAddress.Coordinates;
			var distance = Coordinates.DistanceBetween(location);

			return distance <= vacinitySize;
		}
		
		public override string ToString()
		{
			return FormattedAddress;
		}
	}
}
