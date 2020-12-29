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
            dg.DataSource = IDataBase.DataToDataTable("Select * From kitaplar Where aktif = 1");
        }


            void kitapEkle()
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@kayitNo", SqlDbType.Int) { Value = txtKayitNo.Text });
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
            kitaplarLoad();
            }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            kitapEkle();
            
        }

        private void dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                kitapId = Convert.ToInt32(dg.Rows[e.RowIndex].Cells["id"].Value);
                foreach (DataRow row in IDataBase.DataToDataTable("Select * From Kitaplar Where aktif = 1 and id = @id", new SqlParameter("@id", SqlDbType.Int) { Value = kitapId }).Rows)
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
    }
    }

