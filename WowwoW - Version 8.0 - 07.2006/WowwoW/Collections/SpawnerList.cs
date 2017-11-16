using System;
using System.Collections;
using HelperTools;

namespace Server
{
	/// <summary>
	///   A collection that stores <see cref='BaseSpawner'/> objects.
	/// </summary>
	[Serializable()]
	public class SpawnerList : CollectionBase 
	{
		bool dirty = false;
		Hashtable spawnZones = new Hashtable();
		public bool Dirty
		{
			get { return dirty; }
		}
		#region SERIALISATION
		public SpawnerList( GenericReader gr )
		{
			List.Clear();
			if ( !gr.notFound )
			{
				Deserialize( gr );
			}
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
				int type = gr.ReadInt();
				if ( type == 0 )
					Add( new MobileSpawner( gr ) );
				else
					Add( new GameObjectSpawner( gr ) );

			}
			int n1 = gr.ReadInt();
			for(int t = 0;t < n1;t++ )
			{
				int id = gr.ReadInt();
				int n2 = gr.ReadInt();
				ArrayList al = new ArrayList( n2 );
				World.regSpawners[ id ] = al;
				for(int i = 0;i < n2;i++ )
				{
					al.Add( gr.ReadInt() );
				}
			}
			gr.Close();
			TempSpawner.Clear();
			TempSpawner = null;
		}
		public virtual void Serialize( GenericWriter gw )
		{			
			gw.Write( (int)0 );			
			foreach( BaseSpawner m in this )
			{
				gw.Write( 1 );
				if ( m is MobileSpawner )
					gw.Write( 0 );
				else
					gw.Write( 1 );
				m.Serialize( gw );
			}
			gw.Write( 0 );
			gw.Write( (int)World.regSpawners.Count );
			//Console.WriteLine("{0} spawn path", World.regSpawners.Count );
			IDictionaryEnumerator regcountEnumerator = World.regSpawners.GetEnumerator();
			while ( regcountEnumerator.MoveNext() )
			{
				if ( regcountEnumerator.Value == null )
					continue;
				gw.Write( (int)regcountEnumerator.Key );
				gw.Write( (int)( regcountEnumerator.Value as ArrayList ).Count );
				foreach( int t in ( regcountEnumerator.Value as ArrayList ) )
				{
					gw.Write( t );
				}
			}			
			gw.Close();
			dirty = false;
		}		
		#endregion

		public ArrayList Nearest( int zoneid )
		{
			return (ArrayList)spawnZones[ zoneid ];
		}
		/// <summary>
		///   Initializes a new instance of <see cref='SpawnerList'/>.
		/// </summary>
		public SpawnerList()
		{
		}
		
		/// <summary>
		///   Initializes a new instance of <see cref='SpawnerList'/> based on another <see cref='SpawnerList'/>.
		/// </summary>
		/// <param name='val'>
		///   A <see cref='SpawnerList'/> from which the contents are copied
		/// </param>
		public SpawnerList(SpawnerList val)
		{
			dirty = true;
			this.AddRange(val);
		}
		
		/// <summary>
		///   Initializes a new instance of <see cref='SpawnerList'/> containing any array of <see cref='BaseSpawner'/> objects.
		/// </summary>
		/// <param name='val'>
		///       A array of <see cref='BaseSpawner'/> objects with which to intialize the collection
		/// </param>
		public SpawnerList(BaseSpawner[] val)
		{
			dirty = true;
			this.AddRange(val);
		}
		
		/// <summary>
		///   Represents the entry at the specified index of the <see cref='BaseSpawner'/>.
		/// </summary>
		/// <param name='index'>The zero-based index of the entry to locate in the collection.</param>
		/// <value>The entry at the specified index of the collection.</value>
		/// <exception cref='ArgumentOutOfRangeException'><paramref name='index'/> is outside the valid range of indexes for the collection.</exception>
		public BaseSpawner this[int index] 
		{
			get 
			{
				return ((BaseSpawner)(List[index]));
			}
			set 
			{
				dirty = true;
				List[index] = value;
			}
		}
		
		/// <summary>
		///   Adds a <see cref='BaseSpawner'/> with the specified value to the 
		///   <see cref='SpawnerList'/>.
		/// </summary>
		/// <param name='val'>The <see cref='BaseSpawner'/> to add.</param>
		/// <returns>The index at which the new element was inserted.</returns>
		/// <seealso cref='SpawnerList.AddRange'/>
		public int Add(BaseSpawner val)
		{
			dirty = true;
			if ( ( val as BaseSpawner ).ZoneId == 0 )
			{//	Search the zone id
				return List.Add(val);
			}
			int mapid = ( val as BaseSpawner ).MapId;
			mapid *= 1024;
			ArrayList al = (ArrayList)spawnZones[ mapid + (int)World.zones[ ( val as BaseSpawner ).ZoneId ] ];
			if ( al == null )
				al = (ArrayList)( spawnZones[ mapid + (int)World.zones[ ( val as BaseSpawner ).ZoneId ] ] = new ArrayList() );
			al.Add( val );
			return List.Add(val);
		}
		
		/// <summary>
		///   Copies the elements of an array to the end of the <see cref='SpawnerList'/>.
		/// </summary>
		/// <param name='val'>
		///    An array of type <see cref='BaseSpawner'/> containing the objects to add to the collection.
		/// </param>
		/// <seealso cref='SpawnerList.Add'/>
		public void AddRange(BaseSpawner[] val)
		{
			dirty = true;
			for (int i = 0; i < val.Length; i++) 
			{
				this.Add(val[i]);
			}
		}
		
		/// <summary>
		///   Adds the contents of another <see cref='SpawnerList'/> to the end of the collection.
		/// </summary>
		/// <param name='val'>
		///    A <see cref='SpawnerList'/> containing the objects to add to the collection.
		/// </param>
		/// <seealso cref='SpawnerList.Add'/>
		public void AddRange(SpawnerList val)
		{
			dirty = true;
			for (int i = 0; i < val.Count; i++)
			{
				this.Add(val[i]);
			}
		}
		
		/// <summary>
		///   Gets a value indicating whether the 
		///    <see cref='SpawnerList'/> contains the specified <see cref='BaseSpawner'/>.
		/// </summary>
		/// <param name='val'>The <see cref='BaseSpawner'/> to locate.</param>
		/// <returns>
		/// <see langword='true'/> if the <see cref='BaseSpawner'/> is contained in the collection; 
		///   otherwise, <see langword='false'/>.
		/// </returns>
		/// <seealso cref='SpawnerList.IndexOf'/>
		public bool Contains(BaseSpawner val)
		{
			return List.Contains(val);
		}
		
		/// <summary>
		///   Copies the <see cref='SpawnerList'/> values to a one-dimensional <see cref='Array'/> instance at the 
		///    specified index.
		/// </summary>
		/// <param name='array'>The one-dimensional <see cref='Array'/> that is the destination of the values copied from <see cref='SpawnerList'/>.</param>
		/// <param name='index'>The index in <paramref name='array'/> where copying begins.</param>
		/// <exception cref='ArgumentException'>
		///   <para><paramref name='array'/> is multidimensional.</para>
		///   <para>-or-</para>
		///   <para>The number of elements in the <see cref='SpawnerList'/> is greater than
		///         the available space between <paramref name='arrayIndex'/> and the end of
		///         <paramref name='array'/>.</para>
		/// </exception>
		/// <exception cref='ArgumentNullException'><paramref name='array'/> is <see langword='null'/>. </exception>
		/// <exception cref='ArgumentOutOfRangeException'><paramref name='arrayIndex'/> is less than <paramref name='array'/>'s lowbound. </exception>
		/// <seealso cref='Array'/>
		public void CopyTo(BaseSpawner[] array, int index)
		{
			dirty = true;
			List.CopyTo(array, index);
		}
		
		/// <summary>
		///    Returns the index of a <see cref='BaseSpawner'/> in 
		///       the <see cref='SpawnerList'/>.
		/// </summary>
		/// <param name='val'>The <see cref='BaseSpawner'/> to locate.</param>
		/// <returns>
		///   The index of the <see cref='BaseSpawner'/> of <paramref name='val'/> in the 
		///   <see cref='SpawnerList'/>, if found; otherwise, -1.
		/// </returns>
		/// <seealso cref='SpawnerList.Contains'/>
		public int IndexOf(BaseSpawner val)
		{
			return List.IndexOf(val);
		}
		
		/// <summary>
		///   Inserts a <see cref='BaseSpawner'/> into the <see cref='SpawnerList'/> at the specified index.
		/// </summary>
		/// <param name='index'>The zero-based index where <paramref name='val'/> should be inserted.</param>
		/// <param name='val'>The <see cref='BaseSpawner'/> to insert.</param>
		/// <seealso cref='SpawnerList.Add'/>
		public void Insert(int index, BaseSpawner val)
		{
			dirty = true;
			List.Insert(index, val);
		}
		
		/// <summary>
		///  Returns an enumerator that can iterate through the <see cref='SpawnerList'/>.
		/// </summary>
		/// <seealso cref='IEnumerator'/>
		public new BaseSpawnerEnumerator GetEnumerator()
		{
			return new BaseSpawnerEnumerator(this);
		}
		
		/// <summary>
		///   Removes a specific <see cref='BaseSpawner'/> from the <see cref='SpawnerList'/>.
		/// </summary>
		/// <param name='val'>The <see cref='BaseSpawner'/> to remove from the <see cref='SpawnerList'/>.</param>
		/// <exception cref='ArgumentException'><paramref name='val'/> is not found in the Collection.</exception>
		public void Remove(BaseSpawner val)
		{			
			int mapid = ( val as BaseSpawner ).MapId;
			mapid *= 1024;
			ArrayList al = (ArrayList)spawnZones[ mapid + (int)World.zones[ ( val as BaseSpawner ).ZoneId ] ];
			if ( al != null )
			{
				( (ArrayList)spawnZones[ mapid + (int)World.zones[ ( val as BaseSpawner ).ZoneId ] ] ).Remove( val );
				
			}
			int ind = List.IndexOf( val );
			for( int a = 0;a < World.regSpawners.Count;a++ )
			{
				ArrayList all = (ArrayList)World.regSpawners[ a ];
				if ( all == null )
					continue;
				int toRemove = -1;
				for(int b = 0; b < all.Count;b++ )
				{
					int alb = (int)all[ b ];
					if ( alb > ind )
						all[ b ] = alb - 1;
					else
						if ( alb == ind )
						toRemove = b;
				}
				if ( toRemove != -1 )
					( (ArrayList)World.regSpawners[ a ] ).RemoveAt( toRemove );					
			}
			for( int a = ind;a < World.regSpawners.Count - 1;a++ )
				World.regSpawners[ a ] = World.regSpawners[ a + 1 ];
			dirty = true;
			List.Remove(val);
		}

		
		/// <summary>
		///   Enumerator that can iterate through a SpawnerList.
		/// </summary>
		/// <seealso cref='IEnumerator'/>
		/// <seealso cref='SpawnerList'/>
		/// <seealso cref='BaseSpawner'/>
		public class BaseSpawnerEnumerator : IEnumerator
		{
			IEnumerator baseEnumerator;
			IEnumerable temp;
			
			/// <summary>
			///   Initializes a new instance of <see cref='BaseSpawnerEnumerator'/>.
			/// </summary>
			public BaseSpawnerEnumerator(SpawnerList mappings)
			{
				this.temp = ((IEnumerable)(mappings));
				this.baseEnumerator = temp.GetEnumerator();
			}
			
			/// <summary>
			///   Gets the current <see cref='BaseSpawner'/> in the <seealso cref='SpawnerList'/>.
			/// </summary>
			public BaseSpawner Current 
			{
				get 
				{
					return ((BaseSpawner)(baseEnumerator.Current));
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
			///   Advances the enumerator to the next <see cref='BaseSpawner'/> of the <see cref='SpawnerList'/>.
			/// </summary>
			public bool MoveNext()
			{
				return baseEnumerator.MoveNext();
			}
			
			/// <summary>
			///   Sets the enumerator to its initial position, which is before the first element in the <see cref='SpawnerList'/>.
			/// </summary>
			public void Reset()
			{
				baseEnumerator.Reset();
			}
		}
	}
}