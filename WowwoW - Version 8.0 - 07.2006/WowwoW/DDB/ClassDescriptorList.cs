/*
 * Created by SharpDevelop.
 * User: Hervé
 * Date: 21/10/2005
 * Time: 11:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;

namespace DDB
{
	public class ClassDescriptorList : IDictionary, ICollection, IEnumerable, ICloneable
	{
		protected Hashtable innerHash;
		
		#region "Constructors"
		public  ClassDescriptorList()
		{
			innerHash = new Hashtable();
		}
		
		public ClassDescriptorList(ClassDescriptorList original)
		{
			innerHash = new Hashtable(original.innerHash);
		}
		
		public ClassDescriptorList(IDictionary dictionary)
		{
			innerHash = new Hashtable(dictionary);
		}
		
		public ClassDescriptorList(int capacity)
		{
			innerHash = new Hashtable(capacity);
		}
		
		public ClassDescriptorList(IDictionary dictionary, float loadFactor)
		{
			innerHash = new Hashtable(dictionary, loadFactor);
		}
		
		public ClassDescriptorList(IHashCodeProvider codeProvider, IComparer comparer)
		{
			innerHash = new Hashtable(codeProvider, comparer);
		}
		
		public ClassDescriptorList(int capacity, int loadFactor)
		{
			innerHash = new Hashtable(capacity, loadFactor);
		}
		
		public ClassDescriptorList(IDictionary dictionary, IHashCodeProvider codeProvider, IComparer comparer)
		{
			innerHash = new Hashtable(dictionary, codeProvider, comparer);
		}
		
		public ClassDescriptorList(int capacity, IHashCodeProvider codeProvider, IComparer comparer)
		{
			innerHash = new Hashtable(capacity, codeProvider, comparer);
		}
		
		public ClassDescriptorList(IDictionary dictionary, float loadFactor, IHashCodeProvider codeProvider, IComparer comparer)
		{
			innerHash = new Hashtable(dictionary, loadFactor, codeProvider, comparer);
		}
		
		public ClassDescriptorList(int capacity, float loadFactor, IHashCodeProvider codeProvider, IComparer comparer)
		{
			innerHash = new Hashtable(capacity, loadFactor, codeProvider, comparer);
		}
		#endregion

		#region Implementation of IDictionary
		public ClassDescriptorListEnumerator GetEnumerator()
		{
			return new ClassDescriptorListEnumerator(this);
		}
		
		System.Collections.IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new ClassDescriptorListEnumerator(this);
		}
		
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		
		public void Remove(UInt64 key)
		{
			innerHash.Remove(key);
		}
		
		void IDictionary.Remove(object key)
		{
			Remove ((UInt64)key);
		}
		
		public bool Contains(UInt64 key)
		{
			return innerHash.Contains(key);
		}
		
		bool IDictionary.Contains(object key)
		{
			return Contains((UInt64)key);
		}
		
		public void Clear()
		{
			innerHash.Clear();		
		}
		
		public void Add(UInt64 key, ClassDescriptor value)
		{
			innerHash.Add(key, value);
		}
		
		void IDictionary.Add(object key, object value)
		{
			Add ((UInt64)key, (ClassDescriptor)value);
		}
		
		public bool IsReadOnly 
		{
			get 
			{
				return innerHash.IsReadOnly;
			}
		}
		
		public ClassDescriptor this[UInt64 key] 
		{
			get 
			{
				return (ClassDescriptor) innerHash[key];
			}
			set 
			{
				innerHash[key] = value;
			}
		}
		
		object IDictionary.this[object key] 
		{
			get 
			{
				return this[(UInt64)key];
			}
			set 
			{
				this[(UInt64)key] = (ClassDescriptor)value;
			}
		}
		
		public System.Collections.ICollection Values 
		{
			get 
			{
				return innerHash.Values;
			}
		}
		
		public System.Collections.ICollection Keys 
		{
			get 
			{
				return innerHash.Keys;
			}
		}
		
		public bool IsFixedSize 
		{
			get 
			{
				return innerHash.IsFixedSize;
			}
		}
		#endregion
		
		#region Implementation of ICollection
		public void CopyTo(System.Array array, int index)
		{
			innerHash.CopyTo (array, index);
		}
		
		public bool IsSynchronized 
		{
			get 
			{
				return innerHash.IsSynchronized;
			}
		}
		
		public int Count 
		{
			get 
			{
				return innerHash.Count;
			}
		}
		
		public object SyncRoot 
		{
			get 
			{
				return innerHash.SyncRoot;
			}
		}
		#endregion
		
		#region Implementation of ICloneable
		public ClassDescriptorList Clone()
		{
			ClassDescriptorList clone = new ClassDescriptorList();
			clone.innerHash = (Hashtable) innerHash.Clone();
			return clone;
		}
		
		object ICloneable.Clone()
		{
			return Clone();
		}
		#endregion
		
		#region "HashTable Methods"
		public bool ContainsKey(UInt64 key)
		{
			return innerHash.ContainsKey(key);
		}
		
		public bool ContainsValue(ClassDescriptor value)
		{
			return innerHash.ContainsValue(value);
		}
		
		public static ClassDescriptorList Synchronized(ClassDescriptorList nonSync)
		{
			ClassDescriptorList sync = new ClassDescriptorList();
			sync.innerHash = Hashtable.Synchronized(nonSync.innerHash);
			return sync;
		}
		#endregion

		internal Hashtable InnerHash 
		{
			get 
			{
				return innerHash;
			}
		}
	}
	
	public class ClassDescriptorListEnumerator : IDictionaryEnumerator
	{
		private IDictionaryEnumerator innerEnumerator;
		
		internal ClassDescriptorListEnumerator(ClassDescriptorList enumerable)
		{
			innerEnumerator = enumerable.InnerHash.GetEnumerator();
		}
		
		#region Implementation of IDictionaryEnumerator
		public UInt64 Key 
		{
			get 
			{
				return (UInt64)innerEnumerator.Key;
			}
		}
		
		object IDictionaryEnumerator.Key 
		{
			get 
			{
				return Key;
			}
		}
		
		public ClassDescriptor Value 
		{
			get 
			{
				return (ClassDescriptor)innerEnumerator.Value;
			}
		}
		
		object IDictionaryEnumerator.Value 
		{
			get 
			{
				return Value;
			}
		}
		
		public System.Collections.DictionaryEntry Entry 
		{
			get 
			{
				return innerEnumerator.Entry;
			}
		}
		#endregion
		
		#region Implementation of IEnumerator
		public void Reset()
		{
			innerEnumerator.Reset();
		}
		
		public bool MoveNext()
		{
			return innerEnumerator.MoveNext();
		}
		
		public object Current 
		{
			get 
			{
				return innerEnumerator.Current;
			}
		}
		#endregion
	}
}