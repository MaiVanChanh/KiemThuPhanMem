<%@ Page Title="" Language="C#" MasterPageFile="~/QuanTri.Master" AutoEventWireup="true" CodeBehind="ThucPhamBoSung.aspx.cs" Inherits="Empity_Chinh_2.Admin.ThucPhamBoSung" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
	<br />
	<br />
	<link href="JS/CSS/DoAnNuocUong.css" rel="stylesheet" />
    <link href="TongAdmin/CSs/ThongThe.css" rel="stylesheet" />
	<fieldset>
		<legend><B>QUẢN LÝ THỰC PHẨM BỔ SUNG</B></legend>
	</fieldset>
	 <table  >
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Tìm Nhóm Thực Phẩm:" Width="110px"></asp:Label>
                </td>
                <td>
                     <asp:DropDownList ID="drNhomThucPham" runat="server" CssClass="txt" Height="27px" Width="131px">
                        <asp:ListItem Value="1">Nước uống</asp:ListItem>
                       <asp:ListItem Value="2">Sữa</asp:ListItem>
                       <asp:ListItem Value="3">Đồ ăn</asp:ListItem>
                       <asp:ListItem Value="4">Chất bổ sung</asp:ListItem>
                     	<asp:ListItem Value="5">Tất cả</asp:ListItem>
                     </asp:DropDownList>
                   
                </td>
                <td>
                    <asp:Button ID="btnTimNhomThucPham" runat="server" Text="Tìm" CssClass="btn2" Width="80px" OnClick="btnTimNhomThucPham_Click" />
                    
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Tên Thục Phẩm :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNhapTenThucPhamTim" runat="server" CssClass="txt"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnTimTenThucPham" runat="server" Text="Tìm" CssClass="btn2" Width="80px" OnClick="btnTimTenThucPham_Click"/>
                </td>
                </tr>
            <tr>

            
                <td>
                     <asp:Label ID="Label5" runat="server" Text="Mã thực Phẩm :"></asp:Label>
                    
                </td>
                <td>
                     <asp:TextBox ID="txtTimMaThucPham" runat="server" CssClass="txt"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btntimMaThucPham" runat="server" Text="Tìm " Width="80px" CssClass="btn2" OnClick="btntimMaThucPham_Click" />
                </td>
            </tr>
		 <tr>
			 <td colspan="2">
				 <button type="button" class="btn3"  data-toggle="modal" data-target="#myModal" >Thêm mới</button>
			 </td>
			
		 </tr>
		 
            </table>
    <br />

	<asp:GridView ID="gr" runat="server" AutoGenerateColumns="False" AllowPaging="True" Height="192px" OnPageIndexChanging="gr_PageIndexChanging" Width="1000px" DataKeyNames="ID" OnRowDataBound="gr_RowDataBound" OnRowDeleting="gr_RowDeleting" OnRowEditing="gr_RowEditing" OnRowUpdating="gr_RowUpdating" CssClass="table table-striped table-bordered table-hover dataTable no-footer" OnRowCancelingEdit="gr_RowCancelingEdit">
		<Columns>
			<asp:BoundField DataField="ID" HeaderText="Mã thực phẩm" ReadOnly="True">
			<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="Hình minh họa">
                <EditItemTemplate>
                    <asp:Image ID="Image2" runat="server" Height="150px" ImageUrl='<%# "../image_nguoidung/AnhSanPham/" + Eval("HinhMinhHoa") %>' Width="150px" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl='<%# "../image_nguoidung/AnhSanPham/" + Eval("HinhMinhHoa") %>' Width="150px" />
                </ItemTemplate>
            </asp:TemplateField>
			<asp:BoundField DataField="TenThucPham" HeaderText="Tên thực phẩm" ReadOnly="True" />
			<asp:BoundField DataField="Gia" DataFormatString="{0:N0}" HeaderText="Giá bán">
			<ItemStyle HorizontalAlign="Right" />
			</asp:BoundField>
			<asp:BoundField DataField="SoLuong" DataFormatString="{0:N0}" HeaderText="Số lượng" ReadOnly="True">
			<ItemStyle HorizontalAlign="Right" />
			</asp:BoundField>
			<asp:BoundField DataField="Daban" DataFormatString="{0:N0}" HeaderText="Đã bán">
			<ItemStyle HorizontalAlign="Right" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="Loại thực phẩm">
				<EditItemTemplate>
					<asp:Label ID="Label11" runat="server" Text='<%# cd(Eval("MaLoaiThucPham")) %>'></asp:Label>
				</EditItemTemplate>
				<ItemTemplate>
					<asp:Label ID="Label9" runat="server" Text='<%# cd(Eval("MaLoaiThucPham")) %>'></asp:Label>
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" />
			</asp:TemplateField>
			<asp:CommandField CancelText="Thoát" DeleteText="Xóa" EditText="Sửa" ShowDeleteButton="True" ShowEditButton="True" UpdateText="Lưu">
			<ControlStyle CssClass="btn btn-success" />
			<ItemStyle HorizontalAlign="Center" />
			</asp:CommandField>
		</Columns>
		<EmptyDataTemplate>
            Không có dữ liệu cần tìm hoặc chưa có dữ liệu
        </EmptyDataTemplate>
		<PagerSettings FirstPageText="Trang  &amp;lt;Trang &amp;lt;" LastPageText="&amp;gt;Trang  &amp;gt;" NextPageText="Trang  &amp;gt;" PreviousPageText="'Trang'  &amp;lt;Trang " />
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
          <h4 class="modal-title"><b><i>Thêm mới Thực phẩm bổ sung</i></b></h4>
        </div>
        <div class="modal-body">
			<table>
				<tr>
					<td>
						<div>Tên thực phẩm bổ sung :</div>
					</td>
					<td>
						<asp:TextBox ID="txtTenDANU" CssClass="txt" runat="server"></asp:TextBox>
						<%--<asp:ListBox ID="txtTenBT" CssClass="txt" runat="server"></asp:ListBox>--%>
					</td>
					<td rowspan="4">

						<%--<asp:Image ID="Image1" runat="server" Height="145px" Width="135px" />--%>
					</td>
				</tr>
				<tr>
					<td>
						<div>
							Hình minh họa :
						</div>
					</td>
					<td>
						<asp:FileUpload ID="upAnh" runat="server" OnLoad="upAnh_Load" />
						<%--<asp:FileUpload ID="upAnh"  runat="server" />--%>
					</td>
				</tr>
				<tr>
					<td>
						<div>
							Giá hiện hành :
						</div>
					</td>
					<td>
						<asp:TextBox ID="txtGia" CssClass="txt" runat="server"></asp:TextBox>
						
					</td>
				</tr>
				<tr>
					<td>
						<div>
							Loại thực phẩm:
						</div>

					</td>
					<td>
						<asp:DropDownList ID="drloaiThucPham" runat="server">
							<asp:ListItem>Nước uống</asp:ListItem>
							<asp:ListItem>Sữa</asp:ListItem>
							<asp:ListItem>Đồ ăn</asp:ListItem>
							<asp:ListItem>Chất bổ sung</asp:ListItem>
						</asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td>
						<div>
							Số lượng :
						</div>
						
					</td>
					<td >
						<asp:TextBox ID="txtSoLuong" runat="server"></asp:TextBox>
							<%--<asp:TextBox ID="txtGhiChu" CssClass="txt" runat="server" Height="47px" TextMode="MultiLine" Width="213px"></asp:TextBox>--%>
					</td>
				</tr>
				
			</table>
        </div>
        <div class="modal-footer">
			<asp:Button ID="btnLuu" runat="server"  CssClass="btn btn-default" Text="Lưu" OnClick="btnLuu_Click" />
          <button type="button" class="btn btn-default" data-dismiss="modal">Thoát</button>
        </div>
      </div>
         <br />
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
