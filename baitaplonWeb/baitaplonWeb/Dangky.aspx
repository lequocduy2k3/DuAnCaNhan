<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dangky.aspx.cs" Inherits="baitaplonWeb.Dangky" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Đăng ký</title>
    <link href="css/trangchu.css" rel="stylesheet" />
    <link href="css/Dangky.css" rel="stylesheet" />
    <link
      rel="stylesheet"
      href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.2/css/all.min.css"/>
</head>
<body>
     <header>
      <a href="Trangchu.aspx" class="logo"><i class="fas fa-utensils"></i>Food.</a>
      <nav class="navbar">
        <a class="active" href="Home.aspx">Trang chủ</a>
        <a href="Trangchu.aspx#dishes">Món ăn</a>
        <a href="Trangchu.aspx#about">Giới thiệu</a>
        <a href="Trangchu.aspx#menu">menu</a>
        <a href="Order.aspx">oder</a>
        <a href="login.aspx">Đăng nhập/Đăng ký</a>
      </nav>
      <div class="icons">
        <i class="fas fa-bars" id="menu-bars"></i>
        <i class="fas fa-search" id="search-icon"></i>
        <a href="#" class="fas fa-heart"></a>
        <a href="Cart.aspx" class="fas fa-shopping-cart"></a>
      </div>
    </header>
   <div class="body">
   <div class="register-container">
        <h2>Đăng ký</h2>
        <form runat="server" method="post" onsubmit="return checkLogup()">
            <span id="success" runat="server"></span>
            <div class="input-group">
                <label for="username">Username</label>
                <input type="text" id="username" name="username">
            </div>
            <div class="input-group">
                <label for="email">Email</label>
                <input type="email" id="email" name="email">
            </div>
            <div class="input-group">
                <label for="password">Password</label>
                <input type="password" id="password" name="password">
            </div>
            <div class="input-group">
                <label for="confirm-password">Confirm Password</label>
                <input type="password" id="confirm-password" name="confirm-password">
            </div>
            <span id="error" runat="server" ></span>
            <button type="submit">Đăng ký</button>
        </form>
        <a class="login" href="login.aspx">Bạn đã có tài khoản?</a>
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
          <a href="#">Oder</a>
        </div>
        <div class="box">
          <h3>Thông tin liên lạc</h3>
          <a href="#">+123-345-789</a>
          <a href="#">abc123@gmail.com</a>
        </div>
      </div>
    </section>
<script src="js/trangchu.js"></script>
    <script src="js/Dangky.js"></script>
</body>
</html>