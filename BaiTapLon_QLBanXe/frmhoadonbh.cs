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
    public partial class frmhoadonbh : Form
    {
        static string cnn = ConfigurationManager.ConnectionStrings["QLBanXe"].ConnectionString;
        SqlConnection conn = new SqlConnection(cnn);
        public frmhoadonbh()
        {
            InitializeComponent();
        }

        private void frmhoadonbh_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT dbo.tblHoaDonBH.sMaHD AS [Mã hóa đơn], dbo.tblKhachHang.sTenKH AS [Khách hàng], dbo.tblNhanVien.sTenNV AS [Nhân viên], dbo.tblHoaDonBH.dNgayDatHang AS [Ngày đặt], dbo.tblHoaDonBH.dNgayGiaoHang AS [Ngày giao]\r\nFROM  dbo.tblHoaDonBH INNER JOIN\r\n         dbo.tblKhachHang ON dbo.tblHoaDonBH.sMaKH = dbo.tblKhachHang.sMaKH INNER JOIN\r\n         dbo.tblNhanVien ON dbo.tblHoaDonBH.sMaNV = dbo.tblNhanVien.sMaNV", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(reader);
                dgvhoadonbh.DataSource = tb;
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                LoadDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            hiendsmakhachhang();
            hiendsmanhanvien();
            cbxmakh.SelectedIndex = -1; // Đặt lại chỉ mục của ComboBox về -1 để không chọn bất kỳ mục nào
            cbxmanv.SelectedIndex = -1; // Đặt lại chỉ mục của ComboBox về -1 để không chọn bất kỳ mục nào
            

        }
        public void LoadDataGridView()
        {

            dgvhoadonbh.Columns[0].HeaderText = "Mã hóa đơn";
            dgvhoadonbh.Columns[1].HeaderText = "Tên khách hàng";
            dgvhoadonbh.Columns[2].HeaderText = "Tên nhân viên";
            dgvhoadonbh.Columns[3].HeaderText = "Ngày đặt hàng";
            dgvhoadonbh.Columns[4].HeaderText = "Ngày giao hàng";
            dgvhoadonbh.Columns[0].Width = 100;
            dgvhoadonbh.Columns[1].Width = 150;
            dgvhoadonbh.Columns[2].Width = 100;
            dgvhoadonbh.Columns[3].Width = 150;
            dgvhoadonbh.Columns[4].Width = 150;
            dgvhoadonbh.AllowUserToAddRows = false;
            dgvhoadonbh.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private DataTable laydsmakhachhang()
        {
            using (SqlCommand cmd = new SqlCommand("Select * from tblKhachHang", conn))
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
        private void hiendsmakhachhang()
        {
            DataTable t = laydsmakhachhang();
            DataView dv = new DataView(t);
            dv.Sort = "sTenKH";
            cbxmakh.DataSource = dv;
            cbxmakh.DisplayMember = "sTenKH";
            cbxmakh.ValueMember = "sMaKH";
        }
        private DataTable laydsmanhanvien()
        {
            using (SqlCommand cmd = new SqlCommand("Select * from tblNhanVien", conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable("NV");
                    ad.Fill(dt);
                    return dt;

                }
            }
        }
        private void hiendsmanhanvien()
        {
            DataTable t = laydsmanhanvien();
            DataView dv = new DataView(t);
            dv.Sort = "sTenNV";
            cbxmanv.DataSource = dv;
            cbxmanv.DisplayMember = "sTenNV";
            cbxmanv.ValueMember = "sMaNV";
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmahd.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtmahd.Focus();
                    return;
                }

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                dtpngaydathang.Format = DateTimePickerFormat.Short;
                dtpngaydathang.ShowUpDown = true;

                dtpngaygiaohang.Format = DateTimePickerFormat.Short;
                dtpngaygiaohang.ShowUpDown = true;

                SqlCommand cmd = new SqlCommand("insert into tblHoaDonBH values(@mahd, @makh, @manv, @ngaydathang, @ngaygiaohang)", conn);

                cmd.Parameters.AddWithValue("@mahd", txtmahd.Text);
                cmd.Parameters.AddWithValue("@makh", cbxmakh.SelectedValue);
                cmd.Parameters.AddWithValue("@manv", cbxmanv.SelectedValue);
                cmd.Parameters.AddWithValue("@ngaydathang", dtpngaydathang.Value);
                cmd.Parameters.AddWithValue("@ngaygiaohang", dtpngaygiaohang.Value);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtmahd.Clear();
                cbxmakh.SelectedIndex = -1;
                cbxmanv.SelectedIndex = -1;

                if (conn.State == ConnectionState.Open)
                    conn.Close();

                frmhoadonbh_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtmahd_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Xóa thông báo lỗi trước khi kiểm tra lại
                errmahd.SetError(textBox, "");

                // Kiểm tra xem mã nhân viên đã tồn tại hay chưa
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM tblHoaDonBH WHERE sMaHD = @mahd", conn);
                checkCmd.Parameters.AddWithValue("@mahd", textBox.Text);
                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    errmahd.SetError(textBox, "Mã hóa đơn đã tồn tại. Vui lòng chọn mã nhân viên khác.");
                }
                else
                {
                    errmahd.SetError(textBox, ""); // Xóa thông báo lỗi nếu không có lỗi
                }

                if (conn.State == ConnectionState.Open)
                    conn.Close();

            }
        }

        private void dgvhoadonbh_Click(object sender, EventArgs e)
        {
            if (dgvhoadonbh.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmahd.Text = dgvhoadonbh.CurrentRow.Cells["Mã hóa đơn"].Value.ToString();
            errmahd.SetError(txtmahd, "");
            cbxmakh.Text = dgvhoadonbh.CurrentRow.Cells["Khách hàng"].Value.ToString();
            cbxmanv.Text = dgvhoadonbh.CurrentRow.Cells["Nhân viên"].Value.ToString();
            dtpngaydathang.Text = dgvhoadonbh.CurrentRow.Cells["Ngày đặt"].Value.ToString();
            dtpngaygiaohang.Text = dgvhoadonbh.CurrentRow.Cells["Ngày giao"].Value.ToString();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("update tblHoaDonBH\r\n\tset sMaHD = @mahd , sMaKH = @makh , sMaNV = @manv , dNgayDatHang = @ngaydathang , dNgayGiaoHang = @ngaygiaohang\r\n\twhere sMaHD = @mahd", conn);
                cmd.Parameters.AddWithValue("@mahd", txtmahd.Text);
                cmd.Parameters.AddWithValue("@makh", cbxmakh.SelectedValue);
                cmd.Parameters.AddWithValue("@manv", cbxmanv.SelectedValue);
                cmd.Parameters.AddWithValue("@ngaydathang", dtpngaydathang.Value);
                cmd.Parameters.AddWithValue("@ngaygiaohang", dtpngaygiaohang.Value);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Sửa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
                frmhoadonbh_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void xoaTextBox()
        {
            txtmahd.Clear();
            cbxmakh.SelectedIndex = -1;
            dtpngaydathang.MinDate = DateTime.MinValue;
            dtpngaygiaohang.MinDate = DateTime.MinValue;
            txtmahd.Focus();
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
                    SqlCommand cmd = new SqlCommand("delete tblHoaDonBH where sMaHD = @mahd", conn);
                    cmd.Parameters.AddWithValue("@mahd", txtmahd.Text);
                    cmd.Parameters.AddWithValue("@makh", cbxmakh.Text);
                    cmd.Parameters.AddWithValue("@manv", cbxmanv.Text);
                    cmd.Parameters.AddWithValue("@ngaydathang", dtpngaydathang.Value.ToString("dd/MM/yyyy"));
                    cmd.Parameters.AddWithValue("@ngaygiaohang", dtpngaygiaohang.Value.ToString("dd/MM/yyyy"));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    frmhoadonbh_Load(sender, e);
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

                SqlCommand cmd = new SqlCommand("select * from tblHoaDonBH\r\n\t\twhere sMaHD like '%' +@mahd+ '%' ", conn);
                cmd.Parameters.AddWithValue("@mahd", txtmahd.Text);
               
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(reader);
                dgvhoadonbh.DataSource = tb;
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnxemchitiet_Click(object sender, EventArgs e)
        {
            
            if (dgvhoadonbh.SelectedCells.Count > 0)
            {
                string maHoaDon = dgvhoadonbh.CurrentRow.Cells["Mã hóa đơn"].Value.ToString();
                maHoaDon = txtmahd.Text;
                frmchitiethd formChiTiet = new frmchitiethd(maHoaDon); // Truyền mã hóa đơn vào constructor
                formChiTiet.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết.");
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
