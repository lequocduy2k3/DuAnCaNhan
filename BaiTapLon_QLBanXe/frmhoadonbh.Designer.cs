namespace BaiTapLon
{
    partial class frmhoadonbh
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
            this.components = new System.ComponentModel.Container();
            this.cbxmakh = new System.Windows.Forms.ComboBox();
            this.cbxmanv = new System.Windows.Forms.ComboBox();
            this.btnthoat = new System.Windows.Forms.Button();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.dgvhoadonbh = new System.Windows.Forms.DataGridView();
            this.txtmahd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpngaygiaohang = new System.Windows.Forms.DateTimePicker();
            this.dtpngaydathang = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnxemchitiet = new System.Windows.Forms.Button();
            this.errmahd = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvhoadonbh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errmahd)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxmakh
            // 
            this.cbxmakh.FormattingEnabled = true;
            this.cbxmakh.Location = new System.Drawing.Point(161, 97);
            this.cbxmakh.Name = "cbxmakh";
            this.cbxmakh.Size = new System.Drawing.Size(144, 21);
            this.cbxmakh.TabIndex = 60;
            // 
            // cbxmanv
            // 
            this.cbxmanv.FormattingEnabled = true;
            this.cbxmanv.Location = new System.Drawing.Point(161, 136);
            this.cbxmanv.Name = "cbxmanv";
            this.cbxmanv.Size = new System.Drawing.Size(144, 21);
            this.cbxmanv.TabIndex = 59;
            // 
            // btnthoat
            // 
            this.btnthoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthoat.Location = new System.Drawing.Point(593, 406);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(86, 33);
            this.btnthoat.TabIndex = 58;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // btntimkiem
            // 
            this.btntimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntimkiem.Location = new System.Drawing.Point(458, 406);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(86, 33);
            this.btntimkiem.TabIndex = 57;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxoa.Location = new System.Drawing.Point(314, 406);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(86, 33);
            this.btnxoa.TabIndex = 56;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsua.Location = new System.Drawing.Point(174, 406);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(86, 33);
            this.btnsua.TabIndex = 55;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnthem
            // 
            this.btnthem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthem.Location = new System.Drawing.Point(35, 406);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(86, 33);
            this.btnthem.TabIndex = 54;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // dgvhoadonbh
            // 
            this.dgvhoadonbh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvhoadonbh.Location = new System.Drawing.Point(12, 199);
            this.dgvhoadonbh.Name = "dgvhoadonbh";
            this.dgvhoadonbh.Size = new System.Drawing.Size(695, 192);
            this.dgvhoadonbh.TabIndex = 53;
            this.dgvhoadonbh.Click += new System.EventHandler(this.dgvhoadonbh_Click);
            // 
            // txtmahd
            // 
            this.txtmahd.Location = new System.Drawing.Point(161, 56);
            this.txtmahd.Name = "txtmahd";
            this.txtmahd.Size = new System.Drawing.Size(144, 20);
            this.txtmahd.TabIndex = 50;
            this.txtmahd.TextChanged += new System.EventHandler(this.txtmahd_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Mã nhân viên";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(256, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 51);
            this.label4.TabIndex = 46;
            this.label4.Text = "Bảng hóa đơn bán hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Mã khách hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Mã hóa đơn";
            // 
            // dtpngaygiaohang
            // 
            this.dtpngaygiaohang.CustomFormat = "dd/MM/yyyy";
            this.dtpngaygiaohang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpngaygiaohang.Location = new System.Drawing.Point(465, 98);
            this.dtpngaygiaohang.Name = "dtpngaygiaohang";
            this.dtpngaygiaohang.ShowUpDown = true;
            this.dtpngaygiaohang.Size = new System.Drawing.Size(144, 20);
            this.dtpngaygiaohang.TabIndex = 64;
            // 
            // dtpngaydathang
            // 
            this.dtpngaydathang.CustomFormat = "dd/MM/yyyy";
            this.dtpngaydathang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpngaydathang.Location = new System.Drawing.Point(465, 56);
            this.dtpngaydathang.Name = "dtpngaydathang";
            this.dtpngaydathang.ShowUpDown = true;
            this.dtpngaydathang.Size = new System.Drawing.Size(144, 20);
            this.dtpngaydathang.TabIndex = 63;
            this.dtpngaydathang.Value = new System.DateTime(2024, 4, 5, 13, 14, 2, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(377, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 62;
            this.label7.Text = "Ngày giao hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(377, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Ngày đặt hàng";
            // 
            // btnxemchitiet
            // 
            this.btnxemchitiet.Location = new System.Drawing.Point(12, 170);
            this.btnxemchitiet.Name = "btnxemchitiet";
            this.btnxemchitiet.Size = new System.Drawing.Size(144, 23);
            this.btnxemchitiet.TabIndex = 65;
            this.btnxemchitiet.Text = "Xem chi tiết";
            this.btnxemchitiet.UseVisualStyleBackColor = true;
            this.btnxemchitiet.Click += new System.EventHandler(this.btnxemchitiet_Click);
            // 
            // errmahd
            // 
            this.errmahd.ContainerControl = this;
            // 
            // frmhoadonbh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 444);
            this.Controls.Add(this.btnxemchitiet);
            this.Controls.Add(this.dtpngaygiaohang);
            this.Controls.Add(this.dtpngaydathang);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxmakh);
            this.Controls.Add(this.cbxmanv);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.dgvhoadonbh);
            this.Controls.Add(this.txtmahd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmhoadonbh";
            this.Text = "Bảng hóa đơn bán hàng";
            this.Load += new System.EventHandler(this.frmhoadonbh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvhoadonbh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errmahd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbxmakh;
        private System.Windows.Forms.ComboBox cbxmanv;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.DataGridView dgvhoadonbh;
        private System.Windows.Forms.TextBox txtmahd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpngaygiaohang;
        private System.Windows.Forms.DateTimePicker dtpngaydathang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnxemchitiet;
        private System.Windows.Forms.ErrorProvider errmahd;
    }
}