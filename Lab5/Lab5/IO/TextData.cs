using Lab5.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.IO
{
    public class TextData : IDataSource
    {
        private string _filePath;
        public TextData(string filePath)
        {
            _filePath = filePath;
        
        }
        public List<SinhVien> GetSinhViens()
        {
            List<SinhVien> sinhViens = new List<SinhVien>();
            if (File.Exists(_filePath))
            {
                using (var stream = new FileStream(_filePath,FileMode.Open, FileAccess.Read))
                {
                    using(var reader = new StreamReader(stream))
                    {
                        string line;
                        while((line = reader.ReadLine())!= null)
                        {
                            var sinhVien = ParseSV(line);
                            sinhViens.Add(sinhVien);
                            
                        }
                    }
                }
            }
            return sinhViens;
        }

        public void Save(List<SinhVien> sinhViens)
        {
            using(var stream = new FileStream(_filePath,FileMode.Create, FileAccess.ReadWrite))
            {
                using (var writer = new StreamWriter(stream))
                {
                    foreach(var sinhVien in sinhViens)
                    {
                        var line = SVFormat(sinhVien);
                        writer.WriteLine(line);
                    }
                }
            }
        }
        
        private SinhVien ParseSV(string line)
        {
            var parts = line.Split('*');
            return new SinhVien()
            {
                MaSo = parts[0],
                TenLot = parts[1],
                Ten = parts[2],
                NgaySinh = DateTime.Parse(parts[3]),
                Lop = parts[4],
                Cmnd = parts[5],
                Sdt = parts[6],
                DiaChi = parts[7],
                GioiTinh = (int.Parse(parts[8]) == 1 ? true : false),
                MonHoc = themMH(parts[9]) 



            };
        }
        private string SVFormat(SinhVien sinhVien)
        {
            string dsMonHoc = string.Join(",", sinhVien.MonHoc);
            if (string.IsNullOrWhiteSpace(dsMonHoc))
                dsMonHoc = "null";
            return string.Format("{0}*{1}*{2}*{3}*{4}*{5}*{6}*{7}*{8}*{9}",
                sinhVien.MaSo, 
                sinhVien.TenLot,
                sinhVien.Ten,
                sinhVien.NgaySinh.ToShortDateString(),
                sinhVien.Lop,
                sinhVien.Cmnd,
                sinhVien.Sdt,
                sinhVien.DiaChi,
                (sinhVien.GioiTinh == true?"1":"0"),
                dsMonHoc);
        }
        private List<string> themMH (string line)
        {
            List<string> monHoc = new List<string>();
            string[] mh = line.Split(',');
            foreach(string item in mh)
            {
                monHoc.Add(item);
            }
            return monHoc;
        }
    }
}
