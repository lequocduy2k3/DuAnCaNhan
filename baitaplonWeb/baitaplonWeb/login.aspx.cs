using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace baitaplonWeb
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string user = Request.Form.Get("username");
                string pass = Request.Form.Get("password");

                if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(pass))
                {
                    List<User> listuser = (List<User>)Application["Users"];
                    User loggedInUser = listuser.FirstOrDefault(u => u.Username.Equals(user, StringComparison.OrdinalIgnoreCase) && u.Password.Equals(pass, StringComparison.OrdinalIgnoreCase));

                    if (loggedInUser != null)
                    {
                        Session["username"] = loggedInUser.Username;
                        Session["isAdmin"] = loggedInUser.Role; // Set admin status
                        Response.Redirect("Trangchu.aspx");
                    }
                    else
                    {
                        error.InnerHtml = "Tài khoản hoặc mật khẩu không chính xác.";
                    }
                }
            }
        }
    }
}