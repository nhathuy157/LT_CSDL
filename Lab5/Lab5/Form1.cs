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
    public partial class Form1 : Form
    {
        
        QuanLySinhVien qlsv;
        public Contex context;
        private List<SinhVien> sv;
        public Form1(Contex context)
        {
            InitializeComponent();
            this.context = context;
            sv = context.GetSinhViens();
        }
        //Lấy t hông tin từ form
        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            bool gt = true;
            List<string> mh = new List<string>();
            sv.MaSo = this.mtxt_mssv.Text;
            sv.TenLot = this.txt_tenLot.Text;
            sv.Ten = this.txt_Ten.Text;
            sv.NgaySinh = this.dtp_ngaysinh.Value;
            sv.Lop = this.cbb_lop.Text;
            sv.Cmnd = this.mtxt_CMND.Text;
            sv.Sdt = this.mtxt_sdt.Text;
            sv.DiaChi = this.txt_DiaChi.Text;
            if (rd_Nu.Checked)
                gt = false;
            sv.GioiTinh = gt;
            for (int i = 0; i < this.ckb_mhdk.Items.Count; i++)
                if (ckb_mhdk.GetItemChecked(i))
                    mh.Add(ckb_mhdk.Items[i].ToString());
            sv.MonHoc = mh;
            return sv;
        }
        //Lấy thông tin từ listView
        private SinhVien GetSinhVienLV(ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            sv.MaSo = lvitem.SubItems[0].Text;
            sv.TenLot = lvitem.SubItems[1].Text;
            sv.Ten = lvitem.SubItems[2].Text;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[3].Text);
            sv.Lop = lvitem.SubItems[4].Text;
            sv.Cmnd = lvitem.SubItems[5].Text;
            sv.Sdt = lvitem.SubItems[6].Text;
            sv.DiaChi = lvitem.SubItems[7].Text;
            sv.GioiTinh = false;
            if (lvitem.SubItems[8].Text.Trim() == "Nam")
                sv.GioiTinh = true;
            List<string> mh = new List<string>();
            string[] s = lvitem.SubItems[9].Text.Split(',');
            foreach (string t in s)
                mh.Add(t);
            sv.MonHoc = mh;

            return sv;
        }
        //Thiet lập các thông tin lên form
        private void ThietLapThongTin (SinhVien sv)
        {
            this.mtxt_mssv.Text = sv.MaSo;
            this.txt_tenLot.Text = sv.TenLot;
            this.txt_Ten.Text = sv.Ten;
            this.dtp_ngaysinh.Value = sv.NgaySinh;
            this.cbb_lop.Text = sv.Lop;
            this.mtxt_CMND.Text = sv.Cmnd;
            this.mtxt_sdt.Text = sv.Sdt;
            this.txt_DiaChi.Text = sv.DiaChi;
            if (sv.GioiTinh)
                this.rd_Nam.Checked = true;
            else
                this.rd_Nu.Checked = true;

            for (int i = 0; i < this.ckb_mhdk.Items.Count; i++)
                this.ckb_mhdk.SetItemChecked(i, false);

            foreach (string s in sv.MonHoc)
            {
                for (int i = 0; i < this.ckb_mhdk.Items.Count; i++)
                    if (s.CompareTo(this.ckb_mhdk.Items[i]) == 0)
                        this.ckb_mhdk.SetItemChecked(i, true);
            }
        }
        private void ThemSV (SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MaSo);
            lvitem.SubItems.Add(sv.TenLot);
            lvitem.SubItems.Add(sv.Ten);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.Cmnd);
            lvitem.SubItems.Add(sv.Sdt);
            lvitem.SubItems.Add(sv.DiaChi);
            string gt = " Nữ";
            if (sv.GioiTinh)
                gt = " Nam";
            lvitem.SubItems.Add(gt);
            string mh = "";
            foreach (string s in sv.MonHoc)
                mh += s + ",";
            mh = mh.Substring(0, mh.Length - 1);
            lvitem.SubItems.Add(mh);
            this.lv_SinhVien.Items.Add(lvitem);
        }
        private SinhVien UpdateSV(SinhVien sv)
        {
            SinhVien svUpdate = GetSinhVien();
            sv.MaSo = svUpdate.MaSo;
            sv.Ten = svUpdate.TenLot;
            sv.Ten = svUpdate.Ten;
            sv.NgaySinh = svUpdate.NgaySinh;
            sv.Lop = svUpdate.Lop;
            sv.Cmnd = svUpdate.Cmnd;
            sv.Sdt = svUpdate.Sdt;
            sv.DiaChi = svUpdate.DiaChi;
            sv.GioiTinh = svUpdate.GioiTinh;
            sv.MonHoc = svUpdate.MonHoc;
            return sv;
        }
        //Hiện thỉ sv lên List View
        private void LoadListView(List<SinhVien> danhSach)
        {
            this.lv_SinhVien.Items.Clear();
            foreach(SinhVien sv in qlsv.DanhSach)
            {
                ThemSV(sv);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien(context);
            LoadListView(qlsv.DanhSach);
        }

        private void lv_SinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = lv_SinhVien.SelectedItems.Count;
            if(count > 0)
            {
                ListViewItem item = lv_SinhVien.SelectedItems[0];
                ThietLapThongTin(GetSinhVienLV(item));
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            var s = MessageBox.Show("Bạn có muốn thoát chương trình khum ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(s == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private bool Xet()
        {
            if (mtxt_mssv.Text == "") return false;
            else if (txt_tenLot.Text == "") return false;
            else if (txt_Ten.Text == "") return false;
            else if (cbb_lop.Text == "") return false;
            else if (mtxt_sdt.Text == "") return false;
            else if (mtxt_CMND.Text == "") return false;
            else if (txt_DiaChi.Text == "") return false;
            else if (ckb_mhdk.CheckedItems.Count == 0) return false;
            else return true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            SinhVien kq = qlsv.Tim(sv.MaSo, delegate (object obj1, object obj2)
            {
                return (obj2 as SinhVien).MaSo.CompareTo(obj1.ToString());
            });
            if (Xet())
            {
                if (kq == null)
                {
                    this.qlsv.Them(sv);
                    context.SaveSV();
                    LoadListView(qlsv.DanhSach);

                }
                else
                {
                    MessageBox.Show("Mã số sinh viên đã trùng vui lòng nhập lại dùm tui !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            SinhVien sv = qlsv.Tim(GetSinhVien().MaSo, delegate (object obj1, object obj2)
            {
                return (obj2 as SinhVien).MaSo.CompareTo(obj1.ToString());
            });
            if (Xet())
            {
                bool kqsua;
                kqsua = qlsv.Sua(sv, sv.MaSo, delegate (object obj1, object obj2)
                {
                    return (obj2 as SinhVien).MaSo.CompareTo(obj1.ToString());
                });
                LoadListView(qlsv.DanhSach);
                context.SaveSV();

            }
            else
            {
                MessageBox.Show("Vui lòng sửa lại đầy đủ thông tin trước khi cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }
        private int SoSanhTheoMa(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.MaSo.CompareTo(obj1);
        }

        private void xóaSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem lvitem;
            count = this.lv_SinhVien.Items.Count - 1;
            for (i = count; i > 0; i--)
            {
                lvitem = this.lv_SinhVien.Items[i];
                if (lvitem.Checked || lvitem.Selected)
                    qlsv.Xoa(lvitem.SubItems[0].Text, SoSanhTheoMa);
            }
            LoadListView(qlsv.DanhSach);
            context.SaveSV();

        }

        private void xóaMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = ckb_mhdk.CheckedIndices.Count - 1; i >= 0; i--)
            {
                ckb_mhdk.Items.RemoveAt(ckb_mhdk.CheckedIndices[i]);
            }

        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            frm_Tim frm = new frm_Tim(context);
            frm.ShowDialog();
        }

        private void thêmMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ThemMH frm = new frm_ThemMH();
            var dialog = frm.ShowDialog();

            if(dialog == DialogResult.OK)
            {
                string tenMH = frm.tenMonHoc;
                ckb_mhdk.Items.Add(tenMH);
            }
        }
    }
}
