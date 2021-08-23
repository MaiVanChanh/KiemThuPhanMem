<%@ Page Title="" Language="C#" MasterPageFile="~/MasterNDung.Master" AutoEventWireup="true" CodeBehind="ThucPhamBoSung.aspx.cs" Inherits="Empity_Chinh_2.ThucPhamBoSung" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="styleNguoiDung/CSS_TPBoSung.css" rel="stylesheet" />
        <div id="navbar">
           <div class="serch">
            <h3> <img src="image_nguoidung/AnhChucNang/menu.png" class="bagach" height="34" width="40" /> DANH MỤC SẢN PHẨM </h3>
            
            <div class="cl">
                <asp:DropDownList ID="cbb_dahmuc" CssClass="cbDanhMuc" runat="server" OnLoad="cbb_dahmuc_Load" OnDataBound="cbb_dahmuc_DataBound" OnSelectedIndexChanged="cbb_dahmuc_SelectedIndexChanged" AutoPostBack="True">
               </asp:DropDownList>   
                <asp:TextBox ID="txt_TimSanPham" CssClass="TxtTimSanPham" runat="server" placeholder=" Tìm sản phẩm, loại, tên mong muốn,...." OnTextChanged="txt_TimSanPham_TextChanged" ></asp:TextBox>
               <asp:Button ID="btn_tim" CssClass="btntim" runat="server" Text="" OnClick="btn_tim_Click" />          
            </div>
            </div>
        </div>
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
    
    <div class="thuphambusung">
       
        <div class="listThucPham">
            <dx:ASPxDataView ID="dsThuPham" runat="server" BackColor="White" Font-Size="Large" ForeColor="Maroon" Width="1200px" OnItemCommand="dsThuPham_ItemCommand">
                <SettingsTableLayout ColumnCount="4" RowsPerPage="4" />
<PagerSettings ShowNumericButtons="False">
    <Summary EmptyText="Dữ liệu không có" Text="Trang {0} của {1}" />
                </PagerSettings>
                <ItemTemplate>
                    <asp:Image ID="AnhSanPam" runat="server" Height="160px" ImageUrl='<%# "../image_nguoidung/AnhSanPham/" +Eval("HinhMinhHoa") %>' Width="150px" />
                    <br /><br />
                    <b><asp:Label ID="TenTP" CssClass="tenSP" runat="server" Text='<%# Eval("TenThucPham") %>'></asp:Label></b>
                    <br />
                    <asp:Label ID="LoaiTP" runat="server" Text='<%# cd(Eval("MaLoaiThucPham")) %>'></asp:Label>
                    <br />
                    Số lượng:
                    <asp:Label ID="SoLuong" CssClass="sl_CSDL" runat="server" Text='<%# Eval("SoLuong") %>'></asp:Label>
                    <br />
                    <b>Giá:</b>
                    <asp:Label ID="DonGia" CssClass="giaSP" runat="server" Text='<%# ct(Eval("Gia")) %>'></asp:Label><b> <u> đ</u></b>
                    <br />
                    <asp:ImageButton ID="ImageButton1" CssClass="anh_chon_mua" runat="server" Height="50px" ImageUrl="~/image_nguoidung/AnhChucNang/chon_mua_nn.gif" OnClick="ImageButton1_Click" Width="130px" />
                    <br />
                    <asp:Label ID="IDSP" runat="server" Enabled="False" Text='<%# Eval("ID") %>' Visible="False"></asp:Label>
                </ItemTemplate>
                <ItemStyle BackColor="White" HorizontalAlign="Center" />
                <EmptyDataTemplate>
                    <asp:Label ID="Label1" runat="server" Text="Dữ liệu không có"></asp:Label>
                </EmptyDataTemplate>
            </dx:ASPxDataView>
        </div>
        <div>
        </div>
        <br />
          
    </div>

</asp:Content>
