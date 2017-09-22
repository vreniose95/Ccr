using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Ccr.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Data.Common.Domain
{
	public partial class PostNominalSuffix
	{
		public int PostNominalSuffixID { get; set; }

		public string PostNominalClassificationName { get; set; }
		public PostNominalSuffixClassification PostNominalClassification { get; set; }

		public int LinguisticGenderID { get; set; }
		[ForeignKey("LinguisticGenderID")]
		public LinguisticGender LinguisticGender { get; set; }

		public string SuffixAbbreviation { get; set; }

		public string SuffixName { get; set; }



		private PostNominalSuffix() { }

		public PostNominalSuffix(
			[NotNull] PostNominalSuffixClassification postNominalClassification,
			[NotNull] LinguisticGender linguisticGender,
			[NotNull] string suffixAbbreviation,
			[NotNull] string suffixName) : this()
		{
			postNominalClassification.IsNotNull(nameof(postNominalClassification));
			linguisticGender.IsNotNull(nameof(linguisticGender));
			suffixAbbreviation.IsNotNull(nameof(suffixAbbreviation));
			suffixName.IsNotNull(nameof(suffixName));

			PostNominalClassification = postNominalClassification;
			LinguisticGender = linguisticGender;
			SuffixAbbreviation = suffixAbbreviation;
			SuffixName = suffixName;
		}

		private PostNominalSuffix(
			int postNominalSuffixID,
			[NotNull] PostNominalSuffixClassification postNominalClassification,
			[NotNull] LinguisticGender linguisticGender,
			[NotNull] string suffixAbbreviation,
			[CallerMemberName, NotNull] string memberName = "") : this(
				postNominalClassification,
				linguisticGender,
				suffixAbbreviation,
				memberName.Replace('_',' '))
		{
			PostNominalSuffixID = postNominalSuffixID;
		}
	}
}
