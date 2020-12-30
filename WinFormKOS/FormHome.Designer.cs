
namespace WinFormKOS
{
    partial class FormHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            this.btnEmanetIslem = new System.Windows.Forms.Button();
            this.btnKitapEkle = new System.Windows.Forms.Button();
            this.btnOkuyucuEkle = new System.Windows.Forms.Button();
            this.btnIstatistik = new System.Windows.Forms.Button();
            this.btnAyarlar = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgEmanet = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgMevcutKitaplar = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgOkuyucular = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmanet)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMevcutKitaplar)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOkuyucular)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEmanetIslem
            // 
            this.btnEmanetIslem.Image = ((System.Drawing.Image)(resources.GetObject("btnEmanetIslem.Image")));
            this.btnEmanetIslem.Location = new System.Drawing.Point(12, 24);
            this.btnEmanetIslem.Name = "btnEmanetIslem";
            this.btnEmanetIslem.Size = new System.Drawing.Size(131, 104);
            this.btnEmanetIslem.TabIndex = 0;
            this.btnEmanetIslem.Text = "Emanet İşlemleri";
            this.btnEmanetIslem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmanetIslem.UseVisualStyleBackColor = true;
            // 
            // btnKitapEkle
            // 
            this.btnKitapEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnKitapEkle.Image")));
            this.btnKitapEkle.Location = new System.Drawing.Point(161, 24);
            this.btnKitapEkle.Name = "btnKitapEkle";
            this.btnKitapEkle.Size = new System.Drawing.Size(131, 104);
            this.btnKitapEkle.TabIndex = 1;
            this.btnKitapEkle.Text = "Kitap Ekle";
            this.btnKitapEkle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnKitapEkle.UseVisualStyleBackColor = true;
            this.btnKitapEkle.Click += new System.EventHandler(this.btnKitapEkle_Click);
            // 
            // btnOkuyucuEkle
            // 
            this.btnOkuyucuEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnOkuyucuEkle.Image")));
            this.btnOkuyucuEkle.Location = new System.Drawing.Point(314, 24);
            this.btnOkuyucuEkle.Name = "btnOkuyucuEkle";
            this.btnOkuyucuEkle.Size = new System.Drawing.Size(131, 104);
            this.btnOkuyucuEkle.TabIndex = 2;
            this.btnOkuyucuEkle.Text = "Okuyucu Ekle";
            this.btnOkuyucuEkle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOkuyucuEkle.UseVisualStyleBackColor = true;
            this.btnOkuyucuEkle.Click += new System.EventHandler(this.btnOkuyucuEkle_Click);
            // 
            // btnIstatistik
            // 
            this.btnIstatistik.Image = ((System.Drawing.Image)(resources.GetObject("btnIstatistik.Image")));
            this.btnIstatistik.Location = new System.Drawing.Point(470, 24);
            this.btnIstatistik.Name = "btnIstatistik";
            this.btnIstatistik.Size = new System.Drawing.Size(131, 104);
            this.btnIstatistik.TabIndex = 3;
            this.btnIstatistik.Text = "İstatistik";
            this.btnIstatistik.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnIstatistik.UseVisualStyleBackColor = true;
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.Image = ((System.Drawing.Image)(resources.GetObject("btnAyarlar.Image")));
            this.btnAyarlar.Location = new System.Drawing.Point(618, 24);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(131, 104);
            this.btnAyarlar.TabIndex = 4;
            this.btnAyarlar.Text = "Ayarlar";
            this.btnAyarlar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAyarlar.UseVisualStyleBackColor = true;
            // 
            // btnCikis
            // 
            this.btnCikis.Image = ((System.Drawing.Image)(resources.GetObject("btnCikis.Image")));
            this.btnCikis.Location = new System.Drawing.Point(1015, 24);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(131, 104);
            this.btnCikis.TabIndex = 5;
            this.btnCikis.Text = "Çıkış Yap";
            this.btnCikis.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCikis.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 153);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1127, 288);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgEmanet);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1119, 259);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Emanet Kitaplar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgEmanet
            // 
            this.dgEmanet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmanet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEmanet.Location = new System.Drawing.Point(3, 3);
            this.dgEmanet.Name = "dgEmanet";
            this.dgEmanet.RowHeadersWidth = 51;
            this.dgEmanet.RowTemplate.Height = 24;
            this.dgEmanet.Size = new System.Drawing.Size(1113, 253);
            this.dgEmanet.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgMevcutKitaplar);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1119, 259);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mevcut Kitaplar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgMevcutKitaplar
            // 
            this.dgMevcutKitaplar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMevcutKitaplar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMevcutKitaplar.Location = new System.Drawing.Point(3, 3);
            this.dgMevcutKitaplar.Name = "dgMevcutKitaplar";
            this.dgMevcutKitaplar.RowHeadersWidth = 51;
            this.dgMevcutKitaplar.RowTemplate.Height = 24;
            this.dgMevcutKitaplar.Size = new System.Drawing.Size(1113, 253);
            this.dgMevcutKitaplar.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgOkuyucular);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1119, 259);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Okuyucular";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgOkuyucular
            // 
            this.dgOkuyucular.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOkuyucular.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgOkuyucular.Location = new System.Drawing.Point(3, 3);
            this.dgOkuyucular.Name = "dgOkuyucular";
            this.dgOkuyucular.RowHeadersWidth = 51;
            this.dgOkuyucular.RowTemplate.Height = 24;
            this.dgOkuyucular.Size = new System.Drawing.Size(1113, 253);
            this.dgOkuyucular.TabIndex = 0;
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 453);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnAyarlar);
            this.Controls.Add(this.btnIstatistik);
            this.Controls.Add(this.btnOkuyucuEkle);
            this.Controls.Add(this.btnKitapEkle);
            this.Controls.Add(this.btnEmanetIslem);
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormHome";
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgEmanet)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMevcutKitaplar)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgOkuyucular)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmanetIslem;
        private System.Windows.Forms.Button btnKitapEkle;
        private System.Windows.Forms.Button btnOkuyucuEkle;
        private System.Windows.Forms.Button btnIstatistik;
        private System.Windows.Forms.Button btnAyarlar;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgEmanet;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgMevcutKitaplar;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgOkuyucular;
    }
}