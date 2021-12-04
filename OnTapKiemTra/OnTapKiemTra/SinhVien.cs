using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTapKiemTra
{
    public class SinhVien
    {
        public String MaSo { get; set; }
        public String TenLot { get; set; }
        public String Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public String Sdt { get; set; }
        public String Lop { get; set; }
        public String Khoa { get; set; }
        public String DiaChi { get; set; }
        public bool GioiTinh { get; set; }

    
        public SinhVien(string ms, string tenlot, string ten, DateTime ngay, string lop,
             string sdt, bool gt, string khoa, string dc)
        {
            this.MaSo = ms;
            this.TenLot = tenlot;
            this.Ten = ten;
            this.NgaySinh = ngay;
            this.Lop = lop;
            this.Sdt = sdt;
            this.Khoa = khoa;
            this.DiaChi = dc;
            this.GioiTinh = gt;
        }

        public SinhVien()
        {
            this.MaSo = "";
            this.TenLot = "";
            this.Ten = "";
            this.NgaySinh = DateTime.Now;
            this.Lop = "";
            this.Sdt = "";
            this.Khoa = "";
            this.DiaChi = "";
            this.GioiTinh = false;
        }
    }

}
