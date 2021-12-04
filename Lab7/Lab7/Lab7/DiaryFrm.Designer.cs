
namespace Lab7
{
    partial class DiaryFrm
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
            this.dvg_Bills = new System.Windows.Forms.DataGridView();
            this.lb_date = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_Bills)).BeginInit();
            this.SuspendLayout();
            // 
            // dvg_Bills
            // 
            this.dvg_Bills.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dvg_Bills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvg_Bills.Location = new System.Drawing.Point(176, 0);
            this.dvg_Bills.Name = "dvg_Bills";
            this.dvg_Bills.RowHeadersWidth = 51;
            this.dvg_Bills.RowTemplate.Height = 24;
            this.dvg_Bills.Size = new System.Drawing.Size(834, 448);
            this.dvg_Bills.TabIndex = 1;
            // 
            // lb_date
            // 
            this.lb_date.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_date.FormattingEnabled = true;
            this.lb_date.ItemHeight = 16;
            this.lb_date.Location = new System.Drawing.Point(2, 7);
            this.lb_date.Name = "lb_date";
            this.lb_date.Size = new System.Drawing.Size(168, 436);
            this.lb_date.TabIndex = 2;
            this.lb_date.SelectedIndexChanged += new System.EventHandler(this.lb_date_SelectedIndexChanged);
            // 
            // DiaryFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 450);
            this.Controls.Add(this.lb_date);
            this.Controls.Add(this.dvg_Bills);
            this.Name = "DiaryFrm";
            this.Text = "DiaryFrom";
            ((System.ComponentModel.ISupportInitialize)(this.dvg_Bills)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dvg_Bills;
        private System.Windows.Forms.ListBox lb_date;
    }
}