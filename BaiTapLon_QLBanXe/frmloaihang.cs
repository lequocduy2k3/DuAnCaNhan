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
    public partial class frmloaihang : Form
    {
        static string cnn = ConfigurationManager.ConnectionStrings["QLBanXe"].ConnectionString;
        SqlConnection conn = new SqlConnection(cnn);
        public frmloaihang()
        {
            InitializeComponent();
        }

        private void frmloaihang_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblLoaiHang", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(reader);
                dgvloaihang.DataSource = tb;
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

            dgvloaihang.Columns[0].HeaderText = "Mã loại hàng";
            dgvloaihang.Columns[1].HeaderText = "Tên loại hàng";           
            dgvloaihang.Columns[0].Width = 200;
            dgvloaihang.Columns[1].Width = 245;
            dgvloaihang.AllowUserToAddRows = false;
            dgvloaihang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmaloaihang.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtmaloaihang.Focus();
                    return;
                }
                if (txttenloaihang.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttenloaihang.Focus();
                    return;
                }
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("insert into tblLoaiHang\r\n\tvalues(@maloaihang , @tenloaihang)", conn);

                cmd.Parameters.AddWithValue("@maloaihang", txtmaloaihang.Text);
                cmd.Parameters.AddWithValue("@tenloaihang", txttenloaihang.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
                frmloaihang_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtmaloaihang_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Xóa thông báo lỗi trước khi kiểm tra lại
                errloaihang.SetError(textBox, "");

                // Kiểm tra xem mã nhân viên đã tồn tại hay chưa
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM tblLoaiHang WHERE sMaLoaiHang = @maloaihang", conn);
                checkCmd.Parameters.AddWithValue("@maloaihang", textBox.Text);
                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    errloaihang.SetError(textBox, "Mã loại hàng đã tồn tại. Vui lòng chọn mã loại hàng khác.");
                }
                else
                {
                    errloaihang.SetError(textBox, ""); // Xóa thông báo lỗi nếu không có lỗi
                }

                if (conn.State == ConnectionState.Open)
                    conn.Close();

            }
        }

        private void dgvloaihang_Click(object sender, EventArgs e)
        {
            if (dgvloaihang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmaloaihang.Text = dgvloaihang.CurrentRow.Cells["sMaLoaiHang"].Value.ToString();
            errloaihang.SetError(txtmaloaihang, "");
            txttenloaihang.Text = dgvloaihang.CurrentRow.Cells["sTenLoaiHang"].Value.ToString();
            
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("update tblLoaiHang\r\n\tset sMaLoaiHang = @maloaihang , sTenLoaiHang = @tenloaihang\r\n\twhere sMaLoaiHang = @maloaihang", conn);

                cmd.Parameters.AddWithValue("@maloaihang", txtmaloaihang.Text);
                cmd.Parameters.AddWithValue("@tenloaihang", txttenloaihang.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Sửa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
                frmloaihang_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void xoaTextBox()
        {
            txtmaloaihang.Clear();
            txttenloaihang.Clear();
            
            txtmaloaihang.Focus();
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
                    SqlCommand cmd = new SqlCommand("delete tblLoaiHang where sMaLoaiHang = @maloaihang", conn);
                    cmd.Parameters.AddWithValue("@maloaihang", txtmaloaihang.Text);
                    cmd.Parameters.AddWithValue("@tenloaihang", txttenloaihang.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    frmloaihang_Load(sender, e);
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

                SqlCommand cmd = new SqlCommand(" select sMaLoaiHang , sTenLoaiHang from tblLoaiHang\r\n\t\twhere sTenLoaiHang like '%' +@tenloaihang+ '%' ", conn);
                cmd.Parameters.AddWithValue("@tenloaihang", txttenloaihang.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(reader);
                dgvloaihang.DataSource = tb;
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
