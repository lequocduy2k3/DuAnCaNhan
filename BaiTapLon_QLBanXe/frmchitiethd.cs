using CrystalDecisions.CrystalReports.Engine;
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
    public partial class frmchitiethd : Form
    {
        static string cnn = ConfigurationManager.ConnectionStrings["QLBanXe"].ConnectionString;
        SqlConnection conn = new SqlConnection(cnn);
        private string maHoaDon;

        public frmchitiethd(string maHoaDon)
        {
            InitializeComponent();
            this.maHoaDon = maHoaDon;
            txtmahd.Text = maHoaDon;
        }

        private void frmchitiethd_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from hienchitiethd where Mã = @mahd", conn);
                cmd.Parameters.AddWithValue("@mahd", maHoaDon); // Đảm bảo rằng bạn đã định nghĩa biến maHoaDon

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dgvchitiethd.DataSource = dataTable;
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                LoadDataGridView();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            hiendsmamh();
            cbxmamh.SelectedIndex = -1;
        }
        public void LoadDataGridView()
        {

            dgvchitiethd.Columns[0].HeaderText = "Mã hóa đơn";
            dgvchitiethd.Columns[1].HeaderText = "Mã mặt hàng";
            dgvchitiethd.Columns[2].HeaderText = "Giá bán";
            dgvchitiethd.Columns[3].HeaderText = "Số lượng";
            dgvchitiethd.Columns[4].HeaderText = "Giảm giá";
            dgvchitiethd.Columns[0].Width = 100;
            dgvchitiethd.Columns[1].Width = 150;
            dgvchitiethd.Columns[2].Width = 150;
            dgvchitiethd.Columns[3].Width = 100;
            dgvchitiethd.Columns[4].Width = 150;
            dgvchitiethd.AllowUserToAddRows = false;
            dgvchitiethd.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private DataTable laydsmamh()
        {
            using (SqlCommand cmd = new SqlCommand("Select * from tblMatHang", conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable("TenMH");
                    ad.Fill(dt);
                    return dt;

                }
            }
        }
        private void hiendsmamh()
        {
            DataTable t = laydsmamh();
            DataView dv = new DataView(t);
            dv.Sort = "sTenSP";
            cbxmamh.DataSource = dv;
            cbxmamh.DisplayMember = "sTenSP";
            cbxmamh.ValueMember = "sMaMH";
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtgiaban.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsoluong.Focus();
                    return;
                }
                if (txtsoluong.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số lượng mặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsoluong.Focus();
                    return;
                }
                if (txtgiamgia.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mức giảm giá của hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtgiamgia.Focus();
                    return;
                }
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
               
                SqlCommand cmd = new SqlCommand("insert into tblChiTietHD\r\n\tvalues(@mahd , @mamh , @giaban , @soluong , @giamgia)", conn);

                cmd.Parameters.AddWithValue("@mahd", txtmahd.Text);
                cmd.Parameters.AddWithValue("@mamh", cbxmamh.SelectedValue);
                cmd.Parameters.AddWithValue("@giaban", txtgiaban.Text);
                cmd.Parameters.AddWithValue("@soluong", txtsoluong.Text);
                cmd.Parameters.AddWithValue("@giamgia", txtgiamgia.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
                frmchitiethd_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            // Thiết lập câu lệnh SQL và thêm tham số
            cmd.CommandText = "select * from View_HDBH where id = @mahd";
            cmd.Parameters.AddWithValue("@mahd", txtmahd.Text);

            // Khởi tạo SqlDataAdapter và gán SqlCommand
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // Khởi tạo DataTable để lưu dữ liệu
            DataTable dt = new DataTable("Hoadon");

            // Sử dụng SqlDataAdapter để lấy dữ liệu từ cơ sở dữ liệu và điền vào DataTable
            da.Fill(dt);

            // Đóng kết nối sau khi hoàn thành công việc
            conn.Close();

            // Khởi tạo report Crystal
            CrystalReport1 baocao = new CrystalReport1();
            baocao.SetDataSource(dt);

            // Hiển thị report trong form mới
            frmbaocao f = new frmbaocao();
            f.crystalReportViewer1.ReportSource = baocao;
            f.ShowDialog();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand(" UPDATE dbo.tblChiTietHD\r\n    SET fGiaban = @fGiaban,\r\n        fSoluong = @fSoluong,\r\n        fGiamgia = @fGiamgia\r\n    WHERE sMaHD = @sMaHD AND sMaMH = @sMaMH", conn);
                cmd.Parameters.AddWithValue("@sMaHD", txtmahd.Text);
                cmd.Parameters.AddWithValue("@sMaMH", cbxmamh.SelectedValue);
                cmd.Parameters.AddWithValue("@fGiaban", txtgiaban.Text);
                cmd.Parameters.AddWithValue("@fSoluong", txtsoluong.Text);
                cmd.Parameters.AddWithValue("@fGiamgia", txtgiamgia.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
                frmchitiethd_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvchitiethd_Click(object sender, EventArgs e)
        {
            if (dgvchitiethd.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmahd.Text = dgvchitiethd.CurrentRow.Cells["Mã"].Value.ToString();
            cbxmamh.Text = dgvchitiethd.CurrentRow.Cells["Tên sản phẩm"].Value.ToString();
            txtgiaban.Text = dgvchitiethd.CurrentRow.Cells["Giá"].Value.ToString();
            txtsoluong.Text = dgvchitiethd.CurrentRow.Cells["Số lượng"].Value.ToString();
            txtgiamgia.Text = dgvchitiethd.CurrentRow.Cells["Giảm giá"].Value.ToString();
        }
        private void xoaTextBox()
        {
            txtmahd.Clear();
            cbxmamh.SelectedIndex = -1;
            txtgiaban.Clear();
            txtsoluong.Clear();
            txtgiamgia.Clear();
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
                    SqlCommand cmd = new SqlCommand("delete tblChiTietHD where sMaHD = @mahd and sMaMH = @mamh;", conn);
                    cmd.Parameters.AddWithValue("@mahd", txtmahd.Text);
                    cmd.Parameters.AddWithValue("@mamh", cbxmamh.SelectedValue);
                    cmd.Parameters.AddWithValue("@giaban", txtgiaban.Text);
                    cmd.Parameters.AddWithValue("@soluong", txtsoluong.Text);
                    cmd.Parameters.AddWithValue("@giamgia", txtgiamgia.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    frmchitiethd_Load(sender, e);
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

                SqlCommand cmd = new SqlCommand("SELECT *\r\n    FROM hienchitiethd\r\n    WHERE  Mã = @mahd AND  [Tên sản phẩm] LIKE '%' + @ten_sp + '%';", conn);
                cmd.Parameters.AddWithValue("@mahd", txtmahd.Text);
                cmd.Parameters.AddWithValue("@ten_sp", cbxmamh.Text);
                cmd.Parameters.AddWithValue("@fGiaban", txtgiaban.Text);
                cmd.Parameters.AddWithValue("@fSoluong", txtsoluong.Text);
                cmd.Parameters.AddWithValue("@fGiamgia", txtgiamgia.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(reader);
                dgvchitiethd.DataSource = tb;
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
                frmhoadonbh frmhoadonbh = new frmhoadonbh();
                frmhoadonbh.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Thao tác thoát đã bị hủy bởi người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
