using Microsoft.Office.Interop.Excel;
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
   
    public partial class Form1 : Form
    {
        TreeNode node;
        private List<Khoa> k;
        QuanLySinhVien qlsv;
        private List<SinhVien> sv;
        public Form1(QuanLySinhVien qlsv)
        {
            InitializeComponent();
            this.qlsv = qlsv;
            
            
        }
        private SinhVien GetSVLV(ListViewItem item)
        {
            SinhVien sv = new SinhVien();
            sv.MaSo = item.SubItems[0].Text;
            sv.TenLot = item.SubItems[1].Text;
            sv.Ten = item.SubItems[2].Text;
            sv.GioiTinh = false;
            if (item.SubItems[3].Text.Trim() == "Nam")
                sv.GioiTinh = true;
            sv.NgaySinh = DateTime.Parse(item.SubItems[4].Text);
            sv.Sdt = item.SubItems[5].Text;
            sv.Lop = item.SubItems[6].Text;
            //sv.Khoa = item.SubItems[7].Text;
            //sv.DiaChi = item.SubItems[8].Text;
            return sv;
        }
        private void ThemSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MaSo);
            lvitem.SubItems.Add(sv.TenLot);
            lvitem.SubItems.Add(sv.Ten);
            string gt = " Nữ";
            if (sv.GioiTinh)
                gt = " Nam";
            lvitem.SubItems.Add(gt);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.Sdt);
            lvitem.SubItems.Add(sv.Lop);
            this.lvSinhVien.Items.Add(lvitem);
        }
       
     
        private void LoadTreeView(List<Khoa> khoa)
        {
            foreach(Khoa k in khoa)
            {
                 node = this.tv_ds.Nodes.Add(k.TenKhoa);
                foreach(Lop l in k.lops)
                {
                    node.Nodes.Add(l.TenLop);
                }
            }
            tv_ds.ExpandAll();
        }
        private void LoadListView(List<SinhVien> sinhVien)
        {
            this.lvSinhVien.Items.Clear();
            foreach (SinhVien sv in sinhVien )
            {
                ThemSV(sv);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadListView(qlsv.DanhSachKhoa[0].dssv);
            //qlsv.DanhSachKhoa[0].lops[0].dssv[0].Ten = "Huy 9 tủi";
            LoadTreeView(qlsv.DanhSachKhoa);
        }

        private void tv_ds_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.lvSinhVien.Items.Clear();
            node = e.Node;
            LoadListView(ListParent());
        }
        public List<SinhVien> ListParent()
        {
            List<SinhVien> sv;
            if (node.Level == 0)
            {
                int i = qlsv.DanhSachKhoa.FindIndex(x => x.TenKhoa == node.Text);
                sv = qlsv.DanhSachKhoa[i].dssv;
            }
            else
            {
                int i = qlsv.DanhSachKhoa.FindIndex(x => x.TenKhoa == node.Parent.Text);
                int y = qlsv.DanhSachKhoa[i].lops.FindIndex(x => x.TenLop == node.Text);
                sv = qlsv.DanhSachKhoa[i].lops[y].dssv;
            }
            return sv;


        }
        public int VT_Khoa()
        {
            if (node.Level == 0)
            {
                int i = qlsv.DanhSachKhoa.FindIndex(x => x.TenKhoa == node.Text);
                return i;
            }
            else
            {
                int i = qlsv.DanhSachKhoa.FindIndex(x => x.TenKhoa == node.Parent.Text);
                return i;
            }
        }

        private void txt_sreach_TextChanged(object sender, EventArgs e)
        {
            
            var search = txt_sreach.Text.Trim().ToLower();
            
            
                if (rdMSSV.Checked)
                {
                    var sv = ListParent().FindAll(x => x.MaSo.Trim().ToLower().Contains(search));
                    LoadListView(sv);
                }
                if (rdHoTen.Checked)
                {
                    var sv = ListParent().FindAll(x => x.Ten.Trim().ToLower().Contains(search));
                    LoadListView(sv);
                }
                if (rdSdt.Checked)
                {
                    var sv = ListParent().FindAll(x => x.Sdt.Trim().ToLower().Contains(search));
                    LoadListView(sv);
                }
            
           

        }

        private void txt_sreach_MouseClick(object sender, MouseEventArgs e)
        {
            txt_sreach.Text = "";
        }
      


        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem item;
            int khoa = VT_Khoa();
            count = lvSinhVien.Items.Count - 1;
            for ( i= count; i >= 0; i--)
            {
                item = lvSinhVien.Items[i];
                if (item.Selected || item.Checked)
                {
                        qlsv.DanhSachKhoa[khoa].XoaSV(item.SubItems[0].Text);
                }
                    
            }
            LoadListView(ListParent());
           
        }
        private void ReLoadLV(SinhVien sv)
        {
            int i = qlsv.DanhSachKhoa.FindIndex(x => x.TenKhoa == sv.Khoa);
            int j = qlsv.DanhSachKhoa[i].VT_Lop(sv.Lop);
            LoadListView(qlsv.DanhSachKhoa[i].lops[j].dssv);


        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SinhVien sv = new SinhVien();
            TTSinhVien frm = new TTSinhVien(sv,qlsv);
            if(frm.ShowDialog()== DialogResult.OK)
            {
                ReLoadLV(frm.sv);
            }
            
           
        }

        private void lvSinhVien_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            
            string item = lvSinhVien.SelectedItems[0].Text;
            SinhVien sv = qlsv.DanhSachKhoa[VT_Khoa()].TimSV(item);
            TTSinhVien frm = new TTSinhVien(sv,qlsv);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ReLoadLV(frm.sv);
            }




        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode ten = tv_ds.SelectedNode;
            using (SaveFileDialog sfd = new SaveFileDialog()
            { Filter = "Excel WorkBook|*.xls||*.xlsx", ValidateNames = true,
                InitialDirectory = @"D:\",
            DefaultExt ="xlxs", FileName = ten.Text})
            {
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;
                    app.Visible = false;

                    int i = 1, j = 1;
                    foreach(ListViewItem item in lvSinhVien.Items)
                    {
                        ws.Cells[1, 1] = "ID";
                        ws.Cells[1, 2] = "Họ và tên lót";
                        ws.Cells[1, 3] = "Tên";
                        ws.Cells[1, 4] = "Giới tính";
                        ws.Cells[1, 5] = "Ngày sinh";
                        ws.Cells[1, 6] = "SDT";
                        ws.Cells[1, 7] = "Lớp";
                        ws.Cells[i, j] = item.Text.ToString();
                        foreach(ListViewItem.ListViewSubItem item1 in item.SubItems)
                        {
                            ws.Cells[i, j] = item1.Text.ToString();
                            j++;
                        }
                        j = 1;
                        i++;
                    }
                    wb.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false,
                        XlSaveAsAccessMode.xlNoChange,Type.Missing, Type.Missing );
                    MessageBox.Show("Lưu thành công rồi đó :))", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }
            }
        }

        private void jsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = "json";
            saveFileDialog1.Filter = "Json file (.json)|.*";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.Title = "Nơi lưu file";
            saveFileDialog1.InitialDirectory = @"D:";
            saveFileDialog1.FileName = node.Text;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                qlsv.LuuJson(ListParent(), saveFileDialog1.FileName);
                MessageBox.Show("Bạn đã lưu file thành công" ,"Thông báo",MessageBoxButtons.OK);
            }
            saveFileDialog1.Dispose();
        }
    }
}
