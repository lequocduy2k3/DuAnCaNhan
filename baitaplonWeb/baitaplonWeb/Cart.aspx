<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="baitaplonWeb.Cart" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="css/trangchu.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.2/css/all.min.css">
    <link rel="stylesheet" href="css/trangchu.css">
    <link rel="stylesheet" href="css/giohang.css">
    <title>Giỏ hàng</title>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <a href="Trangchu.aspx" class="logo"><i class="fas fa-utensils"></i>Food.</a>
            <nav class="navbar">
                <a href="/Trangchu.aspx">Trang chủ</a>
                <a href="/Trangchu.aspx">Món ăn</a>
                <a href="/Trangchu.aspx">Giới thiệu</a>
                <a href="/Trangchu.aspx">Menu</a>
                <a href="/Order.aspx">Order</a>
                <a id="log" href="login.aspx" runat="server">Đăng nhập/Đăng ký</a>
                <a id="adminLink" runat="server" href="admin.aspx" visible="false">Quản lý</a> <!-- Thẻ Admin -->

            </nav>
            <div class="icons">
                <i class="fas fa-bars" id="menu-bars"></i>
                <i class="fas fa-search" id="search-icon"></i>
                <a href="#" class="fas fa-heart"></a>
                <a href="/Cart.aspx" class="fas fa-shopping-cart"></a>
            </div>
        </header>


         <!-- search form -->

         <form action="" id="search-form">
          <input
            type="search"
            placeholder="Bạn muốn ăn gì???"
            name=""
            id="search-box"
          />
          <label for="search-box" class="fas fa-search"></label>
          <i class="fas fa-times" id="close"></i>
        </form>

        <div class="dashboard-oder" id="dashboard-oder">
            <h3>Giỏ hàng</h3>
            <div class="oder-address">
                <p>Địa chỉ giao hàng</p>
                <h4>96 Định Công, Hoàng Mai</h4>
            </div>
            <div class="oder-time">
                <span class="fas fa-clock"></span>30 mins <span class="fas fa-map-marker-alt"></span>2 km
            </div>
            <div class="oder-wrapper" id="oder-wrapper">
              <asp:Repeater ID="rptCartItems" runat="server" OnItemCommand="rptCartItems_ItemCommand">
    <ItemTemplate>
        <div id="item_<%# Container.ItemIndex %>" class="oder-card">
            <img class="oder-image" src='<%# Eval("ImageUrl") %>' alt='<%# Eval("Name") %>' />
            <div class="oder-detail">
                <p><%# Eval("Name") %></p>
                <h4 class="order-price">$<%# Eval("Price") %></h4>
                <asp:LinkButton ID="btnIncrease" runat="server" CommandName="Increase" CommandArgument='<%# Container.ItemIndex %>'>
                    <i class="fa-solid fa-plus"></i>
                </asp:LinkButton>
                <input type="text" value='<%# Eval("Quantity") %>' id="quantity_<%# Container.ItemIndex %>" readonly />
                <asp:LinkButton ID="btnDecrease" runat="server" CommandName="Decrease" CommandArgument='<%# Container.ItemIndex %>'>
                    <i class="fa-solid fa-minus"></i>
                </asp:LinkButton>
                <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Container.ItemIndex %>'>
                    <i class="fas fa-times"></i>
                </asp:LinkButton>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>

<asp:Label ID="Label1" runat="server"></asp:Label>
<asp:Label ID="Label2" runat="server"></asp:Label>
<asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="btnCheckout_Click" />

            </div>

            <hr class="divider">
            <div class="order-total">
                <p class="total-food-price">Giá đồ ăn 
                    <asp:Label ID="totalFoodPriceLabel" runat="server" Text="0$"></asp:Label>
                </p>
                <p>Thuế <span>$3</span></p>
                <p>Phí giao hàng <span>$5</span></p>
                <div class="order-promo">
                    <input type="text" class="input-promo" placeholder="Nhập Voucher">
                    <button class="button-promo">Tìm Voucher</button>
                </div>
                <div class="order-total">
                    <hr class="divider">
                    <p>Tổng tiền 
                        <asp:Label ID="totalAmountLabel" runat="server" Text="0$"></asp:Label>
                    </p>
                </div>
                <button class="checkout" onclick="__doPostBack('btnCheckout', '')">Thanh toán</button>
            </div>
        </div>
    </form>
        <script src="js/trangchu.js" defer> </script>
</body>
</html>
