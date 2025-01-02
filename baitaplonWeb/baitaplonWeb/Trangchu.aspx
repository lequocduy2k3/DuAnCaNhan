<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Trangchu.aspx.cs" Inherits="baitaplonWeb.Trangchu" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="css/trangchu.css" />
    <link
      rel="stylesheet"
      href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.2/css/all.min.css"
    />
    <link
      rel="stylesheet"
      href="https://cdn.jsdelivr.net/npm/swiper@11/swiper-bundle.min.css"
    />
    <title>Trang chủ</title>
  </head>
  <body>
    <header>
      <a href="Trangchu.aspx" class="logo"><i class="fas fa-utensils"></i>Food.</a>
      <nav class="navbar">
        <a class="active" href="#home">Trang chủ</a>
        <a href="#dishes">Món ăn</a>
        <a href="#about">Giới thiệu</a>
        <a href="#menu">menu</a>
        <a href="Order.aspx">oder</a>
        <a id="log" href="login.aspx" runat="server">Đăng nhập/Đăng ký</a>
        <a id="adminLink" runat="server" href="admin.aspx" visible="false">Quản lý</a> <!-- Thẻ Admin -->

      </nav>
      <div class="icons">
        <i class="fas fa-bars" id="menu-bars"></i>
        <i class="fas fa-search" id="search-icon"></i>
        <a href="#" class="fas fa-heart"></a>
        <a href="/Cart.aspx" class="fas fa-shopping-cart">Giỏ hàng</a>
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

    <!-- home section start -->

    <section class="home" id="home">
      <div class="swiper home-slider">
        <div class="swiper-wrapper wrapper">
          <div class="swiper-slide slide">
            <div class="content">
              <span>Món ăn đặc biệt của chúng tôi</span>
              <h3>Mì lạnh</h3>
              <p>
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Culpa
                architecto quia animi!
              </p>
              <a href="#" class="btn">ORDER NOW</a>
            </div>
            <div class="image">
              <img src="/Images/img1.jpg" alt="" />
            </div>
          </div>
          <div class="swiper-slide slide">
            <div class="content">
              <span>Món ăn đặc biệt của chúng tôi</span>
              <h3>Gà rán</h3>
              <p>
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Culpa
                architecto quia animi!
              </p>
              <a href="#" class="btn">ORDER NOW</a>
            </div>
            <div class="image">
              <img
                src="/Images/fried-chicken-french-fries-white-plate.jpg"
                alt=""
              />
            </div>
          </div>
          <div class="swiper-slide slide">
            <div class="content">
              <span>Món ăn đặc biệt của chúng tôi</span>
              <h3>Pizza</h3>
              <p>
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Culpa
                architecto quia animi!
              </p>
              <a href="#" class="btn">ORDER NOW</a>
            </div>
            <div class="image">
              <img
                src="/Images/isolated-shot-pizza-with-ham-arugula.jpg"
                alt=""
              />
            </div>
          </div>
        </div>
        <div class="swiper-pagination"></div>
      </div>
    </section>


    <!-- phần món ăn -->


      <section class="dishes" id="dishes">
    <h3 class="sub-heading">Món ăn của chúng tôi</h3>
    <h1 class="heading">Món ăn phổ biến</h1>
    <div class="box-container">
        <%
            List<baitaplonWeb.product> products = Application["ProductHot"] as List<baitaplonWeb.product>;
            foreach (baitaplonWeb.product p in products)
            {
        %>
        <div class="box">
            <a href="#" class="fas fa-heart"></a>
            <a href="#" class="fas fa-eye"></a>
            <a href="ProductDetail.aspx?id=<%=p.Id%>"><img src="<%=p.Image1%>" alt=""></a>
            <h3><a href="ProductDetail.aspx?id=<%=p.Id%>"><%=p.Name %></a></h3>
            <div class="start">
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star-half-alt"></i>
            </div>
            <span><%=p.Price%>$</span>
            <a href="Order.aspx" class="btn">Mua ngay!</a>
            <%--<div class="before"></div> <!-- Đường viền trái -->
            <div class="after"></div> <!-- Đường viền phải -->--%>
        </div>
        <%} %>
    </div>
</section>

    <!-- about start -->

    <section class="about" id="about">
      <h3 class="sub-heading">Giới thiệu</h3>
      <h1 class="heading">Vì sao lại chọn món ăn này</h1>
      <div class="row">
        <div class="image">
          <img src="https://img.freepik.com/free-photo/pizza-smoked-salmon_74190-2497.jpg?uid=R155189160&ga=GA1.1.1920238861.1720428848&semt=ais_user" alt="">
        </div>
        <div class="content">
          <h3>Món ăn ngon nhất</h3>
          <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Eius nesciunt, maiores iure magnam dicta ex nihil aliquid cumque explicabo qui nulla praesentium quasi dolorem consectetur natus ipsum quidem assumenda. Earum.</p>
          <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Placeat quis reiciendis tenetur aperiam repellendus quo officiis! At debitis quis mollitia?</p>
          <div class="icons-container">
            <div class="icons">
              <i class="fas fa-shipping-fast"></i>
              <span>Giao hàng miễn phí</span>
            </div>
            <div class="icons">
              <i class="fas fa-dollar-sign"></i>
              <span>Thanh toán dễ dàng</span>
            </div>
            <div class="icons">
              <i class="fas fa-headset"></i>
              <span>Dịch vụ 24/7</span>
            </div>
          </div>
          <a href="#" class="btn">Tìm hiểu thêm</a>
        </div>
      </div>
    </section>

    <!-- menu section start -->

  


<section class="menu" id="menu">
    <h3 class="sub-heading">Menu của chúng tôi</h3>
    <h1 class="heading">Món ăn ngon hôm nay</h1>
    <div class="box-container">
        <%
            List<baitaplonWeb.product> products1 = Application["ProductList"] as List<baitaplonWeb.product>;
            foreach (baitaplonWeb.product ps in products1)
            {
        %>
        <div class="box">
            <div class="image">
                <a href="ProductDetail.aspx?id=<%=ps.Id%>"><img src="<%=ps.Image1%>" alt=""></a>
                <a href="#" class="fas fa-heart"></a>
            </div>
            <div class="content">
                <div class="start">
                    <i class="fas fa-star"></i>
                    <i class="fas fa-star"></i>
                    <i class="fas fa-star"></i>
                    <i class="fas fa-star"></i>
                    <i class="fas fa-star-half-alt"></i>
                </div>
                <h3><a href="ProductDetail.aspx?id=<%=ps.Id%>"><%=ps.Name %></a></h3>
                <p><%=ps.Description %></p>
                <button type="button" class="btn" 
                        data-id="<%=ps.Id%>" 
                        data-name="<%=ps.Name%>" 
                        data-price="<%=ps.Price%>" 
                        data-image="<%=ps.Image1%>" 
                        onclick="addToCart(this)">
                    Thêm vào giỏ hàng
                </button>
                <span class="price">$<%=ps.Price%></span>
            </div>
        </div>
        <%}%>
    </div>
</section>
<!-- footer section start -->

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

<script>
    function addToCart(button) {
        var id = button.getAttribute('data-id');
        var name = button.getAttribute('data-name');
        var price = button.getAttribute('data-price');
        var image = button.getAttribute('data-image');

        var xhr = new XMLHttpRequest();
        xhr.open('POST', 'Trangchu.aspx/AddToCart', true);
        xhr.setRequestHeader('Content-Type', 'application/json');
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
            id: id,
            name: name,
            price: price,
            image: image
        }));
    }
</script>

<script src="js/trangchu.js"></script>
<script src="https://cdn.jsdelivr.net/npm/swiper@11/swiper-bundle.min.js"></script>
  </body>
</html>

