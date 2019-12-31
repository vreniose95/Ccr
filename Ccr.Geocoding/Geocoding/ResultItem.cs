using System.Collections.Generic;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Geocoding
{
	public class ResultItem
	{
		private Address _input;
		private IEnumerable<Address> _output;


		/// <summary>
		/// Original input for this response
		/// </summary>
		public Address Request
		{
			get => _input;
			[NotNull] set
			{
				value.IsNotNull(nameof(value));
				_input = value;
			}
		}

		/// <summary>
		/// Output for the given input
		/// </summary>
		public IEnumerable<Address> Response
		{
			get => _output;
			[NotNull] set
			{
				value.IsNotNull(nameof(value));
				_output = value;
			}
		}


		public ResultItem(
			[NotNull] Address request, 
			[NotNull] IEnumerable<Address> response)
		{
			Request = request;
			Response = response;
		}
	}
}
