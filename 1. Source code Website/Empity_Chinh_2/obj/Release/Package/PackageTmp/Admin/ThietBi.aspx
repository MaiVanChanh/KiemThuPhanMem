<%@ Page Title="" Language="C#" MasterPageFile="~/Quantri.Master" AutoEventWireup="true" CodeBehind="ThietBi.aspx.cs" Inherits="Empity_Chinh_2.Admin.ThietBi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <asp:GridView ID="GridView2" runat="server"></asp:GridView>
    <link href="TongAdmin/CSs/ThongThe.css" rel="stylesheet" />
	<fieldset>
		<legend><b><i>QUẢN TRỊ THIẾT BỊ</i></b></legend>
	</fieldset>
	<link href="JS/CSS/ThietBi.css" rel="stylesheet" />
	  <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Tìm Tên Thiết bị"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTimTenThietBi" runat="server" CssClass="txt"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnTimtenThietBi" runat="server" Text="Tìm" Width="80px" CssClass="btn2" OnClick="btnTimtenThietBi_Click" />
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Tìm mã thiết bị"></asp:Label>
            </td>
            <td>	
                <asp:TextBox ID="txtTimMaThietBi" runat="server" CssClass="txt"></asp:TextBox>
            </td>
            <td>
				<asp:Button ID="btnTimMaTB" runat="server" Text="Tìm" Width="80px" CssClass="btn2" OnClick="btnTimMaTB_Click"  />
				<%--<asp:Button  ID="btnTimMaTB" runat="server" Text="Tìm" Width="80px" CssClass="btn2" />--%>
            </td>
        </tr>
		  <tr>
			  <td colspan="2">
				   <button type="button" class="btn3"  data-toggle="modal" data-target="#myModal" >Thêm mới</button>
				  <%--<asp:Button ID="btnThemMoi" runat="server" Text="Thêm mới thiết bị" Width="150px" OnClick="btnThemMoi_Click" /></td>--%>
			
		  </tr>
		  <tr>
			  <td colspan="2">
				<asp:Button ID="btnXuatDS" runat="server" Text="Xuất danh sách" Width="150px" OnClick="btnXuatDS_Click" />
			</td>
		  </tr>		 
		  
    </table>
    <br />

	<asp:GridView ID="gr_chinh" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnRowCancelingEdit="gr_chinh_RowCancelingEdit" OnRowDataBound="gr_chinh_RowDataBound" OnRowDeleting="gr_chinh_RowDeleting" OnRowEditing="gr_chinh_RowEditing" OnRowUpdating="gr_chinh_RowUpdating" Width="1000px" DataKeyNames="ID" CssClass="table table-striped table-bordered table-hover dataTable no-footer">
		<Columns>
			<asp:BoundField DataField="ID" HeaderText="Mã thiết bị" ReadOnly="True">
			<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="Hình minh họa">
				<EditItemTemplate>
					<asp:Image ID="Image2" runat="server" ImageUrl='<%# "../image_nguoidung/ThietBiAdmin/" + Eval("HinhMinhHoa") %>' Height="150px" Width="150px" />
				</EditItemTemplate>
				<ItemTemplate>
					<asp:Image ID="Image1" runat="server" ImageUrl='<%# "../image_nguoidung/ThietBiAdmin/" + Eval("HinhMinhHoa") %>' Height="150px" Width="150px" />
				</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField DataField="TenThietBi" HeaderText="Tên thiết bị" ReadOnly="True" />
			<asp:BoundField DataField="Gia" DataFormatString="{0:N0}" HeaderText="Giá mua" ReadOnly="True" />
			<asp:TemplateField HeaderText="Tình trạng">
				<EditItemTemplate>
					<asp:DropDownList ID="drtinhTrang" runat="server" Height="30px" Width="100px">
						<asp:ListItem>Tốt</asp:ListItem>
						<asp:ListItem>Hư</asp:ListItem>
						<asp:ListItem>Cần bảo dưỡng</asp:ListItem>
					</asp:DropDownList>
				</EditItemTemplate>
				<ItemTemplate>
					<asp:Label ID="Label3" runat="server" Text='<%# Eval("TinhTrang") %>'></asp:Label>
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" />
			</asp:TemplateField>
			<asp:BoundField DataField="NgayMua" HeaderText="Ngày mua" ReadOnly="True" DataFormatString="{0:dd/MM/yyyy}">
			<ItemStyle HorizontalAlign="Right" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="Hướng dẫn sử dụng">
				<EditItemTemplate>
					<asp:TextBox ID="txtHD" runat="server" Text='<%# Eval("HuongDan") %>' TextMode="MultiLine"></asp:TextBox>
				</EditItemTemplate>
				<ItemTemplate>
					<asp:Label ID="Label4" runat="server" Text='<%# Eval("HuongDan") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:CommandField CancelText="Thoát" DeleteText="Xóa" EditText="Sửa" ShowDeleteButton="True" ShowEditButton="True" UpdateText="Lưu">
			<ControlStyle CssClass="btn btn-success" />
			<ItemStyle HorizontalAlign="Center" />
			</asp:CommandField>
		</Columns>
	    <EmptyDataTemplate>
            Không có dữ liệu cần tìm hoặc chưa có dữ liệu
        </EmptyDataTemplate>
	    <PagerStyle HorizontalAlign="Center" />
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
          <h4 class="modal-title">Thêm mới thiết bị</h4>
        </div>
        <div class="modal-body">
			<table>
				<tr>
					<td>
						<div>Tên thiết bị :</div>
					</td>
					<td>
						<asp:TextBox ID="txtTenTB" CssClass="txt" runat="server"></asp:TextBox>
						<%--<asp:TextBox ID="txtTenDANU" CssClass="txt" runat="server"></asp:TextBox>--%>						<%--<asp:ListBox ID="txtTenBT" CssClass="txt" runat="server"></asp:ListBox>--%>
					</td>
					<td rowspan="3">
						<%--<asp:Image ID="imAnh" runat="server" />		<%--<asp:Image ID="Image1" runat="server" Height="145px" Width="135px" />--
					</td>
				</tr>
				<tr>
					<td>
						<div>
							Hình minh họa :
						</div>
					</td>
					<td>
						<asp:FileUpload ID="upAnh" runat="server" />
						<%--<asp:FileUpload ID="upAnh" runat="server" OnLoad="upAnh_Load" />--%>						<%--<asp:FileUpload ID="upAnh"  runat="server" />--%>
					</td>
				</tr>
				<tr>
					<td>
						<div>
							Giá mua về :
						</div>
					</td>
					<td>
						<%--<asp:TextBox ID="txtGia" CssClass="txt" runat="server"></asp:TextBox>--%>
						<asp:TextBox ID="txtGia" CssClass="txt" runat="server"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<div>
							Hình minh họa :
						</div>
					</td>
					<td>
						<asp:FileUpload ID="upAnh"  runat="server" />
					</td>
				</tr>
				<tr>
					<td>
						<div>
							Tình trạng:
						</div>

					</td>
					<td>
						<asp:DropDownList ID="drTinhTrang" runat="server" Height="30px">
							<asp:ListItem>Tốt</asp:ListItem>
							<asp:ListItem>Hư</asp:ListItem>
							<asp:ListItem>Cần bảo dưỡng</asp:ListItem>
						</asp:DropDownList>
						<%--<asp:DropDownList ID="drloaiThucPham" runat="server"></asp:DropDownList>--%>
					</td>
				</tr>
				<tr>
					<td>
						<div>
							Hướng dẫn sử dụng :
						</div>
						
					</td>
					<td >
						<asp:TextBox ID="txtHD" CssClass="txt" runat="server" TextMode="MultiLine"></asp:TextBox>
						<%--<asp:TextBox ID="txtSoLuong" runat="server"></asp:TextBox>--%>							<%--<asp:TextBox ID="txtGhiChu" CssClass="txt" runat="server" Height="47px" TextMode="MultiLine" Width="213px"></asp:TextBox>--%>
					</td>
				</tr>
				
			</table>
        </div>
        <div class="modal-footer">
			<asp:Button ID="btnLuu" runat="server"  CssClass="btn btn-default" Text="Lưu" OnClick="btnLuu_Click" />
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
