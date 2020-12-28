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
    public partial class FormKurulum : Form
    {
        public FormKurulum()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKaydol_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtAd.Text) ||
               string.IsNullOrEmpty(txtSoyadi.Text) ||
               string.IsNullOrEmpty(txtKullaniciAdi.Text) ||
               string.IsNullOrEmpty(txtSifre.Text) ||
               string.IsNullOrEmpty(txtSifreTekrar.Text))
            {
                MessageBox.Show("Tüm Alanları Doldurunuz!");
                return;
            }
            if (txtSifre.Text != txtSifreTekrar.Text)
            {
                MessageBox.Show("Şifre Uyuşmuyor!");
                return;
            }
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@adi", SqlDbType.VarChar) { Value = txtAd.Text });
            parameters.Add(new SqlParameter("@soyadi", SqlDbType.VarChar) { Value = txtSoyadi.Text });
            parameters.Add(new SqlParameter("@kullaniciAdi", SqlDbType.VarChar) { Value = txtKullaniciAdi.Text });
            parameters.Add(new SqlParameter("@sifre", SqlDbType.VarChar) { Value = txtSifre.Text });
            IDataBase.executeNonQuery("insert into kullanicilar (adi,soyadi,kullaniciAdi,sifre) Values (@adi ,@soyadi, @kullaniciAdi, @sifre)",parameters);

            FormLogin formLogin = new FormLogin();
            formLogin.Show();

            this.Hide();
        }
    }
}
