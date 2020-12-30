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
    public partial class FormOkuyucuEkle : Form
    {
        public FormOkuyucuEkle()
        {
            InitializeComponent();
        }

        int okuyucuId = 0;
        private void FormOkuyucuEkle_Load(object sender, EventArgs e)
        {

        }
        void okuyucuEkle()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@adi", SqlDbType.Int) { Value = txtAd.Text });
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

          object value = IDataBase.executeScaler("Inser Into okuyucular (adi, soyadi ,cinsiyeti, sinifi, okulNo, cepTel, adres) Values (@adi, @soyadi , @cinsiyeti, @sinifi, @okulNo, @cepTel, @adres)", parameters);
            okuyucuId = Convert.ToInt32(value);

            MessageBox.Show(okuyucuId.ToString());
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            okuyucuEkle();
        }
    }
}
