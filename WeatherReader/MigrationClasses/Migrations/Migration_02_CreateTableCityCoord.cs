using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReader.MigrationClasses.Migrations
{
    class Migration_02_CreateTableCityCoord : WeatherObjectClasses.Migration
    {
        public static string Name = "Create Table to store City Coords data";

        private string UpQuery = string.Format(
            @"
                USE {0} 
                GO
                CREATE TABLE CityCoords
                (                    
	                CoordId uniqueidentifier NOT NULL,
	                Latitude float,
	                Longitude float
                )"
            , Settings.SqlSettings.dataBase); // Add Primary Key and Foreign Key here

        private string DownQuery = string.Format
            (@"
                USE {0}
                GO
                DROP TABLE CityCoords"
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
