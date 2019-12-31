using System;

namespace Ccr.MaterialDesign.CodeEditors
{
	public class GroupNameAttribute
		: Attribute
	{
		public string GroupName { get; }


		public GroupNameAttribute(
			string groupName)
		{
			GroupName = groupName;
		}
	}
}