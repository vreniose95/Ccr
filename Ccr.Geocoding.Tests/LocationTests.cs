using NUnit.Framework;

namespace Ccr.Geocoding.Tests
{
  [TestFixture]
  public class LocationTests
  {
    [Test]
    public void CanCreate()
    {
      const double latitude = 40.7591837;
      const double longitude = -73.9818335;

      var location = new Location(latitude, longitude);

      Assert.AreEqual(location.Latitude, latitude);
      Assert.AreEqual(location.Longitude, longitude);
    }

    [Test]
    public void CanCompareForEquality()
    {
      const double latitude = 40.7591837;
      const double longitude = -73.9818335;

      var location1 = new Location(latitude, longitude);
      var location2 = new Location(latitude, longitude);

      Assert.True(location1.Equals(location2));
      Assert.AreEqual(location1.GetHashCode(), location2.GetHashCode());
    }

    [Test]
    public void CanCalculateHaversineDistanceBetweenTwoAddresses()
    {
      var location1 = new Location(0, 0);
      var location2 = new Location(40, 20);

      var distance1 = location1.DistanceBetween(location2);
      var distance2 = location2.DistanceBetween(location1);

      Assert.AreEqual(distance1, distance2);
    }
  }
}
