
namespace Lab2_2
{
    partial class TimTTGV
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rd_sdt = new System.Windows.Forms.RadioButton();
            this.rd_ten = new System.Windows.Forms.RadioButton();
            this.rd_Id = new System.Windows.Forms.RadioButton();
            this.lbHienThi = new System.Windows.Forms.Label();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rd_sdt);
            this.groupBox1.Controls.Add(this.rd_ten);
            this.groupBox1.Controls.Add(this.rd_Id);
            this.groupBox1.Location = new System.Drawing.Point(45, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm theo";
            // 
            // rd_sdt
            // 
            this.rd_sdt.AutoSize = true;
            this.rd_sdt.Location = new System.Drawing.Point(342, 24);
            this.rd_sdt.Name = "rd_sdt";
            this.rd_sdt.Size = new System.Drawing.Size(118, 24);
            this.rd_sdt.TabIndex = 2;
            this.rd_sdt.TabStop = true;
            this.rd_sdt.Text = "Số điện thoại";
            this.rd_sdt.UseVisualStyleBackColor = true;
            this.rd_sdt.CheckedChanged += new System.EventHandler(this.rd_sdt_CheckedChanged);
            // 
            // rd_ten
            // 
            this.rd_ten.AutoSize = true;
            this.rd_ten.Location = new System.Drawing.Point(197, 26);
            this.rd_ten.Name = "rd_ten";
            this.rd_ten.Size = new System.Drawing.Size(77, 24);
            this.rd_ten.TabIndex = 1;
            this.rd_ten.TabStop = true;
            this.rd_ten.Text = "Họ Tên";
            this.rd_ten.UseVisualStyleBackColor = true;
            this.rd_ten.CheckedChanged += new System.EventHandler(this.rd_ten_CheckedChanged);
            // 
            // rd_Id
            // 
            this.rd_Id.AutoSize = true;
            this.rd_Id.Location = new System.Drawing.Point(30, 26);
            this.rd_Id.Name = "rd_Id";
            this.rd_Id.Size = new System.Drawing.Size(74, 24);
            this.rd_Id.TabIndex = 0;
            this.rd_Id.TabStop = true;
            this.rd_Id.Text = "Mã GV";
            this.rd_Id.UseVisualStyleBackColor = true;
            this.rd_Id.CheckedChanged += new System.EventHandler(this.rd_Id_CheckedChanged);
            // 
            // lbHienThi
            // 
            this.lbHienThi.AutoSize = true;
            this.lbHienThi.Location = new System.Drawing.Point(27, 124);
            this.lbHienThi.Name = "lbHienThi";
            this.lbHienThi.Size = new System.Drawing.Size(50, 20);
            this.lbHienThi.TabIndex = 3;
            this.lbHienThi.Text = "label1";
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(161, 117);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(232, 27);
            this.txt_search.TabIndex = 4;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(421, 116);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(94, 29);
            this.btn_ok.TabIndex = 5;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // TimTTGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 172);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.lbHienThi);
            this.Controls.Add(this.groupBox1);
            this.Name = "TimTTGV";
            this.Text = "TimTTGV";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rd_sdt;
        private System.Windows.Forms.RadioButton rd_ten;
        private System.Windows.Forms.RadioButton rd_Id;
        private System.Windows.Forms.Label lbHienThi;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TextBox txt_search;
    }
}