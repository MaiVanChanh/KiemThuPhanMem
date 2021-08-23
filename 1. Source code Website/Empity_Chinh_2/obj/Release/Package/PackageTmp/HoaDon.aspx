<%@ Page Title="" Language="C#" MasterPageFile="~/MasterNDung.Master" AutoEventWireup="true" CodeBehind="HoaDon.aspx.cs" Inherits="Empity_Chinh_2.HoaDon" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="styleNguoiDung/CSS_HoaDon.css" rel="stylesheet" />
    <div class="bodyHD">
         <div id="navbar">
        <div class="lep">
            
            <img src="image_nguoidung/AnhChucNang/menu2.png" class="anhmenu" />
            <asp:DropDownList ID="menuHD" CssClass="dsHD" runat="server" AutoPostBack="True" Font-Bold="True" OnSelectedIndexChanged="menuHD_SelectedIndexChanged">
                <asp:ListItem Value="1">Tất cả</asp:ListItem>
                <asp:ListItem Value="2">Hóa đơn đăng ký bài tập</asp:ListItem>
                <asp:ListItem Value="3">Hóa đơn mua sản phẩm</asp:ListItem>
            </asp:DropDownList>
            <div class="ptimkiem">
                    <b><asp:Label ID="Label2" CssClass="lb2" runat="server" Text="Tìm theo ngày: "></asp:Label></b>
                    <dx:ASPxDateEdit ID="ngay1" CssClass="ngay" runat="server"></dx:ASPxDateEdit>
                    <!--<asp:TextBox ID="ngay" CssClass="ngay" runat="server" TextMode="Date" ValidateRequestMode="Disabled" ClientIDMode="Inherit" Height="40px"></asp:TextBox>-->
                    <asp:ImageButton ID="timTheoNgay" CssClass="TtheoNgay" runat="server" ImageUrl="~/image_nguoidung/AnhChucNang/tim3.png" OnClick="timTheoNgay_Click" />
             </div> 
        </div>
             </div>
       </div>
    
        <!--////////////////////////-->
             <!--phan dè nhau-->
            <script>
            window.onscroll = function() {myFunction()};

            var navbar = document.getElementById("navbar");
            var sticky = navbar.offsetTop;

            function myFunction() {
              if (window.pageYOffset >= sticky) {
                navbar.classList.add("sticky")
              } else {
                navbar.classList.remove("sticky");
              }
            }
            </script>
    
    <!--kết thúc phan dè nhau-->
        <!--///////////////////////-->
    <div class="gachchan"></div>
        <div class="dsBT"><b><asp:Label ID="dsBT" CssClass="lol_1" runat="server" Text="Danh sách hóa đơn đăng ký bài tập"></asp:Label></b></div>
        <div class="gchan1"></div>
        <div class="dulieu">
            
            <asp:GridView ID="dsDangkyBaiTap" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="1200px" AllowPaging="True" OnPageIndexChanging="dsDangkyBaiTap_PageIndexChanging" OnSelectedIndexChanging="dsDangkyBaiTap_SelectedIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Mã hóa đơn" />
                    <asp:BoundField DataField="TenBaiTap" HeaderText="Tên bài tập đăng ký" />
                    <asp:BoundField DataField="Gia" DataFormatString="{0:N0}" HeaderText="Giá bài tập">
                    <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NgayDangKy" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày đăng ký" />
                    <asp:BoundField DataField="NgayHetHan" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày hết hạn" />
                    <asp:BoundField DataField="TongTien" DataFormatString="{0:N0}" HeaderText="Giá phải thanh toán" />
                </Columns>
                <EmptyDataTemplate>
                    Không có dữ liệu cần tìm
                </EmptyDataTemplate>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>

        </div>
        <div class="dsBT">
            <b><asp:Label ID="dsTPBS" CssClass="lol_1" runat="server" Text="Danh sách hóa đơn mua sản thực phẩm bổ sung"></asp:Label></b>
        </div>
        <div class="gchan2"></div>
        <div class="dulieu">
        
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="1200px" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Mã hóa đơn" />
                    <asp:TemplateField HeaderText="Ảnh sản phẩm">
                        <EditItemTemplate>
                            <asp:Image ID="Image1" runat="server" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="Image2" runat="server" Height="100px" ImageUrl='<%# "image_nguoidung/AnhSanPham/" +Eval("HinhMinhHoa") %>' Width="150px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TenThucPham" HeaderText="Tên sản phẩm" />
                    <asp:BoundField DataField="Gia" DataFormatString="{0:N0}" HeaderText="Giá sản phẩm" />
                    <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" DataFormatString="{0:N0}" >
                    <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TraTien" DataFormatString="{0:N0}" HeaderText="Giá phải thanh toán" >
                    <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NgayMua" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày mua" />
                </Columns>
                <EmptyDataTemplate>
                    Không có dữ liệu cần tìm
                </EmptyDataTemplate>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerSettings LastPageText="&amp;gt  ;&amp;gt;" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        </div>
    
    <br /><br />
    
</asp:Content>
