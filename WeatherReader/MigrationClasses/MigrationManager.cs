using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherReader.MigrationClasses.Migrations;

namespace WeatherReader.WeatherObjectClasses
{
    class MigrationManager
    {
        public List<MigrationClasses.IMigrationable> Migrations;

        public MigrationManager()
        {
            Migrations = new List<MigrationClasses.IMigrationable>();
            
            Migrations.Add(new Migration_01_CreateTablePlaces());
            Migrations.Add(new Migration_02_CreateTableWeather());
        }

        public void RunMigrationsUp()
        {
            try
            {
                if (Core.SQL.TableExists("Places"))
                {
                    foreach(MigrationClasses.IMigrationable DataMigration in Migrations)
                    {
                        DataMigration.Up();
                    }
                }             
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ". Check your connection with SQL Server", "Migration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}
