using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTapKiemTra
{
    public class Lop
    {
        public String TenLop { get; set; }
        public List<SinhVien> dssv; //Danh sách sinh viên trong lớp

        public Lop(string tenLop)
        {
            this.TenLop = tenLop;
            dssv = new List<SinhVien>();
        }
        public SinhVien TimSV(String MaSo)
        {
            return dssv.Find(x => x.MaSo == MaSo);
        }
        public void XoaSV(String MaSo)
        {
            dssv.RemoveAll(x => x.MaSo == MaSo);
        }
        public void CapNhatSV(SinhVien sv)
        {
            int index = dssv.FindIndex(x => x.MaSo == sv.MaSo);
            dssv[index] = sv;
        }
    }
}
