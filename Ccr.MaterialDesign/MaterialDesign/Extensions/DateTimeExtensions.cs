using System;
using System.Globalization;
using System.Linq;

namespace Ccr.MaterialDesign.Extensions
{
	public static class DateTimeExtensions
	{
		//from the material design toolkit by butchersboy
		internal static DateTimeFormatInfo GetDateFormat(
			this CultureInfo culture)
		{
			if (culture == null) 
				throw new ArgumentNullException(nameof(culture));

			if (culture.Calendar is GregorianCalendar)
			{
				return culture.DateTimeFormat;
			}

			GregorianCalendar foundCal = null;
			DateTimeFormatInfo dtfi = null;

			foreach (var cal in culture.OptionalCalendars.OfType<GregorianCalendar>())
			{
				// Return the first Gregorian calendar with CalendarType == Localized 
				// Otherwise return the first Gregorian calendar
				if (foundCal == null)
				{
					foundCal = cal;
				}

				if (cal.CalendarType != GregorianCalendarTypes.Localized) continue;

				foundCal = cal;
				break;
			}


			if (foundCal == null)
			{
				// if there are no GregorianCalendars in the OptionalCalendars list, use the invariant dtfi 
				dtfi = ((CultureInfo)CultureInfo.InvariantCulture.Clone()).DateTimeFormat;
				dtfi.Calendar = new GregorianCalendar();
			}
			else
			{
				dtfi = ((CultureInfo)culture.Clone()).DateTimeFormat;
				dtfi.Calendar = foundCal;
			}

			return dtfi;
		}

		public static string ToTitleCase(this string text, string separator = " ")
		{
			TextInfo textInfo = CultureInfo.CurrentUICulture.TextInfo;

			string lowerText = textInfo.ToLower(text);
			string[] words = lowerText.Split(new[] { separator }, StringSplitOptions.None);

			return String.Join(separator, words.Select(v => textInfo.ToTitleCase(v)));
		}
	}
}
