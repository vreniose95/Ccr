using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics.CodeAnalysis;
using Ccr.Data.Common.Domain;
using Ccr.Data.Common.EntityMaps;
using Ccr.Data.EntityFramework.Functions.Attributes;

namespace Ccr.Data.Common.Context
{
	public class CommonContext
		: DbContext
	{
		public DbSet<City> Cities { get; set; }

		public DbSet<Country> Countries { get; set; }

		public DbSet<DirectionType> DirectionTypes { get; set; }

		public DbSet<Gender> Genders { get; set; }

		public DbSet<PostalAddress> PostalAddresses { get; set; }

		public DbSet<Predirectional> Predirectionals { get; set; }

		public DbSet<State> States { get; set; }

		public DbSet<StreetSuffix> StreetSuffixes { get; set; }

		public DbSet<StreetSuffixVariant> StreetSuffixVariants { get; set; }



#pragma warning disable 168
		[CsSqlFunction]
		[SuppressMessage("ReSharper", "JoinDeclarationAndInitializer")]
		[SuppressMessage("ReSharper", "NotAccessedVariable")]
		public static int LevenshteinDistance(
			[CcrFunctionParameter(100)] string sourceString,
			[CcrFunctionParameter(100)] string targetString)
		{
			string matrix;
			int ld;
			int targetStringLength;
			int sourceStringLength;
			int ii;
			int jj;

			char currentSourceChar;

			char currentTargetChar;
			int cost;
			int above;
			int aboveAndToLeft;
			int toTheLeft;
			int minimumValueOfCells;

			if (sourceString == null || targetString == null)
				return -1;

			sourceStringLength = sourceString.Length;
			targetStringLength = targetString.Length;
			//matrix = 

			throw new NotImplementedException();
		}
#pragma warning restore 168

		public CommonContext() : base(
			"ust_analytics_connection")
		{
			//Database.CommandTimeout = 300;
			//SetCommandTimeOut(310);
			//Database.SetInitializer(new DatabaseInitializer());

			Database.Initialize(true);
		}
		//public void SetCommandTimeOut(int Timeout)
		//{
		//	var objectContext = (this as IObjectContextAdapter).ObjectContext;
		//	objectContext.CommandTimeout = Timeout;
		//}
		protected override void OnModelCreating(
			DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Configurations.Add(new CityMap());
			modelBuilder.Configurations.Add(new CountryMap());
			modelBuilder.Configurations.Add(new DirectionTypeMap());
			modelBuilder.Configurations.Add(new GenderMap());
			modelBuilder.Configurations.Add(new PostalAddressMap());
			modelBuilder.Configurations.Add(new PredirectionalMap());
			modelBuilder.Configurations.Add(new StateMap());
			modelBuilder.Configurations.Add(new StreetSuffixMap());
			modelBuilder.Configurations.Add(new StreetSuffixVariantMap());

			modelBuilder
				.Conventions
				.Remove<OneToManyCascadeDeleteConvention>();
		}


	}
}
