<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangKy.aspx.cs" Inherits="Empity_Chinh_2.DangKy.DangKy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <!-- fonts -->
<link href="//fonts.googleapis.com/css?family=Raleway:100,200,300,400,500,600,700,800,900" rel="stylesheet"/>
<link href="//fonts.googleapis.com/css?family=Monoton" rel="stylesheet"/>
<!-- /fonts -->
<!-- css -->

    <link href="css/style.css" rel="stylesheet" />
</head>
    <body>
        <form id="form1" runat="server">
            <add key="PageInspector:ServerCodeMappingSupport" value="Disabled" />
        <h1 class="w3ls">Đăng ký trở thành thành viên</h1>
<div class="content-w3ls">
	<div class="content-agile1">
		<h2 class="agileits1" >Phòng Gym</h2>
		<p class="agileits2">Mời bạn về với đội của chùng tôi.</p>
	</div>
	<div class="content-agile2">
		<form action="#" method="post">
			<div class="form-control w3layouts"> 
                
				<%--<input type="text" id="firstname" name="firstname" placeholder="Họ và tên" title="Please enter your First Name" required>--%>
                <asp:TextBox ID="firstname" CssClass="firstname" placeholder="Họ và tên...." runat="server"></asp:TextBox>
			</div>

			<div class="form-control w3layouts">
                <asp:TextBox TextMode="Email" ID="email" CssClass="firstname" runat="server" placeholder="Gmail.com" ></asp:TextBox>
				<%--<input type="email" id="email" name="email" placeholder="Gmail.com" title="Please enter a valid email" required>--%>
			</div>

			<div class="form-control agileinfo">	
                <asp:TextBox ID="password1" runat="server" CssClass="firstname" placeholder="Mật khẩu" TextMode="Password"></asp:TextBox>
				<%--<input type="password" class="lock" name="password" placeholder="Mật khẩu" id="password1" required>--%>
			</div>	

			<div class="form-control agileinfo">	
                <asp:TextBox placeholder="Xác nhận mật khẩu" ID="password2" runat="server" CssClass="firstname"></asp:TextBox>
				<%--<input type="password" class="lock" name="confirm-password" placeholder="Xác nhận mật khẩu" id="password2" required>--%>
			</div>	
           
            <asp:Button ID="btnDangKy" CssClass="register" runat="server" Text="Xác nhận đăng ký" OnClick="btnDangKy_Click2" />
            <%--<asp:Button class="register" ID="btnDangKy" runat="server" Text=" Đăng ký" OnClick="btnDangKy_Click1" />--%>
            <%--<asp:Button class="register" ID="btnDangKy" runat="server" Text=" Đăng ký" OnClick="btnDangKy_Click"  />--%>
			<%--<input type="submit" class="register" value="Đăng ký">--%>
		</form>
		<ul class="social-agileinfo wthree2">
			<li><a href="#"><i class="fa fa-facebook"></i></a></li>
			<li><a href="#"><i class="fa fa-youtube"></i></a></li>
			<li><a href="#"><i class="fa fa-twitter"></i></a></li>
			<li><a href="#"><i class="fa fa-google-plus"></i></a></li>
		</ul>
	</div>
	<div class="clear"></div>
</div>

    
    </form>
</body>
</html>
