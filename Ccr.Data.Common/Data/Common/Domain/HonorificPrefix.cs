using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Ccr.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Data.Common.Domain
{
  public partial class HonorificPrefix
	{
		public int HonorificPrefixID { get; set; }

    public string PrefixClassificationName { get; set; }
    public HonorificPrefixClassification PrefixClassification { get; set; }

		public int LinguisticGenderID { get; set; }
		[ForeignKey("LinguisticGenderID")]
		public LinguisticGender LinguisticGender { get; set; }

		public string PrefixAbbreviation { get; set; }

		public string PrefixName { get; set; }


		private HonorificPrefix() { }

    public HonorificPrefix(
			[NotNull] HonorificPrefixClassification prefixClassification,
			[NotNull] LinguisticGender linguisticGender,
			[NotNull] string prefixAbbreviation,
			[NotNull] string prefixName) : this()
    {
	    prefixClassification.IsNotNull(nameof(prefixClassification));
	    linguisticGender.IsNotNull(nameof(linguisticGender));
	    prefixAbbreviation.IsNotNull(nameof(prefixAbbreviation));
	    prefixName.IsNotNull(nameof(prefixName));

			PrefixClassification = prefixClassification;
	    LinguisticGender = linguisticGender;
	    PrefixAbbreviation = prefixAbbreviation;
	    PrefixName = prefixName;
    }

	  private HonorificPrefix(
		  int honorificPrefixID,
		  [NotNull] HonorificPrefixClassification prefixClassification,
		  [NotNull] LinguisticGender linguisticGender,
		  [NotNull] string prefixAbbreviation,
			[CallerMemberName, NotNull] string memberName = "") : this(
				prefixClassification,
				linguisticGender,
				prefixAbbreviation,
				memberName.Replace('_',' '))
	  {
		  HonorificPrefixID = honorificPrefixID;
	  }

		public override string ToString()
		{
			return PrefixName;
		}
	}
}
