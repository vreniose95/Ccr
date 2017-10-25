using System;
using NUnit.Framework;

namespace Ccr.Geocoding.Tests
{
  public static class AddressAssertionExtensions
  {
    public static void AssertLandmark(
      this Address address,
      Landmark landmark)
    {
      foreach (var check in landmark.Checks)
      {
        var component = address[check.addressType];
        Assert.IsNotNull(component);
        Assert.That(
          component.LongName.Trim().Equals(
            check.valueText.Trim(),
            StringComparison.CurrentCultureIgnoreCase));
      }
    }
  }
}
