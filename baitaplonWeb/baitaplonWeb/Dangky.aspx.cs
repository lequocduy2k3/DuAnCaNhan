using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace baitaplonWeb
{
    public partial class Dangky : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string usename = Request.Form.Get("username");
                usename = usename.ToLower();
                string password = Request.Form.Get("password");
                password = password.ToLower();
                string repassword = Request.Form.Get("confirm-password");
                repassword = repassword.ToLower();
                string email = Request.Form.Get("email");
                email = email.ToLower();
                bool isCheck = true;
                if (usename != "" && password != "" && repassword != "" && email != "")
                {
                    List<User> users = (List<User>)Application["Users"];
                    foreach (User user in users)
                    {
                        if (usename == user.Username.ToLower())
                        {
                            isCheck = false;
                            error.InnerHtml = "Tài khoản đã tồn tại";
                            return;
                        }
                    }
                    if (!IsValidGmail(email))
                    {
                        isCheck = false;
                        error.InnerHtml = "Vui lòng nhập đúng định dạng email";
                        return;
                    }
                    if (password.Length < 5)
                    {
                        isCheck = false;
                        error.InnerHtml = "Mật khẩu tối thiểu 5 ký tự";
                        return;
                    }
                    if (isCheck)
                    {
                        success.InnerHtml = "Đăng ký thành công";
                        error.InnerHtml = "";
                        User u = new User(usename, email, password, repassword, false);
                        users.Add(u);
                        Application["Users"] = users;
                    }
                }
            }
        }
        private bool IsValidGmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            string pattern = @"^[a-zA-Z0-9._%+-]+@(gmail\.com|googlemail\.com)$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
    }
}