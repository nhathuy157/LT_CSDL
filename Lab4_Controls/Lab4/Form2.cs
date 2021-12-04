using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Lab4
{
    public partial class frmPicture : Form
    {
        Point p = new Point();
        bool ctrl;
        public PictureBox pbPicture;
        //Phương thức tạo nhập frmPicture
        public frmPicture()
        {
            InitializeComponent();
        }
        //Phương thức tạo lập frmPicture có tham số
        public frmPicture(string name)
        {
            pbPicture = pbHinh;
            InitializeComponent();

            this.pbHinh.ImageLocation = name;

            this.toolStripStatusLabel1.Text = name;

            ctrl = true;
            this.pbHinh.MouseWheel += PbHinh_MouseWheel;
            this.KeyDown += FrmPicture_KeyDown;
            this.KeyUp += FrmPicture_KeyUp;
            

        }

        private void FrmPicture_KeyUp(object sender, KeyEventArgs e)
        {
            this.ctrl = e.Control;
        }

        private void FrmPicture_KeyDown(object sender, KeyEventArgs e)
        {
            this.ctrl = e.Control;
        }

        private void PbHinh_MouseWheel(object sender, MouseEventArgs e)
        {
            if(ctrl)
            {
                if (e.Delta > 0)
                {
                    this.pbHinh.Width += 50;
                    this.pbHinh.Height += 50;
                }
                else
                {
                    this.pbHinh.Width -= 50;
                    this.pbHinh.Height -= 50;
                }

            }
            else
            {
                if(e.Delta > 0)
                {
                    this.pbHinh.Location = new Point(p.X, p.Y - e.Delta);

                }
                else
                {
                    this.pbHinh.Location = new Point(p.X - e.Delta, p.Y);
                }
                

            }

            
        }

        //Sự kiện LoadFrm
        private void frmPicture_Load(object sender, EventArgs e)
        {
            p = this.pbHinh.Location;
        }
        //ReLoad file cho hình

        private void reLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult dlg = this.openFileDialog1.ShowDialog();
            string title = "";
            if (dlg == DialogResult.OK)
            {
                title = this.Text.Substring(0, Text.LastIndexOf(' ') + 1) + openFileDialog1.FileName;
                this.Text = title;
                this.pbHinh.ImageLocation = openFileDialog1.FileName;
                this.toolStripStatusLabel1.Text = openFileDialog1.FileName;
            }
            }
        //Phóng lớn

        public void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pbHinh.Width += 50;
            this.pbHinh.Height += 50;
        }
        //Phóng nhỏ
        public void zoomToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.pbHinh.Width -= 50;
            this.pbHinh.Height -= 50;
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            this.pbHinh.Location = new Point(p.X, p.Y - e.NewValue);
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            this.pbHinh.Location = new Point(p.X - e.NewValue, p.Y);
        }

        public void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("mspaint", String.Format($"\"{this.pbHinh.ImageLocation}\""));
        }
    }
}
