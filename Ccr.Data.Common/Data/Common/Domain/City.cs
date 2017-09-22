using System.ComponentModel.DataAnnotations.Schema;
using Ccr.Core.Extensions;
using Ccr.Data.Common.EntityMaps;
using Core.Data.EntityFramework.Attributes;
using JetBrains.Annotations;

namespace Ccr.Data.Common.Domain
{
	[EntityConfigurationMap(typeof(CityMap))]
	public partial class City
	{
		public int CityID { get; set; }

		public string CityName { get; set; }


		public int StateID { get; set; }
		[ForeignKey("StateID")]
		public virtual State State { get; set; }


		public int CountryID { get; set; }
		[ForeignKey("CountryID")]
		public virtual Country Country { get; set; }


		private City() { }

		public City(
			[NotNull] string cityName,
			[NotNull] State state,
			[NotNull] Country country) : this()
		{
			cityName.IsNotNull(nameof(cityName));
			state.IsNotNull(nameof(state));
			country.IsNotNull(nameof(country));

			CityName = cityName;
			StateID = state.StateID;
			CountryID = country.CountryID;
		}

		internal City(
			int cityID,
			[NotNull] string cityName,
			[NotNull] State state,
			[NotNull] Country country) : this(
				cityName,
				state,
				country)
		{
			CityID = cityID;
		}
	}
}
