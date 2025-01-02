using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon
{
    public partial class frmmain : Form
    {
        public frmmain()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                    Application.Exit();

            }
            else
            {
                MessageBox.Show("Thao tác thoát đã bị hủy bởi người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mnunhanvien_Click(object sender, EventArgs e)
        {
            frmnhanvien frmnhanvien = new frmnhanvien();
            frmnhanvien.Show();
            this.Hide();
        }

        private void mnukhachhang_Click(object sender, EventArgs e)
        {
            frmkhachhang frmkhachhang = new frmkhachhang();
            frmkhachhang.Show();
            this.Hide();
        }

        private void mnuloaihang_Click(object sender, EventArgs e)
        {
            frmloaihang frmloaihang = new frmloaihang();
            frmloaihang.Show();
            this.Hide();
        }

        private void mnumathang_Click(object sender, EventArgs e)
        {
            frmmathang frmmathang = new frmmathang();
            frmmathang.Show();
            this.Hide();
        }

        private void mnuhoadonnhap_Click(object sender, EventArgs e)
        {
            frmhoadonnhap frmhoadonnhap = new frmhoadonnhap();
            frmhoadonnhap.Show();
            this.Hide();
        }

        private void mnunhacc_Click(object sender, EventArgs e)
        {
            frmnhacc frmnhacc = new frmnhacc();
            frmnhacc.Show();
            this.Hide();
        }

        private void mnuhoadonbh_Click(object sender, EventArgs e)
        {
            frmhoadonbh frmhoadonbh = new frmhoadonbh();
            frmhoadonbh.Show();
            this.Hide();
        }
    }
}
