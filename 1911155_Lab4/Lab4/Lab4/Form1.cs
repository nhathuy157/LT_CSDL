using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        QuanLySinhVien qlsv;
        private bool _checked = false;
        public Form1()
        {
            InitializeComponent();
        }
        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            bool gt = true;
            List<string> cn = new List<string>();
            sv.MaSo = this.mtb_mssv.Text;
            sv.HoTen = this.txt_name.Text;
            sv.NgaySinh = this.dtp_ngaysinh.Value;
            sv.DiaChi = this.txt_diachi.Text;
            sv.Lop = this.cb_lop.Text;
            sv.Hinh = this.txt_hinh.Text;
            if (rd_Nu.Checked)
                gt = false;
            sv.GioiTinh = gt;
            sv.email = this.txt_email.Text;
            sv.SoDienThoai = this.mtb_sdt.Text;
            return sv;
        }
        private SinhVien GetSinhVienLV(ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            sv.MaSo = lvitem.SubItems[0].Text;
            sv.HoTen = lvitem.SubItems[1].Text;
            sv.GioiTinh = false;
            if (lvitem.SubItems[2].Text == "Nam")
                sv.GioiTinh = true;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[3].Text);
            sv.Lop = lvitem.SubItems[4].Text;
            sv.SoDienThoai = lvitem.SubItems[5].Text;
            sv.email = lvitem.SubItems[6].Text;
            sv.DiaChi = lvitem.SubItems[7].Text;
            sv.Hinh = lvitem.SubItems[8].Text;
            return sv;
        }
        private void ThietLapThongTin(SinhVien sv)
        {
            this.mtb_sdt.Text = sv.MaSo;
            this.txt_name.Text = sv.HoTen;
            if (sv.GioiTinh)
                this.rd_Nam.Checked = true;
            else
                this.rd_Nu.Checked = true;
            this.dtp_ngaysinh.Value = sv.NgaySinh;
            this.cb_lop.Text = sv.Lop;
            this.mtb_sdt.Text = sv.SoDienThoai;
            this.txt_email.Text = sv.email;
            this.txt_diachi.Text = sv.DiaChi;
            this.txt_hinh.Text = sv.Hinh;
            this.pb_hinh.ImageLocation = sv.Hinh;
        }
        private void ThemSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MaSo);
            lvitem.SubItems.Add(sv.HoTen);
            string gt = "Nữ";
            if (sv.GioiTinh)
                gt = "Nam";
            lvitem.SubItems.Add(gt);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.SoDienThoai);
            lvitem.SubItems.Add(sv.email);
            lvitem.SubItems.Add(sv.DiaChi);
            lvitem.SubItems.Add(sv.Hinh);
            this.lv_sv.Items.Add(lvitem);
        }
        private void LoadListView(List<SinhVien> dssv)
        {

            this.lv_sv.Items.Clear();
            foreach (SinhVien sv in dssv)
            {
                ThemSV(sv);
            }
        }
        private int SoSanhTheoMa(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.MaSo.CompareTo(obj1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien();
            qlsv.DocTuFile();
            LoadListView(qlsv.DanhSach);
        }

        private void lv_sv_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lv_sv.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.lv_sv.SelectedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);
                ThietLapThongTin(sv);
            }
        }

        private void btn_ChonAnh_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open File Image";
            dlg.FileName = "Hãy chọn File";
            dlg.Filter = "Image Files (JPEG, GIF, BMP, etc.)|"
                            + ".jpg;.jpeg;*.gif;*.bmp;"
                            + ".tif;.tiff;*.png|"
                            + "JPEG files (.jpg;.jpeg)|*.jpg;*.jpeg|"
                            + "GIF files (.gif)|.gif|"
                            + "BMP files (.bmp)|.bmp|"
                            + "TIFF files (.tif;.tiff)|*.tif;*.tiff|"
                            + "PNG files (.png)|.png|"
                            + "All files (.)|*.*";

            dlg.InitialDirectory = Environment.CurrentDirectory;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var fileName = dlg.FileName;
                txt_hinh.Text = fileName;
                pb_hinh.Load(fileName);
            }
        }

        private void btn_macdinh_Click(object sender, EventArgs e)
        {
            this.mtb_mssv.Text = "";
            this.txt_name.Text = "";
            this.rd_Nam.Checked = true;
            this.dtp_ngaysinh.Value = DateTime.Now;
            this.cb_lop.Text = this.cb_lop.Items[0].ToString();
            this.mtb_sdt.Text = "";
            this.txt_email.Text = "";
            this.txt_diachi.Text = "";
            this.txt_hinh.Text = "";
            this.pb_hinh.ImageLocation = "";
            LoadListView(qlsv.DanhSach);

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            SinhVien kq = qlsv.Tim(sv.MaSo,delegate (object obj1, object obj2)
            {
                return (obj2 as SinhVien).MaSo.CompareTo(obj1.ToString());
            });
            if(kq == null)
            {
                this.qlsv.Them(sv);
                
            }
            else
            {
                bool kqsua;
                kqsua = qlsv.Sua(sv, sv.MaSo, delegate (object obj1, object obj2)
                {
                    return (obj2 as SinhVien).MaSo.CompareTo(obj1.ToString());
                });
            }
            this.LoadListView(qlsv.DanhSach);
            _checked = true;

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            if (_checked)
            {
                var s = MessageBox.Show("Bạn có muốn lưu không?", "Thông báo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (s == DialogResult.OK)
                {
                    qlsv.Luu("dssv.txt");
                    Application.Exit();
                   
                }   
            }
            else
            {
                Application.Exit();
            }

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qlsv.DanhSach.Clear();
            qlsv.DocTuFile();
            this.LoadListView(qlsv.DanhSach);

        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem lvitem;
            count = this.lv_sv.Items.Count - 1;
            for (i = count; i >= 0; i--)
            {
                lvitem = this.lv_sv.Items[i];
                if (lvitem.Checked)
                    qlsv.Xoa(lvitem.SubItems[0].Text, SoSanhTheoMa);
            }
            this.LoadListView(qlsv.DanhSach);
            this.btn_macdinh.PerformClick();
            _checked = true;

        }
    }
}
