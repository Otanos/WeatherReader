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

        private JObject responseObject;

        private JToken responseToken;

        private JArray responseArray;

        public string JSON
        {
            get { return json; }
            set { json = value; }
        }

        public Deserializer()
        {
            JSON = string.Empty;

        }

        public Rootobject DeserializeJSON()
        {


            responseObject = JObject.Parse(json);

            Rootobject Weather = new Rootobject();

            //Weather.City.name = responseObject["list"].Children()["name"].Value<string>();        
            //Weather.City.name = responseJSON["list"]["name"].ToString();           
            //Weather.Main = responseObject["list"]["main"].ToObject<Main>();
            //return JsonConvert.DeserializeObject<Rootobject>(json);

            responseArray = (JArray)responseObject.SelectToken("list");

            responseToken = (JToken)responseArray.SelectToken("main");

            Weather = responseToken.ToObject<Rootobject>();

            return Weather;
        }
        
    }
}
