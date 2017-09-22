using System;
using Ccr.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Geocoding.Google
{
	public class GoogleAddressComponent
	{
		public GoogleAddressType[] Types { get; }

		public string LongName { get; }

		public string ShortName { get; }


		public GoogleAddressComponent(
			[NotNull] GoogleAddressType[] types, 
			string longName, 
			string shortName)
		{
			types.IsNotNull(nameof(types));
			
			if (types.Length < 1)
				throw new ArgumentException(
					$"Value cannot be empty.", 
					nameof(types));

			Types = types;
			LongName = longName;
			ShortName = shortName;
		}


		public override string ToString()
		{
			return $"{Types[0]}: {LongName}";
		}
	}
}
