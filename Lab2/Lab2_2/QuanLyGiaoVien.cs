using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_2
{
    public delegate int SoSanh(object gv1, object gv2);
    public class QuanLyGiaoVien
    {
        public List<GiaoVien> dsGiaoVien;

        public QuanLyGiaoVien()
        {
            dsGiaoVien = new List<GiaoVien>();
        }
        public GiaoVien this[int index]
        {
            get { return dsGiaoVien[index]; }
            set { dsGiaoVien[index] = value; }
        }
        public void Them(GiaoVien gv)
        {
            this.dsGiaoVien.Add(gv);

        }
        public void Xoa(object obj, SoSanh ss)
        {
            int i = dsGiaoVien.Count - 1;
            for (; i > 0; i--)
                if (ss(obj, this[1]) == 0)
                    this.dsGiaoVien.RemoveAt(i);
        }
        public GiaoVien Tim(object obj, SoSanh ss)
        {
            GiaoVien gvresult = null;
            foreach (GiaoVien gv in dsGiaoVien)
                if(ss(obj, gv)==0)
                {
                    gvresult = gv;
                    break;
                }
            return gvresult; 
        }
        public bool Sua(GiaoVien gvSua, object obj, SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = this.dsGiaoVien.Count - 1;
            for(i=0; i < count; i++)
                if (ss(obj, this[i])==0)
                {
                    this[i] = gvSua;
                    kq = true;
                    break;
                }
            return kq;

        }
        
    }



 }
