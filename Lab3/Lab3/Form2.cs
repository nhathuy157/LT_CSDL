using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class frm_TuyChon : Form
    {
        public string search;
        public TrangThai trangthai;
        private TrangThai loai;
        

        public frm_TuyChon( TrangThai loai )
        {
            this.loai = loai;
            
            InitializeComponent();
        }
        private void frm_TuyChon_Load(object sender, EventArgs e)
        {
            if(loai == TrangThai.timKiem)
            {
                btn_sapxep.Enabled = false; 
            }
            else
            {
                pn_search.Enabled = false;
            }

        }




        private void btn_Thoatt_Click(object sender, EventArgs e)
        {
            Close();
        }

        
        private void btn_Tim_Click(object sender, EventArgs e)
        {
            search = txt_Search.Text;
            if(string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Hãy nhập thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                if(rd_MaSV.Checked == true)
                {
                    trangthai = TrangThai.MaSV;
                   
                }
                if (rd_hoten.Checked == true)
                {
                    trangthai = TrangThai.Ten;
                }
                if (rd_ngaysinh.Checked == true)
                {
                    trangthai = TrangThai.NgaySinh;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void btn_sapxep_Click(object sender, EventArgs e)
        {

            if (rd_MaSV.Checked == true)
            {
                trangthai = TrangThai.MaSV;

            }
            if (rd_hoten.Checked == true)
            {
                trangthai = TrangThai.Ten;
            }
            if (rd_ngaysinh.Checked == true)
            {
                trangthai = TrangThai.NgaySinh;
            }
            DialogResult = DialogResult.OK;
        }
    }
}
