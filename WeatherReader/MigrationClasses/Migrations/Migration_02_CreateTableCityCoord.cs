﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReader.MigrationClasses.Migrations
{
    class Migration_02_CreateTableCityCoord : WeatherObjectClasses.Migration
    {
        public static string Name = "Create Table to store City Coords data";
        public static string Table = "CityCoords";

        private string UpQuery = string.Format(
            @"
                USE {0} 
                GO
                CREATE TABLE {1}
                (                    
	                CoordId uniqueidentifier NOT NULL,
	                Latitude float,
	                Longitude float
                )"
            , Settings.SqlSettings.dataBase
            , Table); // Add Primary Key and Foreign Key here

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
