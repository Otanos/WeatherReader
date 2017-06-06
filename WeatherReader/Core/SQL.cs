using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherReader.Settings;

namespace WeatherReader.Core
{
    public class SQL
    {
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
                if (SqlSettings.Connection.State == ConnectionState.Closed)
                {
                    SqlSettings.Connection.Open();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.DialogResult result;

                result = System.Windows.Forms.MessageBox.Show(
                    ex.Message,
                    "Connection failed",
                    System.Windows.Forms.MessageBoxButtons.RetryCancel,
                    System.Windows.Forms.MessageBoxIcon.Error
                    );

                if (result == System.Windows.Forms.DialogResult.Retry)
                {
                    OpenConnection();
                }
            }

        }

        public static void CloseConnection()
        {
            try
            {
                SqlSettings.Connection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error");
            }
        }

        public static bool TableExists(string table)
        {
            string query = string.Format("SELECT * FROM [{0}].[dbo].[{1}]", SqlSettings.dataBase, table);

            try
            {
                ExecuteCommandQuery(query, QueryType.Select);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void ExecuteCommandQuery(string query, QueryType type)
        {
            OpenConnection();

            switch (type)
            {
                case QueryType.CreateTable:

                    ExecuteNonResponseQuery(query);
                    break;

                case QueryType.Select:
                    
                    Reader = ExecuteResponseQuery(query);
                    break;

                case QueryType.DropTable:

                    ExecuteNonResponseQuery(query);
                    break;

                case QueryType.Insert:

                    ExecuteNonResponseQuery(query);
                    break;
            }

            CloseConnection();
        }

        public static void ConnectionTest()
        {
            OpenConnection();

            CloseConnection();
        }

        private static void ExecuteNonResponseQuery(string query)
        {
            try
            {
                _command = new SqlCommand(query, SqlSettings.Connection);
                _command.CommandType = CommandType.Text;
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Query failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static SqlDataReader ExecuteResponseQuery(string query)
        {
            try
            {
                _command = new SqlCommand(query, SqlSettings.Connection);
                _command.CommandType = CommandType.Text;
                return _command.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Query failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
