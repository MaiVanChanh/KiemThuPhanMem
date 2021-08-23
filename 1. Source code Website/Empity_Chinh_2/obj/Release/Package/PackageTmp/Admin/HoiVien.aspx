<%@ Page Title="" Language="C#" MasterPageFile="~/QuanTri.Master" AutoEventWireup="true" CodeBehind="HoiVien.aspx.cs" Inherits="Empity_Chinh_2.Admin.HoiVien" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
	<link href="JS/CSS/HoiVienAdmin.css" rel="stylesheet" />
    <link href="TongAdmin/CSs/ThongThe.css" rel="stylesheet" />
	<br />
	<fieldset>
		<legend><B>QUẢN LÝ HỘI VIÊN</B></legend>
	</fieldset>
     <article>
            <section>			
                <br />  
                <table>
                    <tr>
                        <td >
                            <div>Chọn ngày : </div>
                        </td>
                        <td>

							<dx:ASPxDateEdit ID="drChonNgay" runat="server" OnButtonClick="drChonNgay_ButtonClick"></dx:ASPxDateEdit>
                        </td>
                        <td>
							<asp:Button ID="btnLocNgay" CssClass="btn2" runat="server" Text="Lọc" OnClick="btnLocNgay_Click" />
							<%--<dx:ASPxButton ID="btnLocNgay" runat="server" Text="Lọc" CssClass="btnHV" Width="80px" OnClick="btnLocNgay_Click"></dx:ASPxButton>--%><%-- <asp:Button ID="btnLuotKhachDK" runat="server" Text="Lọc" Height="24px" Width="51px" OnClick="btnLuotKhachDK_Click" />
                        --%>
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Tìm Tên KH :"></asp:Label>
                        </td>
                        <td>
							<asp:TextBox ID="txtTenKH" CssClass="txt" runat="server"></asp:TextBox>
							<%--<asp:TextBox ID="txtTenKH" runat="server" CssClass="txt"></asp:TextBox>--%>
                        </td>
                        <td>
							<asp:Button ID="btnTenKH" CssClass="btn2" runat="server" Text="Lọc" OnClick="btnTenKH_Click" />
							<%--<dx:ASPxButton ID="btnTenKH" runat="server" Text="Tìm" CssClass="btnHV" Width="80px" OnClick="btnTenKH_Click"></dx:ASPxButton>--%>
                        </td>
                        <td>
                            <div>Lượt  khách đăng kí :</div>
                        </td>
                        <td>
							<asp:DropDownList ID="drLuotKhachDK" CssClass="dr" runat="server">
								<asp:ListItem>Tất cả</asp:ListItem>
								<asp:ListItem>Một tháng</asp:ListItem>
								<asp:ListItem>Một ngày</asp:ListItem>
							</asp:DropDownList>
							<%-- <asp:DropDownList ID="drLuotKhachDK" runat="server" Height="23px" Width="161px">
                                <asp:ListItem>Một ngày</asp:ListItem>
                                <asp:ListItem>Một tháng</asp:ListItem>
                            </asp:DropDownList>--%>
                        </td>
                        <td>
							<asp:Button ID="btnLKDK" runat="server" Text="Lọc" OnClick="btnLKDK_Click" />
							<%--<dx:ASPxButton ID="btnLKDK" runat="server" Text="Lọc" CssClass="btnHV" Width="80px"></dx:ASPxButton>--%>
                                <%-- <asp:Button ID="btnLuotKhachDK" runat="server" Text="Lọc" Height="24px" Width="51px" OnClick="btnLuotKhachDK_Click" />
                        --%></td>
                    </tr>
                    <tr>
                        <td><div> Loại Khách hàng :</div>

                        </td>
                        <td>
							<asp:DropDownList ID="drChonLoaiKhachHang" CssClass="dr" runat="server">
								<asp:ListItem>Tất cả</asp:ListItem>
								<asp:ListItem>Đồng</asp:ListItem>
								<asp:ListItem>Bạc</asp:ListItem>
								<asp:ListItem>Vàng</asp:ListItem>
								<asp:ListItem>Bạc Kim</asp:ListItem>
							</asp:DropDownList>
							<%-- <asp:DropDownList ID="drChonLoaiKhachHang" runat="server" Height="22px" Width="163px">
                                <asp:ListItem>Đồng</asp:ListItem>
                                <asp:ListItem>Bạc</asp:ListItem>
                                <asp:ListItem>Vàng</asp:ListItem>
                                <asp:ListItem>Bạch Kim</asp:ListItem>
                                <asp:ListItem>Kim Cương</asp:ListItem>
                            </asp:DropDownList>--%>
                        </td>
                        <td>
							<asp:Button ID="btnChonLoaiKH" CssClass="btn2" runat="server" Text="Lọc" OnClick="btnChonLoaiKH_Click" />
							<%--<dx:ASPxButton ID="btnChonLoaiKH" runat="server" Text="Lọc" CssClass="btnHV" Width="80px" OnClick="btnChonLoaiKH_Click"></dx:ASPxButton>--%><%-- <asp:Button ID="btnLuotKhachDK" runat="server" Text="Lọc" Height="24px" Width="51px" OnClick="btnLuotKhachDK_Click" />
                        --%>     </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Tìm Mã KH :"></asp:Label>
                        </td>
                        <td>
							<asp:TextBox ID="txtMaKH" CssClass="txt" runat="server"></asp:TextBox>
							<%--<asp:TextBox ID="txtMaKH" runat="server" CssClass="txt"></asp:TextBox>--%>
                        </td>
                        <td>
							<asp:Button ID="btnMaKH" CssClass="btn2" runat="server" Text="Lọc" OnClick="btnMaKH_Click" />
							<%--<dx:ASPxButton ID="btnMaKH" runat="server" Text="Tìm" Width="80px" CssClass="btnHV" OnClick="btnMaKH_Click"></dx:ASPxButton>--%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
							<asp:Button ID="btnXuatDanhSachKH" runat="server" CssClass="db" Text="Xuất danh sách" OnClick="btnXuatDanhSachKH_Click" />
							<%--<asp:Button ID="btnXuatDanhSachKH" CssClass="btnHV" runat="server" Text="xuất danh sách khách hàng" BackColor="#F1D5D5" Height="31px" OnClick="btnXuatDanhSachKH_Click" />--%>
                        </td>
                    </tr>

                </table>
				<br />
                
            </section>     
        </article>
	<asp:GridView ID="grDSKhachHang" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ID" Width="1000px" CssClass="table table-striped table-bordered table-hover dataTable no-footer" OnPageIndexChanging="grDSKhachHang_PageIndexChanging" OnRowDataBound="grDSKhachHang_RowDataBound" OnRowDeleting="grDSKhachHang_RowDeleting">
		<Columns>
			<asp:BoundField DataField="ID" HeaderText="Mã hội viên">
			<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="Hình đại diện">
				<ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="120px" ImageUrl='<%# "../image_nguoidung/AnhDaiDien/"+Eval("HinhMinhHoa") %>' Width="120px" />
                </ItemTemplate>
				<ItemStyle HorizontalAlign="Center" />
			</asp:TemplateField>
			<asp:BoundField DataField="TenNguoiDung" HeaderText="Tên hội viên" />
			<asp:BoundField DataField="TenLoai" HeaderText="Loại hội viên" />
			<asp:BoundField DataField="TK" HeaderText="Tài khoản">
			<ItemStyle BorderStyle="None" HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:BoundField DataField="Pass" HeaderText="Mật khẩu" />
			<asp:BoundField DataField="DiemTichLuy" DataFormatString="{0:N0}" HeaderText="Điểm tích lũy">
			<ItemStyle HorizontalAlign="Right" />
			</asp:BoundField>
			<asp:BoundField DataField="SDT" HeaderText="Số điện thoại">
			<ItemStyle HorizontalAlign="Right" />
			</asp:BoundField>
			<asp:BoundField DataField="Gmail" HeaderText="Gmail" />
			<asp:CommandField CancelText="Thoát" DeleteText="Xóa" HeaderText="Chức năng" ShowDeleteButton="True" UpdateText="Lưu">
			<ControlStyle CssClass="btn btn-success" />
			<ItemStyle HorizontalAlign="Center" />
			</asp:CommandField>
		</Columns>
		<EmptyDataTemplate>
			<asp:Label ID="Label3" runat="server" Text="Dữ liệu không có "></asp:Label>
		</EmptyDataTemplate>
	    <PagerStyle HorizontalAlign="Center" />
	</asp:GridView>
       <br />
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	
</asp:Content>
