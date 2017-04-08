using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReader.Settings
{
    public class SqlSettings
    {
        public static string dataBase = Properties.Resources.Database;

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




    }
}
