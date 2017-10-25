using System.Runtime.CompilerServices;
using Ccr.PresentationCore.Collections;
using JetBrains.Annotations;

namespace Ccr.Geocoding.Tests
{
  public sealed class Landmark
    : ValueEnum<Location>
  {
    public (AddressType addressType, string valueText)[] Checks { get; }

    public static Landmark TheGoldenGateBridge = new Landmark(
      37.8199d,
      -122.4783d,
      new[] {
        (AddressType.Route, "Golden Gate Bridge"),
        (AddressType.Locality, "San Francisco"),
        (AddressType.AdministrativeAreaLevel1, "California"),
        (AddressType.Country, "United States")
      });

    public static Landmark TheWhiteHouse = new Landmark(
      38.8977d,
      -77.0365d,
      new[] {
        (AddressType.StreetNumber, "1600"),
        (AddressType.Route, "Pennsylvania Avenue Northwest"),
        (AddressType.Neighborhood, "Northwest Washington"),
        (AddressType.Locality, "Washington"),
        (AddressType.AdministrativeAreaLevel1, "District of Columbia"),
        (AddressType.Country, "United States"),
        (AddressType.PostalCode, "20500")
      });

    public static Landmark ThirtyRockefellerPlaza = new Landmark(
      40.7597d,
      -73.9800d,
      new[] {
        (AddressType.Premise, "Rockefeller Plaza"),
        (AddressType.StreetNumber, "45"),
        (AddressType.Route, "Rockefeller Plaza"),
        (AddressType.Political, "Manhattan"),
        (AddressType.Locality, "New York"),
        (AddressType.AdministrativeAreaLevel2, "New York County"),
        (AddressType.AdministrativeAreaLevel1, "New York"),
        (AddressType.Country, "United States"),
        (AddressType.PostalCode, "10111")
      });


    private Landmark(
      double latitude,
      double longitude,
      (AddressType addressType, string valueText)[] checks,
      [CallerMemberName, NotNull] string fieldName = "",
      [CallerLineNumber] int line = 0) : base(
        new Location(latitude, longitude),
        fieldName,
        line)
    {
      Checks = checks;
    }
  }
}
