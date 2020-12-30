using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormKOS.Model;

namespace WinFormKOS
{
    public partial class FormOkuyucuEkle : Form
    {
        public FormOkuyucuEkle()
        {
            InitializeComponent();
        }

        int okuyucuId = 0;
        string okuyucuFoto = "";
        private void FormOkuyucuEkle_Load(object sender, EventArgs e)
        {
            okuyucularLoad();
        }
        void okuyucuEkle()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@adi", SqlDbType.VarChar) { Value = txtAd.Text });
            parameters.Add(new SqlParameter("@soyadi", SqlDbType.VarChar) { Value = txtSoyad.Text });
            string cinsiyet = "";
            if(radiobtnErkek.Checked)
            {
                cinsiyet = radiobtnErkek.Text;
            }
            else if(radiobtnKadin.Checked)
            {
                cinsiyet = radiobtnKadin.Text;
            }

            parameters.Add(new SqlParameter("@cinsiyeti", SqlDbType.VarChar) { Value = cinsiyet });
            parameters.Add(new SqlParameter("@sinifi", SqlDbType.VarChar) { Value = txtSinif.Text });
            parameters.Add(new SqlParameter("@okulNo", SqlDbType.VarChar) { Value = txtOkulNo.Text });
            parameters.Add(new SqlParameter("@cepTel", SqlDbType.VarChar) { Value = maskedCepTel.Text });
            parameters.Add(new SqlParameter("@adres", SqlDbType.VarChar) { Value = txtAdres.Text });

          object value = IDataBase.executeScaler("Insert Into okuyucular(adi, soyadi ,cinsiyeti, sinifi, okulNo, cepTel, adres) Values(@adi, @soyadi , @cinsiyeti, @sinifi, @okulNo, @cepTel, @adres) Select @@IDENTITY", parameters);
            okuyucuId = Convert.ToInt32(value);

            fotoSave();

            okuyucularLoad();
            
        }

        void okuyucularLoad()
        {
            dg.DataSource = IDataBase.DataToDataTable("Select * From okuyucular");
        }

        void fotoSave()
        {
            if(!string.IsNullOrEmpty(okuyucuFoto))
            {
                File.Copy(okuyucuFoto, Application.StartupPath + "/profil/" + okuyucuId + ".jpg", true);
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            okuyucuEkle();
        }

        private void btnFotoSec_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "(*jpg)|*.jpg";
            if(openFileDialog.ShowDialog() ==DialogResult.OK)
            {
                okuyucuFoto = openFileDialog.FileName;
                pictureProfil.ImageLocation = okuyucuFoto;
            }
        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                okuyucuId = Convert.ToInt32(dg.Rows[e.RowIndex].Cells["id"].Value);

                pictureProfil.ImageLocation = Helper.profilPath(okuyucuId);

                radiobtnErkek.Checked = false;
                radiobtnKadin.Checked = false;

                foreach (DataRow row in IDataBase.DataToDataTable("Select * From okuyucular Where id = @id", new SqlParameter("@id", SqlDbType.Int) { Value = okuyucuId }).Rows)
                {
                    txtAd.Text = row["adi"].ToString();
                    txtSoyad.Text = row["soyadi"].ToString();
                    string cinsiyet = row["cinsiyeti"].ToString();
                    if(cinsiyet ==radiobtnErkek.Text)
                    {
                        radiobtnErkek.Checked = true;
                    }
                    else if (cinsiyet == radiobtnKadin.Text)
                    {
                        radiobtnKadin.Checked = true;
                    }



                }
                        
             }
        }
    }
}
