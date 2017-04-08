using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReader.WeatherObjectClasses
{
    public class List
    {
        public Main main { get; set; }
        public Weather[] weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public string dt_txt { get; set; }
    }
}
