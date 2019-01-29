using System;
using System.Collections.Generic;
using System.Windows;
using Ccr.Core.Extensions;

namespace Ccr.PresentationCore.Helpers
{
	public class ResourceProvider
	{
		private ResourceDictionary _resourceDictionary;

		private readonly SortedDictionary<object, object> _cache
			= new SortedDictionary<object, object>();

		public ResourceProvider(string packUri)
		{
			SetPackUri(packUri);
		}
		public ResourceProvider(Uri packUri)
		{
			_resourceDictionary = new ResourceDictionary
			{
				Source = packUri
			};
		}

		public void SetPackUri(string packUri)
		{
			_resourceDictionary = new ResourceDictionary
			{
				Source = new Uri(packUri, UriKind.RelativeOrAbsolute)
			};
		}


		public object Get(object key)
		{
			if (_cache.TryGetValue(key, out var _cachedValue))
				return _cachedValue;

			if (!_resourceDictionary.Contains(key))
				throw new KeyNotFoundException();

			var value = _resourceDictionary[key];

			if (!_cache.ContainsKey(key))
			{
				_cache.Add(key, value);
			}

			return value;
		}

		public TValue Get<TValue>(object key)
		{
			var value = Get(key);

			if (!(value is TValue))
				throw new InvalidCastException();

			return value.As<TValue>();
		}
	}
}