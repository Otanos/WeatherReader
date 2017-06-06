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

        public Rootobject Weather;

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
            DataList.Add(string.Format("City: {0}",Weather.City.name));
        }

        public void Show(System.Windows.Forms.RichTextBox Screen)
        {
            GetDeserializedObject();
            
            foreach(string data in DataList)
            {
                Screen.AppendText(data);
            }
        }



    }
}
