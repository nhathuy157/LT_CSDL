using Lab5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.IO
{
    public interface IDataSource
    {
        List<SinhVien> GetSinhViens();

        void Save(List<SinhVien> sinhViens);
    }
}
