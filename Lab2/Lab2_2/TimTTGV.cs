using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab2_2
{
    public partial class TimTTGV : Form
    {
        public List<GiaoVien> dsGiaoVien;
        public GiaoVien gv;
        public TimTTGV(QuanLyGiaoVien qlgv)
        {
            dsGiaoVien = qlgv.dsGiaoVien;
            InitializeComponent();
        }

        private void rd_Id_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton radioButton = (RadioButton)sender;
                if (rd_Id.Checked)
                {
                    lbHienThi.Text = rd_Id.Text;
                }
            }
        }

        private void rd_ten_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton radioButton = (RadioButton)sender;
                if (rd_ten.Checked)
                {
                    lbHienThi.Text = rd_ten.Text;
                }
            }

        }

        private void rd_sdt_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton radioButton = (RadioButton)sender;
                if (rd_sdt.Checked)
                {
                    lbHienThi.Text = rd_sdt.Text;
                }
            }

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            var search = txt_search.Text;
            if (rd_Id.Checked == true)
            {
                GiaoVien kq = dsGiaoVien.Find(x => x.MaSo.Trim() == search.Trim());
                if(kq == null)
                {
                    MessageBox.Show("Không tìm thấy giáo viên có mã số " + search, "Lỗi");
                }
                else
                {
                    frmTBGiaoVien frm = new frmTBGiaoVien();
                    frm.SetText(kq.ToString());
                    frm.ShowDialog();
                }
            }
            if (rd_ten.Checked == true)
            {
                GiaoVien kq = dsGiaoVien.Find(x => x.HoTen.ToLower().Trim() == search.ToLower().Trim());
                if (kq == null)
                {
                    MessageBox.Show("Không tìm thấy giáo viên có họ tên " + search, "Lỗi");
                }
                else
                {
                    frmTBGiaoVien frm = new frmTBGiaoVien();
                    frm.SetText(kq.ToString());
                    frm.ShowDialog();
                }

            }
            if(rd_sdt.Checked == true)
            {

                GiaoVien kq = dsGiaoVien.Find(x => x.SoDT.Trim() == search.Trim());
                if (kq == null)
                {
                    MessageBox.Show("Không tìm thấy giáo viên có số điện thoại " + search, "Lỗi");
                }
                else
                {
                    frmTBGiaoVien frm = new frmTBGiaoVien();
                    frm.SetText(kq.ToString());
                    frm.ShowDialog();
                }

            }
        }
    }
}
