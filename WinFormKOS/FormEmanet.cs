﻿using System;
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
        int okuyucuId = 0;
        int kitapId = 0;
        int cezaTL = 0;
        private void FormEmanet_Load(object sender, EventArgs e)
        {
            okuyucularLoad();
            kitaplarLoad();
        }

        void getOkuyucuProfil()
        {
            pictureProfil.ImageLocation = Helper.profilPath(0);
            lblAdSoyad.Text = "";
            lblSinif.Text = "";
            lblOkulNo.Text = "";
            lblGecikmeBedeli.Text = "";
            cezaTL = 0;

            foreach (DataRow row in IDataBase.DataToDataTable("Select * From okuyucular Where id = @id", new SqlParameter("@id", SqlDbType.Int){Value = okuyucuId }).Rows)

            {
                pictureProfil.ImageLocation = Helper.profilPath(okuyucuId);
                lblAdSoyad.Text = row["adi"].ToString() + "" + row["soyadi"].ToString();
                lblSinif.Text = row["sinifi"].ToString();
                lblOkulNo.Text = row["okulNo"].ToString();
                lblGecikmeBedeli.Text = "YOK";

                cezaTL = getGecikmeBedeli();
               
                if (cezaTL > 0)
                {
                    lblGecikmeBedeli.Text = "Ceza " +string.Format("{0:C}", cezaTL);
                    lblGecikmeBedeli.BackColor = Color.Red;
                }
                else
                {
                    lblGecikmeBedeli.Text = "Uygun";
                    lblGecikmeBedeli.BackColor = Color.Transparent;
                }

                kitapId = getEmanetId();
                getKitapProfil();
            }
        }

        void getKitapProfil()
        {
            lblKayitNo.Text = "";
            lblKitapAdi.Text = "";
            lblYazarAdi.Text = "";

            foreach (DataRow row in IDataBase.DataToDataTable("Select * From kitaplar Where id = @id", new SqlParameter("@id", SqlDbType.Int) { Value = kitapId }).Rows)
            {
                lblKayitNo.Text = row["kayitNo"].ToString();
                lblKitapAdi.Text = row["kitapAdi"].ToString();
                lblYazarAdi.Text = row["yazarAdi"].ToString();
            }
        }
        void okuyucularLoad()
        {
            dgOkuyucular.DataSource = IDataBase.DataToDataTable("Select * From okuyucular Where adi+' '+soyadi Like @search", new SqlParameter("@search", SqlDbType.VarChar) { Value = string.Format("%{0}%", txtFiltreleOkuyucu.Text) });
            dgOkuyucular.Columns["id"].Visible = false;
            dgOkuyucular.Columns["aktif"].Visible = false;

        }
        void kitaplarLoad()
        {
            dgKitaplar.DataSource = IDataBase.DataToDataTable("Select * From kitaplar Where durum = 1 AND kitapAdi Like @search", new SqlParameter("@search", SqlDbType.VarChar) { Value = string.Format("%{0}%", txtFiltreleKitap.Text) });
            dgKitaplar.Columns["id"].Visible = false;
            dgKitaplar.Columns["aktif"].Visible = false;
        }
        void emanetEt()
        { 
            if(kitapId == 0 || okuyucuId == 0)
            {
                MessageBox.Show("Kitap veya okuyucu seçmediniz");
                return;
            }
             if(getEmanetId() > 0)
            {
                MessageBox.Show("Seçili okuyucunun emaneti var");
                return;
            }

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@kitapId", SqlDbType.Int) { Value = kitapId });
            parameters.Add(new SqlParameter("@okuyucuId", SqlDbType.Int) { Value = okuyucuId });
            parameters.Add(new SqlParameter("@emanetVerilisTarihi", SqlDbType.Date) { Value = DateTime.Now });
            parameters.Add(new SqlParameter("@emanetGeriAlmaTarihi", SqlDbType.Date) { Value = DateTime.Now.AddDays(30) });

            IDataBase.executeNonQuery("Update kitaplar Set durum = 0 Where id = @kitapId" + 
                                      " Insert Into emanetler (kitapId , okuyucuId, emanetVerilisTarihi , emanetGeriAlmaTarihi) Values (@kitapId , @okuyucuId , @emanetVerilisTarihi , @emanetGeriAlmaTarihi)", parameters);

            kitaplarLoad();
        
        }

        void sureUzat()
        {
            if (kitapId == 0 || okuyucuId == 0)
            {
                MessageBox.Show("Kitap veya okuyucu seçmediniz");
                return;
            }
            if (getEmanetId() == 0)
            {
                MessageBox.Show("Seçili okuyucunun emaneti yok");
                return;
            }

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@kitapId", SqlDbType.Int) { Value = kitapId });
            parameters.Add(new SqlParameter("@emanetVerilisTarihi", SqlDbType.Date) { Value = DateTime.Now });
            parameters.Add(new SqlParameter("@emanetGeriAlmaTarihi", SqlDbType.Date) { Value = DateTime.Now.AddDays(30) });

            IDataBase.executeNonQuery("Update emanetler Set emanetVerilisTarihi = @emanetVerilisTarihi, emanetGeriAlmaTarihi = @emanetGeriAlmaTarihi Where kitapId = @kitapId", parameters);

            getOkuyucuProfil();
            kitaplarLoad();
        }

        void dusumYap()
        {
            if (kitapId == 0 || okuyucuId == 0)
            {
                MessageBox.Show("Kitap veya okuyucu seçmediniz");
                return;
            }
            if (getEmanetId() == 0)
            {
                MessageBox.Show("Seçili okuyucunun emaneti yok");
                return;
            }

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@kitapId", SqlDbType.Int) { Value = kitapId });
            parameters.Add(new SqlParameter("@emanetIslemTarihi", SqlDbType.Date) { Value = DateTime.Now });
       
            IDataBase.executeNonQuery("Update kitaplar Set durum = 1 Where id = @kitapId " +
                                      "Update emanetler Set emanetIslemTarihi = @emanetIslemTarihi, durum = 1 Where kitapId = @kitapId", parameters);

            getOkuyucuProfil();
            kitaplarLoad();
        }

        int getGecikmeBedeli()
        {
            int cezaTL = 100;
            int gunFark = 0;
            foreach (DataRow row in IDataBase.DataToDataTable("Select * From emanetler Where okuyucuId = @id AND durum = 0 AND aktif = 1", new SqlParameter("@id", SqlDbType.Int) { Value = okuyucuId }).Rows)
            {
                TimeSpan timeSpan = DateTime.Now - Convert.ToDateTime(row["emanetGeriAlmaTarihi"]);
                gunFark = timeSpan.Days;
            }
            if(gunFark > 0)
            {
                return (gunFark * cezaTL);
            }


            return 0;
        }



        int getEmanetId()
        {
            foreach (DataRow row in IDataBase.DataToDataTable("Select * From emanetler Where okuyucuId = @id AND durum = 0 AND aktif = 1", new SqlParameter("@id", SqlDbType.Int) { Value = okuyucuId }).Rows)
            {
                return Convert.ToInt32(row["kitapId"]);
            }
            return 0;
        }

        private void txtFiltreleOkuyucu_TextChanged(object sender, EventArgs e)
        {
            okuyucularLoad();
        }

        private void txtFiltreleKitap_TextChanged(object sender, EventArgs e)
        {
            kitaplarLoad();
        }

        private void dgOkuyucular_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgOkuyucular_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                okuyucuId = Convert.ToInt32(dgOkuyucular.Rows[e.RowIndex].Cells["id"].Value);
                getOkuyucuProfil();

            }
        }

        private void dgKitaplar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
             
                if(okuyucuId == 0)
                {
                    MessageBox.Show("Okuyucu seçiniz");
                    return;
                }
                if(getEmanetId() > 0)
                {
                    MessageBox.Show("Okuyucunun emaneti var");
                    return;
                }
                kitapId = Convert.ToInt32(dgKitaplar.Rows[e.RowIndex].Cells["id"].Value);
                getKitapProfil();
            }
        }

        private void btnEmanetEt_Click(object sender, EventArgs e)
        {
            emanetEt();
        }

        private void btnSureUzat_Click(object sender, EventArgs e)
        {
            if (cezaTL > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Okuyucunun " + string.Format("{0:C}", cezaTL) + " gecikme bedeli teslim alındı mı?", "Gecikme Bedeli",MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    sureUzat();
                }
            }
            else
            {
                sureUzat();
           }
        }

        private void btnDusumYap_Click(object sender, EventArgs e)
        {
            if (cezaTL > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Okuyucunun " + string.Format("{0:C}", cezaTL) + " gecikme bedeli teslim alındı mı?", "Gecikme Bedeli", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dusumYap();
                }
            }
            else
            {
                dusumYap();
            }

        }
    }
}
