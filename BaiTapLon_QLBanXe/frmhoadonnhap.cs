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
    public partial class frmhoadonnhap : Form
    {
        static string cnn = ConfigurationManager.ConnectionStrings["QLBanXe"].ConnectionString;
        SqlConnection conn = new SqlConnection(cnn);
        public frmhoadonnhap()
        {
            InitializeComponent();
        }

        private void frmhoadonnhap_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from tblHoaDonNhap", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(reader);
                dgvhoadonnhap.DataSource = tb;
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                LoadDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            hiendsmamh();
            cbxmamh.SelectedIndex = -1; // Đặt lại chỉ mục của ComboBox về -1 để không chọn bất kỳ mục nào

        }
        public void LoadDataGridView()
        {

            dgvhoadonnhap.Columns[0].HeaderText = "Mã hóa đơn";
            dgvhoadonnhap.Columns[1].HeaderText = "Mã mặt hàng";
            dgvhoadonnhap.Columns[2].HeaderText = "Ngày nhập hàng";
            dgvhoadonnhap.Columns[3].HeaderText = "Số lượng";
            dgvhoadonnhap.Columns[4].HeaderText = "Giá nhập";
            dgvhoadonnhap.Columns[0].Width = 100;
            dgvhoadonnhap.Columns[1].Width = 100;
            dgvhoadonnhap.Columns[2].Width = 150;
            dgvhoadonnhap.Columns[3].Width = 100;
            dgvhoadonnhap.Columns[4].Width = 100;
            dgvhoadonnhap.AllowUserToAddRows = false;
            dgvhoadonnhap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private DataTable laydsmamh()
        {
            using (SqlCommand cmd = new SqlCommand("Select * from tblMatHang", conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable("MaKH");
                    ad.Fill(dt);
                    return dt;

                }
            }
        }
        private void hiendsmamh()
        {
            DataTable t = laydsmamh();
            DataView dv = new DataView(t);
            dv.Sort = "sMaMH";
            cbxmamh.DataSource = dv;
            cbxmamh.DisplayMember = "sMaMH";
            cbxmamh.ValueMember = "sMaMH";
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmahdnhap.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtmahdnhap.Focus();
                    return;
                }

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("insert into tblHoaDonNhap\r\n\tvalues(@mahdnhap , @mamh , @ngaynhaphang , @soluong , @gianhap)", conn);

                cmd.Parameters.AddWithValue("@mahdnhap", txtmahdnhap.Text);
                cmd.Parameters.AddWithValue("@mamh", cbxmamh.SelectedValue);
                cmd.Parameters.AddWithValue("@ngaynhaphang", dtpngaynhaphang.Value);
                cmd.Parameters.AddWithValue("@soluong", txtsoluong.Text);
                cmd.Parameters.AddWithValue("@gianhap", txtgianhap.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cbxmamh.SelectedIndex = -1;

                if (conn.State == ConnectionState.Open)
                    conn.Close();

                frmhoadonnhap_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvhoadonnhap_Click(object sender, EventArgs e)
        {
            if (dgvhoadonnhap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmahdnhap.Text = dgvhoadonnhap.CurrentRow.Cells["sMaDonNhap"].Value.ToString();
            cbxmamh.Text = dgvhoadonnhap.CurrentRow.Cells["sMaMH"].Value.ToString();
            dtpngaynhaphang.Text = dgvhoadonnhap.CurrentRow.Cells["dNgayNhapHang"].Value.ToString();
            txtgianhap.Text = dgvhoadonnhap.CurrentRow.Cells["fGiaNhap"].Value.ToString();
            txtsoluong.Text = dgvhoadonnhap.CurrentRow.Cells["iSoLuong"].Value.ToString();

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("update tblHoaDonNhap\r\n\tset sMaDonNhap = @mahdnhap , sMaMH = @mamh , dNgayNhapHang = @ngaynhaphang , iSoLuong = @soluong , fGiaNhap = @gianhap\r\n\twhere sMaDonNhap = @mahdnhap", conn);
                cmd.Parameters.AddWithValue("@mahdnhap", txtmahdnhap.Text);
                cmd.Parameters.AddWithValue("@mamh", cbxmamh.SelectedValue);
                cmd.Parameters.AddWithValue("@ngaynhaphang", dtpngaynhaphang.Value);
                cmd.Parameters.AddWithValue("@soluong", txtsoluong.Text);
                cmd.Parameters.AddWithValue("@gianhap", txtgianhap.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Sửa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
                frmhoadonnhap_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void xoaTextBox()
        {
            txtmahdnhap.Clear();
            cbxmamh.SelectedIndex = -1;
            dtpngaynhaphang.MinDate = DateTime.MinValue;
            txtsoluong.Clear();
            txtgianhap.Clear();
            txtmahdnhap.Focus();
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
                    SqlCommand cmd = new SqlCommand("delete tblHoaDonNhap where sMaDonNhap = @mahdnhap", conn);
                    cmd.Parameters.AddWithValue("@mahdnhap", txtmahdnhap.Text);
                    cmd.Parameters.AddWithValue("@mamh", cbxmamh.SelectedValue);
                    cmd.Parameters.AddWithValue("@ngaynhaphang", dtpngaynhaphang.Value);
                    cmd.Parameters.AddWithValue("@soluong", txtsoluong.Text);
                    cmd.Parameters.AddWithValue("@gianhap", txtgianhap.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    frmhoadonnhap_Load(sender, e);
                    xoaTextBox();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
