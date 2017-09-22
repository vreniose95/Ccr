using JetBrains.Annotations;

namespace Ccr.Introspective.Tests.Mock
{
	public class PersonFixture
	{
		public int PersonFixtureID { get; protected set; }

		[CanBeNull]
		public string Prefix { get; }

		[NotNull]
		internal string FirstName { get; }

		[CanBeNull]
		protected internal string MiddleName { get; }

		[NotNull]
		protected string LastName { get; }

		[UsedImplicitly, CanBeNull]
		private string Suffix { get; }


		[NotNull]
		public string FullName
		{
			get => $"{FirstName} {MiddleName} {LastName}";
		}

		private PersonFixture()
		{
		}
		protected PersonFixture(
			[CanBeNull] string prefix,
			[NotNull] string firstName,
			[CanBeNull] string middleName,
			[NotNull] string lastName,
			[CanBeNull] string suffix) : this()
		{
			Prefix = prefix;
			FirstName = firstName;
			MiddleName = middleName;
			LastName = lastName;
			Suffix = suffix;
		}

		public PersonFixture(
			int personFixtureID,
			[CanBeNull] string prefix,
			[NotNull] string firstName,
			[CanBeNull] string middleName,
			[NotNull] string lastName,
			[CanBeNull] string suffix) : this(
				prefix,
				firstName,
				middleName,
				lastName,
				suffix)
		{
			PersonFixtureID = personFixtureID;
		}

		protected static PersonFixture Parse(
			string personStr)
		{
			
		}
	}
}
