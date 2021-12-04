
namespace Lab3
{
    partial class frm_TuyChon
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rd_ngaysinh = new System.Windows.Forms.RadioButton();
            this.rd_hoten = new System.Windows.Forms.RadioButton();
            this.rd_MaSV = new System.Windows.Forms.RadioButton();
            this.pn_search = new System.Windows.Forms.Panel();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Tim = new System.Windows.Forms.Button();
            this.btn_sapxep = new System.Windows.Forms.Button();
            this.btn_Thoatt = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pn_search.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rd_ngaysinh);
            this.panel1.Controls.Add(this.rd_hoten);
            this.panel1.Controls.Add(this.rd_MaSV);
            this.panel1.Location = new System.Drawing.Point(42, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 82);
            this.panel1.TabIndex = 0;
            // 
            // rd_ngaysinh
            // 
            this.rd_ngaysinh.AutoSize = true;
            this.rd_ngaysinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_ngaysinh.ForeColor = System.Drawing.Color.Blue;
            this.rd_ngaysinh.Location = new System.Drawing.Point(300, 32);
            this.rd_ngaysinh.Name = "rd_ngaysinh";
            this.rd_ngaysinh.Size = new System.Drawing.Size(103, 22);
            this.rd_ngaysinh.TabIndex = 6;
            this.rd_ngaysinh.Text = "Ngày sinh";
            this.rd_ngaysinh.UseVisualStyleBackColor = true;
            // 
            // rd_hoten
            // 
            this.rd_hoten.AutoSize = true;
            this.rd_hoten.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_hoten.ForeColor = System.Drawing.Color.Blue;
            this.rd_hoten.Location = new System.Drawing.Point(145, 32);
            this.rd_hoten.Name = "rd_hoten";
            this.rd_hoten.Size = new System.Drawing.Size(84, 22);
            this.rd_hoten.TabIndex = 5;
            this.rd_hoten.Text = "Họ Tên";
            this.rd_hoten.UseVisualStyleBackColor = true;
            // 
            // rd_MaSV
            // 
            this.rd_MaSV.AutoSize = true;
            this.rd_MaSV.Checked = true;
            this.rd_MaSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_MaSV.ForeColor = System.Drawing.Color.Blue;
            this.rd_MaSV.Location = new System.Drawing.Point(25, 32);
            this.rd_MaSV.Name = "rd_MaSV";
            this.rd_MaSV.Size = new System.Drawing.Size(78, 22);
            this.rd_MaSV.TabIndex = 4;
            this.rd_MaSV.TabStop = true;
            this.rd_MaSV.Text = "Mã SV";
            this.rd_MaSV.UseVisualStyleBackColor = true;
            // 
            // pn_search
            // 
            this.pn_search.Controls.Add(this.txt_Search);
            this.pn_search.Controls.Add(this.label1);
            this.pn_search.Controls.Add(this.btn_Tim);
            this.pn_search.Location = new System.Drawing.Point(42, 138);
            this.pn_search.Name = "pn_search";
            this.pn_search.Size = new System.Drawing.Size(417, 47);
            this.pn_search.TabIndex = 1;
            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(145, 7);
            this.txt_Search.Multiline = true;
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(199, 32);
            this.txt_Search.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nhập thông tin";
            // 
            // btn_Tim
            // 
            this.btn_Tim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tim.ForeColor = System.Drawing.Color.Red;
            this.btn_Tim.Location = new System.Drawing.Point(348, 3);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(66, 41);
            this.btn_Tim.TabIndex = 4;
            this.btn_Tim.Text = "Tìm";
            this.btn_Tim.UseVisualStyleBackColor = true;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            // 
            // btn_sapxep
            // 
            this.btn_sapxep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sapxep.ForeColor = System.Drawing.Color.Red;
            this.btn_sapxep.Location = new System.Drawing.Point(53, 210);
            this.btn_sapxep.Name = "btn_sapxep";
            this.btn_sapxep.Size = new System.Drawing.Size(149, 42);
            this.btn_sapxep.TabIndex = 2;
            this.btn_sapxep.Text = "Sắp Xếp";
            this.btn_sapxep.UseVisualStyleBackColor = true;
            this.btn_sapxep.Click += new System.EventHandler(this.btn_sapxep_Click);
            // 
            // btn_Thoatt
            // 
            this.btn_Thoatt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Thoatt.ForeColor = System.Drawing.Color.Red;
            this.btn_Thoatt.Location = new System.Drawing.Point(289, 210);
            this.btn_Thoatt.Name = "btn_Thoatt";
            this.btn_Thoatt.Size = new System.Drawing.Size(149, 42);
            this.btn_Thoatt.TabIndex = 3;
            this.btn_Thoatt.Text = "Thoát";
            this.btn_Thoatt.UseVisualStyleBackColor = true;
            this.btn_Thoatt.Click += new System.EventHandler(this.btn_Thoatt_Click);
            // 
            // frm_TuyChon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 294);
            this.Controls.Add(this.btn_Thoatt);
            this.Controls.Add(this.btn_sapxep);
            this.Controls.Add(this.pn_search);
            this.Controls.Add(this.panel1);
            this.Name = "frm_TuyChon";
            this.Text = "Tùy Chọn";
            this.Load += new System.EventHandler(this.frm_TuyChon_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pn_search.ResumeLayout(false);
            this.pn_search.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rd_ngaysinh;
        private System.Windows.Forms.RadioButton rd_hoten;
        private System.Windows.Forms.RadioButton rd_MaSV;
        private System.Windows.Forms.Panel pn_search;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Tim;
        private System.Windows.Forms.Button btn_sapxep;
        private System.Windows.Forms.Button btn_Thoatt;
    }
}