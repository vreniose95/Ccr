using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Std.Core.Collections
{
	public class BijectiveIsomorphicMap<TA, TB>
		: IDictionary<TA, TB>, IReadOnlyDictionary<TA, TB>, IDictionary
	{
		private readonly IDictionary<TA, TB> _isomorphicMapAB;
		[NonSerialized]
		private readonly IDictionary<TB, TA> _isomorphicMapBA;
		[NonSerialized]
		private readonly InverseBijectiveIsomorphicMap _inverseIsomorphicMap;


		public BijectiveIsomorphicMap()
			: this(null, null)
		{
		}

		public BijectiveIsomorphicMap(
			IEqualityComparer<TA> aComparer)
				: this(aComparer, null)
		{
		}

		public BijectiveIsomorphicMap(
			IEqualityComparer<TB> bComparer)
				: this(null, bComparer)
		{
		}

		public BijectiveIsomorphicMap(
			[CanBeNull] IEqualityComparer<TA> aComparer,
			[CanBeNull] IEqualityComparer<TB> bComparer)
		{
			_isomorphicMapAB = new Dictionary<TA, TB>(aComparer);
			_isomorphicMapBA = new Dictionary<TB, TA>(bComparer);

			_inverseIsomorphicMap = new InverseBijectiveIsomorphicMap(this);
		}


		public IDictionary<TB, TA> InverseIsometricMap
		{
			get => _inverseIsomorphicMap;
		}

		public int Count
		{
			get => _isomorphicMapAB.Count;
		}

		object ICollection.SyncRoot
		{
			get => ((ICollection)_isomorphicMapAB).SyncRoot;
		}

		bool ICollection.IsSynchronized
		{
			get => ((ICollection)_isomorphicMapAB).IsSynchronized;
		}

		bool IDictionary.IsFixedSize
		{
			get => ((IDictionary)_isomorphicMapAB).IsFixedSize;
		}

		public bool IsReadOnly
		{
			get => _isomorphicMapAB.IsReadOnly
				|| _isomorphicMapBA.IsReadOnly;
		}

    
		public TB this[TA a]
		{
			get => _isomorphicMapAB[a];
			set
			{
				_isomorphicMapAB[a] = value;
				_isomorphicMapBA[value] = a;
			}
		}

		object IDictionary.this[object a]
		{
			get => ((IDictionary)_isomorphicMapAB)[a];
			set
			{
				((IDictionary)_isomorphicMapAB)[a] = value;
				((IDictionary)_isomorphicMapBA)[value] = a;
			}
		}


		public ICollection<TA> Keys
		{
			get => _isomorphicMapAB.Keys;
		}

		ICollection IDictionary.Keys
		{
			get => ((IDictionary)_isomorphicMapAB).Keys;
		}

		IEnumerable<TA> IReadOnlyDictionary<TA, TB>.Keys
		{
			get => ((IReadOnlyDictionary<TA, TB>)_isomorphicMapAB).Keys;
		}


		public ICollection<TB> Values
		{
			get => _isomorphicMapAB.Values;
		}

		ICollection IDictionary.Values
		{
			get => ((IDictionary)_isomorphicMapAB).Values;
		}

		IEnumerable<TB> IReadOnlyDictionary<TA, TB>.Values
		{
			get => ((IReadOnlyDictionary<TA, TB>)_isomorphicMapAB).Values;
		}


		public IEnumerator<KeyValuePair<TA, TB>> GetEnumerator()
		{
			return _isomorphicMapAB.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return ((IDictionary)_isomorphicMapAB).GetEnumerator();
		}


		public void Add(TA a, TB b)
		{
			_isomorphicMapAB.Add(a, b);
			_isomorphicMapBA.Add(b, a);
		}

		void IDictionary.Add(object a, object b)
		{
			((IDictionary)_isomorphicMapAB).Add(a, b);
			((IDictionary)_isomorphicMapBA).Add(b, a);
		}

		void ICollection<KeyValuePair<TA, TB>>.Add(
			KeyValuePair<TA, TB> item)
		{
			BijectiveIsomorphicMorphism<TA, TB> morphism = item;

			_isomorphicMapAB.Add(item);
			_isomorphicMapBA.Add(morphism.InverseMorphism);
		}

		public bool ContainsKey(TA a)
		{
			return _isomorphicMapAB.ContainsKey(a);
		}

		bool ICollection<KeyValuePair<TA, TB>>.Contains(
			KeyValuePair<TA, TB> item)
		{
			return _isomorphicMapAB.Contains(item);
		}

		public bool TryGetValue(TA a, out TB b)
		{
			return _isomorphicMapAB.TryGetValue(a, out b);
		}
		
		public bool Remove(TA a)
		{
			if (!_isomorphicMapAB.TryGetValue(a, out var b))
				return false;

			_isomorphicMapAB.Remove(a);
			_isomorphicMapBA.Remove(b);

			return true;
		}

		void IDictionary.Remove(object a)
		{
			var iDictionaryAB = (IDictionary)_isomorphicMapAB;

			if (!iDictionaryAB.Contains(a))
				return;

			var b = iDictionaryAB[a];

			iDictionaryAB.Remove(a);
			((IDictionary)_isomorphicMapBA).Remove(b);
		}

		bool ICollection<KeyValuePair<TA, TB>>.Remove(
			KeyValuePair<TA, TB> item)
		{
			return _isomorphicMapAB.Remove(item);
		}
		
		bool IDictionary.Contains(object key)
		{
			return ((IDictionary)_isomorphicMapAB).Contains(key);
		}

		public void Clear()
		{
			_isomorphicMapAB.Clear();
			_isomorphicMapBA.Clear();
		}
    
		void ICollection<KeyValuePair<TA, TB>>.CopyTo(
			KeyValuePair<TA, TB>[] array,
			int arrayIndex)
		{
			_isomorphicMapAB.CopyTo(array, arrayIndex);
		}

		void ICollection.CopyTo(
			Array array,
			int index)
		{
			((IDictionary)_isomorphicMapAB).CopyTo(array, index);
		}

		[OnDeserialized]
		internal void OnDeserialized(
			StreamingContext context)
		{
			_isomorphicMapBA.Clear();

			foreach (BijectiveIsomorphicMorphism<TA, TB> item in _isomorphicMapAB)
				_isomorphicMapBA.Add(item.InverseMorphism);
		}


		private class InverseBijectiveIsomorphicMap
			: IDictionary<TB, TA>,
				IReadOnlyDictionary<TB, TA>,
				IDictionary
		{
			private readonly BijectiveIsomorphicMap<TA, TB> _owner;


			public InverseBijectiveIsomorphicMap(
				[NotNull] BijectiveIsomorphicMap<TA, TB> owner)
			{
				owner.IsNotNull(nameof(owner));
				_owner = owner;
			}


			public int Count
			{
				get => _owner._isomorphicMapBA.Count;
			}

			object ICollection.SyncRoot
			{
				get => ((ICollection)_owner._isomorphicMapBA).SyncRoot;
			}

			bool ICollection.IsSynchronized
			{
				get => ((ICollection)_owner._isomorphicMapBA).IsSynchronized;
			}

			bool IDictionary.IsFixedSize
			{
				get => ((IDictionary)_owner._isomorphicMapBA).IsFixedSize;
			}

			public bool IsReadOnly
			{
				get => _owner._isomorphicMapAB.IsReadOnly 
					|| _owner._isomorphicMapBA.IsReadOnly;
			}

			public TA this[TB b]
			{
				get => _owner._isomorphicMapBA[b];
				set
				{
					_owner._isomorphicMapBA[b] = value;
					_owner._isomorphicMapAB[value] = b;
				}
			}

			object IDictionary.this[object b]
			{
				get => ((IDictionary)_owner._isomorphicMapBA)[b];
				set
				{
					((IDictionary)_owner._isomorphicMapBA)[b] = value;
					((IDictionary)_owner._isomorphicMapAB)[value] = b;
				}
			}

			public ICollection<TB> Keys
			{
				get => _owner._isomorphicMapBA.Keys;
			}

			ICollection IDictionary.Keys
			{
				get => ((IDictionary)_owner._isomorphicMapBA).Keys;
			}

			IEnumerable<TB> IReadOnlyDictionary<TB, TA>.Keys
			{
				get => ((IReadOnlyDictionary<TB, TA>)_owner._isomorphicMapBA).Keys;
			}

			public ICollection<TA> Values
			{
				get => _owner._isomorphicMapBA.Values;
			}

			ICollection IDictionary.Values
			{
				get => ((IDictionary)_owner._isomorphicMapBA).Values;
			}

			IEnumerable<TA> IReadOnlyDictionary<TB, TA>.Values
			{
				get => ((IReadOnlyDictionary<TB, TA>)_owner._isomorphicMapBA).Values;
			}

			public IEnumerator<KeyValuePair<TB, TA>> GetEnumerator()
			{
				return _owner._isomorphicMapBA.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			IDictionaryEnumerator IDictionary.GetEnumerator()
			{
				return ((IDictionary)_owner._isomorphicMapBA).GetEnumerator();
			}

			public void Add(TB b, TA a)
			{
				_owner._isomorphicMapBA.Add(b, a);
				_owner._isomorphicMapAB.Add(a, b);
			}

			void IDictionary.Add(object b, object a)
			{
				((IDictionary)_owner._isomorphicMapBA).Add(b, a);
				((IDictionary)_owner._isomorphicMapAB).Add(a, b);
			}

			void ICollection<KeyValuePair<TB, TA>>.Add(
				KeyValuePair<TB, TA> item)
			{
				BijectiveIsomorphicMorphism<TB, TA> morphism = item;

				_owner._isomorphicMapBA.Add(morphism);
				_owner._isomorphicMapAB.Add(morphism.InverseMorphism);
			}

			public bool ContainsKey(TB b)
			{
				return _owner._isomorphicMapBA.ContainsKey(b);
			}

			bool ICollection<KeyValuePair<TB, TA>>.Contains(
				KeyValuePair<TB, TA> item)
			{
				return _owner._isomorphicMapBA.Contains(item);
			}

			public bool TryGetValue(TB b, out TA a)
			{
				return _owner._isomorphicMapBA.TryGetValue(b, out a);
			}

			public bool Remove(TB b)
			{
				if (!_owner._isomorphicMapBA.TryGetValue(b, out var a))
					return false;

				_owner._isomorphicMapBA.Remove(b);
				_owner._isomorphicMapAB.Remove(a);
				return true;
			}

			void IDictionary.Remove(object b)
			{
				var iDictionaryBA = (IDictionary)_owner._isomorphicMapBA;

				if (!iDictionaryBA.Contains(b))
					return;
        
				var a = iDictionaryBA[b];

				iDictionaryBA.Remove(b);
				((IDictionary)_owner._isomorphicMapAB).Remove(a);
			}

			bool ICollection<KeyValuePair<TB, TA>>.Remove(
				KeyValuePair<TB, TA> item)
			{
				return _owner._isomorphicMapBA.Remove(item);
			}

			bool IDictionary.Contains(object key)
			{
				return ((IDictionary)_owner._isomorphicMapBA).Contains(key);
			}

			public void Clear()
			{
				_owner._isomorphicMapBA.Clear();
				_owner._isomorphicMapAB.Clear();
			}

			void ICollection<KeyValuePair<TB, TA>>.CopyTo(
				KeyValuePair<TB, TA>[] array, 
				int arrayIndex)
			{
				_owner._isomorphicMapBA.CopyTo(array, arrayIndex);
			}

			void ICollection.CopyTo(Array array, int index)
			{
				((IDictionary)_owner._isomorphicMapBA).CopyTo(array, index);
			}
		}
	}
}