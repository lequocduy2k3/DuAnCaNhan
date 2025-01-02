using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace baitaplonWeb
{
    public partial class Cart : Page
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
                BindCartItems();
            }
        }

        private void BindCartItems()
        {
            if (Session["Cart"] != null)
            {
                List<CartItem> cart = (List<CartItem>)Session["Cart"];

                rptCartItems.DataSource = cart;
                rptCartItems.DataBind();

                decimal totalFoodPrice = cart.Sum(item => item.Price * item.Quantity);
                decimal tax = 3.00m;
                decimal deliveryFee = 5.00m;
                decimal totalAmount = totalFoodPrice + tax + deliveryFee;

                totalFoodPriceLabel.Text = totalFoodPrice.ToString("C");
                totalAmountLabel.Text = totalAmount.ToString("C");
            }
        }

        protected void rptCartItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (Session["Cart"] != null)
            {
                List<CartItem> cart = (List<CartItem>)Session["Cart"];
                int index = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName == "Increase")
                {
                    cart[index].Quantity++;
                }
                else if (e.CommandName == "Decrease" && cart[index].Quantity > 1)
                {
                    cart[index].Quantity--;
                }
                else if (e.CommandName == "Delete")
                {
                    cart.RemoveAt(index);
                }

                Session["Cart"] = cart; // Update the session
                BindCartItems(); // Refresh the UI
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Checkout.aspx");
        }
    }

   
}
