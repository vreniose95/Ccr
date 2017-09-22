using System.Runtime.CompilerServices;
using Ccr.Data.Common.EntityMaps;
using Core.Data.EntityFramework.Attributes;

namespace Ccr.Data.Common.Domain
{
	[EntityConfigurationMap(typeof(DirectionTypeMap))]
	public partial class DirectionType
	{
		public int DirectionTypeID { get; set; }

		public string DirectionTypeName { get; set; }


		private DirectionType() { }

		public DirectionType(
			string directionTypeName) : this()
		{
			DirectionTypeName = directionTypeName;
		}
		private DirectionType(
			int directionTypeID,
			[CallerMemberName] string memberName = "") : this(
			memberName.Replace('_', ' '))
		{
			DirectionTypeID = directionTypeID;
		}
	}
}
