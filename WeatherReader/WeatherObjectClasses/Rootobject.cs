using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReader.WeatherObjectClasses
{
    class Rootobject
    {
        public Main Main { get; set; }
        public City City { get; set; }

        public Rootobject()
        {
            Main = new Main();
            City = new City();
        }
    }
}
