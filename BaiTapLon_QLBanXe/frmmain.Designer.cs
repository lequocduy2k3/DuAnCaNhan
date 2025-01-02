namespace BaiTapLon
{
    partial class frmmain
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
            this.label1 = new System.Windows.Forms.Label();
            this.mnuteptin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnthoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnudanhmuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnunhacc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnumathang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuloaihang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnunhanvien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnukhachhang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuhoadon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuhoadonnhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuhoadonbh = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmKiếmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(180, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 104);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chương trình quản lý bán xe";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // mnuteptin
            // 
            this.mnuteptin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnthoat});
            this.mnuteptin.Name = "mnuteptin";
            this.mnuteptin.Size = new System.Drawing.Size(55, 20);
            this.mnuteptin.Text = "Tệp tin";
            // 
            // mnthoat
            // 
            this.mnthoat.Name = "mnthoat";
            this.mnthoat.Size = new System.Drawing.Size(104, 22);
            this.mnthoat.Text = "Thoát";
            this.mnthoat.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // mnudanhmuc
            // 
            this.mnudanhmuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnunhacc,
            this.mnuloaihang,
            this.mnumathang,
            this.mnunhanvien,
            this.mnukhachhang});
            this.mnudanhmuc.Name = "mnudanhmuc";
            this.mnudanhmuc.Size = new System.Drawing.Size(74, 20);
            this.mnudanhmuc.Text = "Danh mục";
            // 
            // mnunhacc
            // 
            this.mnunhacc.Name = "mnunhacc";
            this.mnunhacc.Size = new System.Drawing.Size(180, 22);
            this.mnunhacc.Text = "Nhà cung cấp";
            this.mnunhacc.Click += new System.EventHandler(this.mnunhacc_Click);
            // 
            // mnumathang
            // 
            this.mnumathang.Name = "mnumathang";
            this.mnumathang.Size = new System.Drawing.Size(180, 22);
            this.mnumathang.Text = "Mặt hàng";
            this.mnumathang.Click += new System.EventHandler(this.mnumathang_Click);
            // 
            // mnuloaihang
            // 
            this.mnuloaihang.Name = "mnuloaihang";
            this.mnuloaihang.Size = new System.Drawing.Size(180, 22);
            this.mnuloaihang.Text = "Loại hàng";
            this.mnuloaihang.Click += new System.EventHandler(this.mnuloaihang_Click);
            // 
            // mnunhanvien
            // 
            this.mnunhanvien.Name = "mnunhanvien";
            this.mnunhanvien.Size = new System.Drawing.Size(180, 22);
            this.mnunhanvien.Text = "Nhân viên";
            this.mnunhanvien.Click += new System.EventHandler(this.mnunhanvien_Click);
            // 
            // mnukhachhang
            // 
            this.mnukhachhang.Name = "mnukhachhang";
            this.mnukhachhang.Size = new System.Drawing.Size(180, 22);
            this.mnukhachhang.Text = "Khách hàng";
            this.mnukhachhang.Click += new System.EventHandler(this.mnukhachhang_Click);
            // 
            // mnuhoadon
            // 
            this.mnuhoadon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuhoadonnhap,
            this.mnuhoadonbh});
            this.mnuhoadon.Name = "mnuhoadon";
            this.mnuhoadon.Size = new System.Drawing.Size(65, 20);
            this.mnuhoadon.Text = "Hóa đơn";
            // 
            // mnuhoadonnhap
            // 
            this.mnuhoadonnhap.Name = "mnuhoadonnhap";
            this.mnuhoadonnhap.Size = new System.Drawing.Size(180, 22);
            this.mnuhoadonnhap.Text = "Hóa đơn nhập hàng";
            this.mnuhoadonnhap.Click += new System.EventHandler(this.mnuhoadonnhap_Click);
            // 
            // mnuhoadonbh
            // 
            this.mnuhoadonbh.Name = "mnuhoadonbh";
            this.mnuhoadonbh.Size = new System.Drawing.Size(180, 22);
            this.mnuhoadonbh.Text = "Hóa đơn bán hàng";
            this.mnuhoadonbh.Click += new System.EventHandler(this.mnuhoadonbh_Click);
            // 
            // tìmKiếmToolStripMenuItem
            // 
            this.tìmKiếmToolStripMenuItem.Name = "tìmKiếmToolStripMenuItem";
            this.tìmKiếmToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.tìmKiếmToolStripMenuItem.Text = "Tìm kiếm ";
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.báoCáoToolStripMenuItem.Text = "Báo cáo ";
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuteptin,
            this.mnudanhmuc,
            this.mnuhoadon,
            this.tìmKiếmToolStripMenuItem,
            this.báoCáoToolStripMenuItem,
            this.trợGiúpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(627, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // frmmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(627, 334);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmmain";
            this.Text = "Chương trình quản lý bán xe";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem mnuteptin;
        private System.Windows.Forms.ToolStripMenuItem mnthoat;
        private System.Windows.Forms.ToolStripMenuItem mnudanhmuc;
        private System.Windows.Forms.ToolStripMenuItem mnunhacc;
        private System.Windows.Forms.ToolStripMenuItem mnumathang;
        private System.Windows.Forms.ToolStripMenuItem mnuloaihang;
        private System.Windows.Forms.ToolStripMenuItem mnunhanvien;
        private System.Windows.Forms.ToolStripMenuItem mnukhachhang;
        private System.Windows.Forms.ToolStripMenuItem mnuhoadon;
        private System.Windows.Forms.ToolStripMenuItem mnuhoadonnhap;
        private System.Windows.Forms.ToolStripMenuItem mnuhoadonbh;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

