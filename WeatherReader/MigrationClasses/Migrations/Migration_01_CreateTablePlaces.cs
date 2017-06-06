using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReader.MigrationClasses.Migrations
{
    class Migration_01_CreateTablePlaces:WeatherObjectClasses.Migration
    {
        public static string Description = "Create Table to store places data";
        public static string Table = "Places";

        private string UpQuery = string.Format(
            @"
                USE {0} 
                GO
                CREATE TABLE {1}
                (                    
                    PlaceId varchar(max),
	                Country varchar(max),
	                City varchar(max)
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

        public override void Up()
        {
            Core.SQL.ExecuteCommandQuery(UpQuery, Core.SQL.QueryType.CreateTable);
        }

        public override void Down()
        {
            Core.SQL.ExecuteCommandQuery(DownQuery, Core.SQL.QueryType.DropTable);
        }
    }
}
