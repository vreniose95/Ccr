using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Ccr.PresentationCore.Helpers;

namespace Ccr.Core.Extensions
{
  public static class NotifyPropertyChangedExtension
	{
		public static void MutateVerbose<TField>(
			this INotifyPropertyChangedEx @this,
			ref TField field,
			TField newValue,
			[CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<TField>.Default.Equals(field, newValue))
				return;

			var tempVal = field;
			field = newValue;

		  @this?.RaisePropertyChanged(
				new PropertyChangedEventArgs<TField>(
					propertyName,
					tempVal,
					field));
		}
	}
}
