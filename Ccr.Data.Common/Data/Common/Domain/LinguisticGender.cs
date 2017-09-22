using System.Runtime.CompilerServices;
using Ccr.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Data.Common.Domain
{
	public partial class LinguisticGender
	{
		public int LinguisticGenderID { get; set; }

		public string Abbreviation { get; set; }

		public string LinguisticGenderName { get; set; }


		private LinguisticGender() { }

		public LinguisticGender(
			[NotNull] string abbreviation,
			[NotNull] string linguisticGenderName) : this()
		{
			abbreviation.IsNotNull(nameof(abbreviation));
			linguisticGenderName.IsNotNull(nameof(linguisticGenderName));

			Abbreviation = abbreviation;
			LinguisticGenderName = linguisticGenderName;
		}

		private LinguisticGender(
			int linguisticGenderID,
			[NotNull] string abbreviation,
			[CallerMemberName] string memberName = "") : this(
				abbreviation,
				memberName.Replace('_', ' '))
		{
			LinguisticGenderID = linguisticGenderID;
		}
	}
}
