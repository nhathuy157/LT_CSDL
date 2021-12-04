using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model
{
    public class SinhVien
    {
        public String MaSo { get; set; }
        public String TenLot { get; set; }
        public String Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public String Lop { get; set; }
        public String Cmnd { get; set; }
        public String Sdt { get; set; }
        public String DiaChi { get; set; }
        public bool GioiTinh { get; set; }
        public List<string> MonHoc { get; set; }
        public SinhVien()
        {
            MonHoc = new List<string>();
        }
        public SinhVien(string ms, string tenlot, string ten, DateTime ngay, string lop,
            string cmnd, string sdt, string dc, bool gt, List<string> mh)
        {
            this.MaSo = ms;
            this.TenLot = tenlot;
            this.Ten = ten;
            this.NgaySinh = ngay;
            this.Lop = lop;
            this.Cmnd = cmnd;
            this.Sdt = sdt;
            this.DiaChi = dc;
            this.GioiTinh = gt;
            this.MonHoc = mh;
        }
    }
}
