using System.Runtime.CompilerServices;
using Ccr.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Data.Common.Domain
{
	public partial class Gender
	{
		public int GenderID { get; set; }

		public string Abbreviation { get; set; }

		public string GenderName { get; set; }


		private Gender() { }

		public Gender(
			[NotNull] string abbreviation,
			[NotNull] string genderName) : this()
		{
			abbreviation.IsNotNull(nameof(abbreviation));
			genderName.IsNotNull(nameof(genderName));

			Abbreviation = abbreviation;
			GenderName = genderName;
		}

		private Gender(
			int genderID,
			[NotNull] string abbreviation,
			[CallerMemberName] string memberName = "") : this(
				abbreviation,
				memberName.Replace('_', ' '))
		{
			GenderID = genderID;
		}
	}
}
