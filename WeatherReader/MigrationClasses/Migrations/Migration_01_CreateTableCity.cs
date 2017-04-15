using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReader.MigrationClasses.Migrations
{
    public class Migration_01_CreateTableCity : WeatherObjectClasses.Migration
    {
        public static string Name = "Create Table to store Cities data";

        private string UpQuery = string.Format(
            @"
                USE {0} 
                GO
                CREATE TABLE Cities
                (                    
	                CityId uniqueidentifier NOT NULL,
	                Name varchar(max),
	                Country varchar(max),
	                CoordId uniqueidentifier NOT NULL
                )"
            , Settings.SqlSettings.dataBase); // Add Primary Key and Foreign Key here

        private string DownQuery = string.Format
            (@"
                USE {0}
                GO
                DROP TABLE Cities"
            , Settings.SqlSettings.dataBase);

        public void Up()
        {
            Settings.SqlSettings.ExecuteCommandQuery(UpQuery);
        }

        public void Down()
        {
            Settings.SqlSettings.ExecuteCommandQuery(DownQuery);
        }
    }
}
