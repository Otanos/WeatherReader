using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReader.WeatherObjectClasses
{
    class Main
    {
        public float temp { get; set; }

        public float pressure { get; set; }

        public float humidity { get; set; }

        public float temp_min { get; set; }

        public float temp_max { get; set; }

        public Main()
        {
            temp = 0;
            pressure = 0;
            humidity = 0;
            temp_min = 0;
            temp_max = 0;
        }
    }
}
