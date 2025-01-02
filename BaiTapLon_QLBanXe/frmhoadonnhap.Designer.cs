namespace BaiTapLon
{
    partial class frmhoadonnhap
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
            this.cbxmamh = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsoluong = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtgianhap = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnthoat = new System.Windows.Forms.Button();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.dgvhoadonnhap = new System.Windows.Forms.DataGridView();
            this.txtmahdnhap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpngaynhaphang = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvhoadonnhap)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxmamh
            // 
            this.cbxmamh.FormattingEnabled = true;
            this.cbxmamh.Location = new System.Drawing.Point(132, 86);
            this.cbxmamh.Name = "cbxmamh";
            this.cbxmamh.Size = new System.Drawing.Size(144, 21);
            this.cbxmamh.TabIndex = 104;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 103;
            this.label2.Text = "Mã mặt hàng";
            // 
            // txtsoluong
            // 
            this.txtsoluong.Location = new System.Drawing.Point(408, 86);
            this.txtsoluong.Name = "txtsoluong";
            this.txtsoluong.Size = new System.Drawing.Size(144, 20);
            this.txtsoluong.TabIndex = 102;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(342, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 101;
            this.label6.Text = "Số lượng";
            // 
            // txtgianhap
            // 
            this.txtgianhap.Location = new System.Drawing.Point(408, 112);
            this.txtgianhap.Name = "txtgianhap";
            this.txtgianhap.Size = new System.Drawing.Size(144, 20);
            this.txtgianhap.TabIndex = 98;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 97;
            this.label3.Text = "Giá nhập";
            // 
            // btnthoat
            // 
            this.btnthoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthoat.Location = new System.Drawing.Point(504, 354);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(86, 33);
            this.btnthoat.TabIndex = 96;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            // 
            // btntimkiem
            // 
            this.btntimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntimkiem.Location = new System.Drawing.Point(388, 354);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(86, 33);
            this.btntimkiem.TabIndex = 95;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            // 
            // btnxoa
            // 
            this.btnxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxoa.Location = new System.Drawing.Point(273, 354);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(86, 33);
            this.btnxoa.TabIndex = 94;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsua.Location = new System.Drawing.Point(146, 354);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(86, 33);
            this.btnsua.TabIndex = 93;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnthem
            // 
            this.btnthem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthem.Location = new System.Drawing.Point(24, 354);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(86, 33);
            this.btnthem.TabIndex = 92;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // dgvhoadonnhap
            // 
            this.dgvhoadonnhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvhoadonnhap.Location = new System.Drawing.Point(12, 149);
            this.dgvhoadonnhap.Name = "dgvhoadonnhap";
            this.dgvhoadonnhap.Size = new System.Drawing.Size(602, 184);
            this.dgvhoadonnhap.TabIndex = 91;
            this.dgvhoadonnhap.Click += new System.EventHandler(this.dgvhoadonnhap_Click);
            // 
            // txtmahdnhap
            // 
            this.txtmahdnhap.Location = new System.Drawing.Point(132, 60);
            this.txtmahdnhap.Name = "txtmahdnhap";
            this.txtmahdnhap.Size = new System.Drawing.Size(144, 20);
            this.txtmahdnhap.TabIndex = 90;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(217, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(298, 51);
            this.label4.TabIndex = 89;
            this.label4.Text = "Bảng hóa đơn nhập";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 88;
            this.label1.Text = "Mã hóa đơn";
            // 
            // dtpngaynhaphang
            // 
            this.dtpngaynhaphang.CustomFormat = "dd/MM/yyyy";
            this.dtpngaynhaphang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpngaynhaphang.Location = new System.Drawing.Point(408, 60);
            this.dtpngaynhaphang.Name = "dtpngaynhaphang";
            this.dtpngaynhaphang.ShowUpDown = true;
            this.dtpngaynhaphang.Size = new System.Drawing.Size(144, 20);
            this.dtpngaynhaphang.TabIndex = 106;
            this.dtpngaynhaphang.Value = new System.DateTime(2024, 4, 5, 13, 14, 2, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 105;
            this.label5.Text = "Ngày nhập hàng";
            // 
            // frmhoadonnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 404);
            this.Controls.Add(this.dtpngaynhaphang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxmamh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtsoluong);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtgianhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.dgvhoadonnhap);
            this.Controls.Add(this.txtmahdnhap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "frmhoadonnhap";
            this.Text = "Bảng hóa đơn nhập";
            this.Load += new System.EventHandler(this.frmhoadonnhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvhoadonnhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbxmamh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsoluong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtgianhap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.DataGridView dgvhoadonnhap;
        private System.Windows.Forms.TextBox txtmahdnhap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpngaynhaphang;
        private System.Windows.Forms.Label label5;
    }
}