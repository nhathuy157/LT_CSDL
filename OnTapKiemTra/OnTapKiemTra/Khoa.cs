using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTapKiemTra
{
    public class Khoa
    {
        public String TenKhoa { get; set; }
        public List<SinhVien> dssv; // Danh sách tổng sv trong khoa
        public List<Lop> lops; //Danh sách lớp


        //Hàm tạo lập
        public Khoa(string tenKhoa)
        {
            this.TenKhoa = tenKhoa;
            dssv = new List<SinhVien>();
            lops = new List<Lop>();

        }
        public void ThemSV(SinhVien sv)
        {
            int soLop = lops.FindIndex(x => x.TenLop == sv.Lop);//Tìm vị trí của lớp trong ds lops
            if (soLop == -1)
            {
                 Lop lop = new Lop(sv.Lop); // Tạo ra lớp mới và gán tên
                lop.dssv.Add(sv); //Add sinh viên
                lops.Add(lop); // Add Lớp mới tạo vào danh sách lớp

            }
            else
            {
                lops[soLop].dssv.Add(sv); //thêm sinh viên vào lớp đã tìm ra
            }
            dssv.Add(sv);//Thêm sinh viên vào danh sách tổng
        }
        public int VT_Lop(String tenLop)
        {
            return lops.FindIndex(x => x.TenLop == tenLop);

        }
        public SinhVien TimSV(String MaSo)
        {
            return dssv.Find(x => x.MaSo == MaSo);

        }
        public void XoaSV(String MaSo)
        {
            
            SinhVien sv = dssv.Find(x => x.MaSo == MaSo);
            dssv.Remove(sv);
            lops[VT_Lop(sv.Lop)].XoaSV(MaSo);
 
        }
        public void CapNhatSV(SinhVien sv)
        {
            int index = dssv.FindIndex(x => x.MaSo == sv.MaSo);
            dssv[index] = sv;
            lops[VT_Lop(sv.Lop)].CapNhatSV(sv);
        }
        
    }
}
