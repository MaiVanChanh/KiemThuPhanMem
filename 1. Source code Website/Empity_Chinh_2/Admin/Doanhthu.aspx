<%@ Page Title="" Language="C#" MasterPageFile="~/Quantri.Master" AutoEventWireup="true" CodeBehind="Doanhthu.aspx.cs" Inherits="Empity_Chinh_2.Admin.Doanhthu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
		.auto-style1 {
			height: 26px;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="TongAdmin/CSs/ThongThe.css" rel="stylesheet" />
	<link href="JS/CSS/DoanhThu.css" rel="stylesheet" />
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <br />
    <br />
    <br />
	<fieldset>
		<legend><B>DOANH THU CỬA HÀNG</B></legend>
	</fieldset>
	
	 <table>
        <tr>
            <td class="auto-style1">
                 <asp:Label ID="Label1" runat="server" Text="Chọn ngày :"></asp:Label>
            </td>
           <td class="auto-style1">
			   <%--<dx:ASPxDateEdit ID="dateChonNgay" runat="server" CssClass="txtChonNgay"></dx:ASPxDateEdit>--%>
			   <asp:DropDownList ID="dateChonNgay" runat="server" Height="30px" Width="100px">
				   <asp:ListItem Value="0">Tất cả</asp:ListItem>
				   <asp:ListItem Value="1">Một tháng</asp:ListItem>
				   <asp:ListItem Value="2">Hôm nay</asp:ListItem>
			   </asp:DropDownList>
           </td>
			<td class="auto-style1">
				<asp:Button ID="btnTinh" runat="server" Text="Lọc" OnClick="btnTinh_Click" />
			</td>
            <td colspan="2" class="auto-style1">
                <asp:Label ID="Label2" runat="server" Text="Tổng doanh thu :"></asp:Label>
            </td>
           <td class="auto-style1">
               <asp:TextBox ID="txtTongDoanhThu" runat="server" CssClass="txtTongDoanhThu"></asp:TextBox>
           </td>
        </tr>
         <tr>
             <td>
                 <div>Chọn doanh thu :</div>
             </td>
             <td colspan="3">
                 <asp:DropDownList ID="drChonDoanhThu" runat="server" AutoPostBack="True" Height="30px" Width="236px" OnSelectedIndexChanged="drChonDoanhThu_SelectedIndexChanged">
                     <asp:ListItem Value="0">Doanh thu thực phẩm bổ sung</asp:ListItem>
                     <asp:ListItem Value="1">Doanh thu đăng ký bài tập</asp:ListItem>
                 </asp:DropDownList>
             </td>
         </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="btnXuat" runat="server" Text="Xuất doanh thu" OnClick="btnXuat_Click" />
				
				</td>
        </tr>
    </table>
    <br />
            	<br />
            
    <asp:GridView ID="dsThucPham" runat="server" AutoGenerateColumns="False" Width="1000px" AllowPaging="True" OnPageIndexChanging="dsThucPham_PageIndexChanging" CssClass="table table-striped table-bordered table-hover dataTable no-footer">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="Mã hóa đơn">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="MaKH" HeaderText="Mã khách hàng">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="TenThucPham" HeaderText="Tên thực phẩm bổ sung">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="SoLuong" DataFormatString="{0:N0}" HeaderText="Số lượng">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="Gia" DataFormatString="{0:N0}" HeaderText="Giá bán">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="TongTien" DataFormatString="{0:N0}" HeaderText="Tiền khách phải tra">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="NgayMua" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày lập hóa đơn">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
        <PagerStyle HorizontalAlign="Center" />
    </asp:GridView>		
    <asp:GridView ID="dsdkbt" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="dsdkbt_PageIndexChanging" Visible="False" Width="1000px" CssClass="table table-striped table-bordered table-hover dataTable no-footer">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="Mã hóa đơn">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="MaKH" HeaderText="Mã khách hàng">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="TenBT" HeaderText="Mã bài tập">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="TenBT" HeaderText="Tên bài tập">
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="NgayDangKy" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày đăng ký">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="NgayHetHan" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày hết hạn">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Gia" DataFormatString="{0:N0}" HeaderText="Giá đăng ký">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="TongTien" DataFormatString="{0:N0}" HeaderText="Tiền khách hàng phải trả">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
        </Columns>
        <PagerStyle HorizontalAlign="Center" />
    </asp:GridView>
    <br />
    <br />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
