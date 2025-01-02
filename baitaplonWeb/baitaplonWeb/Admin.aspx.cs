using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace baitaplonWeb
{
    public partial class Admin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["isAdmin"] != null && (bool)Session["isAdmin"])
                {
                    adminLink.Visible = true; // Hiển thị thẻ Admin nếu người dùng là admin
                }
                else
                {
                    adminLink.Visible = false; // Ẩn thẻ Admin nếu không có người dùng đăng nhập hoặc không phải admin
                }

                if (Session["username"] != null)
                {
                    log.InnerHtml = "<a id='log' href='Logout.aspx'>" + Session["username"].ToString() + "/Đăng xuất</a>";
                }
            }
            if (!IsPostBack)
            {
                if (Session["isAdmin"] != null && (bool)Session["isAdmin"])
                {
                    lblVisitorCount.Text = Application["CurrentVisitors"]?.ToString() ?? "0";

                    if (Application["Users"] == null)
                    {
                        Application["Users"] = new List<User>(); // Khởi tạo danh sách người dùng nếu chưa có
                    }

                    BindUserGrid();
                }
                else
                {
                    Response.Redirect("Trangchu.aspx");
                }
            }
        }

        private void BindUserGrid()
        {
            List<User> listuser = Application["Users"] as List<User>;
            if (listuser != null)
            {
                gvUsers.DataSource = listuser;
                gvUsers.DataBind();
            }
            else
            {
                lblError.Text = "Danh sách người dùng không có giá trị.";
            }
        }

        protected void GvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            BindUserGrid();
        }

        protected void GvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            List<User> listuser = Application["Users"] as List<User>;
            if (listuser != null)
            {
                GridViewRow row = gvUsers.Rows[e.RowIndex];
                string username = ((Label)row.FindControl("lblUsername")).Text;
                User user = listuser.Find(u => u.Username == username);
                if (user != null)
                {
                    user.Email = ((TextBox)row.FindControl("txtEmail")).Text;
                    user.Password = ((TextBox)row.FindControl("txtPassword")).Text;
                    user.Role = ((CheckBox)row.FindControl("chkRole")).Checked;
                    gvUsers.EditIndex = -1;
                    BindUserGrid();
                }
                else
                {
                    lblError.Text = "Người dùng không tồn tại.";
                }
            }
            else
            {
                lblError.Text = "Danh sách người dùng không có giá trị.";
            }
        }

        protected void GvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;
            BindUserGrid();
        }

        protected void GvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<User> listuser = Application["Users"] as List<User>;
            if (listuser != null)
            {
                string username = ((Label)gvUsers.Rows[e.RowIndex].FindControl("lblUsername")).Text;
                User user = listuser.Find(u => u.Username == username);
                if (user != null)
                {
                    listuser.Remove(user);
                    BindUserGrid();
                }
                else
                {
                    lblError.Text = "Người dùng không tồn tại.";
                }
            }
            else
            {
                lblError.Text = "Danh sách người dùng không có giá trị.";
            }
        }

        protected void BtnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtNewUsername.Text.Trim();
            string email = txtNewEmail.Text.Trim();
            string password = txtNewPassword.Text.Trim();
            bool isAdmin = chkNewRole.Checked;

            List<User> listuser = Application["Users"] as List<User>;
            if (listuser != null)
            {
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    // Kiểm tra xem tên đăng nhập đã tồn tại chưa
                    if (listuser.Exists(u => u.Username == username))
                    {
                        lblError.Text = "Tên đăng nhập đã tồn tại.";
                    }
                    else
                    {
                        // Thêm người dùng mới với thông tin đã nhập
                        listuser.Add(new User(username, email, password, password, isAdmin));
                        BindUserGrid();
                        // Xóa các giá trị nhập sau khi thêm
                        txtNewUsername.Text = string.Empty;
                        txtNewEmail.Text = string.Empty;
                        txtNewPassword.Text = string.Empty;
                        chkNewRole.Checked = false;
                    }
                }
                else
                {
                    lblError.Text = "Vui lòng điền đầy đủ thông tin.";
                }
            }
            else
            {
                lblError.Text = "Danh sách người dùng không có giá trị.";
            }
        }
    }
}