using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Ccr.Core.Extensions;
using Ccr.Data.Common.EntityMaps;
using Core.Data.EntityFramework.Attributes;
using JetBrains.Annotations;

namespace Ccr.Data.Common.Domain
{
	[EntityConfigurationMap(typeof(PredirectionalMap))]
	public partial class Predirectional
	{
		public int PredirectionalID { get; set; }

		public string Abbreviation { get; set; }

		public string PredirectionalName { get; set; }

		public int DirectionTypeID { get; set; }
		[ForeignKey("DirectionTypeID")]
		public virtual DirectionType DirectionType { get; set; }


		private Predirectional() { }

		public Predirectional(
			string abbreviation,
			[NotNull] DirectionType directionType,
			string predirectionalName) : this()
		{
			abbreviation.IsNotNull(nameof(abbreviation));
			directionType.IsNotNull(nameof(directionType));

			Abbreviation = abbreviation;
			PredirectionalName = predirectionalName;
			DirectionTypeID = directionType.DirectionTypeID;
		}

		private Predirectional(
			int predirectionalID,
			string abbreviation,
			[NotNull] DirectionType directionType,
			[CallerMemberName] string memberName = "") : this(
				abbreviation,
				directionType,
				memberName.Replace('_', ' '))
		{
			PredirectionalID = predirectionalID;
		}
	}

}
