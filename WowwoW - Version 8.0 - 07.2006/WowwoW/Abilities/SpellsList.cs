using System;
using System.Collections;

namespace Server
{
	/// <summary>
	///   A collection that stores <see cref='BaseAbility'/> objects.
	/// </summary>
	[Serializable()]
	public class SpellsList : CollectionBase 
	{
		
		/// <summary>
		///   Initializes a new instance of <see cref='SpellsList'/>.
		/// </summary>
		public SpellsList()
		{
		}
		
		/// <summary>
		///   Initializes a new instance of <see cref='SpellsList'/> based on another <see cref='SpellsList'/>.
		/// </summary>
		/// <param name='val'>
		///   A <see cref='SpellsList'/> from which the contents are copied
		/// </param>
		public SpellsList(SpellsList val)
		{
			this.AddRange(val);
		}
		
		/// <summary>
		///   Initializes a new instance of <see cref='SpellsList'/> containing any array of <see cref='BaseAbility'/> objects.
		/// </summary>
		/// <param name='val'>
		///       A array of <see cref='BaseAbility'/> objects with which to intialize the collection
		/// </param>
		public SpellsList(BaseAbility[] val)
		{
			this.AddRange(val);
		}
		
		/// <summary>
		///   Represents the entry at the specified index of the <see cref='BaseAbility'/>.
		/// </summary>
		/// <param name='index'>The zero-based index of the entry to locate in the collection.</param>
		/// <value>The entry at the specified index of the collection.</value>
		/// <exception cref='ArgumentOutOfRangeException'><paramref name='index'/> is outside the valid range of indexes for the collection.</exception>
		public BaseAbility this[int index] 
		{
			get 
			{
				return ((BaseAbility)(List[index]));
			}
			set 
			{
				List[index] = value;
			}
		}
		
		/// <summary>
		///   Adds a <see cref='BaseAbility'/> with the specified value to the 
		///   <see cref='SpellsList'/>.
		/// </summary>
		/// <param name='val'>The <see cref='BaseAbility'/> to add.</param>
		/// <returns>The index at which the new element was inserted.</returns>
		/// <seealso cref='SpellsList.AddRange'/>
		public int Add(BaseAbility val)
		{
			return List.Add(val);
		}
		public int Add( int val )
		{
			return List.Add( Abilities.abilities[ val ] );
		}		
		/// <summary>
		///   Copies the elements of an array to the end of the <see cref='SpellsList'/>.
		/// </summary>
		/// <param name='val'>
		///    An array of type <see cref='BaseAbility'/> containing the objects to add to the collection.
		/// </param>
		/// <seealso cref='SpellsList.Add'/>
		public void AddRange(BaseAbility[] val)
		{
			for (int i = 0; i < val.Length; i++) 
			{
				this.Add(val[i]);
			}
		}
		
		/// <summary>
		///   Adds the contents of another <see cref='SpellsList'/> to the end of the collection.
		/// </summary>
		/// <param name='val'>
		///    A <see cref='SpellsList'/> containing the objects to add to the collection.
		/// </param>
		/// <seealso cref='SpellsList.Add'/>
		public void AddRange(SpellsList val)
		{
			for (int i = 0; i < val.Count; i++)
			{
				this.Add(val[i]);
			}
		}
		
		/// <summary>
		///   Gets a value indicating whether the 
		///    <see cref='SpellsList'/> contains the specified <see cref='BaseAbility'/>.
		/// </summary>
		/// <param name='val'>The <see cref='BaseAbility'/> to locate.</param>
		/// <returns>
		/// <see langword='true'/> if the <see cref='BaseAbility'/> is contained in the collection; 
		///   otherwise, <see langword='false'/>.
		/// </returns>
		/// <seealso cref='SpellsList.IndexOf'/>
		public bool Contains(BaseAbility val)
		{
			return List.Contains(val);
		}
		
		/// <summary>
		///   Copies the <see cref='SpellsList'/> values to a one-dimensional <see cref='Array'/> instance at the 
		///    specified index.
		/// </summary>
		/// <param name='array'>The one-dimensional <see cref='Array'/> that is the destination of the values copied from <see cref='SpellsList'/>.</param>
		/// <param name='index'>The index in <paramref name='array'/> where copying begins.</param>
		/// <exception cref='ArgumentException'>
		///   <para><paramref name='array'/> is multidimensional.</para>
		///   <para>-or-</para>
		///   <para>The number of elements in the <see cref='SpellsList'/> is greater than
		///         the available space between <paramref name='arrayIndex'/> and the end of
		///         <paramref name='array'/>.</para>
		/// </exception>
		/// <exception cref='ArgumentNullException'><paramref name='array'/> is <see langword='null'/>. </exception>
		/// <exception cref='ArgumentOutOfRangeException'><paramref name='arrayIndex'/> is less than <paramref name='array'/>'s lowbound. </exception>
		/// <seealso cref='Array'/>
		public void CopyTo(BaseAbility[] array, int index)
		{
			List.CopyTo(array, index);
		}
		
		/// <summary>
		///    Returns the index of a <see cref='BaseAbility'/> in 
		///       the <see cref='SpellsList'/>.
		/// </summary>
		/// <param name='val'>The <see cref='BaseAbility'/> to locate.</param>
		/// <returns>
		///   The index of the <see cref='BaseAbility'/> of <paramref name='val'/> in the 
		///   <see cref='SpellsList'/>, if found; otherwise, -1.
		/// </returns>
		/// <seealso cref='SpellsList.Contains'/>
		public int IndexOf(BaseAbility val)
		{
			return List.IndexOf(val);
		}
		
		/// <summary>
		///   Inserts a <see cref='BaseAbility'/> into the <see cref='SpellsList'/> at the specified index.
		/// </summary>
		/// <param name='index'>The zero-based index where <paramref name='val'/> should be inserted.</param>
		/// <param name='val'>The <see cref='BaseAbility'/> to insert.</param>
		/// <seealso cref='SpellsList.Add'/>
		public void Insert(int index, BaseAbility val)
		{
			List.Insert(index, val);
		}
		
		/// <summary>
		///  Returns an enumerator that can iterate through the <see cref='SpellsList'/>.
		/// </summary>
		/// <seealso cref='IEnumerator'/>
		public new BaseAbilityEnumerator GetEnumerator()
		{
			return new BaseAbilityEnumerator(this);
		}
		
		/// <summary>
		///   Removes a specific <see cref='BaseAbility'/> from the <see cref='SpellsList'/>.
		/// </summary>
		/// <param name='val'>The <see cref='BaseAbility'/> to remove from the <see cref='SpellsList'/>.</param>
		/// <exception cref='ArgumentException'><paramref name='val'/> is not found in the Collection.</exception>
		public void Remove(BaseAbility val)
		{
			List.Remove(val);
		}
		
		/// <summary>
		///   Enumerator that can iterate through a SpellsList.
		/// </summary>
		/// <seealso cref='IEnumerator'/>
		/// <seealso cref='SpellsList'/>
		/// <seealso cref='BaseAbility'/>
		public class BaseAbilityEnumerator : IEnumerator
		{
			IEnumerator baseEnumerator;
			IEnumerable temp;
			
			/// <summary>
			///   Initializes a new instance of <see cref='BaseAbilityEnumerator'/>.
			/// </summary>
			public BaseAbilityEnumerator(SpellsList mappings)
			{
				this.temp = ((IEnumerable)(mappings));
				this.baseEnumerator = temp.GetEnumerator();
			}
			
			/// <summary>
			///   Gets the current <see cref='BaseAbility'/> in the <seealso cref='SpellsList'/>.
			/// </summary>
			public BaseAbility Current 
			{
				get 
				{
					return ((BaseAbility)(baseEnumerator.Current));
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
			///   Advances the enumerator to the next <see cref='BaseAbility'/> of the <see cref='SpellsList'/>.
			/// </summary>
			public bool MoveNext()
			{
				return baseEnumerator.MoveNext();
			}
			
			/// <summary>
			///   Sets the enumerator to its initial position, which is before the first element in the <see cref='SpellsList'/>.
			/// </summary>
			public void Reset()
			{
				baseEnumerator.Reset();
			}
		}
	}
}