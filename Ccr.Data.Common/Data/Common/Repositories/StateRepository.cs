using System;
using System.Linq.Expressions;
using Ccr.Data.Common.Context;
using Ccr.Data.Common.Domain;
using Ccr.Data.EntityFramework.Core;
using JetBrains.Annotations;

namespace Ccr.Data.Common.Repositories
{
	public class StateRepository
		: Repository<State, int, CommonContext>
	{
		public override Expression<Func<State, int>> PrimaryKeyExpression
			=> t => t.StateID;


		public StateRepository(
			[NotNull] CommonContext context) : base(
				context)
		{
		}


		[CanBeNull]
		public State FetchStateByName(
			string stateName)
		{
			return FetchSingleOrDefault(t => t.StateName == stateName);
		}

		//public (State state, int deviation) FetchStateByName_ApproximateMatch(
		//	string approximateStateName)
		//{
		//	return Select(
		//		t => (state: t,
		//			CommonContext.DamerauLevenschteinDistance(t.StateName, approximateStateName)));
		//}

		//public IList<(State state, int deviation)> FetchStateByName_ApproximateMatch1(
		//	string approximateStateName)
		//{
		//	return Select(
		//		t => (t,
		//			USTContext
		//				.DamerauLevenschteinDistance(
		//					t.StateName, approximateStateName)));
		//}
		//public IList<Tuple<State, int>> FetchStateByName_ApproximateMatch2(
		//	string approximateStateName)
		//{
		//	return Select(
		//		t => Tuple.Create(t,
		//			USTContext
		//			.DamerauLevenschteinDistance(
		//				t.StateName, approximateStateName)))
		//		.OrderByDescending(t=> t.Item2)
		//		.ToList();
		//}



		[CanBeNull]
		public State FetchStateByAbbreviation(
			string abbreviation)
		{
			return FetchSingleOrDefault(
				t => t.Abbreviation == abbreviation);
		}

		[CanBeNull]
		public State FetchStateByNameOrAbbreviation(
			string nameOrAbbreviation)
		{
			return FetchSingleOrDefault(
				t => t.Abbreviation == nameOrAbbreviation
				|| t.StateName == nameOrAbbreviation);
		}
	}
}
