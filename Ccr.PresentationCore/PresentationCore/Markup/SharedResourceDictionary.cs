using System;
using System.Collections.Generic;
using System.Windows;

namespace Ccr.PresentationCore.Markup
{
	public class SharedResourceDictionary
		: ResourceDictionary
	{
		private Uri _sourceUri;

		private static readonly Dictionary<Uri, ResourceDictionary> _cachedDictionaries
			= new Dictionary<Uri, ResourceDictionary>();


		public new Uri Source
		{
			get => _sourceUri;
			set
			{
				_sourceUri = value;

				if (!_cachedDictionaries.TryGetValue(value, out var _existingDictionary))
				{
					base.Source = value;
					_cachedDictionaries.Add(value, this);
				}
				else
				{
					MergedDictionaries.Add(_existingDictionary);
				}
			}
		}
	}
}
