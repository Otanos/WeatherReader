using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Settings.SqlSettings.ConnectionTest();

            InitializeComponent();
        }

        private void Calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            // not implemented
        }
    }
}
