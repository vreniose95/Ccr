using System.Runtime.CompilerServices;
using Ccr.Data.Common.EntityMaps;
using Core.Data.EntityFramework.Attributes;

namespace Ccr.Data.Common.Domain
{
	[EntityConfigurationMap(typeof(CountryMap))]
	public partial class Country
	{
		public int CountryID { get; set; }

		public string Abbreviation { get; set; }

		public string CountryName { get; set; }


		private Country() { }

		public Country(
			string abbreviation,
			string countryName) : this()
		{
			Abbreviation = abbreviation;
			CountryName = countryName;
		}
		private Country(
			int countryID,
			string abbreviation,
			[CallerMemberName] string memberName = "") : this(
				abbreviation,
				memberName.Replace('_', ' '))
		{
			CountryID = countryID;
		}
	}
}
