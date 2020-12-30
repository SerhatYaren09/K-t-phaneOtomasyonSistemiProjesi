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
    public partial class FormKitapEkle : Form
    {
        public FormKitapEkle()
        {
            InitializeComponent();
        }
       int kitapId = 0;
        private void FormKitapEkle_Load(object sender, EventArgs e)
        {
            comboBoxFill();
            kitaplarLoad();
        }
        void comboBoxFill()
        {
            foreach (DataRow row in IDataBase.DataToDataTable("Select * From dolaplar").Rows)

                cbbDolap.Items.Add(row["adi"].ToString());

            foreach (DataRow row in IDataBase.DataToDataTable("Select * From turler").Rows)

                cbbTur.Items.Add(row["adi"].ToString());

            foreach (DataRow row in IDataBase.DataToDataTable("Select * From yayinevleri").Rows)

                cbbYayınevi.Items.Add(row["adi"].ToString());

            foreach (DataRow row in IDataBase.DataToDataTable("Select * From yazarlar").Rows)

                cbbYazarAdi.Items.Add(row["adi"].ToString());
               
        }

        void kitaplarLoad()
        {
            //Filtreleme
            dg.DataSource = IDataBase.DataToDataTable("Select * From kitaplar Where yazarAdi+' '+kitapAdi Like @search", new SqlParameter("@search", SqlDbType.VarChar) { Value = string.Format("%{0}%", txtFiltrele.Text) });
            dg.Columns["id"].Visible = false;
        }

        int getKayitNo()
        {
            foreach (DataRow row in IDataBase.DataToDataTable("Select ISNULL(MAX(kayitNo), 0) + 1 From kitaplar").Rows)
            {
                return Convert.ToInt32(row[0]);
            }
            return 1;
        }


            void kitapEkle()
            {
            int kayitNo = getKayitNo();
              

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@kayitNo", SqlDbType.Int) { Value = kayitNo });
                parameters.Add(new SqlParameter("@kitapAdi", SqlDbType.VarChar) { Value = txtKitapAdi.Text });
                parameters.Add(new SqlParameter("@yazarAdi", SqlDbType.VarChar) { Value = cbbYazarAdi.Text });
                parameters.Add(new SqlParameter("@yayinevi", SqlDbType.VarChar) { Value = cbbYayınevi.Text });
                parameters.Add(new SqlParameter("@basimyili", SqlDbType.VarChar) { Value = txtBasimYil.Text });
                parameters.Add(new SqlParameter("@sayfaSayisi", SqlDbType.VarChar) { Value = txtSayfaSayisi.Text });
                parameters.Add(new SqlParameter("@tur", SqlDbType.VarChar) { Value = cbbTur.Text });
                parameters.Add(new SqlParameter("@aciklama", SqlDbType.VarChar) { Value = txtAciklama.Text });
                parameters.Add(new SqlParameter("@dolap", SqlDbType.VarChar) { Value = cbbDolap.Text });
                parameters.Add(new SqlParameter("@raf", SqlDbType.VarChar) { Value = txtRaf.Text });
                parameters.Add(new SqlParameter("@sira", SqlDbType.VarChar) { Value = txtSira.Text });

            IDataBase.executeNonQuery("Insert Into kitaplar (kayitNo, kitapAdi, yazarAdi, yayinevi, basimyili, sayfaSayisi, tur, aciklama, dolap, raf, sira) Values(@kayitNo, @kitapAdi, @yazarAdi, @yayinevi, @basimyili, @sayfaSayisi, @tur, @aciklama, @dolap, @raf, @sira)", parameters);

            txtKayitNo.Text = kayitNo.ToString();
            
            kitaplarLoad();
            MessageBox.Show("Kitap ekleme işlemi başarılı");
            }

        void kitapGuncelle()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@kitapAdi", SqlDbType.VarChar) { Value = txtKitapAdi.Text });
            parameters.Add(new SqlParameter("@yazarAdi", SqlDbType.VarChar) { Value = cbbYazarAdi.Text });
            parameters.Add(new SqlParameter("@yayinevi", SqlDbType.VarChar) { Value = cbbYayınevi.Text });
            parameters.Add(new SqlParameter("@basimyili", SqlDbType.VarChar) { Value = txtBasimYil.Text });
            parameters.Add(new SqlParameter("@sayfaSayisi", SqlDbType.VarChar) { Value = txtSayfaSayisi.Text });
            parameters.Add(new SqlParameter("@tur", SqlDbType.VarChar) { Value = cbbTur.Text });
            parameters.Add(new SqlParameter("@aciklama", SqlDbType.VarChar) { Value = txtAciklama.Text });
            parameters.Add(new SqlParameter("@dolap", SqlDbType.VarChar) { Value = cbbDolap.Text });
            parameters.Add(new SqlParameter("@raf", SqlDbType.VarChar) { Value = txtRaf.Text });
            parameters.Add(new SqlParameter("@sira", SqlDbType.VarChar) { Value = txtSira.Text });
            parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = kitapId});

            IDataBase.executeNonQuery("Update kitaplar Set kitapAdi = @kitapAdi, yazarAdi = @yazarAdi, yayinevi = @yayinevi, basimyili = @basimyili, sayfaSayisi = @sayfaSayisi, tur = @tur, aciklama = @aciklama, dolap = @dolap, raf = @raf, sira = @sira Where id = @id", parameters);
            kitaplarLoad();
            MessageBox.Show("Kitap Güncelleme işlemi başarılı");
        }

        void kitapSil()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = kitapId });
            IDataBase.executeNonQuery("Delete From kitaplar Where id = @id", parameters);
            kitaplarLoad();
            temizle();
            MessageBox.Show("Kitap silme işlemi başarılı");
        }

        void temizle()
        {
            kitapId = 0;

            foreach (var item in tableLayoutPanel1.Controls)
            {
                if(item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
                if(item is ComboBox)
                {
                    ((ComboBox)item).Text = "";
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            

            if(kitapId > 0)
            {
                kitapGuncelle();
            }
            else
            {
                kitapEkle();
            }
        }

        private void dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                kitapId = Convert.ToInt32(dg.Rows[e.RowIndex].Cells["id"].Value);
                foreach (DataRow row in IDataBase.DataToDataTable("Select * From kitaplar Where aktif = 1 and id = @id", new SqlParameter("@id", SqlDbType.Int) { Value = kitapId }).Rows)
                {
                    txtKayitNo.Text = row["kayitNo"].ToString();
                    txtKitapAdi.Text = row["kitapAdi"].ToString();
                    cbbYazarAdi.Text = row["yazarAdi"].ToString();
                    cbbYayınevi.Text = row["yayinevi"].ToString();
                    txtBasimYil.Text = row["basimYili"].ToString();
                    txtSayfaSayisi.Text = row["basimYili"].ToString();
                    cbbTur.Text = row["tur"].ToString();
                    txtAciklama.Text = row["aciklama"].ToString();
                    cbbDolap.Text = row["dolap"].ToString();
                    txtRaf.Text = row["raf"].ToString();
                    txtSira.Text = row["sira"].ToString();
                }
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if(kitapId > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçili kitabı silmek istediğinize emin misiniz?", "Kitap Sil", MessageBoxButtons.YesNo);
                if(dialogResult == DialogResult.Yes)
                {
                    kitapSil();
                    
                }
                else
                {
                    MessageBox.Show("İşlem iptal Edildi");
                }
            }
            else
            {
                MessageBox.Show("Kitap Seçiniz");
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void txtFiltrele_TextChanged(object sender, EventArgs e)
        {
            kitaplarLoad();
        }
    }
    }

