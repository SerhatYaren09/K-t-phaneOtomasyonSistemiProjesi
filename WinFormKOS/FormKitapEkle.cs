using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormKOS.Model;

namespace WinFormKOS
{
    public partial class FormKitapEkle : Form
    {
        public FormKitapEkle()
        {
            InitializeComponent();
        }

        private void FormKitapEkle_Load(object sender, EventArgs e)
        {
            comboBoxFill();
        }
        void comboBoxFill()
        {
            foreach(DataRow row in IDataBase.DataToDataTable("Select * From dolaplar").Rows)
            
                cbbDolap.Items.Add(row["adi"].ToString());

            foreach (DataRow row in IDataBase.DataToDataTable("Select * From turler").Rows)

                cbbTur.Items.Add(row["adi"].ToString());

            foreach (DataRow row in IDataBase.DataToDataTable("Select * From yayinevleri").Rows)

                cbbYayınevi.Items.Add(row["adi"].ToString());

            foreach (DataRow row in IDataBase.DataToDataTable("Select * From yazarlar").Rows)

                cbbYazarAdi.Items.Add(row["adi"].ToString());

        }
    }
}
