using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTapKiemTra.IO
{
    interface ILop
    {
        void Save(List<SinhVien> sv, string filePath);

    }
}
