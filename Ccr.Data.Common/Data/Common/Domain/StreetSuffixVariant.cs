using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Ccr.Core.Extensions;
using Ccr.Data.Common.EntityMaps;
using Ccr.Data.EntityFramework.Attributes;
using JetBrains.Annotations;
// ReSharper disable VirtualMemberCallInConstructor
namespace Ccr.Data.Common.Domain
{
	[EntityConfigurationMap(typeof(StreetSuffixVariantMap))]
	public partial class StreetSuffixVariant
	{ 
		public int StreetSuffixVariantID { get; set; }

		public string VariantName { get; set; }

		public int StreetSuffixID { get; set; }
		[ForeignKey("StreetSuffixID")]
		public virtual StreetSuffix StreetSuffix { get; set; }


		private StreetSuffixVariant() { }

		public StreetSuffixVariant(
			[NotNull] StreetSuffix streetSuffix,
			[NotNull] string variantName) : this()
		{
			streetSuffix.IsNotNull(nameof(streetSuffix));
			variantName.IsNotNull(nameof(variantName));

			StreetSuffix = streetSuffix;
			VariantName = variantName;
		}

		private StreetSuffixVariant(
			int streetSuffixVariantID,
			StreetSuffix streetSuffix,
			[CallerMemberName] string memberName = "") : this(
				streetSuffix,
				memberName.Replace('_', ' '))
		{
			StreetSuffixVariantID = streetSuffixVariantID;
		}
	}
}
