using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormKOS.Model;

namespace WinFormKOS
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           

            if (IDataBase.DataToDataTable("Select * From kullanicilar Where aktif = 1").Rows.Count > 0)
                {
                Application.Run(new FormLogin());
            }
            else
            {
                Application.Run(new FormKurulum());
            }
        }
    }
}
