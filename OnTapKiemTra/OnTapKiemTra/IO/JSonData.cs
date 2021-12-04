using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnTapKiemTra.IO
{
    public class JSonData : ILop
    {
        public void Save(List<SinhVien> sv, string filePath)
        {
            var sinhVienData = JsonConvert.SerializeObject(sv);
            File.WriteAllText(filePath, sinhVienData);
        }
    }
}
