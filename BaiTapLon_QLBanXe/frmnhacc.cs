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
    public partial class frmnhacc : Form
    {
        static string cnn = ConfigurationManager.ConnectionStrings["QLBanXe"].ConnectionString;
        SqlConnection conn = new SqlConnection(cnn);
        public frmnhacc()
        {
            InitializeComponent();
        }

        private void frmnhacc_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblNhaCC", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(reader);
                dgvnhacc.DataSource = tb;
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

            dgvnhacc.Columns[0].HeaderText = "Mã nhà cung cấp";
            dgvnhacc.Columns[1].HeaderText = "Tên nhà cung cấp";
            dgvnhacc.Columns[2].HeaderText = "Số điện thoại";
            dgvnhacc.Columns[3].HeaderText = "Địa chỉ";
            dgvnhacc.Columns[0].Width = 100;
            dgvnhacc.Columns[1].Width = 150;
            dgvnhacc.Columns[2].Width = 120;
            dgvnhacc.Columns[3].Width = 177;
            dgvnhacc.AllowUserToAddRows = false;
            dgvnhacc.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmancc.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtmancc.Focus();
                    return;
                }
                if (txttenncc.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttenncc.Focus();
                    return;
                }
                if (txtsdtncc.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số điện thoại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsdtncc.Focus();
                    return;
                }
                if (txtdiachincc.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập địa chỉ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtdiachincc.Focus();
                    return;
                }
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("insert into tblNhaCC\r\n\tvalues(@mancc , @tenncc , @diachi , @sdt)", conn);

                cmd.Parameters.AddWithValue("@mancc", txtmancc.Text);
                cmd.Parameters.AddWithValue("@tenncc", txttenncc.Text);
                cmd.Parameters.AddWithValue("@sdt", txtsdtncc.Text);
                cmd.Parameters.AddWithValue("@diachi", txtdiachincc.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
                frmnhacc_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvkhachhang_Click(object sender, EventArgs e)
        {
            if (dgvnhacc.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmancc.Text = dgvnhacc.CurrentRow.Cells["sMaNcc"].Value.ToString();
            txttenncc.Text = dgvnhacc.CurrentRow.Cells["sTenNcc"].Value.ToString();
            txtsdtncc.Text = dgvnhacc.CurrentRow.Cells["sSdt"].Value.ToString();
            txtdiachincc.Text = dgvnhacc.CurrentRow.Cells["sDiaChi"].Value.ToString();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("update tblNhaCC\r\n\tset sMaNCC = @mancc , sTenNCC = @tenncc , sDiaChi = @diachi , sSdt = @sdt\r\n\twhere sMaNCC = @mancc", conn);

                cmd.Parameters.AddWithValue("@mancc", txtmancc.Text);
                cmd.Parameters.AddWithValue("@tenncc", txttenncc.Text);
                cmd.Parameters.AddWithValue("@sdt", txtsdtncc.Text);
                cmd.Parameters.AddWithValue("@diachi", txtdiachincc.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Sửa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
                frmnhacc_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void xoaTextBox()
        {
            txtmancc.Clear();
            txttenncc.Clear();
            txtsdtncc.Clear();
            txtdiachincc.Clear();

            txtmancc.Focus();
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
                    SqlCommand cmd = new SqlCommand("delete tblNhaCC where sMaNCC = @mancc", conn);
                    cmd.Parameters.AddWithValue("@mancc", txtmancc.Text);
                    cmd.Parameters.AddWithValue("@tenncc", txttenncc.Text);
                    cmd.Parameters.AddWithValue("@sdt", txtsdtncc.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtdiachincc.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    frmnhacc_Load(sender, e);
                    xoaTextBox();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
