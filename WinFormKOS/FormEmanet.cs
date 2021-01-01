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

            foreach (DataRow row in IDataBase.DataToDataTable("Select * From okuyucular Where id = @id", new SqlParameter("@id", SqlDbType.Int){Value = okuyucuId }).Rows)

            {
                pictureProfil.ImageLocation = Helper.profilPath(okuyucuId);
                lblAdSoyad.Text = row["adi"].ToString() + "" + row["soyadi"].ToString();
                lblSinif.Text = row["sinifi"].ToString();
                lblOkulNo.Text = row["okulNo"].ToString();
                lblGecikmeBedeli.Text = "YOK";
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
            dgKitaplar.DataSource = IDataBase.DataToDataTable("Select * From kitaplar Where kitapAdi Like @search", new SqlParameter("@search", SqlDbType.VarChar) { Value = string.Format("%{0}%", txtFiltreleKitap.Text) });
            dgKitaplar.Columns["id"].Visible = false;
            dgKitaplar.Columns["aktif"].Visible = false;
        }
        void emanetEt()
        { 
             if(getEmanetId() > 0)
            {
                MessageBox.Show("Seçili okuyucunun emaneti var");
                return;
            }

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
                kitapId = Convert.ToInt32(dgKitaplar.Rows[e.RowIndex].Cells["id"].Value);
                getKitapProfil();
            }
        }
    }
}
