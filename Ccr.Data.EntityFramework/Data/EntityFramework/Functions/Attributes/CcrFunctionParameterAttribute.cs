using System;
using Ccr.Core.Extensions;
using Ccr.Core.Extensions.NumericExtensions;
using JetBrains.Annotations;
// ReSharper disable ConvertToAutoProperty
// ReSharper disable ArrangeAccessorOwnerBody
namespace Ccr.Data.EntityFramework.Functions.Attributes
{
	[AttributeUsage(AttributeTargets.Parameter)]
	public class CcrFunctionParameterAttribute
		: Attribute
	{
		private Type _type;
		private int? _typeMaxLength;
		private string _name;


		[CanBeNull]
		public Type Type
		{
			get => _type;
			set
			{
				if (value == null)
				{
					_type = null;
					return;
				}
				_type = value;
			}
		}

		[CanBeNull]
		public int? TypeMaxLength
		{
			get => _typeMaxLength;
			set
			{
				if (!value.HasValue)
				{
					_typeMaxLength = null;
					return;
				}
				if (value.Value.IsNotWithin((1, 8000)))
					throw new ArgumentOutOfRangeException(
						nameof(value),
						value,
						$"The value {$"{value.Value}".SQuote()} is" +
						$"not a valid value to set for TypeMaxLength. " +
						$"The value should either be null, or an int " +
						$"between the range of [1 - 8000], inlusively.");
				
				_typeMaxLength = value.Value;
			}
		}

		[CanBeNull]
		public string Name
		{
			get => _name;
			set
			{
				if (value == null)
				{
					_name = null;
					return;
				}
				_name = value;
			}
		}


		
		public CcrFunctionParameterAttribute() { }

		public CcrFunctionParameterAttribute(
			int typeMaxLength) : this()
		{
			TypeMaxLength = typeMaxLength;
		}

		public CcrFunctionParameterAttribute(
			[NotNull] string name) : this()
		{
			name.IsNotNull(nameof(name));
			_name = name;
		}

		public CcrFunctionParameterAttribute(
			[NotNull] Type type,
			[NotNull] string name) : this(
			name)
		{
			type.IsNotNull(nameof(type));
			_type = type;
		}
	}
}
