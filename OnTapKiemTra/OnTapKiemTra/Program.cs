using OnTapKiemTra.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnTapKiemTra
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IDataSource dataSource = new TextData("Data\\dssv.txt");
            QuanLySinhVien qlsv = new QuanLySinhVien(dataSource); 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(qlsv));
        }
    }
}
