using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace BaiTapLon
{
    public partial class frmmathang : Form
    {
        static string cnn = ConfigurationManager.ConnectionStrings["QLBanXe"].ConnectionString;
        SqlConnection conn = new SqlConnection(cnn);
        public frmmathang()
        {
            InitializeComponent();
        }

        private void frmmathang_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblMatHang", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(reader);
                dgvmathang.DataSource = tb;
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                LoadDataGridView();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            hiendsmaloaihang();
            hiendsmanhacc();
            cbxmaloaihang.SelectedIndex = -1; // Đặt lại chỉ mục của ComboBox về -1 để không chọn bất kỳ mục nào
            cbxmancc.SelectedIndex = -1; // Đặt lại chỉ mục của ComboBox về -1 để không chọn bất kỳ mục nào

        }
        public void LoadDataGridView()
        {

            dgvmathang.Columns[0].HeaderText = "Mã mặt hàng";
            dgvmathang.Columns[1].HeaderText = "Tên sản phẩm";
            dgvmathang.Columns[2].HeaderText = "Mã loại hàng";
            dgvmathang.Columns[3].HeaderText = "Mã nhà cung cấp";
            dgvmathang.Columns[4].HeaderText = "Số lượng";
            dgvmathang.Columns[5].HeaderText = "Giá bán";
            dgvmathang.Columns[0].Width = 100;
            dgvmathang.Columns[1].Width = 150;
            dgvmathang.Columns[2].Width = 100;
            dgvmathang.Columns[3].Width = 120;
            dgvmathang.Columns[4].Width = 80;
            dgvmathang.Columns[5].Width = 100;
            dgvmathang.AllowUserToAddRows = false;
            dgvmathang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private DataTable laydsmaloaihang()
        {           
                using (SqlCommand cmd = new SqlCommand("Select * from tblLoaiHang", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable("MaLH");
                        ad.Fill(dt);
                        return dt;

                    }
                }           
        }
        private void hiendsmaloaihang()
        {
            DataTable t = laydsmaloaihang();
            DataView dv = new DataView(t);
            dv.Sort = "sMaLoaiHang";
            cbxmaloaihang.DataSource = dv;
            cbxmaloaihang.DisplayMember = "sMaLoaiHang";
            cbxmaloaihang.ValueMember = "sMaLoaiHang";
        }
        private DataTable laydsmanhacc()
        {
            using (SqlCommand cmd = new SqlCommand("Select * from tblNhaCC", conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable("NCC");
                    ad.Fill(dt);
                    return dt;

                }
            }
        }
        private void hiendsmanhacc()
        {
            DataTable t = laydsmanhacc();
            DataView dv = new DataView(t);
            dv.Sort = "sMaNCC";
            cbxmancc.DataSource = dv;
            cbxmancc.DisplayMember = "sMaNCC";
            cbxmancc.ValueMember = "sMaNCC";
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmamh.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã mặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtmamh.Focus();
                    return;
                }
                if (txttensp.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttensp.Focus();
                    return;
                }
                if (txtsoluong.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số lượng mặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsoluong.Focus();
                    return;
                }
                if (txtgiaban.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập giá bán của mặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtgiaban.Focus();
                    return;
                }
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("insert into tblMatHang\r\n\tvalues(@mamh , @tensp , @maloaihang , @mancc , @soluong , @giaban)", conn);

                cmd.Parameters.AddWithValue("@mamh", txtmamh.Text);
                cmd.Parameters.AddWithValue("@tensp", txttensp.Text);
                cmd.Parameters.AddWithValue("@maloaihang", cbxmaloaihang.Text);
                cmd.Parameters.AddWithValue("@mancc", cbxmancc.Text);
                cmd.Parameters.AddWithValue("@soluong", txtsoluong.Text);
                cmd.Parameters.AddWithValue("@giaban", txtgiaban.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
                frmmathang_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtmamh_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Xóa thông báo lỗi trước khi kiểm tra lại
                errmamh.SetError(textBox, "");

                // Kiểm tra xem mã nhân viên đã tồn tại hay chưa
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM tblMatHang WHERE sMaMH = @mamh", conn);
                checkCmd.Parameters.AddWithValue("@mamh", textBox.Text);
                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    errmamh.SetError(textBox, "Mã mặt hàng đã tồn tại. Vui lòng chọn mã mặt hàng khác.");
                }
                else
                {
                    errmamh.SetError(textBox, ""); // Xóa thông báo lỗi nếu không có lỗi
                }

                if (conn.State == ConnectionState.Open)
                    conn.Close();

            }
        }

        private void dgvmathang_Click(object sender, EventArgs e)
        {
            if (dgvmathang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmamh.Text = dgvmathang.CurrentRow.Cells["sMaMH"].Value.ToString();
            errmamh.SetError(txtmamh, "");
            txttensp.Text = dgvmathang.CurrentRow.Cells["sTenSP"].Value.ToString();           
            cbxmaloaihang.Text = dgvmathang.CurrentRow.Cells["sMaLoaiHang"].Value.ToString();
            cbxmancc.Text = dgvmathang.CurrentRow.Cells["sMaNCC"].Value.ToString();
            txtsoluong.Text = dgvmathang.CurrentRow.Cells["iSoLuong"].Value.ToString();
            txtgiaban.Text = dgvmathang.CurrentRow.Cells["fGiaban"].Value.ToString();

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("update tblMatHang\r\n\tset sMaMH = @mamh , sTenSp = @tensp , sMaLoaiHang = @maloaihang ,\r\n\t\tsMaNCC = @mancc , iSoLuong = @soluong , fGiaban = @giaban\r\n\twhere sMaMH = @mamh", conn);
                cmd.Parameters.AddWithValue("@mamh", txtmamh.Text);
                cmd.Parameters.AddWithValue("@tensp", txttensp.Text);
                cmd.Parameters.AddWithValue("@maloaihang", cbxmaloaihang.Text);
                cmd.Parameters.AddWithValue("@mancc", cbxmancc.Text);
                cmd.Parameters.AddWithValue("@soluong", txtsoluong.Text);
                cmd.Parameters.AddWithValue("@giaban", txtgiaban.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Sửa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
                frmmathang_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void xoaTextBox()
        {
            txtmamh.Clear();
            txttensp.Clear();
            cbxmaloaihang.SelectedIndex = -1; // Đặt lại chỉ mục của ComboBox về -1 để không chọn bất kỳ mục nào
            cbxmancc.SelectedIndex = -1; // Đặt lại chỉ mục của ComboBox về -1 để không chọn bất kỳ mục nào
            txtsoluong.Text = "";
            txtgiaban.Text = "";
            txtmamh.Focus();
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
                    SqlCommand cmd = new SqlCommand("delete tblMatHang where sMaMH = @mamh", conn);
                    cmd.Parameters.AddWithValue("@mamh", txtmamh.Text);
                    cmd.Parameters.AddWithValue("@tensp", txttensp.Text);
                    cmd.Parameters.AddWithValue("@maloaihang", cbxmaloaihang.Text);
                    cmd.Parameters.AddWithValue("@mancc", cbxmancc.Text);
                    cmd.Parameters.AddWithValue("@soluong", txtsoluong.Text);
                    cmd.Parameters.AddWithValue("@giaban", txtgiaban.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    frmmathang_Load(sender, e);
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

                SqlCommand cmd = new SqlCommand(" select * from tblMatHang\r\n\t\twhere sTenSp like '%' +@tensp+ '%' ", conn);
                cmd.Parameters.AddWithValue("@mamh", txtmamh.Text);
                cmd.Parameters.AddWithValue("@tensp", txttensp.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable tb = new DataTable();
                tb.Load(reader);
                dgvmathang.DataSource = tb;
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
