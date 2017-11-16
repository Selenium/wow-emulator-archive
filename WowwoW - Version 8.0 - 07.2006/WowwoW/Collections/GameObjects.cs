using System;
using System.Collections;
using HelperTools;

namespace Server
{
	/// <summary>
	///   A collection that stores <see cref='GameObject'/> objects.
	/// </summary>
	[Serializable()]
	public class GameObjects : CollectionBase 
	{
		bool dirty = false;
		public bool Dirty
		{
			get { return dirty; }
		}
		#region SERIALISATION
		public GameObjects( GenericReader gr )
		{
			List.Clear();
			if ( !gr.notFound )
				Deserialize( gr );
		}

		public static Hashtable TempSpawner = new Hashtable();
		public virtual void Deserialize( GenericReader gr )
		{
			TempSpawner[ 0 ] = null;
			int version = gr.ReadInt();
			
			while( true )
			{
				int n = gr.ReadInt();
				if ( n == 0 )
					break;
				Add( new GameObject( gr ) );
			}
			gr.Close();
			TempSpawner.Clear();
			TempSpawner = null;
		}
		public virtual void Serialize( GenericWriter gw )
		{
			gw.Write( (int)0 );			
			foreach( GameObject m in this )
			{
				if ( m.SpawnerLink == null )
				{
					gw.Write( 1 );
					m.Serialize( gw );
				}
			}
			gw.Write( 0 );
			gw.Close();
			dirty = false;
		}		
		#endregion
		/// <summary>
		///   Initializes a new instance of <see cref='GameObjects'/>.
		/// </summary>
		public GameObjects()
		{
		}
		
		/// <summary>
		///   Initializes a new instance of <see cref='GameObjects'/> based on another <see cref='GameObjects'/>.
		/// </summary>
		/// <param name='val'>
		///   A <see cref='GameObjects'/> from which the contents are copied
		/// </param>
		public GameObjects(GameObjects val)
		{
			dirty = true;
			this.AddRange(val);
		}
		
		/// <summary>
		///   Initializes a new instance of <see cref='GameObjects'/> containing any array of <see cref='GameObject'/> objects.
		/// </summary>
		/// <param name='val'>
		///       A array of <see cref='GameObject'/> objects with which to intialize the collection
		/// </param>
		public GameObjects(GameObject[] val)
		{
			dirty = true;
			this.AddRange(val);
		}
		
		/// <summary>
		///   Represents the entry at the specified index of the <see cref='GameObject'/>.
		/// </summary>
		/// <param name='index'>The zero-based index of the entry to locate in the collection.</param>
		/// <value>The entry at the specified index of the collection.</value>
		/// <exception cref='ArgumentOutOfRangeException'><paramref name='index'/> is outside the valid range of indexes for the collection.</exception>
		public GameObject this[int index] 
		{
			get 
			{
				return ((GameObject)(List[index]));
			}
			set 
			{
				dirty = true;
				List[index] = value;
			}
		}
		
		/// <summary>
		///   Adds a <see cref='GameObject'/> with the specified value to the 
		///   <see cref='GameObjects'/>.
		/// </summary>
		/// <param name='val'>The <see cref='GameObject'/> to add.</param>
		/// <returns>The index at which the new element was inserted.</returns>
		/// <seealso cref='GameObjects.AddRange'/>
		public int Add(GameObject val)
		{
			dirty = true;
			return List.Add(val);
		}
		
		/// <summary>
		///   Copies the elements of an array to the end of the <see cref='GameObjects'/>.
		/// </summary>
		/// <param name='val'>
		///    An array of type <see cref='GameObject'/> containing the objects to add to the collection.
		/// </param>
		/// <seealso cref='GameObjects.Add'/>
		public void AddRange(GameObject[] val)
		{
			dirty = true;
			for (int i = 0; i < val.Length; i++) 
			{
				this.Add(val[i]);
			}
		}
		
		/// <summary>
		///   Adds the contents of another <see cref='GameObjects'/> to the end of the collection.
		/// </summary>
		/// <param name='val'>
		///    A <see cref='GameObjects'/> containing the objects to add to the collection.
		/// </param>
		/// <seealso cref='GameObjects.Add'/>
		public void AddRange(GameObjects val)
		{
			dirty = true;
			for (int i = 0; i < val.Count; i++)
			{
				this.Add(val[i]);
			}
		}
		
		/// <summary>
		///   Gets a value indicating whether the 
		///    <see cref='GameObjects'/> contains the specified <see cref='GameObject'/>.
		/// </summary>
		/// <param name='val'>The <see cref='GameObject'/> to locate.</param>
		/// <returns>
		/// <see langword='true'/> if the <see cref='GameObject'/> is contained in the collection; 
		///   otherwise, <see langword='false'/>.
		/// </returns>
		/// <seealso cref='GameObjects.IndexOf'/>
		public bool Contains(GameObject val)
		{
			return List.Contains(val);
		}
		
		/// <summary>
		///   Copies the <see cref='GameObjects'/> values to a one-dimensional <see cref='Array'/> instance at the 
		///    specified index.
		/// </summary>
		/// <param name='array'>The one-dimensional <see cref='Array'/> that is the destination of the values copied from <see cref='GameObjects'/>.</param>
		/// <param name='index'>The index in <paramref name='array'/> where copying begins.</param>
		/// <exception cref='ArgumentException'>
		///   <para><paramref name='array'/> is multidimensional.</para>
		///   <para>-or-</para>
		///   <para>The number of elements in the <see cref='GameObjects'/> is greater than
		///         the available space between <paramref name='arrayIndex'/> and the end of
		///         <paramref name='array'/>.</para>
		/// </exception>
		/// <exception cref='ArgumentNullException'><paramref name='array'/> is <see langword='null'/>. </exception>
		/// <exception cref='ArgumentOutOfRangeException'><paramref name='arrayIndex'/> is less than <paramref name='array'/>'s lowbound. </exception>
		/// <seealso cref='Array'/>
		public void CopyTo(GameObject[] array, int index)
		{
			dirty = true;
			List.CopyTo(array, index);
		}
		
		/// <summary>
		///    Returns the index of a <see cref='GameObject'/> in 
		///       the <see cref='GameObjects'/>.
		/// </summary>
		/// <param name='val'>The <see cref='GameObject'/> to locate.</param>
		/// <returns>
		///   The index of the <see cref='GameObject'/> of <paramref name='val'/> in the 
		///   <see cref='GameObjects'/>, if found; otherwise, -1.
		/// </returns>
		/// <seealso cref='GameObjects.Contains'/>
		public int IndexOf(GameObject val)
		{
			return List.IndexOf(val);
		}
		
		/// <summary>
		///   Inserts a <see cref='GameObject'/> into the <see cref='GameObjects'/> at the specified index.
		/// </summary>
		/// <param name='index'>The zero-based index where <paramref name='val'/> should be inserted.</param>
		/// <param name='val'>The <see cref='GameObject'/> to insert.</param>
		/// <seealso cref='GameObjects.Add'/>
		public void Insert(int index, GameObject val)
		{
			dirty = true;
			List.Insert(index, val);
		}
		
		/// <summary>
		///  Returns an enumerator that can iterate through the <see cref='GameObjects'/>.
		/// </summary>
		/// <seealso cref='IEnumerator'/>
		public new GameObjectEnumerator GetEnumerator()
		{
			return new GameObjectEnumerator(this);
		}
		
		/// <summary>
		///   Removes a specific <see cref='GameObject'/> from the <see cref='GameObjects'/>.
		/// </summary>
		/// <param name='val'>The <see cref='GameObject'/> to remove from the <see cref='GameObjects'/>.</param>
		/// <exception cref='ArgumentException'><paramref name='val'/> is not found in the Collection.</exception>
		public void Remove(GameObject val)
		{
			dirty = true;
			List.Remove(val);
		}
		
		/// <summary>
		///   Enumerator that can iterate through a GameObjects.
		/// </summary>
		/// <seealso cref='IEnumerator'/>
		/// <seealso cref='GameObjects'/>
		/// <seealso cref='GameObject'/>
		public class GameObjectEnumerator : IEnumerator
		{
			IEnumerator baseEnumerator;
			IEnumerable temp;
			
			/// <summary>
			///   Initializes a new instance of <see cref='GameObjectEnumerator'/>.
			/// </summary>
			public GameObjectEnumerator(GameObjects mappings)
			{
				this.temp = ((IEnumerable)(mappings));
				this.baseEnumerator = temp.GetEnumerator();
			}
			
			/// <summary>
			///   Gets the current <see cref='GameObject'/> in the <seealso cref='GameObjects'/>.
			/// </summary>
			public GameObject Current 
			{
				get 
				{
					return ((GameObject)(baseEnumerator.Current));
				}
			}
			
			object IEnumerator.Current 
			{
				get 
				{
					return baseEnumerator.Current;
				}
			}
			
			/// <summary>
			///   Advances the enumerator to the next <see cref='GameObject'/> of the <see cref='GameObjects'/>.
			/// </summary>
			public bool MoveNext()
			{
				return baseEnumerator.MoveNext();
			}
			
			/// <summary>
			///   Sets the enumerator to its initial position, which is before the first element in the <see cref='GameObjects'/>.
			/// </summary>
			public void Reset()
			{
				baseEnumerator.Reset();
			}
		}
	}
}