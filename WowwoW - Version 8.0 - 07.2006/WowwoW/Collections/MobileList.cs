
using System;
using System.Collections;
using HelperTools;
using System.Threading;

namespace Server
{
	/// <summary>
	///     <para>
	///       A collection that stores <see cref='.Mobile'/> objects.
	///    </para>
	/// </summary>
	/// <seealso cref='.MobileList'/>
	[Serializable()]
	public class MobileList : CollectionBase 
	{
		public ArrayList onKalimdor = new ArrayList();
		public ArrayList onEasternKindoms = new ArrayList();

		public ArrayList GetContinent( ushort mapId )
		{
			if ( mapId == 0 )
				return onEasternKindoms;
			return onKalimdor;
		}


		/// <summary>
		///     <para>
		///       Initializes a new instance of <see cref='.MobileList'/>.
		///    </para>
		/// </summary>
		public MobileList()
		{
		}
		
		/// <summary>
		///     <para>
		///       Initializes a new instance of <see cref='.MobileList'/> based on another <see cref='.MobileList'/>.
		///    </para>
		/// </summary>
		/// <param name='value'>
		///       A <see cref='.MobileList'/> from which the contents are copied
		/// </param>
		/*
		public MobileList(MobileList val)
		{
			this.AddRange(val);
		}*/
		
		/// <summary>
		///     <para>
		///       Initializes a new instance of <see cref='.MobileList'/> containing any array of <see cref='.Mobile'/> objects.
		///    </para>
		/// </summary>
		/// <param name='value'>
		///       A array of <see cref='.Mobile'/> objects with which to intialize the collection
		/// </param>
		public MobileList(Mobile[] val)
		{
			this.AddRange(val);
		}
		public MobileList( GenericReader gr )
		{
			Thread.CurrentThread.Priority = ThreadPriority.Highest;
			List.Clear();
			if ( !gr.notFound )
			{
				Deserialize( gr );
			}
		}

		//public static Hashtable TempSpawner = new Hashtable();
		public static Hashtable TempSummon = new Hashtable();
		public virtual void Deserialize( GenericReader gr )
		{
			int version = gr.ReadInt();
			//TempSpawner[ 0 ] = null;
			
			//Console.WriteLine("n {0}", n );
			Object.GUID = gr.ReadInt64();
			while( true )
			{
				int n = gr.ReadInt();
				if ( n == 0 )
					break;
				Add( Mobile.Load( gr ) );
			}
			gr.Close();			
			
		}
		public virtual void Serialize( GenericWriter gw )
		{
			gw.Write( (int)0 );	
			gw.Write( Object.GUID );
			foreach( Mobile m in this.onEasternKindoms )
			{
			//	if ( !( m is Character ) )
					if ( !( m is Corps ) )
						if ( m.SummonedBy != null || m.CharmedBy != null )//|| m is BaseSpawner )
						{
							gw.Write( (int)1 );
							m.Serialize( gw );
						}
			}			
			foreach( Mobile m in this.onKalimdor )
			{
			//	if ( !( m is Character ) )
					if ( !( m is Corps ) )
						if ( m.SummonedBy != null || m.CharmedBy != null )// || m is BaseSpawner )
						{
							gw.Write( (int)1 );
							m.Serialize( gw );
						}
			}
		}		
		/// <summary>
		/// <para>Represents the entry at the specified index of the <see cref='.Mobile'/>.</para>
		/// </summary>
		/// <param name='index'><para>The zero-based index of the entry to locate in the collection.</para></param>
		/// <value>
		///    <para> The entry at the specified index of the collection.</para>
		/// </value>
		/// <exception cref='System.ArgumentOutOfRangeException'><paramref name='index'/> is outside the valid range of indexes for the collection.</exception>
	/*	public Mobile this[int index] {
			get {
				return ((Mobile)(List[index]));
			}
			set {
				List[index] = value;
			}
		}*/
/*
		public Mobile FindByGuid( UInt64 guid, ushort mapId )
		{
			if ( mapId == 0 )
			{
				foreach( Mobile m in onEasternKindoms )
					if ( m.Guid == guid )
						return m;
			}
			else
			{
			}
			return null;	
		}*/
		
		/// <summary>
		///    <para>Adds a <see cref='.Mobile'/> with the specified value to the 
		///    <see cref='.MobileList'/> .</para>
		/// </summary>
		/// <param name='value'>The <see cref='.Mobile'/> to add.</param>
		/// <returns>
		///    <para>The index at which the new element was inserted.</para>
		/// </returns>
		/// <seealso cref='.MobileList.AddRange'/>
		public int Add( Mobile val )
		{
			val.moveVector = new Server.Mobile.MoveVector( val, val.X, val.Y, val.Z );
			if ( val.MapId == 0 )
				return onEasternKindoms.Add( val );
			return onKalimdor.Add( val );
		}
		public int Add(Mobile val, bool sendToAllPlayer )
		{
			//val.moveVector = new Server.Mobile.MoveVector( val, val.X, val.Y, val.Z );
			int ret = this.Add( val );
		/*	if ( sendToAllPlayer )
				foreach( Character ch in World.allConnectedChars )
					if ( ch.Distance( val ) < 160 * 160 )
					{
						ch.Player.RefreshMobileList();
					}*/
			return ret;
		}
		/// <summary>
		/// <para>Copies the elements of an array to the end of the <see cref='.MobileList'/>.</para>
		/// </summary>
		/// <param name='value'>
		///    An array of type <see cref='.Mobile'/> containing the objects to add to the collection.
		/// </param>
		/// <returns>
		///   <para>None.</para>
		/// </returns>
		/// <seealso cref='.MobileList.Add'/>
		public void AddRange(Mobile[] val)
		{
			for (int i = 0; i < val.Length; i++) 
			{
				this.Add( val[ i ] );
			}
		}
		
		/// <summary>
		///     <para>
		///       Adds the contents of another <see cref='.MobileList'/> to the end of the collection.
		///    </para>
		/// </summary>
		/// <param name='value'>
		///    A <see cref='.MobileList'/> containing the objects to add to the collection.
		/// </param>
		/// <returns>
		///   <para>None.</para>
		/// </returns>
		/// <seealso cref='.MobileList.Add'/>
		/*public void AddRange(MobileList val)
		{
			for (int i = 0; i < val.Count; i++)
			{
				this.Add(val[i]);
			}
		}*/
		
		/// <summary>
		/// <para>Gets a value indicating whether the 
		///    <see cref='.MobileList'/> contains the specified <see cref='.Mobile'/>.</para>
		/// </summary>
		/// <param name='value'>The <see cref='.Mobile'/> to locate.</param>
		/// <returns>
		/// <para><see langword='true'/> if the <see cref='.Mobile'/> is contained in the collection; 
		///   otherwise, <see langword='false'/>.</para>
		/// </returns>
		/// <seealso cref='.MobileList.IndexOf'/>
		public bool Contains( Mobile val )
		{
			if ( val.MapId == 0 )
				return onEasternKindoms.Contains( val );
			return onKalimdor.Contains( val );
		}
		
		/// <summary>
		/// <para>Copies the <see cref='.MobileList'/> values to a one-dimensional <see cref='System.Array'/> instance at the 
		///    specified index.</para>
		/// </summary>
		/// <param name='array'><para>The one-dimensional <see cref='System.Array'/> that is the destination of the values copied from <see cref='.MobileList'/> .</para></param>
		/// <param name='index'>The index in <paramref name='array'/> where copying begins.</param>
		/// <returns>
		///   <para>None.</para>
		/// </returns>
		/// <exception cref='System.ArgumentException'><para><paramref name='array'/> is multidimensional.</para> <para>-or-</para> <para>The number of elements in the <see cref='.MobileList'/> is greater than the available space between <paramref name='arrayIndex'/> and the end of <paramref name='array'/>.</para></exception>
		/// <exception cref='System.ArgumentNullException'><paramref name='array'/> is <see langword='null'/>. </exception>
		/// <exception cref='System.ArgumentOutOfRangeException'><paramref name='arrayIndex'/> is less than <paramref name='array'/>'s lowbound. </exception>
		/// <seealso cref='System.Array'/>
		/*public void CopyTo(Mobile[] array, int index)
		{
			List.CopyTo(array, index);
		}*/
		
		/// <summary>
		///    <para>Returns the index of a <see cref='.Mobile'/> in 
		///       the <see cref='.MobileList'/> .</para>
		/// </summary>
		/// <param name='value'>The <see cref='.Mobile'/> to locate.</param>
		/// <returns>
		/// <para>The index of the <see cref='.Mobile'/> of <paramref name='value'/> in the 
		/// <see cref='.MobileList'/>, if found; otherwise, -1.</para>
		/// </returns>
		/// <seealso cref='.MobileList.Contains'/>
	/*	public int IndexOf(Mobile val)
		{
			return List.IndexOf(val);
		}
		
		/// <summary>
		/// <para>Inserts a <see cref='.Mobile'/> into the <see cref='.MobileList'/> at the specified index.</para>
		/// </summary>
		/// <param name='index'>The zero-based index where <paramref name='value'/> should be inserted.</param>
		/// <param name=' value'>The <see cref='.Mobile'/> to insert.</param>
		/// <returns><para>None.</para></returns>
		/// <seealso cref='.MobileList.Add'/>
		public void Insert(int index, Mobile val)
		{
			List.Insert(index, val);
		}
		*/
		/// <summary>
		///    <para>Returns an enumerator that can iterate through 
		///       the <see cref='.MobileList'/> .</para>
		/// </summary>
		/// <returns><para>None.</para></returns>
		/// <seealso cref='System.Collections.IEnumerator'/>
		public new MobileEnumerator GetEnumerator()
		{
			return new MobileEnumerator( this );
		}
		
		/// <summary>
		///    <para> Removes a specific <see cref='.Mobile'/> from the 
		///    <see cref='.MobileList'/> .</para>
		/// </summary>
		/// <param name='value'>The <see cref='.Mobile'/> to remove from the <see cref='.MobileList'/> .</param>
		/// <returns><para>None.</para></returns>
		/// <exception cref='System.ArgumentException'><paramref name='value'/> is not found in the Collection. </exception>
		public void Remove( Mobile val )
		{
			if ( val.MapId == 0 )
				this.onEasternKindoms.Remove( val );
			onKalimdor.Remove(val);
		}
		public class MobileEnumerator : IEnumerator
		{
			int cursor = 0;
			int mapId = 0;
			MobileList from;
			
			public MobileEnumerator( MobileList mappings )
			{
				from = mappings;
		//		this.baseEnumerator = temp.GetEnumerator();
			}
			
			public Mobile Current 
			{
				get 
				{
					if ( mapId == 0 )
						return (Mobile)from.onEasternKindoms[ cursor ];
					return (Mobile)from.onKalimdor[ cursor ];
				}
			}
			
			object IEnumerator.Current 
			{
				get 
				{
					if ( mapId == 0 )
						return (Mobile)from.onEasternKindoms[ cursor ];
					return (Mobile)from.onKalimdor[ cursor ];
				}
			}
			
			public bool MoveNext()
			{
				if ( mapId == 0 )
				{
					cursor++;
					if( cursor == from.onEasternKindoms.Count )
					{						
						if ( from.onKalimdor.Count == 0 )
							return false;
						cursor = 0;
						mapId = 1;
						return true;
					}
					return false;
				}
				cursor++;
				if ( from.onKalimdor.Count <= cursor )
					return false;
				return true;
			}
			
			bool IEnumerator.MoveNext()
			{
				if ( mapId == 0 )
				{
					cursor++;
					if( cursor == from.onEasternKindoms.Count )
					{						
						if ( from.onKalimdor.Count == 0 )
							return false;
						cursor = 0;
						mapId = 1;
						return true;
					}
					return false;
				}
				cursor++;
				if ( from.onKalimdor.Count <= cursor )
					return false;
				return true;
			}
			
			public void Reset()
			{
				cursor = 0;
				mapId = 0;
			}
			
			void IEnumerator.Reset()
			{
				cursor = 0;
				mapId = 0;
			}
		}
		/*
		public class MobileEnumerator : IEnumerator
		{
			IEnumerator baseEnumerator;
			IEnumerable temp;
			
			public MobileEnumerator(MobileList mappings)
			{
				this.temp = ((IEnumerable)(mappings));
				this.baseEnumerator = temp.GetEnumerator();
			}
			
			public Mobile Current {
				get {
					return ((Mobile)(baseEnumerator.Current));
				}
			}
			
			object IEnumerator.Current {
				get {
					return baseEnumerator.Current;
				}
			}
			
			public bool MoveNext()
			{
				return baseEnumerator.MoveNext();
			}
			
			bool IEnumerator.MoveNext()
			{
				return baseEnumerator.MoveNext();
			}
			
			public void Reset()
			{
				baseEnumerator.Reset();
			}
			
			void IEnumerator.Reset()
			{
				baseEnumerator.Reset();
			}
		}
		*/
	}
}
