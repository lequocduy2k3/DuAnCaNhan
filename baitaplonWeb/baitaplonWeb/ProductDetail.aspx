<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="baitaplonWeb.ProductDetail" %>

<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Chi Tiết Sản Phẩm</title>
    <link href="css/trangchu.css" rel="stylesheet" />
    <link href="css/ProductDetail.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
</head>
<body>
    <form id="form1" runat="server">
    <header>
        <a href="Trangchu.aspx" class="logo"><i class="fas fa-utensils"></i>Food.</a>
        <nav class="navbar">
            <a href="Trangchu.aspx">Trang chủ</a>
            <a href="Trangchu.aspx#dishes">Món ăn</a>
            <a href="Trangchu.aspx#about">Giới thiệu</a>
            <a href="Trangchu.aspx#menu">Menu</a>
            <a href="Order.aspx">Order</a>
            <a id="log" href="login.aspx" runat="server">Đăng nhập/Đăng ký</a>
            <a id="adminLink" runat="server" href="admin.aspx" visible="false">Quản lý</a>
        </nav>
        <div class="icons">
            <i class="fas fa-bars" id="menu-bars"></i>
            <i class="fas fa-search" id="search-icon"></i>
            <a href="#" class="fas fa-heart"></a>
            <a href="Cart.aspx" class="fas fa-shopping-cart"></a>
        </div>
    </header>
    <div id="body">
        <% 
            baitaplonWeb.product p = Application["ProductDetail"] as baitaplonWeb.product; 
        %>
        <div class="product-detail">
            <div class="image-slider">
                <button class="slider-btn prev-btn">&lt;</button>
                <div class="slider-container">
                    <img src="<%= p.Image1 %>" alt="Ảnh Sản Phẩm 1" class="slider-image">
                    <img src="<%= p.Image2 %>" alt="Ảnh Sản Phẩm 2" class="slider-image">
                    <img src="<%= p.Image3 %>" alt="Ảnh Sản Phẩm 3" class="slider-image">
                </div>
                <button class="slider-btn next-btn">&gt;</button>
            </div>
            <div class="product-info">
                <h1><%= p.Name %></h1>
                <p><%= p.Description %></p>
                <p class="price">Giá: $<%= p.Price %></p>
                <button class="add-to-cart-btn" onclick="AddToCart(this)"><i class="fas fa-shopping-cart"></i> Thêm vào giỏ hàng</button>

                
            <%--<asp:Button ID="btnDelete" runat="server" OnClientClick="return confirmDelete();" OnClick="BtnDelete_Click" Text="Xóa Sản Phẩm" />
<asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>--%>

            </div>
        </div>
    </div>
    <section class="footer">
        <div class="box-container">
            <div class="box">
                <h3>Địa điểm</h3>
                <a href="#">96 Định Công</a>
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
    <script>
        document.addEventListener('DOMContentLoaded', function () {
            document.querySelector('.add-to-cart-btn').addEventListener('click', function () {
                var productId = <%= p.Id %>; // Lấy ID sản phẩm từ code-behind
                var productName = '<%= p.Name %>'.replace(/'/g, "\\'"); // Lấy tên sản phẩm từ code-behind
                var productPrice = <%= p.Price %>; // Lấy giá sản phẩm từ code-behind
                var productImage = '<%= p.Image1 %>'.replace(/'/g, "\\'"); // Lấy URL hình ảnh sản phẩm từ code-behind

                // Gửi yêu cầu AJAX để thêm vào giỏ hàng
                var xhr = new XMLHttpRequest();
                xhr.open('POST', 'ProductDetail.aspx/AddToCart', true);
                xhr.setRequestHeader('Content-Type', 'application/json; charset=utf-8');
                xhr.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
                xhr.onreadystatechange = function () {
                    if (xhr.readyState === XMLHttpRequest.DONE) {
                        if (xhr.status === 200) {
                            alert('Món ăn đã được thêm vào giỏ hàng!');
                        } else {
                            console.error('Lỗi:', xhr.status, xhr.responseText); // Hiển thị lỗi chi tiết trong console
                            alert('Đã xảy ra lỗi khi thêm món ăn vào giỏ hàng.');
                        }
                    }
                };
                xhr.send(JSON.stringify({
                    id: productId,
                    name: productName,
                    price: productPrice,
                    image: productImage
                }));
            });
        });

            //function confirmDelete() {
            //    return confirm("Bạn có chắc chắn muốn xóa sản phẩm này không?");
            //}
    </script>
        <script src="js/trangchu.js"></script>
        <script src="js/ProductDetail.js"></script>
    </form>
</body>
</html>
