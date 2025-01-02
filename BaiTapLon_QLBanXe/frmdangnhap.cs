using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon
{
    public partial class frmdangnhap : Form
    {
        static string cnn = ConfigurationManager.ConnectionStrings["QLBanXe"].ConnectionString;
        SqlConnection conn = new SqlConnection(cnn);
        public frmdangnhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string tk = txttaikhoan.Text;
                string mk = txtmatkhau.Text;
                string sql = "select * from tblTaiKhoan where TaiKhoan = '" + tk + "' and Matkhau = '" + mk + "' ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    MessageBox.Show("Đăng nhập thành công");
                    frmmain mainForm = new frmmain(); // Sửa tên biến thành frmMain
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    // Hiển thị thông báo lỗi bằng Error Provider
                    errorProvider1.SetError(txttaikhoan, "Tài khoản hoặc mật khẩu không đúng");
                    errorProvider1.SetError(txtmatkhau, "Tài khoản hoặc mật khẩu không đúng");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }

        }

        private void btnthoat_Click(object sender, EventArgs e)
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
    }
}
