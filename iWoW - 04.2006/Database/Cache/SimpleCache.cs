using System;
using System.Collections;

namespace WoWDaemon.Database.Cache
{

	/// <summary>
	/// A simple <c>Hashtable</c> based cache
	/// </summary>
	public class SimpleCache : ICache 
	{
		private Hashtable cache = new Hashtable();

		/// <summary>
		/// Return's all Keys that are in the Stored in the Cache
		/// </summary>
		/// <value>All Keys that are in the Cache</value>
		public ICollection Keys 
		{
			get 
			{
				return cache.Keys;
			}
		}

		/// <summary>
		/// Gets or sets cached data
		/// </summary>
		/// <value>The cached object or <c>null</c></value>
		public object this[object key] 
		{
			get 
			{
				WeakReference wr = cache[key] as WeakReference;
				if (wr == null || !wr.IsAlive) 
				{
					cache.Remove(key);
					return null;
				}
				return wr.Target; 
			}
			set 
			{ 
				if(value == null)
					cache.Remove(key);
				cache[key] = new WeakReference(value);
			}
		}
	}
}