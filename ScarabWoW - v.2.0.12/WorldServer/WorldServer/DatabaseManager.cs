namespace WorldServer
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Net.Sockets;

    internal class DatabaseManager
    {
        private MySqlCommand cmd;
        public MySqlConnection Connection = new MySqlConnection();

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
    }
}

