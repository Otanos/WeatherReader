using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReader.Settings
{
    public class SqlSettings
    {
        public string Database;

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
