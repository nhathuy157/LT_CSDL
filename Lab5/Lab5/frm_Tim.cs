using Lab5.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public delegate int SoSanh(object sv1, object sv2);
    public partial class frm_Tim : Form
    {
        //public SinhVien sv;
        public Contex _context;
        QuanLySinhVien qlsv;
        public List<SinhVien> dsSinhVien;
        

        public frm_Tim(Contex context)
        {
            this._context = context;
            dsSinhVien = _context.GetSinhViens();
            InitializeComponent();
        }
       
        private void frm_Tim_Load(object sender, EventArgs e)
        {

            qlsv = new QuanLySinhVien(_context);
            LoadListViewAdd(dsSinhVien);

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private int SoSanhTheoMa(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.MaSo.CompareTo(obj1.ToString());
        }
        private int SoSanhTheoTen(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.Ten.CompareTo(obj1.ToString());
        }
        private int SoSanhTheoLop(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.Lop.CompareTo(obj1.ToString());
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            dsSinhVien = new List<SinhVien>();
            SinhVien sv = null;

            if (txt_Search.Text =="")
            {
                MessageBox.Show("Bạn chưa nhập thông tin");
            }
            else
            {
                if (rd_Ms.Checked == true)
                {
                    sv = qlsv.Tim(txt_Search.Text.Trim(), SoSanhTheoMa);
                    dsSinhVien.Add(sv);
                   

                }
                else if (rd_Ten.Checked == true)
                {
                    sv = qlsv.Tim(txt_Search.Text.Trim(), SoSanhTheoTen);
                    dsSinhVien.Add(sv);

                }
                else if (rd_Lop.Checked == true)
                {
                    sv = qlsv.Tim(txt_Search.Text.Trim(), SoSanhTheoLop);
                    dsSinhVien.Add(sv);

                }
                if (sv == null)
                {
                    MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    LoadListViewAdd(dsSinhVien);

                }

            }

            
            
            
        }

        private void rd_Ms_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton radioButton = (RadioButton)sender;
                if (rd_Ms.Checked)
                {
                    lbHienThi.Text = rd_Ms.Text;
                }
            }

        }

        private void rd_Ten_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton radioButton = (RadioButton)sender;
                if (rd_Ten.Checked)
                {
                    lbHienThi.Text = rd_Ten.Text;
                }
            }

        }

        private void rd_Lop_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton radioButton = (RadioButton)sender;
                if (rd_Lop.Checked)
                {
                    lbHienThi.Text = rd_Lop.Text;
                }
            }

        }
        private void LoadListViewAdd(List<SinhVien> danhSach)
        {
            this.lv_SinhVien.Items.Clear();
            foreach (SinhVien sv in dsSinhVien)
            {
                
                AddSV(sv);
            }
            
        }
        private void AddSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MaSo);
            lvitem.SubItems.Add(sv.TenLot);
            lvitem.SubItems.Add(sv.Ten);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.Cmnd);
            lvitem.SubItems.Add(sv.Sdt);
            lvitem.SubItems.Add(sv.DiaChi);
            this.lv_SinhVien.Items.Add(lvitem);
        }
    }
}
