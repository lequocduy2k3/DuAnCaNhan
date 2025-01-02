using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.Services;

namespace baitaplonWeb
{
    public partial class Order : Page
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
                // Lấy danh sách sản phẩm từ Application state
                List<product> products = Application["ProductList"] as List<product>;

                if (products != null)
                {
                    // Gán danh sách sản phẩm cho Repeater control
                    rptMenuItems.DataSource = products;
                    rptMenuItems.DataBind();
                }
            }
        }

        [WebMethod]
        public static void AddToCart(int id, string name, decimal price, string image)
        {
            List<CartItem> cart = HttpContext.Current.Session["Cart"] as List<CartItem>;
            if (cart == null)
            {
                cart = new List<CartItem>();
                HttpContext.Current.Session["Cart"] = cart;
            }

            CartItem existingItem = cart.Find(item => item.Id == id);
            if (existingItem != null)
            {
                existingItem.Quantity++; // Tăng số lượng nếu món ăn đã có trong giỏ hàng
            }
            else
            {
                CartItem item = new CartItem
                {
                    Id = id,
                    Name = name,
                    Price = price,
                    ImageUrl = image,
                    Quantity = 1 // Mặc định số lượng là 1 khi thêm mới
                };
                cart.Add(item);
            }

            // Cập nhật session với giỏ hàng đã thay đổi
            HttpContext.Current.Session["Cart"] = cart;

            // Đảm bảo rằng các thay đổi được lưu
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        }

       
    }
}
