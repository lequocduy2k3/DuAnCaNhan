<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="baitaplonWeb.Order" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="css/trangchu.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.2/css/all.min.css">
    <link rel="stylesheet" href="css/oder.css">

    <title>Order</title>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <a href="Trangchu.aspx" class="logo"><i class="fas fa-utensils"></i>Food.</a>
            <nav class="navbar">
                <a  href="/Trangchu.aspx">Trang chủ</a>
                <a href="/Trangchu.aspx">Món ăn</a>
                <a href="/Trangchu.aspx">Giới thiệu</a>
                <a href="/Trangchu.aspx">Menu</a>
                <a class="active" href="/Order.aspx">Order</a>
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


        <div class="dashboard">
            <div class="dashboard-banner">
                <img src="https://img.freepik.com/premium-photo/burger-hamburger-cheeseburger-fast-food-advertising-banner-with-copy-space-your-branding_742418-17079.jpg?uid=R155189160&ga=GA1.1.1920238861.1720428848&semt=ais_user" alt="">
                <div class="banner-promo">
                    <h1>
                        <span> Giảm 50%</span> <br />Món ăn ngon <br />
                        Trên tay bạn
                    </h1>
                </div>
            </div>
            <h3 class="dashboard-title">Đề Xuất Món Ăn Cho Bạn</h3>
            <div class="dashboard-menu">
                <a href="#">Yêu thích</a>
                <a href="#">Bán chạy nhất</a>
                <a href="#">Gần bạn</a>
                <a href="#">Khuyến mãi</a>
                <a href="#">Xếp hạng cao</a>
                <a href="#">Tất cả</a>
            </div>
            <div class="dashboard-content">
                <asp:Repeater ID="rptMenuItems" runat="server">
    <ItemTemplate>
        <div class="dashboard-card">
            <a href="ProductDetail.aspx?id=<%# Eval("Id") %>">
                <img class="card-image" src='<%# Eval("Image1") %>' alt='<%# Eval("Name") %>' /> 
                <div class="card-detail">
                    <h4><%# Eval("Name") %> <span>$<%# Eval("Price") %></span></h4>
                    <p class="card-time"><span class="fas fa-clock"></span>15-30 mins</p>
                </div>
            </a>
                <button class="btn btn-add-to-cart" 
                        data-id='<%# Eval("Id") %>' 
                        data-name='<%# Eval("Name") %>' 
                        data-price='<%# Eval("Price") %>' 
                        data-image='<%# Eval("Image1") %>' 
                        onclick="addToCart(this)">
                    Thêm vào giỏ hàng
                </button>       
        </div>
    </ItemTemplate>
</asp:Repeater>
            </div>
        </div>

        <section class="footer">
            <div class="box-container">
                <div class="box">
                    <h3>Địa điểm</h3>
                    <a href="#">96 Định công</a>
                </div>
                <div class="box">
                    <h3>Đường dẫn nhanh</h3>
                    <a href="#">Trang chủ</a>
                    <a href="#">Món ăn</a>
                    <a href="#">Giới thiệu</a>
                    <a href="#">Menu</a>
                    <a href="#">Order</a>
                </div>
                <div class="box">
                    <h3>Thông tin liên lạc</h3>
                    <a href="#">+123-345-789</a>
                    <a href="#">abc123@gmail.com</a>
                </div>
            </div>
        </section>
    </form>
    <script src="js/trangchu.js"></script>
    <script>
        function addToCart(element) {
            var id = element.getAttribute('data-id');
            var name = element.getAttribute('data-name');
            var price = element.getAttribute('data-price');
            var image = element.getAttribute('data-image');

            var xhr = new XMLHttpRequest();
            xhr.open('POST', 'Order.aspx/AddToCart', true);
            xhr.setRequestHeader('Content-Type', 'application/json');
            xhr.setRequestHeader('X-Requested-With', 'XMLHttpRequest'); // Đảm bảo đây là yêu cầu AJAX
            xhr.onreadystatechange = function () {
                if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
                    alert('Món ăn đã được thêm vào giỏ hàng!');
                } else if (xhr.readyState === XMLHttpRequest.DONE) {
                    alert('Có lỗi xảy ra khi thêm món ăn vào giỏ hàng!');
                }
            };
            xhr.send(JSON.stringify({ id: id, name: name, price: price, image: image }));
        }

    </script>
</body>
</html>
