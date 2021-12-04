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
    public partial class frm_ThemMH : Form
    {
        public string tenMonHoc;
        public frm_ThemMH()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if(txt_MH.Text =="")
            {
                MessageBox.Show("Vui lòng nhập thông tin","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tenMonHoc = txt_MH.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        

        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
