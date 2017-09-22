using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Ccr.Core.Extensions;
using JetBrains.Annotations;
// ReSharper disable VirtualMemberCallInConstructor
namespace Ccr.Data.Common.Domain
{
	public partial class PostNominalSuffixClassification
	{
		public int PostNominalSuffixClassificationID { get; set; }

		public string SuffixClassificationName { get; set; }

		public virtual ICollection<PostNominalSuffix> PostNominalSuffixes { get; set; }



		private PostNominalSuffixClassification()
		{
			PostNominalSuffixes = new HashSet<PostNominalSuffix>();
		}

		public PostNominalSuffixClassification(
			[NotNull] string suffixClassificationName) : this()
		{
			suffixClassificationName.IsNotNull(nameof(suffixClassificationName));

			SuffixClassificationName = suffixClassificationName;
		}

		private PostNominalSuffixClassification(
			int postNominalSuffixClassificationID,
			[CallerMemberName] string memberName = "") : this(
			memberName.Replace('_', ' '))
		{
			PostNominalSuffixClassificationID = postNominalSuffixClassificationID;
		}
			

	}
}
