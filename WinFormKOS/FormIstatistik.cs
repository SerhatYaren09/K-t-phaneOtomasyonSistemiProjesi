using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormKOS
{
    public partial class FormIstatistik : Form
    {
        public FormIstatistik()
        {
            InitializeComponent();
        }

        private void FormIstatistik_Load(object sender, EventArgs e)
        {
           
        }
        
        /*Okuyucular
        Kitaplar
        Yazarlar
        Türler */

       /* Select adi+' '+soyadi, COUNT(*) From emanetler Inner Join okuyucular On okuyucular.id = emanetler.okuyucuId Where okuyucular.aktif = 1 AND emanetler.aktif = 1 Group By adi+' '+soyadi

        Select kitapAdi, COUNT(*) From emanetler Inner Join kitaplar On kitaplar.id = emanetler.kitapId Group By kitapAdi

        Select yazarAdi, COUNT(*) From emanetler Inner Join kitaplar On kitaplar.id = emanetler.kitapId Group By yazarAdi

        Select tur, COUNT(*) From emanetler Inner Join kitaplar On kitaplar.id = emanetler.kitapId Group By tur
       */

        void istatistikGor()
        {
            string query = "";
            switch(cbbIstatistik.SelectedIndex)
            {

                case 0:
                    query = "Select adi+' '+soyadi, COUNT(*) From emanetler Inner Join okuyucular On okuyucular.id = emanetler.okuyucuId Where okuyucular.aktif = 1 AND emanetler.aktif = 1 Group By adi+' '+soyadi";
                break;

                case 1:
                    query = "Select kitapAdi, COUNT(*) From emanetler Inner Join kitaplar On kitaplar.id = emanetler.kitapId Group By kitapAdi";
                    break;

                case 2:
                    query = "Select yazarAdi, COUNT(*) From emanetler Inner Join kitaplar On kitaplar.id = emanetler.kitapId Group By yazarAdi";
                    break;


                default:
                    break;
            }
        }

    }
}
