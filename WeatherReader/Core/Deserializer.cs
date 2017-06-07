using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherReader.WeatherObjectClasses;

namespace WeatherReader.Core
{
    class Deserializer
    {
        private string json;

        public string JSON
        {
            get { return json; }
            set { json = value; }
        }

        public Deserializer()
        {
            JSON = string.Empty;
        }

        public RootWeather DeserializeJSON()
        {
            var RootWeather = JsonConvert.DeserializeObject<RootWeather>(json);

            return RootWeather;
        }
        
    }
}
