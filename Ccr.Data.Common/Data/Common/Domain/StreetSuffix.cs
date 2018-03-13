using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Ccr.Data.Common.EntityMaps;
using Ccr.Data.EntityFramework.Attributes;

// ReSharper disable VirtualMemberCallInConstructor
namespace Ccr.Data.Common.Domain
{
	[EntityConfigurationMap(typeof(StreetSuffixMap))]
	public partial class StreetSuffix
	{
		public int StreetSuffixID { get; set; }

		public string Abbreviation { get; set; }

		public string PrimaryName { get; set; }
		
		public virtual ICollection<StreetSuffixVariant> StreetSuffixVariants { get; set; }


		private StreetSuffix()
		{
			StreetSuffixVariants = new HashSet<StreetSuffixVariant>();
		}

		public StreetSuffix(
			string abbreviation,
			string primaryName) : this()
		{
			Abbreviation = abbreviation;
			PrimaryName = primaryName;
		}

		private StreetSuffix(
			int streetSuffixID,
			string abbreviation,
			[CallerMemberName] string memberName = "") : this(
				abbreviation,
				memberName.Replace('_', ' '))
		{
			StreetSuffixID = streetSuffixID;
		}
	}
}
