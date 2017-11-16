using System;
using System.IO;
using System.Data;
/*using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;*/
using ByteFX.Data.MySqlClient;
using System.Xml;


namespace WoWDaemon.Database.Connection
{
	/// <summary>
	/// Class for Handling the Connection to the ADO.Net Layer of the Databases.
	/// Funktions for loading and storing the complete Dataset are in there.
	/// </summary>
	public class DataConnection
	{
		string connString;
		ConnectionType connType;
       	
		/// <summary>
		/// Constructor to set up a Database
		/// </summary>
		/// <param name="connType">Connection-Type the Database should use</param>
		/// <param name="connString">Connection-String to indicate the Parameters of the Datasource.
		///     XML = Directory where the XML-Files sould be stored
		///     MYSQL = ADO.NET ConnectionString 
		///     MSSQL = ADO.NET ConnectionString 
		///     OLEDB = ADO.NET ConnectionString 
		///     ODBC = ADO.NET ConnectionString 
		/// </param>
		public DataConnection(ConnectionType connType, string connString)
		{
			this.connType = connType;
			this.connString = connString;

			//if Directory has no trailing \ than append it ;-)
			if(connType == ConnectionType.DATABASE_XML)
			{
				if(connString[connString.Length - 1] != '\\')
					this.connString = connString + "\\";

				if(!Directory.Exists(connString))
				{
					try
					{
						Directory.CreateDirectory(connString);
					}
					catch(Exception)
					{
					}
				}
			}	
		}

		/// <summary>
		/// Load an Dataset with the a Table
		/// </summary>
		/// <param name="tableName">Name of the Table to Load in the DataSet</param>
		/// <param name="dataSet">DataSet that sould be filled</param>
		/// <exception cref="DatabaseException"></exception>
		public void LoadDataSet(string tableName, DataSet dataSet)
		{
			dataSet.Clear();
			switch(connType)
			{
				case ConnectionType.DATABASE_XML:
				{
					string filename = connString + tableName + ".xml";
					try
					{
						dataSet.ReadXml(filename);
						dataSet.AcceptChanges();
					}
					catch ( System.IO.FileNotFoundException )
					{
						try
						{
							dataSet.WriteXml(filename);
							dataSet.WriteXmlSchema(connString + tableName + ".xsd");
						}
						catch (Exception ex)
						{
							throw new DatabaseException("Could not create XML-Databasefiles (Directory present ?)", ex);
						}
					}
					break;
				}
				case ConnectionType.DATABASE_MYSQL:
				{
					try
					{
						MySqlConnection conn = new MySqlConnection(connString);
						MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * from `" + tableName + "`", conn);

						adapter.Fill(dataSet.Tables[tableName]);
					}
					catch (Exception ex)
					{
						throw new DatabaseException("Could not load the Database-Table", ex);
					}
					break;
				}
				/*case ConnectionType.DATABASE_MSSQL:
				{
					try
					{
						SqlConnection conn = new SqlConnection(connString);
						SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from " + tableName, conn);

						adapter.Fill(dataSet.Tables[tableName]);
					}
					catch (Exception ex)
					{
						throw new DatabaseException("Could not load the Database-Table", ex);
					}

					break;
				}
				case ConnectionType.DATABASE_ODBC:
				{
					try
					{
						OdbcConnection conn = new OdbcConnection(connString);
						OdbcDataAdapter adapter = new OdbcDataAdapter("SELECT * from " + tableName, conn);

						adapter.Fill(dataSet.Tables[tableName]);
					}
					catch (Exception ex)
					{
						throw new DatabaseException("Could not load the Database-Table", ex);
					}
					break;
				}
				case ConnectionType.DATABASE_OLEDB:
				{
					try
					{
						OleDbConnection conn = new OleDbConnection(connString);
						OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * from " + tableName, conn);

						adapter.Fill(dataSet.Tables[tableName]);
					}
					catch (Exception ex)
					{
						throw new DatabaseException("Could not load the Database-Table", ex);
					}
					break;
				}*/
			}
		}

		/// <summary>
		/// Writes all Changes in a Dataset to the Table
		/// </summary>
		/// <param name="tableName">Name of the Table to update</param>
		/// <param name="dataSet">DataSet set contains the Changes that sould be written</param>
		/// <exception cref="DatabaseException"></exception>

		public void SaveDataSet(string tableName, DataSet dataSet)
		{
			if(dataSet.HasChanges() == false)
				return;

			switch(connType)
			{
				case ConnectionType.DATABASE_XML:
				{
					try
					{
						dataSet.WriteXml(connString + tableName + ".xml");
						dataSet.AcceptChanges();
						dataSet.WriteXmlSchema(connString + tableName + ".xsd");
					}
					catch (Exception e)
					{
						throw new DatabaseException("Could not save Databases in XML-Files!", e);
					}

					break;
				}
				case ConnectionType.DATABASE_MYSQL:
				{
					try
					{
						MySqlConnection conn = new MySqlConnection(connString);
						MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * from `" + tableName + "`", conn);
						MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);

						conn.Open();
						adapter.DeleteCommand = builder.GetDeleteCommand();
						adapter.UpdateCommand = builder.GetUpdateCommand();
						adapter.InsertCommand = builder.GetInsertCommand();

						DataSet changes = dataSet.GetChanges();

						adapter.Update(changes, tableName);
						dataSet.AcceptChanges();
					}
					catch (Exception ex)
					{
						throw new DatabaseException("Could not save the Database-Table", ex);
					}

					break;
				}
/*				case ConnectionType.DATABASE_MSSQL:
				{
					try
					{
						SqlConnection conn = new SqlConnection(connString);
						SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from " + tableName, conn);
						SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

						adapter.DeleteCommand = builder.GetDeleteCommand();
						adapter.UpdateCommand = builder.GetUpdateCommand();
						adapter.InsertCommand = builder.GetInsertCommand();

						DataSet changes = dataSet.GetChanges();

						adapter.Update(changes, tableName);
						dataSet.AcceptChanges();
					}
					catch (Exception ex)
					{
						throw new DatabaseException("Could not save the Database-Table", ex);
					}
					
					break;
				}
				case ConnectionType.DATABASE_ODBC:
				{
					try
					{
						OdbcConnection conn = new OdbcConnection(connString);
						OdbcDataAdapter adapter = new OdbcDataAdapter("SELECT * from " + tableName, conn);
						OdbcCommandBuilder builder = new OdbcCommandBuilder(adapter);

						adapter.DeleteCommand = builder.GetDeleteCommand();
						adapter.UpdateCommand = builder.GetUpdateCommand();
						adapter.InsertCommand = builder.GetInsertCommand();

						DataSet changes = dataSet.GetChanges();

						adapter.Update(changes, tableName);
						dataSet.AcceptChanges();
					}
					catch (Exception ex)
					{
						throw new DatabaseException("Could not save the Database-Table", ex);
					}

					break;
				}
				case ConnectionType.DATABASE_OLEDB:
				{
					try
					{
						OleDbConnection conn = new OleDbConnection(connString);
						OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * from " + tableName, conn);
						OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);

						adapter.DeleteCommand = builder.GetDeleteCommand();
						adapter.UpdateCommand = builder.GetUpdateCommand();
						adapter.InsertCommand = builder.GetInsertCommand();

						DataSet changes = dataSet.GetChanges();

						adapter.Update(changes, tableName);
						dataSet.AcceptChanges();
					}
					catch (Exception ex)
					{
						throw new DatabaseException("Could not save the Database-Table", ex);
					}
					break;
				}*/
			}
		}
	}
}
