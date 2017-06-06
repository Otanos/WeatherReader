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

                Core.RequestHandler.GetWeather(cityid);

                Presenter.Deserializer.JSON = Core.RequestHandler.GetResponse;

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
