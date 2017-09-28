namespace Ccr.Introspective.Tests.Mock
{
	public class AddressFixture
	{
		public int BuildingNumber { get; }

		public string Street { get; }

		public string City { get; }

		public string State { get; }

		public int PostalCode { get; }

		public string Country { get; }


		public AddressFixture(
			int _buildingNumber,
			string _street,
			string _city,
			string _state,
			int _postalCode,
			string _country)
		{
			BuildingNumber = _buildingNumber;
			Street = _street;
			City = _city;
			State = _state;
			PostalCode = _postalCode;
			Country = _country;
		}
	}
}
