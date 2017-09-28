using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Ccr.Core.Extensions;

namespace Ccr.Data.Common.Constructs
{
	public partial class PersonName
	{
		public string ToString(string format, IFormatProvider formatProvider)
		{
			void formatToken(
				PersonNameTokenType token,
				ref StringBuilder _builder)
			{
				switch (token)
				{
					case PersonNameTokenType.Comma:
						{
							_builder.Append(',');
							_builder.Append(' ');
							break;
						}
					case PersonNameTokenType.HonorificPrefixFull:
					case PersonNameTokenType.HonorificPrefixAbbreviationWithPeriod:
					case PersonNameTokenType.HonorificPrefixAbbreviationWithoutPeriod:
						{
							var prefix = Prefix;
							if (prefix == null)
								return;

							switch (token)
							{
								case PersonNameTokenType.HonorificPrefixFull:
									_builder.Append(prefix.PrefixName);
									break;

								case PersonNameTokenType.HonorificPrefixAbbreviationWithPeriod:
									_builder.Append(prefix.PrefixAbbreviation);
									_builder.Append('.');
									break;

								case PersonNameTokenType.HonorificPrefixAbbreviationWithoutPeriod:
									_builder.Append(prefix.PrefixAbbreviation);
									break;
							}
							_builder.Append(' ');
							break;
						}

					case PersonNameTokenType.453Full:
					case PersonNameTokenType.FirstNameInitialWithPeriod:
					case PersonNameTokenType.FirstNameInitialWithoutPeriod:
						{
							switch (token)
							{
								case PersonNameTokenType.FirstNameFull:
									_builder.Append(FirstName);
									break;

								case PersonNameTokenType.FirstNameInitialWithPeriod:
									_builder.Append(FirstName[0]);
									_builder.Append('.');
									break;

								case PersonNameTokenType.FirstNameInitialWithoutPeriod:
									_builder.Append(FirstName[0]);
									break;
							}
							_builder.Append(' ');
							break;
						}

					case PersonNameTokenType.MiddleNameFull:
					case PersonNameTokenType.MiddleNameInitialWithPeriod:
					case PersonNameTokenType.MiddleNameInitialWithoutPeriod:
						{
							switch (token)
							{
								case PersonNameTokenType.MiddleNameFull:
									if (!MiddleName.IsNullOrEmptyEx())
									{
										_builder.Append(MiddleName);
									}
									else
									{
										if (MiddleInitial.HasValue)
										{
											_builder.Append(MiddleInitial.Value);
											_builder.Append('.');
											_builder.Append(' ');
										}
									}
									break;

								case PersonNameTokenType.MiddleNameInitialWithPeriod:
									if (MiddleInitial.HasValue)
									{
										_builder.Append(MiddleInitial.Value);
										_builder.Append('.');
										_builder.Append(' ');
									}
									break;

								case PersonNameTokenType.MiddleNameInitialWithoutPeriod:
									if (MiddleInitial.HasValue)
									{
										_builder.Append(MiddleInitial.Value);
										_builder.Append(' ');
									}
									break;
							}
							break;
						}

					case PersonNameTokenType.LastNameFull:
					case PersonNameTokenType.LastNameInitialWithPeriod:
					case PersonNameTokenType.LastNameInitialWithoutPeriod:
						{
							switch (token)
							{
								case PersonNameTokenType.LastNameFull:
									_builder.Append(LastName);
									break;

								case PersonNameTokenType.LastNameInitialWithPeriod:
									_builder.Append(LastName[0]);
									_builder.Append('.');
									break;

								case PersonNameTokenType.LastNameInitialWithoutPeriod:
									_builder.Append(LastName[0]);
									break;
							}
							_builder.Append(' ');
							break;
						}

					case PersonNameTokenType.PostNominalSuffixFull:
					case PersonNameTokenType.PostNominalSuffixAbbreviationWithPeriod:
					case PersonNameTokenType.PostNominalSuffixAbbreviationWithoutPeriod:
						{
							var suffix = Suffix;
							if (suffix == null)
								return;

							_builder.Append(' ');

							switch (token)
							{
								case PersonNameTokenType.PostNominalSuffixFull:
									_builder.Append(suffix.SuffixName);
									break;

								case PersonNameTokenType.PostNominalSuffixAbbreviationWithPeriod:
									_builder.Append(suffix.SuffixAbbreviation);
									_builder.Append('.');
									break;

								case PersonNameTokenType.PostNominalSuffixAbbreviationWithoutPeriod:
									_builder.Append(suffix.SuffixAbbreviation);
									break;
							}
							break;
						}
					case PersonNameTokenType.Invalid:
						throw new IndexOutOfRangeException();

					default:
						throw new InvalidEnumArgumentException();
				}
			}
			var pnString = __PNString.Parse(format);
			var builder = new StringBuilder();

			foreach (var token in pnString.Tokens)
			{
				formatToken(token, ref builder);
			}

			return builder.ToString();
		}


		/*
		 * HP. Fn M. Ln PS.
		 * 
		 "([Hp|HP.|HP] )?[Fn|F.] ([Mn|M.] )?[Ln|L.]( [Ps|PS.|PS])?"
			 
			 */
		protected internal class __PNString
		{
			private readonly PersonNameTokenType[] _tokens;

			public IReadOnlyList<PersonNameTokenType> Tokens
			{
				get => _tokens;
			}


			private __PNString()
			{
			}
			internal __PNString(
				PersonNameTokenType[] tokens) : this()
			{
				_tokens = tokens;
			}


			public static __PNString Parse(
				string pnString)
			{
				var _tokenArray = pnString
					.Split(' ', '.', ',')
					.Select(t => t.Trim())
					.Select(GetToken)
					.ToArray();

				return new __PNString(
					_tokenArray);
			}

			private static PersonNameTokenType GetToken(
				string tokenStr)
			{
				switch (tokenStr)
				{
					case ",":
						return PersonNameTokenType.Comma;

					case "Hp":
						return PersonNameTokenType.HonorificPrefixFull;
					case "HP.":
						return PersonNameTokenType.HonorificPrefixAbbreviationWithPeriod;
					case "HP":
						return PersonNameTokenType.HonorificPrefixAbbreviationWithoutPeriod;

					case "Fn":
						return PersonNameTokenType.FirstNameFull;
					case "F.":
						return PersonNameTokenType.FirstNameInitialWithPeriod;
					case "FN":
						return PersonNameTokenType.FirstNameInitialWithoutPeriod;

					case "Mn":
						return PersonNameTokenType.MiddleNameFull;
					case "M.":
						return PersonNameTokenType.MiddleNameInitialWithPeriod;
					case "MN":
						return PersonNameTokenType.MiddleNameInitialWithoutPeriod;

					case "Ln":
						return PersonNameTokenType.LastNameFull;
					case "L.":
						return PersonNameTokenType.LastNameInitialWithPeriod;
					case "LN":
						return PersonNameTokenType.LastNameInitialWithoutPeriod;

					case "Ps":
						return PersonNameTokenType.PostNominalSuffixFull;
					case "P.":
						return PersonNameTokenType.PostNominalSuffixAbbreviationWithPeriod;
					case "PS":
						return PersonNameTokenType.PostNominalSuffixAbbreviationWithoutPeriod;

					default:
						return PersonNameTokenType.Invalid;
				}
			}
		}
		protected internal enum PersonNameTokenType
		{
			Invalid = -1,
			Unknown = 0,

			HonorificPrefixFull = 1,
			HonorificPrefixAbbreviationWithPeriod = 2,
			HonorificPrefixAbbreviationWithoutPeriod = 3,

			FirstNameFull = 4,
			FirstNameInitialWithPeriod = 5,
			FirstNameInitialWithoutPeriod = 6,

			MiddleNameFull = 7,
			MiddleNameInitialWithPeriod = 8,
			MiddleNameInitialWithoutPeriod = 9,

			LastNameFull = 10,
			LastNameInitialWithPeriod = 11,
			LastNameInitialWithoutPeriod = 12,

			PostNominalSuffixFull = 13,
			PostNominalSuffixAbbreviationWithPeriod = 14,
			PostNominalSuffixAbbreviationWithoutPeriod = 15,

			Comma = 50


		}
	}
}
