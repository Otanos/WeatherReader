using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReader.Settings
{
    public class SqlSettings
    {
        public static string dataBase = Properties.Resources.Database;

        private static string _serverName = Properties.Resources.Server;

        private static string _connectionString = string.Format("Server={0};Database={1};Trusted_Connection=True;", _serverName, dataBase);

        private static SqlConnection _connection = new SqlConnection(_connectionString);

        private static SqlCommand _command;

        public static SqlDataReader Reader;

        public enum QueryType
        {
            Select,
            Insert,
            Update,
            CreateDatabase,
            DropDatabase,
            CreateTable,
            DropTable
        }

        public static void OpenConnection()
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.DialogResult result;

                result = System.Windows.Forms.MessageBox.Show(
                    ex.Message, 
                    "Connection failed", 
                    System.Windows.Forms.MessageBoxButtons.RetryCancel, 
                    System.Windows.Forms.MessageBoxIcon.Error
                    );
                
                if(result == System.Windows.Forms.DialogResult.Retry)
                {
                    OpenConnection();
                }                
            }
            
        }

        public static void CloseConnection()
        {
            try
            {
                _connection.Close();
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error");
            }
        }

        public static void ExecuteCommandQuery(string query, QueryType type)
        {
            OpenConnection();

            switch (type)
            {
                case QueryType.CreateTable:

                    _command = new SqlCommand(query, _connection);
                    _command.CommandType = CommandType.Text;
                    _command.ExecuteNonQuery();

                    break;

                case QueryType.Select:

                    _command = new SqlCommand(query, _connection);
                    _command.CommandType = CommandType.Text;
                    Reader = _command.ExecuteReader();

                    break;

                case QueryType.DropTable:

                    _command = new SqlCommand(query, _connection);
                    _command.CommandType = CommandType.Text;
                    _command.ExecuteNonQuery();

                    break;

                case QueryType.Insert:
                    //not implemented
                    break;
            }
            
            CloseConnection();
        }

        public static void ConnectionTest()
        {
            OpenConnection();

            CloseConnection();
        }


    }
}
