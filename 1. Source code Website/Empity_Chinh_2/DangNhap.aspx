<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="Empity_Chinh_2.DangNhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <!-- Đăng nhập -->
       

    </title>
</head>
<body>
     
    <form id="form1" runat="server">
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <meta name="keywords" content="Space Login Form Responsive Widget,Login form widgets, Sign up Web forms , Login signup Responsive web form,Flat Pricing table,Flat Drop downs,Registration Forms,News letter Forms,Elements" />
        <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
        function hideURLbar(){ window.scrollTo(0,1); } </script>
        <!-- Đăng nhập tài khoản -->
        <link href="//fonts.googleapis.com/css?family=Montserrat:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i&amp;subset=latin-ext,vietnamese" rel="stylesheet"/>
        <link href="styleNguoiDung/CSS_DangNhap.css" rel="stylesheet" />
        <div class="main">
		<div class="main-w3l">
			<h1 class="logo-w3"><br/></h1>
			<div class="w3layouts-main">
				<h2><span>Thế Giới Cơ Bắp</span></h2>
				<div class="social">
					<a href="TrangChu.aspx">THE GYM</a>
				</div>
					<h3></h3>
					
                        <img src="image_nguoidung/DangNhap/user.png" class="anh_tk" />
                            <asp:TextBox ID="txtTaiKhoan" CssClass="email" placeholder="Nhập tên tài khoản..." required=""  runat="server"></asp:TextBox>
						<!--<input placeholder="Username or Email" name="Email" type="email" required="">-->
                           
                            <asp:TextBox ID="txtMatKhau" CssClass="password" placeholder="Nhập mật khẩu..." runat="server" required="" TextMode="Password"></asp:TextBox>
                            
						<!--<input placeholder="Password" name="Password" type="password" required="">-->
                            <asp:Button ID="btn_DangNhap" CssClass="login" runat="server" Text="Đăng nhập"  OnClick="btn_DangNhap_Click" />
						<!--<input type="submit" value="Get Started" name="login">-->
					
                    <!--<img src="image_nguoidung/DangNhap/lock.png" class="anh_mk" />-->
					<h6><a href="#">Bạn đã đăng ký tài khoản chưa?</a></h6>
			</div>
			<!-- //main -->
			
			<!--footer-->
			<div class="footer-w3l">
				<p>Các bạn đã biết gì cơ bắp chưa</p>
			</div>
			<!--//footer-->
		</div>
	</div>
    </form>
</body>
</html>
