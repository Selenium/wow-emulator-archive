using System;
using System.Collections;

namespace WoWDaemon.Database.Cache
{
	
	/// <summary>
	/// Implementors define a caching algorithm.
	/// </summary>
	/// <remarks>
	/// All implementations MUST be threadsafe
	/// </remarks>
	public interface ICache {

		/// <summary>
		/// Gets a Collection of all Key that are in the Cache at the Moment
		/// </summary>
		/// <value>All Keys that are in the Cache</value>

		ICollection Keys
		{
			get;
		}

		/// <summary>
		/// Gets or sets cached data
		/// </summary>
		/// <value>The cached object or <c>null</c></value>
		/// <exception cref="CacheException"></exception>
		object this [object key] 
		{
			get;
			set;
		}
	
	}


}
