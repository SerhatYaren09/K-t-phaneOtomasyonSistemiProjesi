using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormKOS.Model;

namespace WinFormKOS
{
    public partial class FormEmanet : Form
    {
        public FormEmanet()
        {
            InitializeComponent();
        }

        private void FormEmanet_Load(object sender, EventArgs e)
        {
            okuyucularLoad();
        }
        void okuyucularLoad()
        {
            dgOkuyucular.DataSource = IDataBase.DataToDataTable("Select * From okuyucular Where aktif = 1 and adi+' '+soyadi Like @search", new SqlParameter("@search", SqlDbType.VarChar) { Value = string.Format("%(0)%", txtFiltreleOkuyucu.Text) });
        }

        private void txtFiltreleOkuyucu_TextChanged(object sender, EventArgs e)
        {
            okuyucularLoad();
        }
    }
}
