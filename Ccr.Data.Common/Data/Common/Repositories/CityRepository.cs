using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Ccr.Core.Extensions;
using Ccr.Data.Common.Context;
using Ccr.Data.Common.Domain;
using Ccr.Data.EntityFramework.Core;
using JetBrains.Annotations;

namespace Ccr.Data.Common.Repositories
{
	public class CityRepository
		: Repository<City, int, CommonContext>
	{
		public override Expression<Func<City, int>> PrimaryKeyExpression
			=> t => t.CityID;

		public CityRepository(
			[NotNull] CommonContext context) : base(
				context)
		{
		}

		[CanBeNull]
		public City FetchCityByName(
			string cityName)
		{
			return FetchSingleOrDefault(
				t => t.CityName == cityName);
		}

		[CanBeNull]
		public City FetchCityByNameAndState(
			string cityName, 
			[NotNull] State state)
		{
			state.IsNotNull(nameof(state));

			return FetchSingleOrDefault(
				t => t.CityName == cityName
				&& t.StateID == state.StateID);
		}

		[CanBeNull]
		public IList<City> FetchCitiesInState(
			[NotNull] State state)
		{
			state.IsNotNull(nameof(state));

			return FetchWhere(
				t => t.StateID == state.StateID);
		}

	}
}
