namespace AuthServer
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Net.Sockets;

    internal class DatabaseManager
    {
        private MySqlCommand cmd;
        private MySqlConnection Connection = new MySqlConnection();

        public void CloseConnection()
        {
            this.Connection.Close();
        }

        public bool Connect(string ip, int port, string database, string user, string password)
        {
            this.Connection.ConnectionString = "Data Source=" + ip + ";Port=" + port.ToString() + ";Database='" + database + "';User ID=" + user + ";Password=" + password + ";";
            try
            {
                this.Connection.Open();
            }
            catch (MySqlException exception)
            {
                Console.WriteLine(exception.Message + "\nPlease check options!");
                return false;
            }
            catch (SocketException exception2)
            {
                Console.WriteLine(exception2.Message + "\nPlease check options!");
                return false;
            }
            return true;
        }

        public MySqlDataReader Read(string command)
        {
            this.cmd = new MySqlCommand(command, this.Connection);
            return this.cmd.ExecuteReader();
        }

        public int Write(string command)
        {
            this.cmd = new MySqlCommand(command, this.Connection);
            return this.cmd.ExecuteNonQuery();
        }

        public void WriteSessionKey(string AccName, byte[] hash)
        {
            this.cmd.Connection = this.Connection;
            this.cmd.CommandText = "UPDATE accounts SET sessionkey=?hash WHERE name='" + AccName + "'";
            this.cmd.Parameters.Add("?hash", hash);
            this.cmd.ExecuteNonQuery();
        }
    }
}

