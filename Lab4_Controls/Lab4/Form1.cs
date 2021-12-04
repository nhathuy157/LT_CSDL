using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class frmPictureView : Form
    {
        int count = 0;
        public frmPictureView()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlg = this.openFileDlg.ShowDialog();
            if(dlg == DialogResult.OK)
            {
                frmPicture frm = new frmPicture(openFileDlg.FileName);
                frm.MdiParent = this;
                count++;
                frm.Text = "Picture" + count + "-" + openFileDlg.FileName;
                frm.Show();
            }
            this.toolStripStatusLabel1.Text = "Tổng số Form con:" + count.ToString();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlg = this.saveFileDlg.ShowDialog();
            if(dlg == DialogResult.OK)
            {
                frmPicture frm = this.ActiveMdiChild as frmPicture;
                try
                {
                    Image img = frm.pbPicture.Image;
                    img.Save(saveFileDlg.FileName, ImageFormat.Bmp);

                }
                catch 
                {
                    MessageBox.Show("Lỗi lưu file");

                    
                }

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void statusStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool check = this.statusStripToolStripMenuItem.Checked;
            if (check)
                this.statusStrip1.Visible = true;
            else
                this.statusStrip1.Visible = false;

        }

        private void toolStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool check = this.toolStripToolStripMenuItem.Checked;
            if (check)
                this.toolStrip1.Visible = true;
            else
                this.toolStrip1.Visible = false;

        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void arrangeHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal) ;
        }

        private void arrangeVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void maximizeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
                frm.WindowState = FormWindowState.Maximized;

        }

        private void minimizeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
                frm.WindowState = FormWindowState.Minimized;


        }
        //ZoomOut
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmPicture frm = this.ActiveMdiChild as frmPicture;
            frm.zoomToolStripMenuItem_Click(sender, e);

        }
        //ZoomIn
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmPicture frm = this.ActiveMdiChild as frmPicture;
            frm.zoomToolStripMenuItem1_Click(sender, e);

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmPicture frm = this.ActiveMdiChild as frmPicture;
            frm.editToolStripMenuItem_Click(sender, e);
        }
    }
}
