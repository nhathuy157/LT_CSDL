using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTapKiemTra.IO
{
    public class TextData : IDataSource
    {
        private string _filePath;
        public TextData(string filePath)
        {
            _filePath = filePath;

        }
        public List<Khoa> GetKhoas()
        {

            List<Khoa> khoas = new List<Khoa>(); // tạo ds khoa mới
            if (File.Exists(_filePath))
            {
                using (var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null) // đọc một dòng cho đến khi hết
                        {
                            var sinhVien = ParseSV(line);
                            int vtKhoa = khoas.FindIndex(x => x.TenKhoa == sinhVien.Khoa); //Rìm vị trí của khoa trong ds khoas
                            if(vtKhoa == -1)
                            {
                                Khoa khoa = new Khoa(sinhVien.Khoa); //Tạo ds khoa
                                khoa.ThemSV(sinhVien); //Thêm sv vào khoa và lớp
                                khoas.Add(khoa); //Thêm khoa vào ds khoas
                            }
                            else
                            {
                                if(khoas[vtKhoa].dssv.FindIndex(x => x.MaSo == sinhVien.MaSo) == -1) //TÌm maso trung 
                                {
                                    khoas[vtKhoa].ThemSV(sinhVien);
                                }
                            }
                        }
                    }
                }
            }
            return khoas; // Trả về ds khoas
        }

        public void Save(List<Khoa> khoas)
        {
            using (var stream = new FileStream(_filePath, FileMode.Create, FileAccess.ReadWrite))
            {
                using (var writer = new StreamWriter(stream))
                {
                    
                    foreach (var khoa in khoas )
                    {

                       foreach (SinhVien sinhviens in khoa.dssv)
                        {
                            var line = SVFormat(sinhviens);
                            writer.WriteLine(line);
                        }
                        
                    }
                }
            }
        }
        private SinhVien ParseSV(string line)
        {
            var parts = line.Split('\t');
            SinhVien sv = new SinhVien();

            sv.MaSo = parts[0].Trim();
            sv.TenLot = parts[1].Trim();
            sv.Ten = parts[2].Trim();
            sv.Lop = parts[3].Trim();
            sv.Khoa = parts[4].Trim();
            if (parts.Length > 5)
            {
                sv.GioiTinh = (int.Parse(parts[5].Trim()) == 1 ? true : false);
                sv.NgaySinh = DateTime.Parse(parts[6].Trim());
                sv.Sdt = parts[7].Trim();
                sv.DiaChi = parts[8].Trim();
            }
            

            return sv;
                  
            
        }
        private string SVFormat(SinhVien sinhVien)
        {

            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}",
               sinhVien.MaSo,
               sinhVien.TenLot,
               sinhVien.Ten,
               sinhVien.Lop,
               sinhVien.Khoa,
               (sinhVien.GioiTinh == true ? "1" : "0"),
               sinhVien.NgaySinh,
               sinhVien.Sdt,
               sinhVien.DiaChi);
        }
    }
}
