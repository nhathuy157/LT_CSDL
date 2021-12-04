using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class SinhVien
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Hinh { get; set; }
        public string Lop { get; set; }
        public bool GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string email { get; set; }
        public string DiaChi { get; set; }

        public SinhVien()
        {
        }
        public SinhVien(string ms, string ht, DateTime ngay, string dc, string lop
        , string sdt, string mail, string hinh, bool gt)
        {
            this.MaSo = ms;
            this.HoTen = ht;
            this.NgaySinh = ngay;
            this.DiaChi = dc;
            this.Lop = lop;
            this.SoDienThoai = sdt;
            this.email = mail;
            this.Hinh = hinh;
            this.GioiTinh = gt;
        }


    }




}
