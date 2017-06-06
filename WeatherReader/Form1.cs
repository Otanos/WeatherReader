using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherReader.Dropdown;

namespace WeatherReader
{
    public partial class Form1 : Form
    {
        CityDropdown Cities;
        DataPresenter Presenter;

        public Form1()
        {
            Cities = new CityDropdown();
            Presenter = new DataPresenter();

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cities.Show(CityDropdown);            
        }

        private void Calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            // not implemented
        }

        private void CheckWeatherButton_Click(object sender, EventArgs e)
        {
            if (Cities.IsSelected())
            {
                string cityid = Cities.GetIdByCityName(Cities.Current);

                //Core.RequestHandler.GetWeather(cityid);

                //DataField.AppendText(Core.RequestHandler.GetResponse);                

                Presenter.Deserializer.JSON = @"{
                            'cnt':1,
                            'list':[{
	                            'coord':{
		                            'lon':18.55,
		                            'lat':50.11

                                },
	                            'sys':{
		                            'type':1,
		                               'id':5356,
		'message':0.0095,
		'country':'PL',
		'sunrise':1496630290,
		'sunset':1496688673
	},
	'weather':[{
		'id':800,
		'main':'Clear',
		'description':'clear sky',
		'icon':'01d'
	}],
	'main':{
		'temp':293.71,
		'pressure':1014,
		'humidity':42,
		'temp_min':293.15,
		'temp_max':294.15
	},
	'visibility':10000,
	'wind':{
		'speed':4.1,
		'deg':60
	},
	'clouds':{
		'all':0
	},
	'dt':1496686603,
	'id':7531758,
	'name':'Rybnik'
}]
}";

                //Presenter.Deserializer.JSON = Core.RequestHandler.GetResponse;
                 
                Presenter.Show(DataField);
            }
            else
            {
                MessageBox.Show("City is required", "Action aborted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CityDropdown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cities.Current = CityDropdown.SelectedItem.ToString();
        }
    }
}
