using System;

namespace WoWDaemon.Database.Connection
{
	/// <summary>
	/// Enum what Datatstorage should be used
	/// </summary>
	public enum ConnectionType 
	{
		DATABASE_XML,		//Use XML-Files as Database
		DATABASE_MYSQL,		//Use the internal MySQL-Driver for Database
		/*DATABASE_MSSQL,		//Use Microsoft SQL-Server
		DATABASE_ODBC,		//Use an ODBC-Datasource
		DATABASE_OLEDB		//Use an OLEDB-Datasource*/
	}
}
