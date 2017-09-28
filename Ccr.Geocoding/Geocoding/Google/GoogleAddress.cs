using System.Linq;
using Ccr.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Geocoding.Google
{
	public class GoogleAddress
		: Address
	{
		public GoogleAddressType Type { get; }

		public GoogleLocationType LocationType { get; }

		public GoogleAddressComponent[] Components { get; }

		public bool IsPartialMatch { get; }

		public GoogleViewport Viewport { get; }

		public Bounds Bounds { get; }

		public string PlaceId { get; }


		public GoogleAddressComponent this[GoogleAddressType type]
		{
			get
			{
				return Components
					.FirstOrDefault(c => c.Types.Contains(type));
			}
		}
		public GoogleAddressComponent GetComponent(
			params GoogleAddressType[] types)
		{
			return Components
				.SingleOrDefault(c => c.Types.SequenceEqual(types));
		}



		public GoogleAddress(
			GoogleAddressType type, 
			string formattedAddress, 
			[NotNull] GoogleAddressComponent[] components,
			Location coordinates, 
			GoogleViewport viewport, 
			Bounds bounds, 
			bool isPartialMatch, 
			GoogleLocationType locationType, 
			string placeId) : base(
				formattedAddress, 
				coordinates,
				"Google")
		{
			components.IsNotNull(nameof(components));

			Type = type;
			Components = components;
			IsPartialMatch = isPartialMatch;
			Viewport = viewport;
			Bounds = bounds;
			LocationType = locationType;
			PlaceId = placeId;
		}
	}
}
