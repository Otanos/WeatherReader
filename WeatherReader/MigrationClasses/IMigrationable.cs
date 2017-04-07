using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReader.MigrationClasses
{
    interface IMigrationable
    {
        void Up();
        void Down();
    }
}
