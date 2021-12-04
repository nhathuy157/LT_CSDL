using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnTapKiemTra
{
    public partial class TTSinhVien : Form
    {
        public QuanLySinhVien qlsv;
        public SinhVien sv;
        



        public TTSinhVien(SinhVien sv,QuanLySinhVien qlsv)
        {
            this.qlsv = qlsv;
            this.sv = sv;
            InitializeComponent();
        }
        private SinhVien GetSV()
        {
            
            sv.MaSo = mtxt_Maso.Text;
            sv.TenLot = txt_Ho.Text;
            sv.Ten = txt_Ten.Text;
            sv.NgaySinh = dtp_ngaysinh.Value;
            sv.GioiTinh = (rd_Nam.Checked == true ? true : false);
            sv.Lop = cbb_Lop.Text;
            sv.Khoa = cbb_Khoa.Text;
            sv.DiaChi = txt_diachi.Text;
            sv.Sdt = mtxt_sdt.Text;

            return sv;
        }
        private void Load_CbbKhoa()
        {
            cbb_Khoa.Items.Clear();
            
            
            foreach(var k in qlsv.DanhSachKhoa)
            {
                cbb_Khoa.Items.Add(k.TenKhoa);

                 
            }
        }
        private void Load_CbbLop(int vt_khoa)
        {
            cbb_Lop.Items.Clear();
            foreach (var l in qlsv.DanhSachKhoa[vt_khoa].lops)
            {
                cbb_Lop.Items.Add(l.TenLop);
            }


        }
        private void SetSVInControl()
        {
                mtxt_Maso.Text = sv.MaSo;
                txt_Ho.Text = sv.TenLot;
                txt_Ten.Text = sv.Ten;
                rd_Nam.Checked = (sv.GioiTinh == true ? true : false);
                rd_Nu.Checked = (sv.GioiTinh == false ? true : false);
                dtp_ngaysinh.Text = DateTime.Now.ToShortDateString();
                cbb_Khoa.Text = sv.Khoa;
                cbb_Lop.Text = sv.Lop;
                mtxt_sdt.Text = sv.Sdt;
                txt_diachi.Text = sv.DiaChi;
        }

        private void TTSinhVien_Load(object sender, EventArgs e)
        {
            Load_CbbKhoa();
            if (sv.MaSo != "")
            {
                this.mtxt_Maso.Enabled = false;
                
            }
            else
            {
                cbb_Khoa.SelectedIndex = 0;

            }
            SetSVInControl();
        }

        private void cbb_Khoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cbb_Khoa.SelectedIndex;
            Load_CbbLop(i);
        }
        private bool Xet()
        {
            if (mtxt_Maso.Text == "") return false;
            else if (txt_Ho.Text == "") return false;
            else if (txt_Ten.Text == "") return false;
            else if (cbb_Khoa.Text == "") return false;
            //else if (mtxt_sdt.Text == "") return false;
            else if (cbb_Lop.Text == "") return false;
            //else if (txt_diachi.Text == "") return false;
            
            else return true;
        }
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            
            SinhVien student = GetSV();
            int i = qlsv.DanhSachKhoa.FindIndex(x => x.TenKhoa == cbb_Khoa.SelectedItem.ToString());
          

            if (Xet())
            {
                SinhVien kq = qlsv.DanhSachKhoa[i].TimSV(sv.MaSo);
                if (kq == null)
                {
                    qlsv.DanhSachKhoa[i].ThemSV(student);
                    this.Close();
                    MessageBox.Show("Bạn đã lưu thành công", "Thông báo", MessageBoxButtons.OK);
                    DialogResult = DialogResult.OK;
                    

                }
                else
                {
                    qlsv.DanhSachKhoa[i].CapNhatSV(student);
                    this.Close();
                    MessageBox.Show("Bạn đã cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                    DialogResult = DialogResult.OK;

                }

            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }
    }
}
