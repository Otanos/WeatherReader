using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReader.Dropdown
{
    class CityDropdown
    {
        private Dictionary<string, string> Cities = new Dictionary<string, string>();

        public string Current;

        public CityDropdown()
        {
            List<Settings.PlacesHolder> PlacesJSON = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Settings.PlacesHolder>>(Settings.Places.json);

            foreach (Settings.PlacesHolder Place in PlacesJSON)
            {
                Cities.Add(Place.Id, Place.Name);
            }
        }

        public string GetCityById(string id)
        {
            if(Cities.ContainsKey(id))
            {
                return Cities.Select(x => x.Key.Equals(id)).ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public string GetIdByCityName(string name)
        {
            return Cities
                .ContainsValue(name) ? Cities
                    .Where(v => v.Value == name)
                    .Select(k => k.Key)
                    .FirstOrDefault() : string.Empty;
        }

        public List<string> GetCities()
        {
            return Cities.Select(x => x.Value).ToList();
        }

        public bool IsSelected()
        {
            if(Current == null || Current == string.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Show(System.Windows.Forms.ComboBox CitiesPicker)
        {     
            foreach(string City in GetCities())
            {
                CitiesPicker.Items.Add(City);
            }
        }
    }
}
