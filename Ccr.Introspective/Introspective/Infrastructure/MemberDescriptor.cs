using System;
using System.Reflection;

namespace Ccr.Introspective.Infrastructure
{
	/// <summary>
	/// A descriptor class that wraps the options of <see cref="BindingFlags"/> fluently 
	/// and defines a set of possible <see cref="MemberDescriptor"/> configurations statically.
	/// </summary>
	public partial class MemberDescriptor
	{
		#region Fields
		/// <summary>
		/// A derive-once field caching the equivalent <see cref="BindingFlags"/> determined 
		/// by the <see cref="MemberDescriptor"/>'s MemberScope, MemberAccessibility and 
		/// CaseSensitivity configuration for use in <see cref="System.Reflection"/> calls.
		/// </summary>
		private BindingFlags? _bindingFlags;

		#endregion

		#region Properties
		/// <summary>
		/// Defines the accessibility of the member (Public, NonPublic, or Any)
		/// </summary>
		public MemberAccessibility MemberAccessibility { get; }

		/// <summary>
		/// Defines the declaration scope of the member (Static, Instance, or Any)
		/// </summary>
		public MemberScope MemberScope { get; }

		/// <summary>
		/// Specifies whether the member identifier should be matched without case sensitivity.
		/// </summary>
		public bool CaseInsensitive { get; }

		#endregion

		#region Constructor
		/// <summary>
		/// Creates an instance of the <see cref="MemberDescriptor"/> class.
		/// </summary>
		/// <param name="memberAccessibility">
		/// Defines the accessibility of the member (Public, NonPublic, or Any)
		/// </param>
		/// <param name="memberScope">
		/// Defines the declaration scope of the member (Static, Instance, or Any)
		/// </param>
		/// <param name="caseInsensitive">
		/// Specifies whether the member identifier should be matched without case sensitivity.
		/// The default value for this parameter is <c>false</c>
		/// </param>
		private MemberDescriptor(
			MemberAccessibility memberAccessibility,
			MemberScope memberScope = MemberScope.Instance,
			bool caseInsensitive = false)
		{
			MemberAccessibility = memberAccessibility;
			MemberScope = memberScope;
			CaseInsensitive = caseInsensitive;
		}

		#endregion

		#region Methods
		/// <summary>
		/// Creates the equivalent <see cref="BindingFlags"/> by the <see cref="MemberDescriptor"/>'s 
		/// MemberScope, MemberAccessibility and CaseSensitivity configuration for use in 
		/// <see cref="System.Reflection"/> calls. The <see cref="BindingFlags"/> instance is only resolved
		/// once and cached in the <see cref="Nullable{BindingFlags}"/> field <see cref="_bindingFlags"/>.
		/// </summary>
		/// <returns>
		/// The equivalent <see cref="BindingFlags"/> configuration for this <see cref="MemberDescriptor"/>
		/// </returns>lol
		private BindingFlags resolveBindingFlags()
		{
			if (_bindingFlags.HasValue)
				return _bindingFlags.Value;

			var bindingFlags =
				(BindingFlags.Default |
				(BindingFlags)MemberAccessibility |
				(BindingFlags)MemberScope);

			if (CaseInsensitive)
				bindingFlags |= BindingFlags.IgnoreCase;

			return (_bindingFlags = bindingFlags).Value;
		}

		#endregion

		#region Operators
		/// <summary>
		/// Converts an instance of the type <see cref="MemberDescriptor"/> to its' equivalent 
		/// <see cref="BindingFlags"/> implicitly.
		/// </summary>
		/// <param name="this">
		/// The instance of the <see cref="MemberDescriptor"/> class
		/// </param>
		public static implicit operator BindingFlags(
			MemberDescriptor @this)
		{
			return @this.resolveBindingFlags();
		}

		#endregion
	}
}
