using System;

namespace Ccr.Core.TypeSystemInfo
{
	public class BuiltInTypeInfo
	{
		public Type SystemType { get; }

		public BuiltInTypeInfo(
			Type systemType)
		{
			SystemType = systemType;
		}
	}
}
