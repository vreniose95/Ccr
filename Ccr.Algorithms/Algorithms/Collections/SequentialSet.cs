using System;
using System.Collections.Generic;

namespace Ccr.Algorithms.Collections
{
	public abstract class SequentialSet
	{
		private static readonly IDictionary<Type, SequentialSetMemberResolver> _memberResolverMap
			= new Dictionary<Type, SequentialSetMemberResolver>();


		protected object[] ValueArrayBase
		{
			get
			{
				var sequentialSetType = GetType();

				if (!_memberResolverMap.TryGetValue(sequentialSetType, out var memberResolver))
				{
					memberResolver = new SequentialSetMemberResolver(sequentialSetType);
					_memberResolverMap.Add(sequentialSetType, memberResolver);
				}
				return memberResolver.ExtractValueArrayBase(this);
			}
		}

		//public static TSequentialSet BuildSet<TValue, TSequentialSet>(
		//  params TValue[] values)
		//    where TSequentialSet
		//      : SequentialPair<TValue>
		//{

		//}
	}
}