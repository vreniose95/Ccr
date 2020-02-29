using System;

namespace Ccr.Geocoding
{
	public class GeocodingException
		: Exception
	{
		private const string defaultMessage =
			"There was an error processing the geocoding request. " +
			"See Status or InnerException for more information.";
    
		public GeocodingStatus Status { get; }


		public GeocodingException(
			GeocodingStatus status) : base(
				defaultMessage)
		{
			Status = status;
		}

		public GeocodingException(
			Exception innerException) : base(
				defaultMessage, 
				innerException)
		{
			Status = GeocodingStatus.Error;
		}
	}
}
