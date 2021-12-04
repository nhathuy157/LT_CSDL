
namespace Lab5
{
    partial class frm_Tim
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gr_Tim = new System.Windows.Forms.GroupBox();
            this.rd_Lop = new System.Windows.Forms.RadioButton();
            this.rd_Ten = new System.Windows.Forms.RadioButton();
            this.rd_Ms = new System.Windows.Forms.RadioButton();
            this.lbHienThi = new System.Windows.Forms.Label();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.btn_Tim = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.lv_SinhVien = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gr_Tim.SuspendLayout();
            this.SuspendLayout();
            // 
            // gr_Tim
            // 
            this.gr_Tim.Controls.Add(this.rd_Lop);
            this.gr_Tim.Controls.Add(this.rd_Ten);
            this.gr_Tim.Controls.Add(this.rd_Ms);
            this.gr_Tim.Location = new System.Drawing.Point(160, 15);
            this.gr_Tim.Name = "gr_Tim";
            this.gr_Tim.Size = new System.Drawing.Size(454, 100);
            this.gr_Tim.TabIndex = 0;
            this.gr_Tim.TabStop = false;
            this.gr_Tim.Text = "Tìm theo";
            // 
            // rd_Lop
            // 
            this.rd_Lop.AutoSize = true;
            this.rd_Lop.Location = new System.Drawing.Point(340, 43);
            this.rd_Lop.Name = "rd_Lop";
            this.rd_Lop.Size = new System.Drawing.Size(53, 21);
            this.rd_Lop.TabIndex = 2;
            this.rd_Lop.TabStop = true;
            this.rd_Lop.Text = "Lớp";
            this.rd_Lop.UseVisualStyleBackColor = true;
            this.rd_Lop.CheckedChanged += new System.EventHandler(this.rd_Lop_CheckedChanged);
            // 
            // rd_Ten
            // 
            this.rd_Ten.AutoSize = true;
            this.rd_Ten.Location = new System.Drawing.Point(185, 43);
            this.rd_Ten.Name = "rd_Ten";
            this.rd_Ten.Size = new System.Drawing.Size(54, 21);
            this.rd_Ten.TabIndex = 1;
            this.rd_Ten.TabStop = true;
            this.rd_Ten.Text = "Tên";
            this.rd_Ten.UseVisualStyleBackColor = true;
            this.rd_Ten.CheckedChanged += new System.EventHandler(this.rd_Ten_CheckedChanged);
            // 
            // rd_Ms
            // 
            this.rd_Ms.AutoSize = true;
            this.rd_Ms.Location = new System.Drawing.Point(33, 43);
            this.rd_Ms.Name = "rd_Ms";
            this.rd_Ms.Size = new System.Drawing.Size(67, 21);
            this.rd_Ms.TabIndex = 0;
            this.rd_Ms.TabStop = true;
            this.rd_Ms.Text = "Mã số";
            this.rd_Ms.UseVisualStyleBackColor = true;
            this.rd_Ms.CheckedChanged += new System.EventHandler(this.rd_Ms_CheckedChanged);
            // 
            // lbHienThi
            // 
            this.lbHienThi.AutoSize = true;
            this.lbHienThi.Location = new System.Drawing.Point(157, 149);
            this.lbHienThi.Name = "lbHienThi";
            this.lbHienThi.Size = new System.Drawing.Size(46, 17);
            this.lbHienThi.TabIndex = 1;
            this.lbHienThi.Text = "label1";
            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(263, 146);
            this.txt_Search.Multiline = true;
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(351, 32);
            this.txt_Search.TabIndex = 2;
            // 
            // btn_Tim
            // 
            this.btn_Tim.Location = new System.Drawing.Point(246, 206);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(103, 36);
            this.btn_Tim.TabIndex = 3;
            this.btn_Tim.Text = "Tìm";
            this.btn_Tim.UseVisualStyleBackColor = true;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(428, 206);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(103, 36);
            this.btn_Thoat.TabIndex = 4;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // lv_SinhVien
            // 
            this.lv_SinhVien.CheckBoxes = true;
            this.lv_SinhVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lv_SinhVien.FullRowSelect = true;
            this.lv_SinhVien.GridLines = true;
            this.lv_SinhVien.HideSelection = false;
            this.lv_SinhVien.Location = new System.Drawing.Point(12, 265);
            this.lv_SinhVien.Name = "lv_SinhVien";
            this.lv_SinhVien.Size = new System.Drawing.Size(769, 178);
            this.lv_SinhVien.TabIndex = 5;
            this.lv_SinhVien.UseCompatibleStateImageBehavior = false;
            this.lv_SinhVien.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "MSSV";
            this.columnHeader1.Width = 72;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Họ và tên lót";
            this.columnHeader2.Width = 93;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên";
            this.columnHeader3.Width = 67;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ngày sinh";
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Lớp";
            this.columnHeader5.Width = 57;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "CMND";
            this.columnHeader6.Width = 95;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Số điện thoại";
            this.columnHeader7.Width = 129;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Địa chỉ liên lạc";
            this.columnHeader8.Width = 156;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Giới tính";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Môn học đăng ký";
            // 
            // frm_Tim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 455);
            this.Controls.Add(this.lv_SinhVien);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_Tim);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.lbHienThi);
            this.Controls.Add(this.gr_Tim);
            this.Name = "frm_Tim";
            this.Text = "Tìm Sinh Viên";
            this.Load += new System.EventHandler(this.frm_Tim_Load);
            this.gr_Tim.ResumeLayout(false);
            this.gr_Tim.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gr_Tim;
        private System.Windows.Forms.RadioButton rd_Lop;
        private System.Windows.Forms.RadioButton rd_Ten;
        private System.Windows.Forms.RadioButton rd_Ms;
        private System.Windows.Forms.Label lbHienThi;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Button btn_Tim;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.ListView lv_SinhVien;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
    }
}