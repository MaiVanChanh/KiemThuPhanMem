<%@ Page Title="" Language="C#" MasterPageFile="~/Quantri.Master" AutoEventWireup="true" CodeBehind="NhanVien.aspx.cs" Inherits="Empity_Chinh_2.Admin.NhanVien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
		<br />
		<br />
	<link href="JS/CSS/NhanVien.css" rel="stylesheet" />
	<fieldset>
		

		<legend>
			<b>DANH SÁCH NHÂN VIÊN</b>
		</legend>
	</fieldset>
	<table class="TimNV">
		<tr>
			<td>
				<asp:label runat="server" text="Tìm Mã NV:" Width="90px"></asp:label>
			</td>
			<td>
				<div class="input-group custom-search-form">
					<asp:TextBox ID="txttmanv" CssClass="form-control" runat="server"></asp:TextBox>
					 <span class="input-group-btn">
						 <asp:Button ID="btntimMNV" CssClass="btn btn-primary" runat="server" Text="Tìm" OnClick="btntimMNV_Click" />
						<%--<asp:Button ID="btntimMNV" CssClass="btn btn-primary"  runat="server" Text="Tìm" OnClick="btntimMNV_Click" />--%>
					 </span>
				 </div>
			</td>
			
			<td>
				<asp:Label ID="Label2" runat="server" Text="Tên Nhân Viên:" Width="120px"></asp:Label>
				<%--<dx:ASPxLabel ID="t" runat="server" Text="Nhập Tên Nhân Viên:" Width="120px" ></dx:ASPxLabel>--%>
			</td>
			<td>
				<div class="input-group custom-search-form">
			<asp:TextBox ID="txtttennv" CssClass="form-control" runat="server"></asp:TextBox>
				 <span class="input-group-btn">
						<asp:Button ID="btntTenNV" CssClass="btn btn-primary"  runat="server" Text="Tìm" OnClick="btntTenNV_Click" />
                  </span>
            </div>
			 </td>
			
			<td>
				<asp:Label ID="Label1" runat="server" Text="Tìm bộ phận :" Width="89px"></asp:Label>
				<%--<dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Tìm Mã Bộ Phận:" Width="100px"></dx:ASPxLabel>--%>
			</td>
			<td>
                <asp:DropDownList ID="drTimBoPhan" runat="server" Width="150px" Height="40px" AutoPostBack="True" OnSelectedIndexChanged="drTimBoPhan_SelectedIndexChanged"></asp:DropDownList>
			</td>

		</tr>
		
		<tr>
			<td colspan="2"><b>
				 <button type="button" class="btn3"  data-toggle="modal" data-target="#myModal" >Thêm mới</button>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Button ID="btntataCa" runat="server" Text="Hiện tất cả" OnClick="btntataCa_Click" Width="200px" /></td>
		
		</tr>
		<tr>
			<td colspan="6">
				<asp:Button ID="btnXuat" runat="server" Text="Xuất danh sách nhân viên" CssClass="btn3" OnClick="btnXuat_Click" Width="200px" /></td>
		</tr>
	</table>
    <br />
    <br />
    <link href="TongAdmin/CSs/ThongThe.css" rel="stylesheet" />
	<asp:GridView ID="grDS" runat="server" AllowPaging="True" AutoGenerateColumns="False" Height="229px" OnDataBound="grDS_DataBound" OnRowCancelingEdit="grDS_RowCancelingEdit" OnRowDataBound="grDS_RowDataBound" OnRowDeleting="grDS_RowDeleting" OnRowEditing="grDS_RowEditing" OnRowUpdating="grDS_RowUpdating" Width="1090px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
		<AlternatingRowStyle BackColor="#DCDCDC" />
		<Columns>
			<asp:BoundField DataField="ID" HeaderText="Mã NV" ReadOnly="True">
			<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="Hình đại diện">
				<EditItemTemplate>
					<asp:Image ID="Image2" runat="server" ImageUrl='<%# "../image_nguoidung/AnhDaiDien/"+Eval("HinhMinhHoa") %>' Height="120px" Width="120px" />
				</EditItemTemplate>
				<ItemTemplate>
					<asp:Image ID="Image1" runat="server" ImageUrl='<%# "../image_nguoidung/AnhDaiDien/"+Eval("HinhMinhHoa") %>' Height="120px" Width="120px" />
				</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField DataField="TenNguoiDung" HeaderText="Họ Tên" ReadOnly="True">
			<ItemStyle HorizontalAlign="Left" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="Giới tính">
				<EditItemTemplate>
					<asp:Label ID="Label4" runat="server" Text='<%# cd(Eval("GioiTinh")) %>'></asp:Label>
				</EditItemTemplate>
				<ItemTemplate>
					<asp:Label ID="Label3" runat="server" Text='<%# cd(Eval("GioiTinh")) %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Bộ phận làm">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="80px">
                        <asp:ListItem>Hướng dẫn viên</asp:ListItem>
                        <asp:ListItem>Kế toán</asp:ListItem>
                        <asp:ListItem>Bảo vệ</asp:ListItem>
                        <asp:ListItem>Bảo trì thiết bị</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("TenBoPhan") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
			<asp:BoundField DataField="Tuoi" HeaderText="Tuổi" ReadOnly="True">
			<ItemStyle HorizontalAlign="Right" />
			</asp:BoundField>
			<asp:BoundField DataField="SDT" HeaderText="SDT" ReadOnly="True" />
			<asp:BoundField DataField="Gmail" HeaderText="Gmail" ReadOnly="True" />
			<asp:BoundField DataField="LuongCoban" DataFormatString="{0:N0}" HeaderText="Lương" ReadOnly="True">
			<ItemStyle HorizontalAlign="Right" />
			</asp:BoundField>
			<asp:BoundField DataField="NgayDangKy" HeaderText="Ngày đăng ký" ReadOnly="True" DataFormatString="{0:dd/MM/yyyy}" />
			<asp:CommandField CancelText="Thoát" DeleteText="Xóa" EditText="Sửa" ShowDeleteButton="True" ShowEditButton="True" UpdateText="Lưu">
			<ControlStyle CssClass="btn btn-success" />
			<ItemStyle HorizontalAlign="Center" />
			</asp:CommandField>
		</Columns>
		<EmptyDataTemplate>
            Không có dữ liệu cần tìm hoặc chưa có
        </EmptyDataTemplate>
		<FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
		<PagerSettings FirstPageText="Trang &amp;lt;&amp;lt;" LastPageText="Trang &amp;gt;&amp;gt;" />
		<PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
		</asp:GridView>

	
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
	 <div class="container">

  <%--<button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>--%>

  <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title"><b><i>THÊM MỚI NHÂN VIÊN</i></b></h4>
        </div>
        <div class="modal-body" >
			<table >
			<tr>
				<td>
					<div>Tên nhân viên :</div>
				</td>
				<td>
					<asp:TextBox ID="txtTenNV" CssClass="txt" runat="server"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<div>Giới tính :</div>
				</td>
				<td>
					<asp:DropDownList ID="drGioiTinh" runat="server" Height="30px" Width="100px">
					<asp:ListItem Value="1">Nam</asp:ListItem>
					<asp:ListItem Value="0">Nữ</asp:ListItem>
					</asp:DropDownList>
					<%--<asp:DropDownList ID="drGioiTinh" runat="server" Height="30px" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="drGioiTinh_SelectedIndexChanged">
						<asp:ListItem Value="1">Nam</asp:ListItem>
						<asp:ListItem Value="0">Nữ</asp:ListItem>
					</asp:DropDownList>--%>
				</td>
			</tr>
			<tr>
				<td>
					<div>Tên tài khoản đăng nhập :</div>
				</td>
				<td>
					<asp:TextBox ID="txtTenTK" CssClass="txt" runat="server"></asp:TextBox>
				</td>
				</tr>
			<tr>
				<td>
					<div>
						Mật khẩu đăng nhập :
					</div>
				</td>
				<td>
					<asp:TextBox CssClass="txt" ID="txtPass" runat="server"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<div>
						Chọn bộ phận làm việc :
					</div>
				</td>
				<td>
					<asp:DropDownList ID="drBoPhan" runat="server" Height="30px" Width="100px" OnSelectedIndexChanged="drBoPhan_SelectedIndexChanged"></asp:DropDownList>
				</td>
				</tr>
			
			<%--<tr>
				<td>
					<asp:Button ID="Button1" runat="server" CssClass="btn2" OnClick="btnThem_Click" Text="Lưu dữ liệu" Width="100px" />
				</td>
				<td>
					<asp:Button ID="btnThoat" runat="server" CssClass="btn2" OnClick="btnThoat_Click" Text="Thoát" Width="100px" />
				</td>
			</tr>--%>
		</table>
        </div>
        <div class="modal-footer">
			<asp:Button ID="btnLuu" runat="server" CssClass="btn btn-default" Text="Lưu" OnClick="btnLuu_Click" />
			<%--<asp:Button ID="btnLuu" runat="server"  CssClass="btn btn-default" Text="Lưu" OnClick="btnLuu_Click" />--%>
          <button type="button" class="btn btn-default" data-dismiss="modal">Thoát</button>
        </div>
      </div>
      
    </div>
  </div>
  
</div>
	
	   <br />
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
