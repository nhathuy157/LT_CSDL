using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_2
{
    public partial class frmGiaoVien : Form
    {
        QuanLyGiaoVien qlgv ;
        public frmGiaoVien()
        {
            
            
            InitializeComponent();
        }

        private void frmGiaoVien_Load(object sender, EventArgs e)
        {
            qlgv = new QuanLyGiaoVien();
            string lienhe = "http://it.dlu.vn/e-learning/Default.aspx";
            this.linklbLienHe.Links.Add(0, lienhe.Length, lienhe);
            this.cbbMaSo.SelectedItem = this.cbbMaSo.Items[0];
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            int i = this.lbDSMonHoc.SelectedItems.Count-1;
            while(i >= 0)
            {
                this.lbMonHocDay.Items.Add(lbDSMonHoc.SelectedItems[i]);
                this.lbDSMonHoc.Items.Remove(lbDSMonHoc.SelectedItems[i]);
                i--;
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int i = this.lbMonHocDay.SelectedItems.Count - 1;
            while(i >= 0)
            {
                this.lbDSMonHoc.Items.Add(lbMonHocDay.SelectedItems[i]);
                this.lbMonHocDay.Items.Add(lbMonHocDay.SelectedItems[i]);
                i--;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }
        public void Reset()
        {
            this.cbbMaSo.Text = "";
            this.txtHoTen.Text = "";
            this.txtMail.Text = "";
            this.mtxtSoDT.Text = "";
            this.rdNam.Checked = true;

            //Bỏ chọn trên checkboxNgoaiNgu
            for (int i = 0; i < chklbNgoaiNgu.Items.Count - 1; i++)
                chklbNgoaiNgu.SetItemChecked(i, false);
            //Chuyển các môn từ lbMonMon hoc sang Danh Sách MH
            foreach (Object ob in this.lbMonHocDay.Items)
                this.lbDSMonHoc.Items.Add(ob);
            this.lbMonHocDay.Items.Clear();
        }

        private void linklbLienHe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string s = e.Link.LinkData.ToString();
            Process.Start(s);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            frmTBGiaoVien frm = new frmTBGiaoVien();
            frm.SetText(GetGiaoVien().ToString());
            frm.ShowDialog();
        }
        public GiaoVien GetGiaoVien()
        {
            string gt = "Nam";
            if (rdNu.Checked)
                gt = "Nữ";
            GiaoVien gv = new GiaoVien();
            gv.MaSo = this.cbbMaSo.Text;
            gv.GioiTinh = gt;
            gv.HoTen = this.txtHoTen.Text;
            gv.NgaySinh = this.dtpNgaySinh.Value;
            gv.Mail = this.txtMail.Text;
            gv.SoDT = this.mtxtSoDT.Text;
            //Lay thong tin NN
            string ngoaingu = "";
            for (int i = 0; i < chklbNgoaiNgu.Items.Count - 1; i++)
                if (chklbNgoaiNgu.GetItemChecked(i))
                    ngoaingu += chklbNgoaiNgu.Items[i] + ";";
            gv.NgoaiNgu = ngoaingu.Split(';');
            DanhMucMonHoc mh = new DanhMucMonHoc();
            foreach (object ob in lbMonHocDay.Items)
                mh.Them(new MonHoc(ob.ToString()));
            gv.dsMonHoc = mh;
            return gv;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            GiaoVien gv = GetGiaoVien();
            GiaoVien kq = qlgv.Tim(gv.MaSo, delegate (object gv1, object gv2)
             {
                 return (gv2 as GiaoVien).MaSo.CompareTo(gv1.ToString());

             });
            if(kq != null)
            {
                MessageBox.Show("Mã giáo viên đã tồn tại!", "Lỗi");
            }
            else
            {
                this.qlgv.Them(gv);
                frmTBGiaoVien frm = new frmTBGiaoVien();
                frm.SetText(GetGiaoVien().ToString());
                frm.ShowDialog();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            TimTTGV frm = new TimTTGV(qlgv);
            frm.ShowDialog();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
