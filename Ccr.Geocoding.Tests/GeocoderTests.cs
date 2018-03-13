using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Ccr.Geocoding.Tests
{
  [TestFixture]
  public class GeocoderTests
  {
    private const string _apiKey
      = "AIzaSyDfgHD5nn_qH7t_rfyIYSwylObxpG_uEOQ";

    private Geocoder _geocoder;

    // ReSharper disable ArrangeAccessorOwnerBody
    protected Geocoder geocoder
    {
      get => _geocoder ?? (_geocoder = new Geocoder(_apiKey));
    }
    // ReSharper enable ArrangeAccessorOwnerBody


    [Test]
    [TestCase("1600 Pennsylvania Ave NW, Washington, DC 20006")]
    public async Task CanGeocodeStreetAddress(
      string address)
    {
      var addresses = (await geocoder.GeocodeAsync(address)).ToArray();
      addresses[0].AssertLandmark(Landmark.TheWhiteHouse);
    }

    [Test]
    [TestCase("Golden Gate Bridge, San Francisco, CA")]
    public async Task CanGeocodeLandmarks(
      string address)
    {
      var addresses = (await geocoder.GeocodeAsync(address)).ToArray();
      addresses[0].AssertLandmark(Landmark.TheGoldenGateBridge);
    }

    [Test]
    [TestCase("30 Rockefeller Plaza, New York City, New York")]
    public async Task CanGeocodeSkyscrapers(
      string address)
    {
      var addresses = (await geocoder.GeocodeAsync(address)).ToArray();
      addresses[0].AssertLandmark(Landmark.ThirtyRockefellerPlaza);
    }


    [Test]
    [TestCase("1600 Pennsylvania Ave NW, Washington, DC 20006")]
    public async Task CanValidateGeocodedStreetAddressIsWithinVacinity(
      string address)
    {
      var addresses = (await geocoder.GeocodeAsync(address)).ToArray();
      Assert.That(
        addresses[0]
          .Coordinates
          .IsInVacinity(
            Landmark
              .TheWhiteHouse
              .Value,
            Distance.StandardVacinity));
    }

    [Test]
    [TestCase("Golden Gate Bridge, San Francisco, CA")]
    public async Task CanValidateGeocodedLandmarkAddressIsWithinVacinity(
      string address)
    {
      var addresses = (await geocoder.GeocodeAsync(address)).ToArray();
      Assert.That(
        addresses[0]
          .Coordinates
          .IsInVacinity(
            Landmark
              .TheGoldenGateBridge
              .Value,
            Distance.StandardVacinity));
    }

    [Test]
    [TestCase("30 Rockefeller Plaza, New York City, New York")]
    public async Task CanValidateGeocodedSkyscraperAddressIsWithinVacinity(
      string address)
    {
      var addresses = (await geocoder.GeocodeAsync(address)).ToArray();
      Assert.That(
        addresses[0]
          .Coordinates
          .IsInVacinity(
            Landmark
              .ThirtyRockefellerPlaza
              .Value,
            Distance.StandardVacinity));
    }
  }
}
