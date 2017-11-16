using System;
using System.Collections;
using HelperTools;

namespace Server
{
	/// <summary>
	///   A collection that stores <see cref='Coord'/> objects.
	/// </summary>
	[Serializable()]
	public class Trajet : CollectionBase 
	{
		public UInt64 guid;
		public float longueur;
		public static ArrayList allLinks = new ArrayList();
		#region SERIALISATION
		public Trajet( GenericReader gr )
		{
			List.Clear();
			if ( !gr.notFound )
				Deserialize( gr );
		}

		public virtual void Deserialize( GenericReader gr )
		{
			int version = gr.ReadInt();
			int n = gr.ReadInt();
			guid = (UInt64)gr.ReadInt64();
			longueur = 0;
			//Coord last = null;
			for(int t = 0;t < n;t++)
			{
				byte typ = gr.ReadByte();
				if ( typ == 0 )
				{									
					float x = gr.ReadFloat();
					float y = gr.ReadFloat();
					float z = gr.ReadFloat();
					int p1 = gr.ReadInt();
					int p2 = gr.ReadInt();
					int n1 = gr.ReadInt();
					int n2 = gr.ReadInt();
					Coord nc = new Coord( x, y, z, null, null );
					allLinks.Add( nc );
					allLinks.Add( p1 );
					allLinks.Add( p2 );
					allLinks.Add( n1 );
					allLinks.Add( n2 );					
					Add( nc );	
				}
				else
				{
					float x = gr.ReadFloat();
					float y = gr.ReadFloat();
					float z = gr.ReadFloat();
					int p1 = gr.ReadInt();
					int p2 = gr.ReadInt();
					int n1 = gr.ReadInt();
					int n2 = gr.ReadInt();
					Intersection ii = new Intersection( null, null, null, null, x, y, z );
					allLinks.Add( ii );
					allLinks.Add( p1 );
					allLinks.Add( p2 );
					allLinks.Add( n1 );
					allLinks.Add( n2 );	
					p1 = gr.ReadInt();
					p2 = gr.ReadInt();
					n1 = gr.ReadInt();
					n2 = gr.ReadInt();
					allLinks.Add( p1 );
					allLinks.Add( p2 );
					allLinks.Add( n1 );
					allLinks.Add( n2 );		
					Add( ii );	
				}
			}
		}
		public virtual void Serialize( GenericWriter gw )
		{
			gw.Write( (int)0 );			
			gw.Write( (int)List.Count );	
			gw.Write( guid );
			foreach( Coord t in this )
			{
				if ( t is Intersection )
					gw.Write( (byte)1 );
				else
					gw.Write( (byte)0 );
				gw.Write( (float)t.x );
				gw.Write( (float)t.y );
				gw.Write( (float)t.z );
				int p = 0;
				int n = 0;
				t.previous.TrajetNum( ref p, ref n );
				gw.Write( (int)p );
				gw.Write( (int)n );
				t.next.TrajetNum( ref p, ref n );
				gw.Write( (int)p );
				gw.Write( (int)n );
				if ( t is Intersection )
				{
					Intersection ii = (Intersection)t;
					ii.left.TrajetNum( ref p, ref n );
					gw.Write( (int)p );
					gw.Write( (int)n );
					ii.right.TrajetNum( ref p, ref n );
					gw.Write( (int)p );
					gw.Write( (int)n );
				}
			}
		}			
		#endregion
		/// <summary>
		///   Initializes a new instance of <see cref='Trajet'/>.
		/// </summary>
		public Trajet()
		{
			guid = Object.GUID++;
		}
		public UInt64 Guid
		{
			get { return guid; }
		}
		
		/// <summary>
		///   Initializes a new instance of <see cref='Trajet'/> based on another <see cref='Trajet'/>.
		/// </summary>
		/// <param name='val'>
		///   A <see cref='Trajet'/> from which the contents are copied
		/// </param>
		public Trajet(Trajet val)
		{
			this.AddRange(val);
		}
		
		/// <summary>
		///   Initializes a new instance of <see cref='Trajet'/> containing any array of <see cref='Coord'/> objects.
		/// </summary>
		/// <param name='val'>
		///       A array of <see cref='Coord'/> objects with which to intialize the collection
		/// </param>
		public Trajet(Coord[] val)
		{
			this.AddRange(val);
		}
		
		/// <summary>
		///   Represents the entry at the specified index of the <see cref='Coord'/>.
		/// </summary>
		/// <param name='index'>The zero-based index of the entry to locate in the collection.</param>
		/// <value>The entry at the specified index of the collection.</value>
		/// <exception cref='ArgumentOutOfRangeException'><paramref name='index'/> is outside the valid range of indexes for the collection.</exception>
		public Coord this[int index] 
		{
			get 
			{
				return ((Coord)(List[index]));
			}
			set 
			{
				List[index] = value;
			}
		}
		
		/// <summary>
		///   Adds a <see cref='Coord'/> with the specified value to the 
		///   <see cref='Trajet'/>.
		/// </summary>
		/// <param name='val'>The <see cref='Coord'/> to add.</param>
		/// <returns>The index at which the new element was inserted.</returns>
		/// <seealso cref='Trajet.AddRange'/>
		public int Add(Coord val )
		{
			return List.Add( val );
		}
		public int Add( Coord val, Coord previous )
		{
			Coord left = null;
			Coord right = null;
			Trajet where = null;
			float x = 0;
			float y = 0;
			float z = 0;
			if ( previous != null )
			{
				foreach( Trajet t in World.trajets )
				{
					try
					{
						Coord current = t[ 0 ];
						bool debut = true;
						while( !( !debut && current == t[ 0 ] ) && current.next != null )
						{
							debut = false;
							float x1 = current.x;
							float y1 = current.y;
							float x2 = current.next.x;
							float y2 = current.next.y;
							float x3 = val.x;
							float y3 = val.y;
							float x4 = previous.x;
							float y4 = previous.y;
							if ( x1 == x2 )
							{
								current = current.next;
								continue;
							}
							float d1 = ( ( y1 - y2 ) * ( x3 - x4 ) - ( y3 - y4 ) * ( x1 - x2 ) );
							if ( d1 == 0 )
							{
								current = current.next;
								continue;
							}
							x = ( ( x3 * y4 - x4 * y3 ) * 
								(x1 - x2) - (x1 * y2 - x2 * y1) * ( x3 - x4 ) )
								/ d1;
							y = x * ( ( y1 - y2 ) / ( x1 - x2 ) ) 
								+ ( ( x1 * y2 - x2 * y1 ) / ( x1 - x2 ) );
							float d1x = x1 - x2;
							float d1y = y1 - y2;
							float dist = d1x * d1x + d1y * d1y;
							float dx1 = x1 - x;
							float dx2 = x2 - x;
							float dy1 = y1 - y;
							float dy2 = y2 - y;
							if ( ( dx1 == 0 && dy1 == 0 ) || ( dx2 == 0 && dy2 == 0 ) )
							{
								current = current.next;
								continue;
							}
							dx1 *= dx1;
							dy1 *= dy1;
							dx2 *= dx2;
							dy2 *= dy2;
							if ( dx1 + dy1 > dist )
							{
								current = current.next;
								continue;
							}
							if ( dx2 + dy2 > dist )
							{
								current = current.next;
								continue;
							}
							float d2x = x3 - x4;
							float d2y = y3 - y4;
							dist = d2x * d2x + d2y * d2y;
							float dx3 = x3 - x;
							float dx4 = x4 - x;
							float dy3 = y3 - y;
							float dy4 = y4 - y;
							if ( ( dx3 == 0 && dy3 == 0 ) || ( dx4 == 0 && dy4 == 0 ) )
							{
								current = current.next;
								continue;
							}
							dx3 *= dx3;
							dy3 *= dy3;
							dx4 *= dx4;
							dy4 *= dy4;
							if ( dx3 + dy3 > dist )
							{
								current = current.next;
								continue;
							}
							if ( dx4 + dy4 > dist )
							{
								current = current.next;
								continue;
							}
							//calcul du Z
							float z1 = current.z;
							float z2 = current.next.z;
							float z3 = val.z;
							float z4 = previous.z;
							/*	float x = ( ( x3 * z4 - x4 * z3 ) * 
									(x1 - x2) - (x1 * z2 - x2 * z1) * ( x3 - x4 ) )
									/ ( ( z1 - z2 ) * ( x3 - x4 ) - ( z3 - z4 ) * ( x1 - x2 ) );*/
							z = x * ( ( z1 - z2 ) / ( x1 - x2 ) ) 
								+ ( ( x1 * z2 - x2 * z1 ) / ( x1 - x2 ) );
						
							//	Console.WriteLine("Intersection en {0};{1};{2}", x, y, z );
							left = current;
							right = current.next;
							where = t;
							break;
						}
					}
					catch( Exception e )
					{
						Console.WriteLine("{0}", e.Message );
					}
					if ( where != null )
						break;
				}
				if ( where != null )
				{
					Intersection inter1 = new Intersection( 
						left,
						right,
						previous,
						val,
						x, y, z );
					val.previous = inter1;
					previous.next = inter1;
					
					List.Add( inter1 );	
					Intersection inter2 = new Intersection( 
						previous,
						val,
						left,
						right,
						x, y, z );
					left.next = inter2;
					right.previous = inter2;
					where.Add( inter2 );					
				}
			}
			return List.Add(val);
		}
		
		/// <summary>
		///   Copies the elements of an array to the end of the <see cref='Trajet'/>.
		/// </summary>
		/// <param name='val'>
		///    An array of type <see cref='Coord'/> containing the objects to add to the collection.
		/// </param>
		/// <seealso cref='Trajet.Add'/>
		public void AddRange(Coord[] val)
		{
			for (int i = 0; i < val.Length; i++) 
			{
				this.Add(val[i]);
			}
		}
		
		/// <summary>
		///   Adds the contents of another <see cref='Trajet'/> to the end of the collection.
		/// </summary>
		/// <param name='val'>
		///    A <see cref='Trajet'/> containing the objects to add to the collection.
		/// </param>
		/// <seealso cref='Trajet.Add'/>
		public void AddRange(Trajet val)
		{
			for (int i = 0; i < val.Count; i++)
			{
				this.Add(val[i]);
			}
		}
		
		/// <summary>
		///   Gets a value indicating whether the 
		///    <see cref='Trajet'/> contains the specified <see cref='Coord'/>.
		/// </summary>
		/// <param name='val'>The <see cref='Coord'/> to locate.</param>
		/// <returns>
		/// <see langword='true'/> if the <see cref='Coord'/> is contained in the collection; 
		///   otherwise, <see langword='false'/>.
		/// </returns>
		/// <seealso cref='Trajet.IndexOf'/>
		public bool Contains(Coord val)
		{
			return List.Contains(val);
		}
		
		/// <summary>
		///   Copies the <see cref='Trajet'/> values to a one-dimensional <see cref='Array'/> instance at the 
		///    specified index.
		/// </summary>
		/// <param name='array'>The one-dimensional <see cref='Array'/> that is the destination of the values copied from <see cref='Trajet'/>.</param>
		/// <param name='index'>The index in <paramref name='array'/> where copying begins.</param>
		/// <exception cref='ArgumentException'>
		///   <para><paramref name='array'/> is multidimensional.</para>
		///   <para>-or-</para>
		///   <para>The number of elements in the <see cref='Trajet'/> is greater than
		///         the available space between <paramref name='arrayIndex'/> and the end of
		///         <paramref name='array'/>.</para>
		/// </exception>
		/// <exception cref='ArgumentNullException'><paramref name='array'/> is <see langword='null'/>. </exception>
		/// <exception cref='ArgumentOutOfRangeException'><paramref name='arrayIndex'/> is less than <paramref name='array'/>'s lowbound. </exception>
		/// <seealso cref='Array'/>
		public void CopyTo(Coord[] array, int index)
		{
			List.CopyTo(array, index);
		}
		
		/// <summary>
		///    Returns the index of a <see cref='Coord'/> in 
		///       the <see cref='Trajet'/>.
		/// </summary>
		/// <param name='val'>The <see cref='Coord'/> to locate.</param>
		/// <returns>
		///   The index of the <see cref='Coord'/> of <paramref name='val'/> in the 
		///   <see cref='Trajet'/>, if found; otherwise, -1.
		/// </returns>
		/// <seealso cref='Trajet.Contains'/>
		public int IndexOf(Coord val)
		{
			return List.IndexOf(val);
		}
		
		/// <summary>
		///   Inserts a <see cref='Coord'/> into the <see cref='Trajet'/> at the specified index.
		/// </summary>
		/// <param name='index'>The zero-based index where <paramref name='val'/> should be inserted.</param>
		/// <param name='val'>The <see cref='Coord'/> to insert.</param>
		/// <seealso cref='Trajet.Add'/>
		public void Insert(int index, Coord val)
		{
			List.Insert(index, val);
		}
		
		/// <summary>
		///  Returns an enumerator that can iterate through the <see cref='Trajet'/>.
		/// </summary>
		/// <seealso cref='IEnumerator'/>
		public new CoordEnumerator GetEnumerator()
		{
			return new CoordEnumerator(this);
		}
		
		/// <summary>
		///   Removes a specific <see cref='Coord'/> from the <see cref='Trajet'/>.
		/// </summary>
		/// <param name='val'>The <see cref='Coord'/> to remove from the <see cref='Trajet'/>.</param>
		/// <exception cref='ArgumentException'><paramref name='val'/> is not found in the Collection.</exception>
		public void Remove(Coord val)
		{
			List.Remove(val);
		}
		
		/// <summary>
		///   Enumerator that can iterate through a Trajet.
		/// </summary>
		/// <seealso cref='IEnumerator'/>
		/// <seealso cref='Trajet'/>
		/// <seealso cref='Coord'/>
		public class CoordEnumerator : IEnumerator
		{
			IEnumerator baseEnumerator;
			IEnumerable temp;
			
			/// <summary>
			///   Initializes a new instance of <see cref='CoordEnumerator'/>.
			/// </summary>
			public CoordEnumerator(Trajet mappings)
			{
				this.temp = ((IEnumerable)(mappings));
				this.baseEnumerator = temp.GetEnumerator();
			}
			
			/// <summary>
			///   Gets the current <see cref='Coord'/> in the <seealso cref='Trajet'/>.
			/// </summary>
			public Coord Current 
			{
				get 
				{
					return ((Coord)(baseEnumerator.Current));
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
			///   Advances the enumerator to the next <see cref='Coord'/> of the <see cref='Trajet'/>.
			/// </summary>
			public bool MoveNext()
			{
				return baseEnumerator.MoveNext();
			}
			
			/// <summary>
			///   Sets the enumerator to its initial position, which is before the first element in the <see cref='Trajet'/>.
			/// </summary>
			public void Reset()
			{
				baseEnumerator.Reset();
			}
		}
	}
}
