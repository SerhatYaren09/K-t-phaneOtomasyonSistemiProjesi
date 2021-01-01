using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormKOS.Model;

namespace WinFormKOS
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        void dataGridViewLoad()
        {
            dgEmanet.DataSource = IDataBase.DataToDataTable("Select kayitNo AS [Kayıt No], kitapAdi AS [Kitap Adı], yazarAdi AS [Yazar Adı], yayinevi AS [Yayınevi], basimYili AS [Basım Yılı], sayfaSayisi AS [Sayfa Sayısı], tur AS [tür], aciklama AS [Açıklama], dolap AS [dolap], raf AS [raf], sira AS [sıra], aktif AS [aktif], durum AS [durum] From kitaplar Where aktif = 1 and durum = 0");
            dgMevcutKitaplar.DataSource = IDataBase.DataToDataTable("Select Select kayitNo AS [Kayıt No], kitapAdi AS [Kitap Adı], yazarAdi AS [Yazar Adı], yayinevi AS [Yayınevi], basimYili AS [Basım Yılı], sayfaSayisi AS [Sayfa Sayısı], tur AS [tür], aciklama AS [Açıklama], dolap AS [dolap], raf AS [raf], sira AS [sıra], aktif AS [aktif], durum AS [durum] From kitaplar Where aktif = 1 and durum = 1");
            dgOkuyucular.DataSource = IDataBase.DataToDataTable("Select adi AS [Adı], soyadi AS [Soyadı], cinsiyeti AS [Cinsiyeti], sinifi AS [Sınıfı], okulNo AS [Okul Numarası], cepTel AS [Cep Telefonu], adres AS [Adres] From okuyucular Where aktif = 1");
        }
        private void FormHome_Load(object sender, EventArgs e)
        {
            
           // MessageBox.Show(UserInfo.userId.ToString());
        }

        private void btnKitapEkle_Click(object sender, EventArgs e)
        {
            FormKitapEkle formKitapEkle = new FormKitapEkle();
            formKitapEkle.Show();
        }

        private void btnOkuyucuEkle_Click(object sender, EventArgs e)
        {
            FormOkuyucuEkle formOkuyucuEkle = new FormOkuyucuEkle();
            formOkuyucuEkle.Show();
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            Form1 formEdit = new Form1();
            formEdit.Show();
        }

        private void btnEmanetIslem_Click(object sender, EventArgs e)
        {
            FormEmanet formEmanet = new FormEmanet();
            formEmanet.Show();
        }

        private void btnIstatistik_Click(object sender, EventArgs e)
        {
            FormIstatistik formIstatistik = new FormIstatistik();
            formIstatistik.Show();
        }

        private void FormHome_Activated(object sender, EventArgs e)
        {
            dataGridViewLoad();
        }
    }
}
