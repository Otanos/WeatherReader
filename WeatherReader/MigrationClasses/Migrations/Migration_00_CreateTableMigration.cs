using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReader.MigrationClasses.Migrations
{
    class Migration_00_CreateTableMigration : WeatherObjectClasses.Migration
    {
        public static string Name = "Create Table to store all migration records";
        public static string Table = "Migrations";

        private string UpQuery = string.Format(
            @"
                USE {0} 
                GO
                CREATE TABLE {1}
                (                    
	                MigrationId uniqueidentifier NOT NULL,
	                Table varchar(100),
	                Description varchar(max)
                )"
            , Settings.SqlSettings.dataBase
            , Table);

        private string DownQuery = string.Format
            (@"
                USE {0}
                GO
                DROP TABLE {1}"
            , Settings.SqlSettings.dataBase
            , Table);

        public void Up()
        {
            Settings.SqlSettings.ExecuteCommandQuery(UpQuery, Settings.SqlSettings.QueryType.CreateTable);
        }

        public void Down()
        {
            Settings.SqlSettings.ExecuteCommandQuery(DownQuery, Settings.SqlSettings.QueryType.DropTable);
        }
    }
}
