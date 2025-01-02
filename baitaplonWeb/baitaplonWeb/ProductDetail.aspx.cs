using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace baitaplonWeb
{
    public partial class ProductDetail : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Kiểm tra và hiển thị hoặc ẩn liên kết Admin
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

            // Lấy ID sản phẩm từ Query String
            int id = int.Parse(Request.QueryString.Get("id") ?? "0");
            if (id > 0)
            {
                // Lấy danh sách sản phẩm từ Application state
                List<product> list = Application["ProductList"] as List<product>;

                // Kiểm tra nếu danh sách sản phẩm không null
                if (list != null)
                {
                    // Tìm sản phẩm theo ID
                    product selectedProduct = list.FirstOrDefault(item => item.Id == id);
                    if (selectedProduct != null)
                    {
                        // Lưu sản phẩm vào Application state
                        Application["ProductDetail"] = selectedProduct;
                    }
                    else
                    {
                        // Nếu không tìm thấy sản phẩm với ID, chuyển hướng về trang chủ
                        Response.Redirect("Trangchu.aspx");
                    }
                }
                else
                {
                    // Nếu danh sách sản phẩm không có, chuyển hướng về trang chủ
                    Response.Redirect("Trangchu.aspx");
                }
            }
            else
            {
                // Nếu ID không hợp lệ, chuyển hướng về trang chủ
                Response.Redirect("Trangchu.aspx");
            }
        }

        [WebMethod]
        public static object AddToCart(int id, string name, decimal price, string image)
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

                // Cập nhật session với giỏ hàng đã thay đổi
                HttpContext.Current.Session["Cart"] = cart;

                // Đảm bảo rằng các thay đổi được lưu
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);

                return new { success = true, message = "Sản phẩm đã được thêm vào giỏ hàng!" };
            }
            catch (Exception ex)
            {
                return new { success = false, message = "Đã xảy ra lỗi: " + ex.Message };
            }
        }

        //protected void BtnDelete_Click(object sender, EventArgs e)
        //{
        //    // Kiểm tra xem người dùng có phải là admin không
        //    if (Session["isAdmin"] != null && (bool)Session["isAdmin"])
        //    {
        //        // Lấy ID sản phẩm từ query string
        //        int id;
        //        bool isIdValid = int.TryParse(Request.QueryString.Get("id"), out id);

        //        // Kiểm tra ID hợp lệ và không âm
        //        if (isIdValid && id > 0)
        //        {
        //            // Lấy danh sách sản phẩm từ Application state
        //            List<product> list = Application["ProductList"] as List<product>;

        //            // Kiểm tra danh sách sản phẩm không null
        //            if (list != null)
        //            {
        //                // Tìm sản phẩm cần xóa theo ID
        //                product productToDelete = list.FirstOrDefault(item => item.Id == id);
        //                if (productToDelete != null)
        //                {
        //                    // Xóa sản phẩm khỏi danh sách
        //                    list.Remove(productToDelete);
        //                    Application["ProductList"] = list; // Cập nhật danh sách vào Application state

        //                    lblMessage.Text = "Sản phẩm đã được xóa thành công.";
        //                }
        //                else
        //                {
        //                    lblMessage.Text = "Sản phẩm không tồn tại.";
        //                }
        //            }
        //            else
        //            {
        //                lblMessage.Text = "Danh sách sản phẩm không tồn tại.";
        //            }
        //        }
        //        else
        //        {
        //            lblMessage.Text = "ID sản phẩm không hợp lệ.";
        //        }
        //    }
        //    else
        //    {
        //        lblMessage.Text = "Bạn không có quyền xóa sản phẩm này.";
        //    }
        //}




    }
}
