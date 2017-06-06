using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherReader.Settings
{
    public class SqlSettings
    {
        public static string dataBase = Properties.Resources.Database;

        private static string _serverName = Properties.Resources.Server;

        private static string _connectionString = string.Format("Server={0};Database={1};Trusted_Connection=True;", _serverName, dataBase);

        private static SqlConnection _connection = new SqlConnection(_connectionString);

        public static SqlConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }


    }
}
