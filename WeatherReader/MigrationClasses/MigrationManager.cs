using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherReader.MigrationClasses.Migrations;

namespace WeatherReader.WeatherObjectClasses
{
    class MigrationManager
    {
        public List<MigrationClasses.IMigrationable> Migrations;


        public MigrationManager()
        {
            Migrations = new List<MigrationClasses.IMigrationable>();

            Migrations.Add(new Migration_00_CreateTableMigration());

            Migrations.Add(new Migration_01_CreateTableCity());

            Migrations.Add(new Migration_02_CreateTableCityCoord());

            Migrations.Add(new Migration_03_CreateTableWinds());
        }

        private int GetMigrationIndex()
        {
            int index = 0;

            string query = string.Format(@"
                USE {0}
                GO
                SELECT * FROM Migrations"
                , Settings.SqlSettings.dataBase);

            Settings.SqlSettings.ExecuteCommandQuery(query, Settings.SqlSettings.QueryType.Select);

            if (Settings.SqlSettings.Reader.HasRows)
            {
                while (Settings.SqlSettings.Reader.Read())
                {
                    index++;
                }

                return index;
            }
            else
            {
                return 0;
            } 
        }

        public void RunMigrationsUp(int index)
        {
            for(int x=0; x < index; x++)
            {
                Migrations[x].Up();
            }
        }

        public void RunMigrationsDown(int index)
        {
            for(int x=index; x >= 0; x--)
            {
                Migrations[x].Down();
            }
        }



    }
}
