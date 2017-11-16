using System;
using System.Collections;

namespace Server
{
	public class Skills : IDictionary, ICollection, IEnumerable, ICloneable
	{
		protected Hashtable innerHash;
		
		#region "Constructors"
		public  Skills()
		{
			innerHash = new Hashtable();
		}
		
		public Skills(Skills original)
		{
			innerHash = new Hashtable(original.innerHash);
		}
		
		public Skills(IDictionary dictionary)
		{
			innerHash = new Hashtable(dictionary);
		}
		
		public Skills(int capacity)
		{
			innerHash = new Hashtable(capacity);
		}
		
		public Skills(IDictionary dictionary, float loadFactor)
		{
			innerHash = new Hashtable(dictionary, loadFactor);
		}
		
		public Skills(IHashCodeProvider codeProvider, IComparer comparer)
		{
			innerHash = new Hashtable(codeProvider, comparer);
		}
		
		public Skills(int capacity, int loadFactor)
		{
			innerHash = new Hashtable(capacity, loadFactor);
		}
		
		public Skills(IDictionary dictionary, IHashCodeProvider codeProvider, IComparer comparer)
		{
			innerHash = new Hashtable(dictionary, codeProvider, comparer);
		}
		
		public Skills(int capacity, IHashCodeProvider codeProvider, IComparer comparer)
		{
			innerHash = new Hashtable(capacity, codeProvider, comparer);
		}
		
		public Skills(IDictionary dictionary, float loadFactor, IHashCodeProvider codeProvider, IComparer comparer)
		{
			innerHash = new Hashtable(dictionary, loadFactor, codeProvider, comparer);
		}
		
		public Skills(int capacity, float loadFactor, IHashCodeProvider codeProvider, IComparer comparer)
		{
			innerHash = new Hashtable(capacity, loadFactor, codeProvider, comparer);
		}
		#endregion

		#region Implementation of IDictionary
		public SkillsEnumerator GetEnumerator()
		{
			return new SkillsEnumerator(this);
		}
		
		System.Collections.IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new SkillsEnumerator(this);
		}
		
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		
		public void Remove(ushort key)
		{
			innerHash.Remove(key);
		}
		
		void IDictionary.Remove(object key)
		{
			Remove ((ushort)key);
		}
		
		public bool Contains(ushort key)
		{
			return innerHash.Contains(key);
		}
		
		bool IDictionary.Contains(object key)
		{
			return Contains((ushort)key);
		}
		
		public void Clear()
		{
			innerHash.Clear();		
		}
		
		public void Add(ushort key, Skill value)
		{
			innerHash.Add(key, value);
		}
		
		void IDictionary.Add(object key, object value)
		{
			Add ((ushort)key, (Skill)value);
		}
		
		public bool IsReadOnly 
		{
			get 
			{
				return innerHash.IsReadOnly;
			}
		}
		
		public Skill this[ushort key] 
		{
			get 
			{
				return (Skill) innerHash[key];
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
				return this[(ushort)key];
			}
			set 
			{
				this[(ushort)key] = (Skill)value;
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
		public Skills Clone()
		{
			Skills clone = new Skills();
			clone.innerHash = (Hashtable) innerHash.Clone();
			return clone;
		}
		
		object ICloneable.Clone()
		{
			return Clone();
		}
		#endregion
		
		#region "HashTable Methods"

		public void Add( Skill s )
		{
			this[ s.Id ] = s;
		}

		public bool ContainsKey(ushort key)
		{
			return innerHash.ContainsKey(key);
		}
		
		public bool ContainsValue(Skill value)
		{
			return innerHash.ContainsValue(value);
		}
		
		public static Skills Synchronized(Skills nonSync)
		{
			Skills sync = new Skills();
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
	
	public class SkillsEnumerator : IDictionaryEnumerator
	{
		private IDictionaryEnumerator innerEnumerator;
		
		internal SkillsEnumerator(Skills enumerable)
		{
			innerEnumerator = enumerable.InnerHash.GetEnumerator();
		}
		
		#region Implementation of IDictionaryEnumerator
		public ushort Key 
		{
			get 
			{
				return (ushort)innerEnumerator.Key;
			}
		}
		
		object IDictionaryEnumerator.Key 
		{
			get 
			{
				return Key;
			}
		}
		
		public Skill Value 
		{
			get 
			{
				return (Skill)innerEnumerator.Value;
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