using Lab5.IO;
using Lab5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Contex
    {
        private List<SinhVien> sv;
        private IDataSource dataSource;

        public Contex(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }
        public List<SinhVien> GetSinhViens()
        {
            if (sv == null)
                sv = dataSource.GetSinhViens();
            return sv;
        }
        public void SaveSV()
        {
            dataSource.Save(sv);
        }

    }
}
