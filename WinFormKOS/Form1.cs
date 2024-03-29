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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int rowId = 0;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        string getTableName()
        {
            switch (cbbTableName.SelectedIndex)
            {
                case 0:
                    return "yazarlar";

                case 1:
                    return "yayinevleri";

                case 2:
                    return "turler";

                case 3:
                    return "dolaplar";

                default:
                    return "";



            }

        }
        void tableLoad()
        {
            if (!string.IsNullOrEmpty(getTableName()))
            {
                dg.DataSource = IDataBase.DataToDataTable("Select * From " + getTableName());
                dg.Columns["id"].Visible = false;
            }
        }
        void ekle()
        {
            IDataBase.executeNonQuery("Insert Into " + getTableName() + "(adi) Values(@adi)", new SqlParameter("@adi", SqlDbType.VarChar) { Value = txtAd.Text });
            tableLoad();
            MessageBox.Show("Ekleme işlemi başarılı");
        }

        void guncelle()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@adi", SqlDbType.VarChar) { Value = txtAd.Text });
            parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = rowId });

            IDataBase.executeNonQuery(" Update " + getTableName() + " Set adi = @adi Where id = @id", parameters);
            tableLoad();

            MessageBox.Show("Güncelleme işlemi başarılı");
        }

        void sil()
        {
            IDataBase.executeNonQuery("Delete " + getTableName() + " Where id = @id", new SqlParameter("@id", SqlDbType.Int) { Value = rowId });
            temizle();
            tableLoad();

            MessageBox.Show("Silme işlemi başarılı");
        }

        void temizle()
        {
            rowId = 0;
            txtAd.Text = "";
        }
        private void cbbTableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            tableLoad();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(getTableName()))
            {
                MessageBox.Show("Tablo seçimi yapınız");
                return;
            }

            if (rowId > 0)
            {
                guncelle();
            }
            else
            {
                ekle();
            }
        }

        private void dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                rowId = Convert.ToInt32(dg.Rows[e.RowIndex].Cells["id"].Value);
                txtAd.Text = dg.Rows[e.RowIndex].Cells["adi"].Value.ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (rowId > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Seçili satırı silmek istediğinize emin misiniz?", "Satır Sil", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    sil();

                }
            }
            else
            {
                MessageBox.Show("Satır Seçiniz");
            }
        }
       private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
