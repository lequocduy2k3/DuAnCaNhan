using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace BaiTapLon
{
    public partial class frmnhanvien : Form
    {
        static string cnn = ConfigurationManager.ConnectionStrings["QLBanXe"].ConnectionString;
        SqlConnection conn = new SqlConnection(cnn);
        public frmnhanvien()
        {
            InitializeComponent();
        }

        private void frmnhanvien_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblNhanVien", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(reader);
                dgvnhanvien.DataSource = tb;
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

            dgvnhanvien.Columns[0].HeaderText = "Mã nhân viên";
            dgvnhanvien.Columns[1].HeaderText = "Tên nhân viên";
            dgvnhanvien.Columns[2].HeaderText = "Số điện thoại";
            dgvnhanvien.Columns[3].HeaderText = "Ngày sinh";
            dgvnhanvien.Columns[4].HeaderText = "Giới tính";
            dgvnhanvien.Columns[5].HeaderText = "Ngày vào làm";
            dgvnhanvien.Columns[0].Width = 100;
            dgvnhanvien.Columns[1].Width = 150;
            dgvnhanvien.Columns[2].Width = 100;
            dgvnhanvien.Columns[3].Width = 100;
            dgvnhanvien.Columns[4].Width = 100;
            dgvnhanvien.Columns[5].Width = 100;
            dgvnhanvien.AllowUserToAddRows = false;
            dgvnhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {    
            try
            {
                if (txtmanv.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtmanv.Focus();
                    return;
                }
                if (txttennv.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttennv.Focus();
                    return;
                }
                if (txtsdt.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số điện thoại nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsdt.Focus();
                    return;
                }
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("insert into tblNhanVien\r\n\tvalues(@manv , @tennv , @sdt , @ngaysinh , @gioitinh , @ngayvaolam)", conn);

                cmd.Parameters.AddWithValue("@manv", txtmanv.Text);
                cmd.Parameters.AddWithValue("@tennv", txttennv.Text);
                cmd.Parameters.AddWithValue("@sdt", txtsdt.Text);
                cmd.Parameters.AddWithValue("@ngaysinh", dtpngaysinh.Value.ToString("dd/MM/yyyy"));
                cmd.Parameters.AddWithValue("@ngayvaolam", dtpngayvaolam.Value.ToString("dd/MM/yyyy"));
                if (chknam.Checked)
                {
                    cmd.Parameters.AddWithValue("@gioitinh", "Nam");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@gioitinh", "Nu");
                }
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
                frmnhanvien_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtmanv_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Xóa thông báo lỗi trước khi kiểm tra lại
                errmanv.SetError(textBox, "");

                // Kiểm tra xem mã nhân viên đã tồn tại hay chưa
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM tblNhanVien WHERE sMaNV = @manv", conn);
                checkCmd.Parameters.AddWithValue("@manv", textBox.Text);
                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    errmanv.SetError(textBox, "Mã nhân viên đã tồn tại. Vui lòng chọn mã nhân viên khác.");
                }
                else
                {
                    errmanv.SetError(textBox, ""); // Xóa thông báo lỗi nếu không có lỗi
                }

                if (conn.State == ConnectionState.Open)
                    conn.Close();

            }
        }

        private void dgvnhanvien_Click(object sender, EventArgs e)
        {
           
            if (dgvnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmanv.Text = dgvnhanvien.CurrentRow.Cells["sMaNV"].Value.ToString();
            errmanv.SetError(txtmanv, "");
            txttennv.Text = dgvnhanvien.CurrentRow.Cells["sTenNV"].Value.ToString();
            if (dgvnhanvien.CurrentRow.Cells["dGioiTinh"].Value.ToString() == "Nam")
            {
                chknam.Checked = true;
                chknu.Checked = false;
            }
            else if (dgvnhanvien.CurrentRow.Cells["dGioiTinh"].Value.ToString() == "Nu")
            {
                chknu.Checked = true;
                chknam.Checked = false;
            }
            else
            {
                chknam.Checked = false;
                chknu.Checked = false;
            }
            txtsdt.Text = dgvnhanvien.CurrentRow.Cells["sSdt"].Value.ToString();
            dtpngaysinh.Text = dgvnhanvien.CurrentRow.Cells["dNgaySinh"].Value.ToString();
            dtpngayvaolam.Text = dgvnhanvien.CurrentRow.Cells["dNgayVaoLam"].Value.ToString();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("update tblNhanVien\r\n\tset sMaNV = @manv , sTenNV = @tennv , sSdt = @sdt , dNgaySinh = @ngaysinh , dGioiTinh = @gioitinh , dNgayVaoLam = @ngayvaolam\r\n\twhere sMaNV = @manv", conn);

                cmd.Parameters.AddWithValue("@manv", txtmanv.Text);
                cmd.Parameters.AddWithValue("@tennv", txttennv.Text);
                cmd.Parameters.AddWithValue("@sdt", txtsdt.Text);
                cmd.Parameters.AddWithValue("@ngaysinh", dtpngaysinh.Value.ToString("dd/MM/yyyy"));
                cmd.Parameters.AddWithValue("@ngayvaolam", dtpngayvaolam.Value.ToString("dd/MM/yyyy"));
                if (chknam.Checked)
                {
                    cmd.Parameters.AddWithValue("@gioitinh", "Nam");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@gioitinh", "Nu");
                }
                cmd.ExecuteNonQuery();

                MessageBox.Show("Sửa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
                frmnhanvien_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void xoaTextBox()
        {
            txtmanv.Clear();
            txttennv.Clear();
            txtsdt.Clear();
            dtpngaysinh.Value = DateTime.Now; // Đặt lại ngày sinh về ngày hiện tại
            dtpngayvaolam.Value = DateTime.Now; // Đặt lại ngày vào làm về ngày hiện tại
        
            txtmanv.Focus();
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
                    SqlCommand cmd = new SqlCommand("delete tblNhanVien where sMaNV = @manv", conn);
                    cmd.Parameters.AddWithValue("@manv", txtmanv.Text);
                    cmd.Parameters.AddWithValue("@tennv", txttennv.Text);
                    cmd.Parameters.AddWithValue("@sdt", txtsdt.Text);
                    cmd.Parameters.AddWithValue("@ngaysinh", dtpngaysinh.Value.ToString("dd/MM/yyyy"));
                    cmd.Parameters.AddWithValue("@ngayvaolam", dtpngayvaolam.Value.ToString("dd/MM/yyyy"));
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    frmnhanvien_Load(sender, e);
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

                SqlCommand cmd = new SqlCommand(" select * from tblNhanVien\r\n\t\twhere sTenNV like '%' +@tennv+ '%' ", conn);
                cmd.Parameters.AddWithValue("@tennv", txttennv.Text);               
            SqlDataReader reader = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(reader);
                dgvnhanvien.DataSource = tb;
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
