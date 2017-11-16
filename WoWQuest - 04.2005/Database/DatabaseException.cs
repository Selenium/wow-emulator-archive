using System;

namespace WoWDaemon.Database 
{
	public class DatabaseException : Exception
	{
		public DatabaseException(Exception e) : base("", e) { }
		public DatabaseException(string msg, Exception e) : base(msg, e) { }
		public DatabaseException(string msg) : base(msg) { }
	}
}
