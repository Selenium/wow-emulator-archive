/*
 * Created by SharpDevelop.
 * User: DrNexus
 * Date: 29/09/2005
 * Time: 19:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;

namespace Server
{
	public class GameObjectsList : IDictionary, ICollection, IEnumerable, ICloneable
	{
		protected Hashtable innerHash;
		
		#region "Constructors"
		public  GameObjectsList()
		{
			innerHash = new Hashtable();
		}
		
		public GameObjectsList(GameObjectsList original)
		{
			innerHash = new Hashtable(original.innerHash);
		}
		
		public GameObjectsList(IDictionary dictionary)
		{
			innerHash = new Hashtable(dictionary);
		}
		
		public GameObjectsList(int capacity)
		{
			innerHash = new Hashtable(capacity);
		}
		
		public GameObjectsList(IDictionary dictionary, float loadFactor)
		{
			innerHash = new Hashtable(dictionary, loadFactor);
		}
		
		public GameObjectsList(IHashCodeProvider codeProvider, IComparer comparer)
		{
			innerHash = new Hashtable(codeProvider, comparer);
		}
		
		public GameObjectsList(int capacity, int loadFactor)
		{
			innerHash = new Hashtable(capacity, loadFactor);
		}
		
		public GameObjectsList(IDictionary dictionary, IHashCodeProvider codeProvider, IComparer comparer)
		{
			innerHash = new Hashtable(dictionary, codeProvider, comparer);
		}
		
		public GameObjectsList(int capacity, IHashCodeProvider codeProvider, IComparer comparer)
		{
			innerHash = new Hashtable(capacity, codeProvider, comparer);
		}
		
		public GameObjectsList(IDictionary dictionary, float loadFactor, IHashCodeProvider codeProvider, IComparer comparer)
		{
			innerHash = new Hashtable(dictionary, loadFactor, codeProvider, comparer);
		}
		
		public GameObjectsList(int capacity, float loadFactor, IHashCodeProvider codeProvider, IComparer comparer)
		{
			innerHash = new Hashtable(capacity, loadFactor, codeProvider, comparer);
		}
		#endregion

		#region Implementation of IDictionary

		public bool Exist( int id )
		{
			if ( innerHash[ id ] == null )
				return false;
			return true;
		}

		public GameObjectsListEnumerator GetEnumerator()
		{
			return new GameObjectsListEnumerator(this);
		}
		
		System.Collections.IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new GameObjectsListEnumerator(this);
		}
		
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		
		public void Remove(int key)
		{
			innerHash.Remove(key);
		}
		
		void IDictionary.Remove(object key)
		{
			Remove ((int)key);
		}
		
		public bool Contains(int key)
		{
			return innerHash.Contains(key);
		}
		
		bool IDictionary.Contains(object key)
		{
			return Contains((int)key);
		}
		
		public void Clear()
		{
			innerHash.Clear();		
		}
		
		public void Add(int key, Type value)
		{
			innerHash.Add(key, value);
		}
		
		void IDictionary.Add(object key, object value)
		{
			Add ((int)key, (Type)value);
		}
		
		public bool IsReadOnly 
		{
			get 
			{
				return innerHash.IsReadOnly;
			}
		}
		
		public Type this[int key] 
		{
			get 
			{
				return (Type) innerHash[key];
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
				return this[(int)key];
			}
			set 
			{
				this[(int)key] = (Type)value;
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
		public GameObjectsList Clone()
		{
			GameObjectsList clone = new GameObjectsList();
			clone.innerHash = (Hashtable) innerHash.Clone();
			return clone;
		}
		
		object ICloneable.Clone()
		{
			return Clone();
		}
		#endregion
		
		#region "HashTable Methods"
		public bool ContainsKey(int key)
		{
			return innerHash.ContainsKey(key);
		}
		
		public bool ContainsValue(Type value)
		{
			return innerHash.ContainsValue(value);
		}
		
		public static GameObjectsList Synchronized(GameObjectsList nonSync)
		{
			GameObjectsList sync = new GameObjectsList();
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
	
	public class GameObjectsListEnumerator : IDictionaryEnumerator
	{
		private IDictionaryEnumerator innerEnumerator;
		
		internal GameObjectsListEnumerator(GameObjectsList enumerable)
		{
			innerEnumerator = enumerable.InnerHash.GetEnumerator();
		}
		
		#region Implementation of IDictionaryEnumerator
		public int Key 
		{
			get 
			{
				return (int)innerEnumerator.Key;
			}
		}
		
		object IDictionaryEnumerator.Key 
		{
			get 
			{
				return Key;
			}
		}
		
		public Type Value 
		{
			get 
			{
				return (Type)innerEnumerator.Value;
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