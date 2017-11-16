/*
 * Created by SharpDevelop.
 * User: DrNexus
 * Date: 12/10/2005
 * Time: 19:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.Reflection;

namespace HelperTools
{
	public class AssemblyList : IDictionary, ICollection, IEnumerable, ICloneable
	{
		protected Hashtable innerHash;
		
		#region "Constructors"
		public  AssemblyList()
		{
			innerHash = new Hashtable();
		}
		
		public AssemblyList(AssemblyList original)
		{
			innerHash = new Hashtable(original.innerHash);
		}
		
		public AssemblyList(IDictionary dictionary)
		{
			innerHash = new Hashtable(dictionary);
		}
		
		public AssemblyList(int capacity)
		{
			innerHash = new Hashtable(capacity);
		}
		
		public AssemblyList(IDictionary dictionary, float loadFactor)
		{
			innerHash = new Hashtable(dictionary, loadFactor);
		}
		
		public AssemblyList(IHashCodeProvider codeProvider, IComparer comparer)
		{
			innerHash = new Hashtable(codeProvider, comparer);
		}
		
		public AssemblyList(int capacity, int loadFactor)
		{
			innerHash = new Hashtable(capacity, loadFactor);
		}
		
		public AssemblyList(IDictionary dictionary, IHashCodeProvider codeProvider, IComparer comparer)
		{
			innerHash = new Hashtable(dictionary, codeProvider, comparer);
		}
		
		public AssemblyList(int capacity, IHashCodeProvider codeProvider, IComparer comparer)
		{
			innerHash = new Hashtable(capacity, codeProvider, comparer);
		}
		
		public AssemblyList(IDictionary dictionary, float loadFactor, IHashCodeProvider codeProvider, IComparer comparer)
		{
			innerHash = new Hashtable(dictionary, loadFactor, codeProvider, comparer);
		}
		
		public AssemblyList(int capacity, float loadFactor, IHashCodeProvider codeProvider, IComparer comparer)
		{
			innerHash = new Hashtable(capacity, loadFactor, codeProvider, comparer);
		}
		#endregion

		#region Implementation of IDictionary
		public AssemblyListEnumerator GetEnumerator()
		{
			return new AssemblyListEnumerator(this);
		}
		
		System.Collections.IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new AssemblyListEnumerator(this);
		}
		
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		
		public void Remove(string key)
		{
			innerHash.Remove(key);
		}
		
		void IDictionary.Remove(object key)
		{
			Remove ((string)key);
		}
		
		public bool Contains(string key)
		{
			return innerHash.Contains(key);
		}
		
		bool IDictionary.Contains(object key)
		{
			return Contains((string)key);
		}
		
		public void Clear()
		{
			innerHash.Clear();		
		}
		
		public void Add(string key, Assembly value)
		{
			innerHash.Add(key, value);
		}
		
		void IDictionary.Add(object key, object value)
		{
			Add ((string)key, (Assembly)value);
		}
		
		public bool IsReadOnly 
		{
			get 
			{
				return innerHash.IsReadOnly;
			}
		}
		
		public Assembly this[string key] 
		{
			get 
			{
				return (Assembly) innerHash[key];
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
				return this[(string)key];
			}
			set 
			{
				this[(string)key] = (Assembly)value;
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
		public AssemblyList Clone()
		{
			AssemblyList clone = new AssemblyList();
			clone.innerHash = (Hashtable) innerHash.Clone();
			return clone;
		}
		
		object ICloneable.Clone()
		{
			return Clone();
		}
		#endregion
		
		#region "HashTable Methods"
		public bool ContainsKey(string key)
		{
			return innerHash.ContainsKey(key);
		}
		
		public bool ContainsValue(Assembly value)
		{
			return innerHash.ContainsValue(value);
		}
		
		public static AssemblyList Synchronized(AssemblyList nonSync)
		{
			AssemblyList sync = new AssemblyList();
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
	
	public class AssemblyListEnumerator : IDictionaryEnumerator
	{
		private IDictionaryEnumerator innerEnumerator;
		
		internal AssemblyListEnumerator(AssemblyList enumerable)
		{
			innerEnumerator = enumerable.InnerHash.GetEnumerator();
		}
		
		#region Implementation of IDictionaryEnumerator
		public string Key 
		{
			get 
			{
				return (string)innerEnumerator.Key;
			}
		}
		
		object IDictionaryEnumerator.Key 
		{
			get 
			{
				return Key;
			}
		}
		
		public Assembly Value 
		{
			get 
			{
				return (Assembly)innerEnumerator.Value;
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