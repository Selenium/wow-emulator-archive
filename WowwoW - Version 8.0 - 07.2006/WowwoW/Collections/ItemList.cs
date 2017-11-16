/*
 * Created by SharpDevelop.
 * User: BIOSTAT26
 * Date: 18/01/2005
 * Time: 14:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;


namespace Server.Items
{
	/// <summary>
	///     <para>
	///       A collection that stores <see cref='.Item'/> objects.
	///    </para>
	/// </summary>
	/// <seealso cref='.ItemList'/>
	[Serializable()]
	public class ItemList : CollectionBase {
		
		/// <summary>
		///     <para>
		///       Initializes a new instance of <see cref='.ItemList'/>.
		///    </para>
		/// </summary>
		public ItemList()
		{
		}
		
		/// <summary>
		///     <para>
		///       Initializes a new instance of <see cref='.ItemList'/> based on another <see cref='.ItemList'/>.
		///    </para>
		/// </summary>
		/// <param name='value'>
		///       A <see cref='.ItemList'/> from which the contents are copied
		/// </param>
		public ItemList(ItemList val)
		{
			this.AddRange(val);
		}
		
		/// <summary>
		///     <para>
		///       Initializes a new instance of <see cref='.ItemList'/> containing any array of <see cref='.Item'/> objects.
		///    </para>
		/// </summary>
		/// <param name='value'>
		///       A array of <see cref='.Item'/> objects with which to intialize the collection
		/// </param>
		public ItemList(Item[] val)
		{
			this.AddRange(val);
		}
		
		/// <summary>
		/// <para>Represents the entry at the specified index of the <see cref='.Item'/>.</para>
		/// </summary>
		/// <param name='index'><para>The zero-based index of the entry to locate in the collection.</para></param>
		/// <value>
		///    <para> The entry at the specified index of the collection.</para>
		/// </value>
		/// <exception cref='System.ArgumentOutOfRangeException'><paramref name='index'/> is outside the valid range of indexes for the collection.</exception>
		public Item this[int index] {
			get {
				return ((Item)(List[index]));
			}
			set {
				List[index] = value;
			}
		}
		
		/// <summary>
		///    <para>Adds a <see cref='.Item'/> with the specified value to the 
		///    <see cref='.ItemList'/> .</para>
		/// </summary>
		/// <param name='value'>The <see cref='.Item'/> to add.</param>
		/// <returns>
		///    <para>The index at which the new element was inserted.</para>
		/// </returns>
		/// <seealso cref='.ItemList.AddRange'/>
		public int Add(Item val)
		{
			return List.Add(val);
		}
		
		/// <summary>
		/// <para>Copies the elements of an array to the end of the <see cref='.ItemList'/>.</para>
		/// </summary>
		/// <param name='value'>
		///    An array of type <see cref='.Item'/> containing the objects to add to the collection.
		/// </param>
		/// <returns>
		///   <para>None.</para>
		/// </returns>
		/// <seealso cref='.ItemList.Add'/>
		public void AddRange(Item[] val)
		{
			for (int i = 0; i < val.Length; i++) {
				this.Add(val[i]);
			}
		}
		
		/// <summary>
		///     <para>
		///       Adds the contents of another <see cref='.ItemList'/> to the end of the collection.
		///    </para>
		/// </summary>
		/// <param name='value'>
		///    A <see cref='.ItemList'/> containing the objects to add to the collection.
		/// </param>
		/// <returns>
		///   <para>None.</para>
		/// </returns>
		/// <seealso cref='.ItemList.Add'/>
		public void AddRange(ItemList val)
		{
			for (int i = 0; i < val.Count; i++)
			{
				this.Add(val[i]);
			}
		}
		
		/// <summary>
		/// <para>Gets a value indicating whether the 
		///    <see cref='.ItemList'/> contains the specified <see cref='.Item'/>.</para>
		/// </summary>
		/// <param name='value'>The <see cref='.Item'/> to locate.</param>
		/// <returns>
		/// <para><see langword='true'/> if the <see cref='.Item'/> is contained in the collection; 
		///   otherwise, <see langword='false'/>.</para>
		/// </returns>
		/// <seealso cref='.ItemList.IndexOf'/>
		public bool Contains(Item val)
		{
			return List.Contains(val);
		}
		
		/// <summary>
		/// <para>Copies the <see cref='.ItemList'/> values to a one-dimensional <see cref='System.Array'/> instance at the 
		///    specified index.</para>
		/// </summary>
		/// <param name='array'><para>The one-dimensional <see cref='System.Array'/> that is the destination of the values copied from <see cref='.ItemList'/> .</para></param>
		/// <param name='index'>The index in <paramref name='array'/> where copying begins.</param>
		/// <returns>
		///   <para>None.</para>
		/// </returns>
		/// <exception cref='System.ArgumentException'><para><paramref name='array'/> is multidimensional.</para> <para>-or-</para> <para>The number of elements in the <see cref='.ItemList'/> is greater than the available space between <paramref name='arrayIndex'/> and the end of <paramref name='array'/>.</para></exception>
		/// <exception cref='System.ArgumentNullException'><paramref name='array'/> is <see langword='null'/>. </exception>
		/// <exception cref='System.ArgumentOutOfRangeException'><paramref name='arrayIndex'/> is less than <paramref name='array'/>'s lowbound. </exception>
		/// <seealso cref='System.Array'/>
		public void CopyTo(Item[] array, int index)
		{
			List.CopyTo(array, index);
		}
		
		/// <summary>
		///    <para>Returns the index of a <see cref='.Item'/> in 
		///       the <see cref='.ItemList'/> .</para>
		/// </summary>
		/// <param name='value'>The <see cref='.Item'/> to locate.</param>
		/// <returns>
		/// <para>The index of the <see cref='.Item'/> of <paramref name='value'/> in the 
		/// <see cref='.ItemList'/>, if found; otherwise, -1.</para>
		/// </returns>
		/// <seealso cref='.ItemList.Contains'/>
		public int IndexOf(Item val)
		{
			return List.IndexOf(val);
		}
		
		/// <summary>
		/// <para>Inserts a <see cref='.Item'/> into the <see cref='.ItemList'/> at the specified index.</para>
		/// </summary>
		/// <param name='index'>The zero-based index where <paramref name='value'/> should be inserted.</param>
		/// <param name=' value'>The <see cref='.Item'/> to insert.</param>
		/// <returns><para>None.</para></returns>
		/// <seealso cref='.ItemList.Add'/>
		public void Insert(int index, Item val)
		{
			List.Insert(index, val);
		}
		
		/// <summary>
		///    <para>Returns an enumerator that can iterate through 
		///       the <see cref='.ItemList'/> .</para>
		/// </summary>
		/// <returns><para>None.</para></returns>
		/// <seealso cref='System.Collections.IEnumerator'/>
		public new ItemEnumerator GetEnumerator()
		{
			return new ItemEnumerator(this);
		}
		
		/// <summary>
		///    <para> Removes a specific <see cref='.Item'/> from the 
		///    <see cref='.ItemList'/> .</para>
		/// </summary>
		/// <param name='value'>The <see cref='.Item'/> to remove from the <see cref='.ItemList'/> .</param>
		/// <returns><para>None.</para></returns>
		/// <exception cref='System.ArgumentException'><paramref name='value'/> is not found in the Collection. </exception>
		public void Remove(Item val)
		{
			List.Remove(val);
		}
		
		public class ItemEnumerator : IEnumerator
		{
			IEnumerator baseEnumerator;
			IEnumerable temp;
			
			public ItemEnumerator(ItemList mappings)
			{
				this.temp = ((IEnumerable)(mappings));
				this.baseEnumerator = temp.GetEnumerator();
			}
			
			public Item Current {
				get {
					return ((Item)(baseEnumerator.Current));
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
	}
}
