using System;
using System.Linq;
using System.Reflection;
using Ccr.Std.Extensions;
using Ccr.Std.Introspective.Extensions;
using Ccr.Std.Introspective.Infrastructure;

namespace Ccr.Algorithms.Collections
{
	internal class SequentialSetMemberResolver
	{
		private MethodInfo[] _memberAccessors;


		protected Type SequentialSetType { get; }

		internal int SequenceLength
		{
			get => MemberAccessors.Length;
		}

		protected MethodInfo[] MemberAccessors
		{
			get => _memberAccessors
				?? (_memberAccessors = resolveMemberAccessors());
		}


		public SequentialSetMemberResolver(
			Type sequentialSetType)
		{
			SequentialSetType = sequentialSetType;
		}


		internal object[] ExtractValueArrayBase(
			SequentialSet sequenceInstance)

		{
			if (sequenceInstance.GetType() != SequentialSetType)
				throw new InvalidOperationException(
					$"incorrect sequentialSet type");

			return MemberAccessors
				.Select(t => t.Invoke(sequenceInstance, new object[] { }))
				.ToArray();
		}

		private MethodInfo[] resolveMemberAccessors()
		{
			return SequentialSetType
				.Reflect()
				.GetPropertiesWithAttribute<SequentialSetValueAttribute>(
					MemberDescriptor.Public)
				.OrderBy(t => t.attribute.Index)
				.Select(t => t.propertyInfo.GetMethod)
				.ToArray();
		}
	}
}