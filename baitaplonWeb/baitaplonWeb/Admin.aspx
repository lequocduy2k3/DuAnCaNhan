<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="baitaplonWeb.Admin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Page</title>
    <style>
        /* Tổng thể */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
            padding-top: 40px;
        }

        /* Form chứa nội dung */
        form {
            max-width: 1200px;
            margin: 20px auto;
            padding: 20px;
            background-color: #fff;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
            border-radius: 8px;
        }

        /* Tiêu đề trang */
        h1 {
            font-size: 36px;
            color: #333;
            margin-bottom: 20px;
        }

        /* Đoạn văn thông tin */
        p {
            font-size: 22px;
            color: #666;
            margin-bottom: 20px;
        }

        /* Bảng quản lý người dùng */
        #gvUsers {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }

        #gvUsers th, #gvUsers td {
            border: 1px solid #ddd;
            padding: 10px;
            text-align: left;
        }

        #gvUsers th {
            background-color: #333;
            color: #fff;
        }

        #gvUsers tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        #gvUsers tr:hover {
            background-color: #f1f1f1;
        }

        /* Nút thêm tài khoản */
        #btnAddUser {
            display: inline-block;
            padding: 10px 20px;
            font-size: 20px;
            color: #fff;
            background-color: #333;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        #btnAddUser:hover {
            background-color: #555;
        }

        /* Các điều khiển nhập liệu */
        .form-control {
            display: block;
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ddd;
            border-radius: 5px;
        }

        /* Nút thêm tài khoản */
        .form-control-button {
            display: inline-block;
            padding: 10px 20px;
            font-size: 16px;
            color: #fff;
            background-color: #333;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .form-control-button:hover {
            background-color: #555;
        }

        /* Thông báo lỗi */
        #lblError {
            color: red;
            font-weight: bold;
        }
    </style>
    <link href="css/trangchu.css" rel="stylesheet" />
    <link
  rel="stylesheet"
  href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.2/css/all.min.css"/>

</head>
<body>
    <form id="form1" runat="server">
         <header>
  <a href="Trangchu.aspx" class="logo"><i class="fas fa-utensils"></i>Food.</a>
  <nav class="navbar">
    <a class="active" href="Trangchu.aspx">Trang chủ</a>
    <a href="Trangchu.aspx#dishes">Món ăn</a>
    <a href="Trangchu.aspx#about">Giới thiệu</a>
    <a href="Trangchu.aspx#menu">menu</a>
    <a href="Order.aspx">oder</a>
    <a id="log" href="login.aspx" runat="server">Đăng nhập/Đăng ký</a>
    <a id="adminLink" runat="server" href="admin.aspx" visible="false">Quản lý</a> <!-- Thẻ Admin -->
  </nav>
  <div class="icons">
    <i class="fas fa-bars" id="menu-bars"></i>
    <i class="fas fa-search" id="search-icon"></i>
    <a href="#" class="fas fa-heart"></a>
    <a href="Cart.aspx" class="fas fa-shopping-cart"></a>
  </div>
</header>
        <div>
            <h1>Admin Page</h1>
            <p>Số lượng người đang truy cập: <asp:Label ID="lblVisitorCount" runat="server" Text=""></asp:Label></p>
            <h2>Quản lý tài khoản</h2>
            <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" OnRowEditing="GvUsers_RowEditing" OnRowUpdating="GvUsers_RowUpdating" OnRowCancelingEdit="GvUsers_RowCancelingEdit" OnRowDeleting="GvUsers_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="Tên đăng nhập">
                        <ItemTemplate>
                            <asp:Label ID="lblUsername" runat="server" Text='<%# Bind("Username") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblUsername" runat="server" Text='<%# Bind("Username") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Text='<%# Bind("Email") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mật khẩu">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" Text='<%# Bind("Password") %>' TextMode="SingleLine"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Admin">
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkRole" runat="server" Checked='<%# Bind("Role") %>'></asp:CheckBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:TextBox ID="txtNewUsername" runat="server" CssClass="form-control" Placeholder="Tên đăng nhập" />
            <asp:TextBox ID="txtNewEmail" runat="server" CssClass="form-control" Placeholder="Email" />
            <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" TextMode="SingleLine" Placeholder="Mật khẩu" />
            <asp:CheckBox ID="chkNewRole" runat="server" Text="Admin" />
            <asp:Button ID="btnAddUser" runat="server" CssClass="form-control-button" Text="Thêm tài khoản" OnClick="BtnAddUser_Click" />
            <asp:Label ID="lblError" runat="server" />
        </div>
    </form>
    <script src="js/trangchu.js"></script>

</body>
</html>