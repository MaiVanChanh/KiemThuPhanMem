<%@ Page Title="" Language="C#" MasterPageFile="~/Quantri.Master" AutoEventWireup="true" CodeBehind="ThongTinLienHe.aspx.cs" Inherits="Empity_Chinh_2.Admin.ThongTinLienHe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
	<br />
	<br />
    <link href="TongAdmin/CSs/ThongThe.css" rel="stylesheet" />
    <link href="JS/CSS/LienHe.css" rel="stylesheet" />
	<fieldset>
		<legend>DANH SÁCH LIÊN HỆ</legend>
	</fieldset>
	<table>
		<tr>
			
			<td class="auto-style1">
				<div>
					<div>Lọc dạng ngày :</div>
				</div>
			</td>
			<td class="auto-style1">
				<asp:dropdownlist runat="server" ID="drlocNgay" AutoPostBack="True" OnSelectedIndexChanged="drlocNgay_SelectedIndexChanged">
                    <asp:ListItem>Tất cả</asp:ListItem>
                    <asp:ListItem>Hôm nay</asp:ListItem>
                    <asp:ListItem>Một năm</asp:ListItem>
                    <asp:ListItem>Một tháng</asp:ListItem>
                </asp:dropdownlist>
			</td>
			<td class="auto-style1">
				<div> </div>
			</td>
			<td class="auto-style1">
				&nbsp;</td>
		</tr>
        <tr>
            <td>
				<div>
					<div></div>
				</div>
			</td>
			<td>
				&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnXuat" runat="server" Text="Xuất danh sách liên hệ" OnClick="btnXuat_Click" />
            </td>
            
        </tr>
	</table>
    <br />


    

    <asp:GridView ID="gr" runat="server" AutoGenerateColumns="False" Width="1000px" OnRowCommand="gr_RowCommand" CssClass="table table-striped table-bordered table-hover dataTable no-footer" DataKeyNames="ID" OnSelectedIndexChanging="gr_SelectedIndexChanging" AllowPaging="True" OnDataBound="gr_DataBound" OnPageIndexChanging="gr_PageIndexChanging" OnRowCancelingEdit="gr_RowCancelingEdit" OnRowDataBound="gr_RowDataBound" OnRowDeleting="gr_RowDeleting" OnRowEditing="gr_RowEditing">
        <Columns>
            <asp:BoundField HeaderText="Mã liên hệ" DataField="ID">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Tên khách hàng" DataField="TenKhachHang" />
            <asp:BoundField HeaderText="SDT" DataField="SDT" >
            <ControlStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Gmail" DataField="Gmail" />
            <asp:TemplateField HeaderText="Ngày liên hệ">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# cd(Eval("NgayLienHe")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Nội dung" DataField="NoiDung" >
            <ControlStyle CssClass="nd" />
            </asp:BoundField>
            <asp:CommandField CancelText="Thoát" DeleteText="Xóa" ShowDeleteButton="True" />
        </Columns>
        <EmptyDataTemplate>
            Chưa có dữ liệu
        </EmptyDataTemplate>
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
			
        </div>
        <div class="modal-footer">
			<asp:Button ID="btnLuu" runat="server"  CssClass="btn btn-default" Text="Lưu" />
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
