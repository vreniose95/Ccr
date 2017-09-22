using System.Runtime.CompilerServices;
using Ccr.Data.Common.EntityMaps;
using Core.Data.EntityFramework.Attributes;

namespace Ccr.Data.Common.Domain
{
	[EntityConfigurationMap(typeof(StateMap))]
	public partial class State
	{
		public int StateID { get; set; }

		public string Abbreviation { get; set; }

		public string StateName { get; set; }


		private State() { }

		public State(
			string abbreviation,
			string stateName) : this()
		{
			Abbreviation = abbreviation;
			StateName = stateName;
		}

		private State(
			int stateID,
			string abbreviation,
			[CallerMemberName] string memberName = "") : this(
				abbreviation,
				memberName.Replace('_', ' '))
		{
			StateID = stateID;
		}
	}
}
