using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTapKiemTra.IO
{
    public interface IDataSource
    {
        List<Khoa> GetKhoas(); //Trả về nguyên danh sách của tất cả khoa đọc được

        void Save(List<Khoa> khoas);
    }
}
