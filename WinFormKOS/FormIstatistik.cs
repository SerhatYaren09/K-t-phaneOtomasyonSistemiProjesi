using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormKOS
{
    public partial class FormIstatistik : Form
    {
        public FormIstatistik()
        {
            InitializeComponent();
        }

        private void FormIstatistik_Load(object sender, EventArgs e)
        {
            chart1.Series["Durum"].Points.AddXY("İstanbul", 15000000);
            chart1.Series["Durum"].Points.AddXY("İzmir", 5000000);
            chart1.Series["Durum"].Points.AddXY("Aydın", 1000000);
        }
    }
}
