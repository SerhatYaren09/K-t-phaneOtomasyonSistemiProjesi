
namespace WinFormKOS
{
    partial class FormIstatistik
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbIstatistik = new System.Windows.Forms.ComboBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kategori Seç:";
            // 
            // cbbIstatistik
            // 
            this.cbbIstatistik.FormattingEnabled = true;
            this.cbbIstatistik.Items.AddRange(new object[] {
            "Okuyucular",
            "Kitaplar",
            "Yazarlar",
            "Türler"});
            this.cbbIstatistik.Location = new System.Drawing.Point(112, 17);
            this.cbbIstatistik.Name = "cbbIstatistik";
            this.cbbIstatistik.Size = new System.Drawing.Size(121, 24);
            this.cbbIstatistik.TabIndex = 1;
            this.cbbIstatistik.SelectedIndexChanged += new System.EventHandler(this.cbbIstatistik_SelectedIndexChanged);
            // 
            // chart
            // 
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(16, 62);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Durum";
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(1360, 451);
            this.chart.TabIndex = 2;
            this.chart.Text = "chart1";
            // 
            // FormIstatistik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 555);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.cbbIstatistik);
            this.Controls.Add(this.label1);
            this.Name = "FormIstatistik";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormIstatistik";
            this.Load += new System.EventHandler(this.FormIstatistik_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbIstatistik;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}