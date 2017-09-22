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


		protected Country() { }

		public Country(
			string abbreviation,
			string memberName) : this()
		{
			Abbreviation = abbreviation;
			CountryName = memberName.Replace('_', ' ');
		}
		internal Country(
			int countryID,
			string abbreviation,
			[CallerMemberName] string memberName = "") : this(
			abbreviation,
			memberName)
		{
			CountryID = countryID;
		}
	}
}
