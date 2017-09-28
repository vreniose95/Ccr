using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ccr.Data.Common.Domain;
using Ccr.Data.Common.EntityMaps;

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



		public const string dbo = nameof(dbo);

		/*	[DbFunction("CodeFirstDatabaseSchema", "DamerauLevenschteinDistance")]
			public static int DamerauLevenschteinDistance(
				string SourceString,
				string TargetString)
			{
				throw new NotImplementedException();
			}
			*/

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
