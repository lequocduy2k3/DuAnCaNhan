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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace BaiTapLon
{
    public partial class frmkhachhang : Form
    {
        static string cnn = ConfigurationManager.ConnectionStrings["QLBanXe"].ConnectionString;
        SqlConnection conn = new SqlConnection(cnn);
        public frmkhachhang()
        {
            InitializeComponent();
        }

        private void frmkhachhang_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblKhachHang", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(reader);
                dgvkhachhang.DataSource = tb;
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                LoadDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadDataGridView()
        {

            dgvkhachhang.Columns[0].HeaderText = "Mã khách hàng";
            dgvkhachhang.Columns[1].HeaderText = "Tên khách hàng";
            dgvkhachhang.Columns[2].HeaderText = "Số điện thoại";
            dgvkhachhang.Columns[3].HeaderText = "Địa chỉ";         
            dgvkhachhang.Columns[0].Width = 100;
            dgvkhachhang.Columns[1].Width = 150;
            dgvkhachhang.Columns[2].Width = 120;
            dgvkhachhang.Columns[3].Width = 177;
            dgvkhachhang.AllowUserToAddRows = false;
            dgvkhachhang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmakh.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtmakh.Focus();
                    return;
                }
                if (txttenkh.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttenkh.Focus();
                    return;
                }
                if (txtsdtkh.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số điện thoại khách hảng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsdtkh.Focus();
                    return;
                }
                if (txtdiachi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập địa chỉ khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtdiachi.Focus();
                    return;
                }
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("insert into tblKhachHang\r\n\tvalues(@makh , @tenkh , @sdt , @diachi)", conn);

                cmd.Parameters.AddWithValue("@makh", txtmakh.Text);
                cmd.Parameters.AddWithValue("@tenkh", txttenkh.Text);
                cmd.Parameters.AddWithValue("@sdt", txtsdtkh.Text);
                cmd.Parameters.AddWithValue("@diachi", txtdiachi.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
                frmkhachhang_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtmakh_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Xóa thông báo lỗi trước khi kiểm tra lại
                errmakh.SetError(textBox, "");

                // Kiểm tra xem mã nhân viên đã tồn tại hay chưa
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM tblKhachHang WHERE sMaKH = @makh", conn);
                checkCmd.Parameters.AddWithValue("@makh", textBox.Text);
                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    errmakh.SetError(textBox, "Mã khách hàng đã tồn tại. Vui lòng chọn mã khách hàng khác.");
                }
                else
                {
                    errmakh.SetError(textBox, ""); // Xóa thông báo lỗi nếu không có lỗi
                }

                if (conn.State == ConnectionState.Open)
                    conn.Close();

            }
        }

        private void dgvkhachhang_Click(object sender, EventArgs e)
        {
            if (dgvkhachhang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmakh.Text = dgvkhachhang.CurrentRow.Cells["sMaKH"].Value.ToString();
            errmakh.SetError(txtmakh, "");
            txttenkh.Text = dgvkhachhang.CurrentRow.Cells["sTenKH"].Value.ToString();            
            txtsdtkh.Text = dgvkhachhang.CurrentRow.Cells["sSdt"].Value.ToString();
            txtdiachi.Text = dgvkhachhang.CurrentRow.Cells["sDiaChi"].Value.ToString();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("update tblKhachHang\r\n\tset sMaKH = @makh , sTenKH = @tenkh , sSdt = @sdt , sDiaChi = @diachi\r\n\twhere sMaKH = @makh", conn);

                cmd.Parameters.AddWithValue("@makh", txtmakh.Text);
                cmd.Parameters.AddWithValue("@tenkh", txttenkh.Text);
                cmd.Parameters.AddWithValue("@sdt", txtsdtkh.Text);
                cmd.Parameters.AddWithValue("@diachi", txtdiachi.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Sửa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
                frmkhachhang_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void xoaTextBox()
        {
            txtmakh.Clear();
            txttenkh.Clear();
            txtsdtkh.Clear();
            txtdiachi.Clear();
           
            txtmakh.Focus();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Nếu người dùng chọn Yes
                if (result == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("delete tblKhachHang where sMaKH = @makh", conn);
                    cmd.Parameters.AddWithValue("@makh", txtmakh.Text);
                    cmd.Parameters.AddWithValue("@tenkh", txttenkh.Text);
                    cmd.Parameters.AddWithValue("@sdt", txtsdtkh.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtdiachi.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    frmkhachhang_Load(sender, e);
                    xoaTextBox();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand(" select * from tblKhachHang\r\n\t\twhere sTenKH like '%' +@tenkh+ '%' ", conn);
                cmd.Parameters.AddWithValue("@tenkh", txttenkh.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(reader);
                dgvkhachhang.DataSource = tb;
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frmmain main = new frmmain();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Thao tác thoát đã bị hủy bởi người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
