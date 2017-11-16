using System;

namespace WoWDaemon.Database.Cache
{

	/// <summary>
	/// Represents any exception from an <c>ICache</c>
	/// </summary>
	public class CacheException : DatabaseException {
		/// <summary>
		/// Constructor for an CacheException that indicates a Problem with the Cache
		/// </summary>
		/// <param name="s">String that describes the Error</param>
		public CacheException(string s) : base(s) { }

		/// <summary>
		/// Constructor for an CacheException that indicates a Problem with the Cache
		/// </summary>
		/// <param name="e">Exception that is the Reason for the Cache-Problem</param>
		public CacheException(Exception e) : base(e) { }
	}

}
