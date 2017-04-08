using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReader.MigrationClasses.Migrations
{
    public class Migration_01_CreateTableCity: WeatherObjectClasses.Migration
    {
        public static string Name = "Create Table for Cities";

        private string UpQuery = string.Format
            (@"
                USE {0} 
                GO
                CREATE TABLE Cities
                (                    
	                CityId uniqueidentifier NOT NULL,
	                Name varchar(max),
	                Country varchar(max),
	                CoordId uniqueidentifier NOT NULL
                )            
            "); // Add Primary Key and Foreign Key here

        private string DownQuery = string.Format
            (@"
                USE {0}
                GO
                DROP TABLE Cities
            ");

        public void Up()
        {
            // not implemented
        }

        public void Down()
        {
            // not implemented
        }
    }
}
