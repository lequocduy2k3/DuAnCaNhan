using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;

namespace baitaplonWeb
{
    public partial class Trangchu : Page
    {
      

        protected void Page_Load(object sender, EventArgs e)
        {
            List<product> list = new List<product>();
            List<product> products = (List<product>)Application["ProductList"];
            foreach (product p in products)
            {
                if (p.Id == 1 || p.Id == 2 || p.Id == 4 || p.Id == 6 || p.Id == 8 || p.Id == 9)
                {
                    list.Add(p);
                }
            }
            Application["ProductHot"] = list;
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
               
        }
        [WebMethod]
        public static string AddToCart(int id, string name, decimal price, string image)
        {
            try
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

                HttpContext.Current.Session["Cart"] = cart;

                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);

                return new JavaScriptSerializer().Serialize(new { success = true, message = "Món ăn đã được thêm vào giỏ hàng!" });
            }
            catch (Exception ex)
            {
                return new JavaScriptSerializer().Serialize(new { success = false, message = "Đã xảy ra lỗi: " + ex.Message });
            }
        }

       
    }
}
