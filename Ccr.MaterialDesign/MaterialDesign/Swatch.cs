using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ccr.Core.Extensions;
using Ccr.MaterialDesign.Primitives.Behaviors.Services;
using Ccr.Xaml.Collections;

// ReSharper disable ArrangeAccessorOwnerBody
namespace Ccr.MaterialDesign
{
	public class Swatch
		: HostedElement<Palette>,
		  IList,
		  IList<MaterialBrush>
	{
		private readonly ReactiveCollection<MaterialBrush> _primaries
			= new ReactiveCollection<MaterialBrush>();

		private readonly ReactiveCollection<MaterialBrush> _accents
			= new ReactiveCollection<MaterialBrush>();


		public MaterialBrush ExemplarHue
		{
			get
			{
				if(_primaries.Count >= 10)
					return _primaries[6];

				return null;
			}
	}
		
		public SwatchClassifier SwatchClassifier { get; set; }

		
		public IReadOnlyCollection<MaterialBrush> Primaries
		{
			get { return _primaries; }
		}

		public IReadOnlyCollection<MaterialBrush> Accents
		{
			get { return _accents; }
		}

		public IReadOnlyCollection<MaterialBrush> Materials
		{
			get { return _primaries.Concat(_accents).ToArray(); }
		}



		//protected override Freezable CreateInstanceCore()
		//{
		//	return new Swatch();
		//}
		public IEnumerator<MaterialBrush> GetEnumerator()
		{
			return Materials.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		void ICollection.CopyTo(Array array, int index)
		{
			Materials.ToArray().CopyTo(array, index);
		}

		bool ICollection<MaterialBrush>.Remove(MaterialBrush item)
		{
			throw new NotImplementedException();
		}

		public int Count
		{
			get
			{
				return Materials.ToArray().Length;
			}
		}
		bool ICollection<MaterialBrush>.IsReadOnly
		{
			get { return false; }
		}
		int ICollection.Count
		{
			get { return Count; }
		}
		object ICollection.SyncRoot
		{
			get { return Materials.ToArray().SyncRoot; }
		}
		bool ICollection.IsSynchronized
		{
			get { return true; }
		}
		int IList.Add(object value)
		{
			Add(value.As<MaterialBrush>());
			return Count;
		}

		bool IList.Contains(object value)
		{
			return Contains(value.As<MaterialBrush>());
		}

		public void Add(MaterialBrush item)
		{
			item.AttachHost(this);
			if (item.Identity.IsAccent)
			{
				_accents.Add(item);
			}
			else
			{
				_primaries.Add(item);
			}
		}

		void ICollection<MaterialBrush>.Clear()
		{
			throw new NotImplementedException();
		}

		public bool Contains(MaterialBrush item)
		{
			return Materials.Contains(item);
		}

		public void CopyTo(MaterialBrush[] array, int arrayIndex)
		{
			Materials.ToArray().CopyTo(array, arrayIndex);
		}

		void IList.Clear()
		{
			throw new NotImplementedException();
		}

		int IList.IndexOf(object value)
		{
			return IndexOf(value.As<MaterialBrush>());
		}

		void IList.Insert(int index, object value)
		{
			throw new NotImplementedException();
		}

		void IList.Remove(object value)
		{
			throw new NotImplementedException();
		}

		public int IndexOf(MaterialBrush item)
		{
			return Materials.ToList().IndexOf(item);
		}

		void IList<MaterialBrush>.Insert(int index, MaterialBrush item)
		{
			throw new NotSupportedException();
		}

		void IList<MaterialBrush>.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		public MaterialBrush this[int index]
		{
			get { return Materials.ToList()[index]; }
			set { throw new NotImplementedException(); }
		}

		void IList.RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		object IList.this[int index]
		{
			get { return this[index]; }
			set { throw new NotImplementedException(); }
		}
		bool IList.IsReadOnly
		{
			get { return false; }
		}
		bool IList.IsFixedSize
		{
			get { return false; }
		}
	}
}
