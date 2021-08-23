<%@ Page Title="" Language="C#" MasterPageFile="~/QuanTri.Master" AutoEventWireup="true" CodeBehind="DSBT.aspx.cs" Inherits="Empity_Chinh_2.Admin.DSBT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
	<br />
	<br />
	<link href="JS/CSS/DanhSachBaiTapAmin.css" rel="stylesheet" />
	<fieldset>
		<legend><B>QUẢN LÝ DANH SÁCH CÁC BÀI TẬP</B></legend>
	</fieldset>
	<table>
		<tr>
			<td>
				<div>Tìm mã BT :</div>
			</td>
			<td >
				<div class="input-group custom-search-form">
					<asp:TextBox ID="txttMaBT" CssClass="form-control" runat="server"></asp:TextBox>
					<%--<asp:TextBox ID="txttMaBT" CssClass="form-control" runat="server"></asp:TextBox>--%>
					 <span class="input-group-btn">
						 <asp:Button ID="btnTimMaBt" CssClass="btn btn-primary" runat="server" Text="Tìm" OnClick="btnTimMaBt_Click" />
					<%--<asp:Button ID="btnTimMaBt" CssClass="btn btn-primary" runat="server" Text="Tìm" />--%>
					 </span>
				 </div>
			</td>
			<td>
				<div>TìmTìm tên bài tập :</div>
			</td>
			<td>
				<div class="input-group custom-search-form">
					<asp:TextBox ID="txtTimTenBt" CssClass="form-control" runat="server"></asp:TextBox>
					<%--<asp:TextBox ID="txtTimTenBt" CssClass="form-control" runat="server"></asp:TextBox>--%>
					 <span class="input-group-btn">
						 <asp:Button ID="btnTimtenBT" CssClass="btn btn-primary" runat="server" Text="Tìm" OnClick="btnTimtenBT_Click" />
					<%--<asp:Button ID="btnTimtenBT" CssClass="btn btn-primary" runat="server" Text="Tìm" />--%>
					 </span>
				 </div>
			</td>
		</tr>
		<tr>
			<td >
				 <button type="button" class="btn3"  data-toggle="modal" data-target="#myModal" >Thêm mới</button>

			</td>
			<td>
				&nbsp;</td>
		</tr>
	</table>
	<br />
    <div class="nenTable">
        <link href="TongAdmin/CSs/ThongThe.css" rel="stylesheet" />     
	<asp:GridView ID="grDS" runat="server" AutoGenerateColumns="False" Width="1000px" AllowPaging="True" DataKeyNames="ID" OnRowCancelingEdit="grDS_RowCancelingEdit" OnRowDataBound="grDS_RowDataBound" OnRowDeleting="grDS_RowDeleting" OnRowEditing="grDS_RowEditing" OnRowUpdating="grDS_RowUpdating" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnPageIndexChanging="grDS_PageIndexChanging" GridLines="Vertical">
		<AlternatingRowStyle BackColor="#DCDCDC" />
		<Columns>
			<asp:BoundField DataField="ID" HeaderText="Mã bài tập" ReadOnly="True">
			<ItemStyle HorizontalAlign="Center" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="Hình minh họa">
				<EditItemTemplate>
					<asp:Image ID="Image2" runat="server" ImageUrl='<%# "~/image_nguoidung/AnhBaiTap/" +Eval("HinhMinhHoa") %>' Height="150px" Width="150px" />
				</EditItemTemplate>
				<ItemTemplate>
					<asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/image_nguoidung/AnhBaiTap/" +Eval("HinhMinhHoa") %>' Height="150px" Width="150px" />
				</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField DataField="TenBaiTap" HeaderText="Tên bài tập" ReadOnly="True" />
			<asp:BoundField DataField="GhiChu" HeaderText="Ghi chú" />
			<asp:BoundField DataField="Gia" DataFormatString="{0:N0}" HeaderText="Giá">
			<ItemStyle HorizontalAlign="Right" />
			</asp:BoundField>
			<asp:TemplateField HeaderText="Thời hạn (tháng)">
				<EditItemTemplate>
					<asp:DropDownList ID="drChonThoiHan" runat="server" Height="16px" SelectedValue='<%# Eval("ThoiHan") %>' Width="126px">
						<asp:ListItem>2</asp:ListItem>
						<asp:ListItem>3</asp:ListItem>
						<asp:ListItem>4</asp:ListItem>
					</asp:DropDownList>
				</EditItemTemplate>
				<ItemTemplate>
					<asp:Label ID="Label1" runat="server" Text='<%# Eval("ThoiHan") %>'></asp:Label>
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" />
			</asp:TemplateField>
			<asp:CommandField CancelText="Thoát" DeleteText="Xóa" EditText="Sửa" HeaderText="Chức năng" ShowDeleteButton="True" ShowEditButton="True" UpdateText="Lưu">
			<ControlStyle CssClass="btn btn-success" />
			<ItemStyle HorizontalAlign="Center" />
			</asp:CommandField>
		</Columns>
		<FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
		<PagerSettings FirstPageText="Trang &amp;lt; Trang  &amp;lt;" LastPageText="của &amp;gt; trang&amp;gt;" NextPageText="Trang &amp;gt;" PreviousPageText="Trang &amp;lt;" />
		<PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
	</asp:GridView>

</div>
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
						<div>Tên bài tập :</div>
					</td>
					<td>
						<asp:TextBox ID="txtTenBT" CssClass="txt" runat="server"></asp:TextBox>
						<%--<asp:ListBox ID="txtTenBT" CssClass="txt" runat="server"></asp:ListBox>--%>
					</td>
					<td rowspan="4">
						&nbsp;</td>
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
							Thời hạn sử dụng :
						</div>

					</td>
					<td>
						<asp:DropDownList ID="drThoiHan" runat="server" Height="30px" Width="100px">
							<asp:ListItem>2</asp:ListItem>
							<asp:ListItem>3</asp:ListItem>
							<asp:ListItem>4</asp:ListItem>
							<asp:ListItem>5</asp:ListItem>
						</asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td>
						<div>
							Ghi chú :
						</div>
						
					</td>
					<td colspan="2">
							<asp:TextBox ID="txtGhiChu" CssClass="txt" runat="server" Height="47px" TextMode="MultiLine" Width="213px"></asp:TextBox>
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
