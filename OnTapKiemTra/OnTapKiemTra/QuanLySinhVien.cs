using OnTapKiemTra.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnTapKiemTra
{
    public class QuanLySinhVien
    {
        ILop lop;
        IDataSource _dataSource;
        public List<Khoa> DanhSachKhoa;
        

        public QuanLySinhVien(IDataSource dataSource)
        {
            this._dataSource = dataSource;
            DanhSachKhoa = _dataSource.GetKhoas();//Lấy danh sách từ file gán vô ds quản lý


        }
        public Khoa this[int index]
        {
            get { return DanhSachKhoa[index]; }
            set { DanhSachKhoa[index] = value; }
        }
        public void LuuJson(List<SinhVien> sv, string filePath)
        {
            ILop lop = new JSonData();
            lop.Save(sv, filePath);
        }
    }
}
