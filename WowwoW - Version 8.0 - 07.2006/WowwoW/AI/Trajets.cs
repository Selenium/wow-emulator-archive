using System;
using HelperTools;
using System.Collections;

namespace Server
{
	/// <summary>
	///   A collection that stores <see cref='Trajet'/> objects.
	/// </summary>
	[Serializable()]
	public class Trajets : CollectionBase 
	{
		bool dirty = false;
		public bool Dirty
		{
			get { return dirty; }
			set { dirty = value; }
		}
		#region SERIALISATION
		public Trajets( GenericReader gr )
		{
			List.Clear();
			if ( !gr.notFound )
				Deserialize( gr );
		}

		public virtual void Deserialize( GenericReader gr )
		{
			int version = gr.ReadInt();
			int n = gr.ReadInt();
			for(int t = 0;t < n;t++)
			{
				Add( new Trajet( gr ) );
			}
			gr.Close();
			for(int t = 0;t < Trajet.allLinks.Count; )
			{
				Coord c = (Coord)Trajet.allLinks[ t++ ];
				int p1 = (int)Trajet.allLinks[ t++ ];
				int p2 = (int)Trajet.allLinks[ t++ ];
				int n1 = (int)Trajet.allLinks[ t++ ];
				int n2 = (int)Trajet.allLinks[ t++ ];
				c.previous = this[ p1 ][ p2 ];
				c.next = this[ n1 ][ n2 ];
				if ( c is Intersection )
				{
					Intersection ii = (Intersection)c;
					p1 = (int)Trajet.allLinks[ t++ ];
					p2 = (int)Trajet.allLinks[ t++ ];
					n1 = (int)Trajet.allLinks[ t++ ];
					n2 = (int)Trajet.allLinks[ t++ ];
					ii.left = this[ p1 ][ p2 ];
					ii.right = this[ n1 ][ n2 ];
				}
			}
			Trajet.allLinks.Clear();
			GC.Collect();
		}
		public virtual void Serialize( GenericWriter gw )
		{
			gw.Write( (int)0 );			
			gw.Write( (int)List.Count );	
			foreach( Trajet t in this )
				t.Serialize( gw );
			gw.Close();
			Dirty = false;
		}			
		#endregion
		/// <summary>
		///   Initializes a new instance of <see cref='Trajets'/>.
		/// </summary>
		public Trajets()
		{
		}

		public Trajet Find( UInt64 guid )
		{
			foreach( Trajet t in this )
				if ( t.Guid == guid )
					return t;
			return null;
		}
		
		/// <summary>
		///   Initializes a new instance of <see cref='Trajets'/> based on another <see cref='Trajets'/>.
		/// </summary>
		/// <param name='val'>
		///   A <see cref='Trajets'/> from which the contents are copied
		/// </param>
		public Trajets(Trajets val)
		{
			
			this.AddRange(val);
		}
		
		/// <summary>
		///   Initializes a new instance of <see cref='Trajets'/> containing any array of <see cref='Trajet'/> objects.
		/// </summary>
		/// <param name='val'>
		///       A array of <see cref='Trajet'/> objects with which to intialize the collection
		/// </param>
		public Trajets(Trajet[] val)
		{
			
			this.AddRange(val);
		}
		
		/// <summary>
		///   Represents the entry at the specified index of the <see cref='Trajet'/>.
		/// </summary>
		/// <param name='index'>The zero-based index of the entry to locate in the collection.</param>
		/// <value>The entry at the specified index of the collection.</value>
		/// <exception cref='ArgumentOutOfRangeException'><paramref name='index'/> is outside the valid range of indexes for the collection.</exception>
		public Trajet this[int index] 
		{
			get 
			{
				return ((Trajet)(List[index]));
			}
			set 
			{
				
				List[index] = value;
			}
		}
		
		/// <summary>
		///   Adds a <see cref='Trajet'/> with the specified value to the 
		///   <see cref='Trajets'/>.
		/// </summary>
		/// <param name='val'>The <see cref='Trajet'/> to add.</param>
		/// <returns>The index at which the new element was inserted.</returns>
		/// <seealso cref='Trajets.AddRange'/>
		public int Add(Trajet val)
		{
			
			return List.Add(val);
		}
		
		/// <summary>
		///   Copies the elements of an array to the end of the <see cref='Trajets'/>.
		/// </summary>
		/// <param name='val'>
		///    An array of type <see cref='Trajet'/> containing the objects to add to the collection.
		/// </param>
		/// <seealso cref='Trajets.Add'/>
		public void AddRange(Trajet[] val)
		{
			
			for (int i = 0; i < val.Length; i++) 
			{
				this.Add(val[i]);
			}
		}
		
		/// <summary>
		///   Adds the contents of another <see cref='Trajets'/> to the end of the collection.
		/// </summary>
		/// <param name='val'>
		///    A <see cref='Trajets'/> containing the objects to add to the collection.
		/// </param>
		/// <seealso cref='Trajets.Add'/>
		public void AddRange(Trajets val)
		{
			
			for (int i = 0; i < val.Count; i++)
			{
				this.Add(val[i]);
			}
		}
		
		/// <summary>
		///   Gets a value indicating whether the 
		///    <see cref='Trajets'/> contains the specified <see cref='Trajet'/>.
		/// </summary>
		/// <param name='val'>The <see cref='Trajet'/> to locate.</param>
		/// <returns>
		/// <see langword='true'/> if the <see cref='Trajet'/> is contained in the collection; 
		///   otherwise, <see langword='false'/>.
		/// </returns>
		/// <seealso cref='Trajets.IndexOf'/>
		public bool Contains(Trajet val)
		{
			return List.Contains(val);
		}
		
		/// <summary>
		///   Copies the <see cref='Trajets'/> values to a one-dimensional <see cref='Array'/> instance at the 
		///    specified index.
		/// </summary>
		/// <param name='array'>The one-dimensional <see cref='Array'/> that is the destination of the values copied from <see cref='Trajets'/>.</param>
		/// <param name='index'>The index in <paramref name='array'/> where copying begins.</param>
		/// <exception cref='ArgumentException'>
		///   <para><paramref name='array'/> is multidimensional.</para>
		///   <para>-or-</para>
		///   <para>The number of elements in the <see cref='Trajets'/> is greater than
		///         the available space between <paramref name='arrayIndex'/> and the end of
		///         <paramref name='array'/>.</para>
		/// </exception>
		/// <exception cref='ArgumentNullException'><paramref name='array'/> is <see langword='null'/>. </exception>
		/// <exception cref='ArgumentOutOfRangeException'><paramref name='arrayIndex'/> is less than <paramref name='array'/>'s lowbound. </exception>
		/// <seealso cref='Array'/>
		public void CopyTo(Trajet[] array, int index)
		{
			
			List.CopyTo(array, index);
		}
		
		/// <summary>
		///    Returns the index of a <see cref='Trajet'/> in 
		///       the <see cref='Trajets'/>.
		/// </summary>
		/// <param name='val'>The <see cref='Trajet'/> to locate.</param>
		/// <returns>
		///   The index of the <see cref='Trajet'/> of <paramref name='val'/> in the 
		///   <see cref='Trajets'/>, if found; otherwise, -1.
		/// </returns>
		/// <seealso cref='Trajets.Contains'/>
		public int IndexOf(Trajet val)
		{
			return List.IndexOf(val);
		}
		
		/// <summary>
		///   Inserts a <see cref='Trajet'/> into the <see cref='Trajets'/> at the specified index.
		/// </summary>
		/// <param name='index'>The zero-based index where <paramref name='val'/> should be inserted.</param>
		/// <param name='val'>The <see cref='Trajet'/> to insert.</param>
		/// <seealso cref='Trajets.Add'/>
		public void Insert(int index, Trajet val)
		{
			
			List.Insert(index, val);
		}
		
		/// <summary>
		///  Returns an enumerator that can iterate through the <see cref='Trajets'/>.
		/// </summary>
		/// <seealso cref='IEnumerator'/>
		public new TrajetEnumerator GetEnumerator()
		{
			return new TrajetEnumerator(this);
		}
		
		/// <summary>
		///   Removes a specific <see cref='Trajet'/> from the <see cref='Trajets'/>.
		/// </summary>
		/// <param name='val'>The <see cref='Trajet'/> to remove from the <see cref='Trajets'/>.</param>
		/// <exception cref='ArgumentException'><paramref name='val'/> is not found in the Collection.</exception>
		public void Remove(Trajet val)
		{
			
			List.Remove(val);
		}
		
		/// <summary>
		///   Enumerator that can iterate through a Trajets.
		/// </summary>
		/// <seealso cref='IEnumerator'/>
		/// <seealso cref='Trajets'/>
		/// <seealso cref='Trajet'/>
		public class TrajetEnumerator : IEnumerator
		{
			IEnumerator baseEnumerator;
			IEnumerable temp;
			
			/// <summary>
			///   Initializes a new instance of <see cref='TrajetEnumerator'/>.
			/// </summary>
			public TrajetEnumerator(Trajets mappings)
			{
				this.temp = ((IEnumerable)(mappings));
				this.baseEnumerator = temp.GetEnumerator();
			}
			
			/// <summary>
			///   Gets the current <see cref='Trajet'/> in the <seealso cref='Trajets'/>.
			/// </summary>
			public Trajet Current 
			{
				get 
				{
					return ((Trajet)(baseEnumerator.Current));
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
			///   Advances the enumerator to the next <see cref='Trajet'/> of the <see cref='Trajets'/>.
			/// </summary>
			public bool MoveNext()
			{
				return baseEnumerator.MoveNext();
			}
			
			/// <summary>
			///   Sets the enumerator to its initial position, which is before the first element in the <see cref='Trajets'/>.
			/// </summary>
			public void Reset()
			{
				baseEnumerator.Reset();
			}
		}
	}
}
