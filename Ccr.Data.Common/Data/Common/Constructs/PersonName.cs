using System;
using System.ComponentModel.DataAnnotations.Schema;
using Ccr.Data.Common.Domain;
using JetBrains.Annotations;
using Ccr.Core.Extensions;
// ReSharper disable ConvertToAutoProperty
// ReSharper disable ArrangeAccessorOwnerBody
namespace Ccr.Data.Common.Constructs
{
  public partial class PersonName
    : IFormattable
  {
    [CanBeNull]
    private readonly HonorificPrefix _prefix;
		[NotNull]
    private readonly string _firstName;
		[CanBeNull]
    private char? _middleInitial;
    [CanBeNull]
    private readonly string _fullMiddleName;
    [NotNull]
    private readonly string _lastName;
    [CanBeNull]
    private readonly PostNominalSuffix _suffix;
    [NotNull]
    private readonly Gender _gender;


    /// <summary>
    /// Returns the honorific prefix, if provided. If no honorific prefix
    /// is provided, the method will return <langword>null</langword>.
    /// </summary>
    [CanBeNull]
    public HonorificPrefix Prefix
    {
      get => _prefix;
    }
    /// <summary>
    /// Returns the first name of the person.
    /// </summary>
    /// <remarks>
    /// The return value cannot be null.
    /// </remarks>
    [NotNull]
    public string FirstName
    {
      get => _firstName;
    }

    /// <summary>
    /// This property returns the person's full middle name if provided.
    /// If the full middle name was not supplied, but the middle inital was,
    /// then the returned value will be a single, capitalized character  
    /// initial representing the person's middle name, followed by a period.
    /// If neither of the two are pryeahovided, then <langword>null</langword>
    /// will be returned.
    /// </summary>
    [CanBeNull]
    public string MiddleName
    {
      get
      {
        if (!_fullMiddleName.IsNullOrEmptyEx())
          return _fullMiddleName;

        return
          !_middleInitial.HasValue
            ? $"{_middleInitial}."
            : null;
      }
    }

	  [CanBeNull, NotMapped]
	  public char? MiddleInitial
	  {
		  get
		  {
				if (!_fullMiddleName.IsNullOrEmptyEx())
				  return (_middleInitial = _fullMiddleName[0]).Value;

			  return _middleInitial;
		  }
	  }

		/// <summary>
		/// Returns the last name of the person.
		/// </summary>
		/// <remarks>
		/// The return value cannot be null.
		/// </remarks>
		[NotNull]
    public string LastName
    {
      get => _lastName;
    }

    /// <summary>
    /// Returns the honorific prefix, if provided. If no honorific prefix
    /// is provided, the method will return <langword>null</langword>.
    /// </summary>
    [CanBeNull]
    public PostNominalSuffix Suffix
    {
      get => _suffix;
    }

    /// <summary>
    /// Returns the Gender of the person. If no gender is provided, the
    /// default entity, <see cref="T:Gender.Unset"/> is returned.
    /// </summary>
    /// <remarks>
    /// The return value cannot be null.
    /// </remarks>
    [NotNull]
    public Gender Gender
    {
      get => _gender;
    }



    public PersonName(
      [NotNull] string firstName,
      [NotNull] string lastName) : this(
      null,
      firstName,
      null,
      lastName,
      null,
      Gender.Unset)
    {
    }

    public PersonName(
      [NotNull] string firstName,
      [NotNull] string middleNameOrInitial,
      [NotNull] string lastName) : this(
      null,
      firstName,
      middleNameOrInitial,
      lastName,
      null,
      Gender.Unset)
    {
    }

    public PersonName(
      [NotNull] string firstName,
      [NotNull] string lastName,
      [NotNull] Gender gender) : this(
      null,
      firstName,
      null,
      lastName,
      null,
      gender)
    {
    }

    public PersonName(
      [NotNull] string firstName,
      [NotNull] string middleNameOrInitial,
      [NotNull] string lastName,
      [NotNull] Gender gender) : this(
      null,
      firstName,
      middleNameOrInitial,
      lastName,
      null,
      gender)
    {
    }


    public PersonName(
      [NotNull] HonorificPrefix prefix,
      [NotNull] string firstName,
      [NotNull] string middleNameOrInitial,
      [NotNull] string lastName,
      [NotNull] Gender gender) : this(
      prefix,
      firstName,
      middleNameOrInitial,
      lastName,
      null,
      gender)
    {
    }

    public PersonName(
      [NotNull] string firstName,
      [NotNull] string lastName,
      [NotNull] PostNominalSuffix suffix) : this(
      null,
      firstName,
      null,
      lastName,
      suffix,
      Gender.Unset)
    {
    }

    public PersonName(
      [NotNull] string firstName,
      [NotNull] string middleNameOrInitial,
      [NotNull] string lastName,
      [NotNull] PostNominalSuffix suffix) : this(
      null,
      firstName,
      middleNameOrInitial,
      lastName,
      suffix,
      Gender.Unset)
    {
    }

    public PersonName(
      [NotNull] string firstName,
      [NotNull] string middleNameOrInitial,
      [NotNull] string lastName,
      [NotNull] PostNominalSuffix suffix,
      [NotNull] Gender gender) : this(
      null,
      firstName,
      middleNameOrInitial,
      lastName,
      suffix,
      gender)
    {
    }

    protected PersonName(
      [CanBeNull] HonorificPrefix prefix,
      [NotNull] string firstName,
      [CanBeNull] string middleNameOrInitial,
      [NotNull] string lastName,
      [CanBeNull] PostNominalSuffix suffix,
      [NotNull] Gender gender)
    {
      firstName.IsNotNull(nameof(firstName));
      firstName.IsNotNull(nameof(gender));
      firstName.IsNotNull(nameof(firstName));

      _prefix = prefix;

      _firstName = firstName.Trim().ToTitleCase();

      _lastName = lastName;
      _suffix = suffix;
      _gender = gender;

      if (middleNameOrInitial == null)
        return;

      middleNameOrInitial = middleNameOrInitial.Trim().ToTitleCase();

      if (!middleNameOrInitial.IsNullOrEmptyEx())
      {
        if (middleNameOrInitial.Length == 1)
        {
          _middleInitial = middleNameOrInitial[0];
        }
        else if (middleNameOrInitial.Length == 2)
        {
          if (middleNameOrInitial[1] == '.')
          {
            _middleInitial = middleNameOrInitial[0];
          }
          else
          {
            _middleInitial = null;
            _fullMiddleName = middleNameOrInitial;
          }
        }
      }
      else
      {
        _middleInitial = null;
        _fullMiddleName = middleNameOrInitial;
      }
    }
  }
}
