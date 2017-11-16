/*
 * Created by SharpDevelop.
 * User: Rv
 * Date: 15/02/2005
 * Time: 22:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using HelperTools;
using System.Net;
using System.Xml;

namespace Server
{
	/// <summary>
	///   A collection that stores <see cref='Account'/> objects.
	/// </summary>
	[Serializable()]
	public class Accounts : CollectionBase 
	{
		#region CONSTRUCTORS
		/// <summary>
		///   Initializes a new instance of <see cref='Accounts'/> based on another <see cref='Accounts'/>.
		/// </summary>
		/// <param name='val'>
		///   A <see cref='Accounts'/> from which the contents are copied
		/// </param>
		public Accounts( Accounts val )
		{
			this.AddRange(val);
		}
		
		/// <summary>
		///   Initializes a new instance of <see cref='Accounts'/> containing any array of <see cref='Account'/> objects.
		/// </summary>
		/// <param name='val'>
		///       A array of <see cref='Account'/> objects with which to intialize the collection
		/// </param>
		public Accounts(Account[] val)
		{
			this.AddRange(val);
		}
		/// <summary>
		///   Initializes a new instance of <see cref='Accounts'/>.
		/// </summary>
		public Accounts()
		{
		}
		public Accounts( string fname )
		{
			this.Load( fname );
		}
		public Accounts( GenericReader gr )
		{
			Deserialize( gr );
		}
		public Account FindAccountByIp( IPAddress e, int port )
		{
			if ( port == 0 )
				return FindAccountByIp( e );
			foreach( Account a in this )
				if ( a.Ip != null && a.Ip.Equals( e ) && ( port == a.Port || a.Port == 0 ) )
					return a;
			return null;
		}
		public Account FindAccountByIp( IPAddress e )
		{
			foreach( Account a in this )
				if ( a.Ip != null && a.Ip.Equals( e ) )
					return a;
			return null;
		}
		public Account FindNotLoggedAccountByIp( IPAddress e )
		{
			foreach( Account a in this )
				if ( a.Ip != null && a.Ip.Equals( e ) && a.SelectedChar == null )
					return a;
			return null;
		}
		#endregion

		public void SendMessageToConnectedGM( string str )
		{
			int t;
			byte []data = new byte[ str.Length + 4 + 4 + 8 + 1 + 2 + 32 ];
			t = 4;
			data[ t++ ] = 0;		
			t = 17;
			Converter.ToBytes( str, data, ref t );

			foreach( Account a in this )
			{
				if ( a.SelectedChar == null )
					continue;
				if ( a.AccessLevel == AccessLevels.PlayerLevel )
					continue;
				int offset = 4;
				Converter.ToBytes( 0xa, data, ref offset );
				Converter.ToBytes( (byte)0, data, ref offset );
				Converter.ToBytes( (UInt64)0, data, ref offset );
				Converter.ToBytes( str.Length + 1, data, ref offset );
				Converter.ToBytes( str, data, ref offset );
				Converter.ToBytes( (short)0, data, ref offset );
				a.Handler.Send( 0x96, data, offset );
			}
		}
		public void BroadCastMessage( string str )
		{
			int t;
			byte []data = new byte[ str.Length + 4 + 4 + 8 + 1 + 2 + 32 ];
			t = 4;
			data[ t++ ] = 0;		
			t = 17;
			Converter.ToBytes( str, data, ref t );

			foreach( Account a in this )
			{
				if ( a.SelectedChar == null )
					continue;
				int offset = 4;
				Converter.ToBytes( 0xa, data, ref offset );
				Converter.ToBytes( (byte)0, data, ref offset );
				Converter.ToBytes( (UInt64)0, data, ref offset );
				Converter.ToBytes( str.Length + 1, data, ref offset );
				Converter.ToBytes( str, data, ref offset );
				Converter.ToBytes( (short)0, data, ref offset );
				a.Handler.Send( 0x96, data, offset );
			}
		}

		
		/// <summary>
		///   Represents the entry at the specified index of the <see cref='Account'/>.
		/// </summary>
		/// <param name='index'>The zero-based index of the entry to locate in the collection.</param>
		/// <value>The entry at the specified index of the collection.</value>
		/// <exception cref='ArgumentOutOfRangeException'><paramref name='index'/> is outside the valid range of indexes for the collection.</exception>
		public Account this[int index] 
		{
			get 
			{
				return ((Account)(List[index]));
			}
			set 
			{
				List[index] = value;
			}
		}

		#region SERIALISATION
		public void Deserialize( GenericReader gr )
		{
			List.Clear();
			if ( !gr.notFound )
			{
				int version = gr.ReadInt();
				int n = gr.ReadInt();
				for(int t = 0;t < n;t++ )
				{
					Add( new Account( gr ) );					
				}
			}
			if ( Count == 0 )
			{				
				Account admin = new Account( "admin", "changeme", AccessLevels.Admin );			
				Add( admin );				
			}
			if ( !gr.notFound )
				gr.Close();
		}
		public void Serialize( GenericWriter gw )
		{
			gw.Write( (int)0 );
			gw.Write( (int)this.Count );
			foreach( Account a in this )
			{
				a.Serialize( gw );
			}
			gw.Close();
		}

		/// <summary> 
		/// Load all accounts from xml file 
		/// </summary> 
		/// <param name="filename">file with accounts</param> 
		/// <returns></returns> 
		public void Load( string filename ) 
		{ 
			if ( System.IO.File.Exists( filename ) ) 
			{ 
				XmlFile file = new XmlFile( filename ); 

				int ver = 1;//readed version, for compatibility (new account list) 

				if ( file.DocumentElement.Attributes["version"]!= null ) 
				{ 
					try { ver = Convert.ToInt32(file.DocumentElement.Attributes["version"]); } 
					catch { ver = 1; } 
					// need corrections, maybe wrong file or bad records? .. etc 
				} 
             
				foreach ( XmlNode node in file.DocumentElement.SelectNodes( "account" ) ) 
				{ 
					Account acc = new Account( ver, node, file ); 
					if ( acc != null ) 
						List.Add( acc ); 
				} 
			} 
			if ( Count == 0 )
			{				
				Account admin = new Account( "admin", "changeme", AccessLevels.Admin );			
				Add( admin );				
			}
		} 

		public void Save( string filename ) 
		{ 
			XmlFile file = new XmlFile( false, "", "accounts" ); 
			int version = 0;          
			file.AddAttribute( file.DocumentElement, "version", version.ToString() );//adding version of accountlist 
          
			foreach ( Account acc in this ) 
			{ 
				file.DocumentElement.AppendChild( acc.Save( file ) ); 
			} 

			file.Save( filename ); 
		} 
		#endregion

		public Account FindByUserName( string user )
		{
			foreach( Account acc in this )
			{
				if ( acc.Username.ToUpper() == user )
					return acc;
			}
			return null;
		}
		/// <summary>
		///   Adds a <see cref='Account'/> with the specified value to the 
		///   <see cref='Accounts'/>.
		/// </summary>
		/// <param name='val'>The <see cref='Account'/> to add.</param>
		/// <returns>The index at which the new element was inserted.</returns>
		/// <seealso cref='Accounts.AddRange'/>
		public int Add(Account val)
		{
			return List.Add(val);
		}
		
		/// <summary>
		///   Copies the elements of an array to the end of the <see cref='Accounts'/>.
		/// </summary>
		/// <param name='val'>
		///    An array of type <see cref='Account'/> containing the objects to add to the collection.
		/// </param>
		/// <seealso cref='Accounts.Add'/>
		public void AddRange(Account[] val)
		{
			for (int i = 0; i < val.Length; i++) 
			{
				this.Add(val[i]);
			}
		}
		
		/// <summary>
		///   Adds the contents of another <see cref='Accounts'/> to the end of the collection.
		/// </summary>
		/// <param name='val'>
		///    A <see cref='Accounts'/> containing the objects to add to the collection.
		/// </param>
		/// <seealso cref='Accounts.Add'/>
		public void AddRange(Accounts val)
		{
			for (int i = 0; i < val.Count; i++)
			{
				this.Add(val[i]);
			}
		}
		
		/// <summary>
		///   Gets a value indicating whether the 
		///    <see cref='Accounts'/> contains the specified <see cref='Account'/>.
		/// </summary>
		/// <param name='val'>The <see cref='Account'/> to locate.</param>
		/// <returns>
		/// <see langword='true'/> if the <see cref='Account'/> is contained in the collection; 
		///   otherwise, <see langword='false'/>.
		/// </returns>
		/// <seealso cref='Accounts.IndexOf'/>
		public bool Contains(Account val)
		{
			return List.Contains(val);
		}
		
		/// <summary>
		///   Copies the <see cref='Accounts'/> values to a one-dimensional <see cref='Array'/> instance at the 
		///    specified index.
		/// </summary>
		/// <param name='array'>The one-dimensional <see cref='Array'/> that is the destination of the values copied from <see cref='Accounts'/>.</param>
		/// <param name='index'>The index in <paramref name='array'/> where copying begins.</param>
		/// <exception cref='ArgumentException'>
		///   <para><paramref name='array'/> is multidimensional.</para>
		///   <para>-or-</para>
		///   <para>The number of elements in the <see cref='Accounts'/> is greater than
		///         the available space between <paramref name='arrayIndex'/> and the end of
		///         <paramref name='array'/>.</para>
		/// </exception>
		/// <exception cref='ArgumentNullException'><paramref name='array'/> is <see langword='null'/>. </exception>
		/// <exception cref='ArgumentOutOfRangeException'><paramref name='arrayIndex'/> is less than <paramref name='array'/>'s lowbound. </exception>
		/// <seealso cref='Array'/>
		public void CopyTo(Account[] array, int index)
		{
			List.CopyTo(array, index);
		}
		
		/// <summary>
		///    Returns the index of a <see cref='Account'/> in 
		///       the <see cref='Accounts'/>.
		/// </summary>
		/// <param name='val'>The <see cref='Account'/> to locate.</param>
		/// <returns>
		///   The index of the <see cref='Account'/> of <paramref name='val'/> in the 
		///   <see cref='Accounts'/>, if found; otherwise, -1.
		/// </returns>
		/// <seealso cref='Accounts.Contains'/>
		public int IndexOf(Account val)
		{
			return List.IndexOf(val);
		}
		
		/// <summary>
		///   Inserts a <see cref='Account'/> into the <see cref='Accounts'/> at the specified index.
		/// </summary>
		/// <param name='index'>The zero-based index where <paramref name='val'/> should be inserted.</param>
		/// <param name='val'>The <see cref='Account'/> to insert.</param>
		/// <seealso cref='Accounts.Add'/>
		public void Insert(int index, Account val)
		{
			List.Insert(index, val);
		}
		
		/// <summary>
		///  Returns an enumerator that can iterate through the <see cref='Accounts'/>.
		/// </summary>
		/// <seealso cref='IEnumerator'/>
		public new AccountEnumerator GetEnumerator()
		{
			return new AccountEnumerator(this);
		}
		
		/// <summary>
		///   Removes a specific <see cref='Account'/> from the <see cref='Accounts'/>.
		/// </summary>
		/// <param name='val'>The <see cref='Account'/> to remove from the <see cref='Accounts'/>.</param>
		/// <exception cref='ArgumentException'><paramref name='val'/> is not found in the Collection.</exception>
		public void Remove(Account val)
		{
			List.Remove(val);
		}
		
		/// <summary>
		///   Enumerator that can iterate through a Accounts.
		/// </summary>
		/// <seealso cref='IEnumerator'/>
		/// <seealso cref='Accounts'/>
		/// <seealso cref='Account'/>
		public class AccountEnumerator : IEnumerator
		{
			IEnumerator baseEnumerator;
			IEnumerable temp;
			
			/// <summary>
			///   Initializes a new instance of <see cref='AccountEnumerator'/>.
			/// </summary>
			public AccountEnumerator(Accounts mappings)
			{
				this.temp = ((IEnumerable)(mappings));
				this.baseEnumerator = temp.GetEnumerator();
			}
			
			/// <summary>
			///   Gets the current <see cref='Account'/> in the <seealso cref='Accounts'/>.
			/// </summary>
			public Account Current 
			{
				get 
				{
					return ((Account)(baseEnumerator.Current));
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
			///   Advances the enumerator to the next <see cref='Account'/> of the <see cref='Accounts'/>.
			/// </summary>
			public bool MoveNext()
			{
				return baseEnumerator.MoveNext();
			}
			
			/// <summary>
			///   Sets the enumerator to its initial position, which is before the first element in the <see cref='Accounts'/>.
			/// </summary>
			public void Reset()
			{
				baseEnumerator.Reset();
			}
		}
	}
}