using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherReader.WeatherObjectClasses;

namespace WeatherReader
{
    class DataPresenter
    {
        public Core.Deserializer Deserializer;

        private List<string> DataList;

        public RootWeather Weather;

        public DataPresenter()
        {
            DataList = new List<string>();
            Deserializer = new Core.Deserializer();
        }

        private void GetDeserializedObject()
        {
            Weather = Deserializer.DeserializeJSON();
        }

        private void PrepareList()
        {
            //DataList.Add(string.Format("City: {0}",Weather.City.name));
        }

        public void Show(System.Windows.Forms.RichTextBox Screen)
        {
            GetDeserializedObject();

            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(Weather.List.Select(dt => dt.Dt).FirstOrDefault());

            int celcius = ((int)Weather.List.Select(t => t.Main.Temp).FirstOrDefault() - 273);
           
            string ToShow = string.Format(@"
            CURRENT WEATHER
            Date: {0}
            Time: {1}
            City: {2}
            Description: {3}
            Temperature (Kelvins): {4} K
            Temperature (Celcius): {5} C
            Pressure: {6} hPa
            Humidity: {7} %
            Clouds: {8} %
            Wind Speed: {9} m/s",
                dtDateTime.Date,
                dtDateTime.TimeOfDay,
                Weather.List.Select(x => x.Name).FirstOrDefault(),
                Weather.List.Select(d => d.Weather.Select(m => m.Description).FirstOrDefault()).FirstOrDefault(),
                Weather.List.Select(t => t.Main.Temp).FirstOrDefault(),
                celcius,
                Weather.List.Select(p => p.Main.Pressure).FirstOrDefault(),
                Weather.List.Select(h => h.Main.Humidity).FirstOrDefault(),
                Weather.List.Select(c => c.Clouds.All).FirstOrDefault(),
                Weather.List.Select(w => w.Wind.Speed).FirstOrDefault()
                );

            Screen.AppendText(ToShow);
        }



    }
}
