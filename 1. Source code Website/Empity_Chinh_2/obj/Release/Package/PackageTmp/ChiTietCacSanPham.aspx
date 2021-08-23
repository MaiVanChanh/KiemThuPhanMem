<%@ Page Title="" Language="C#" MasterPageFile="~/MasterNDung.Master" AutoEventWireup="true" CodeBehind="ChiTietCacSanPham.aspx.cs" Inherits="Empity_Chinh_2.ChiTietCacSanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
		.auto-style1 {
			height: 41px;
		}
	    .auto-style2 {
           
           height:285px;
           width:285px;
        }
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="styleNguoiDung/CSS_CTietSanPham.css" rel="stylesheet" />
    <div class="than">
        <div>
			<table>
				<tr>
					<td rowspan="8">
                        <div class="anhSSP">
						    <asp:Image ID="upAnh" CssClass="auto-style2" runat="server" />
                        </div>
					</td>
					
				</tr>
				<tr>
					<td colspan="2" class="tenCT">
						<b class="tenSP"><i>CHI TIẾT SẢN PHẨM</i> <asp:Label ID="txtMa" runat="server" Visible="False"></asp:Label></b>
					</td>
				</tr>
			
				<tr>
					<td>
						<div>
							Tên sản phẩm : <asp:Label ID="txtTen" CssClass="tenSP1" runat="server" Text="Label"></asp:Label>
						</div>
					</td>
					
				</tr>
				<tr>
					<td>
						<div>
							<b>Gias bán: </b> <asp:Label ID="txtGia" CssClass="giaSP" runat="server" Text="Label"> </asp:Label> <i> </i><u>đ</u>
						</div>
					</td>
					
				</tr>
				<tr>
					<td class="auto-style1">
						<div>
							Còn lại : <asp:Label ID="txtConLAi" runat="server" Text="Label"></asp:Label>
						</div>
						
					</td>
					
				</tr>
				<tr>
					<td>
						<div>
							Số lượng mua : <asp:DropDownList ID="drSoLuong" Width="100px" Height="30px" runat="server" AutoPostBack="True" Font-Size="15px"></asp:DropDownList>
						</div>
					</td>
					
				</tr>
				<tr>
					<td>
                        <asp:Image ID="Image2" data-toggle="modal" style="cursor:pointer" data-target="#myModal" runat="server"  Height="95px" ImageUrl="~/image_nguoidung/AnhChucNang/chon_mua_nn.gif" Width="230px" />
						<%--<asp:ImageButton ID="btnMua" runat="server" OnClick="btnMua_Click" Height="70" ImageUrl="" />--%>
					</td>
				</tr>
			</table>


        </div>
        <br />

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
                        
                        <h4 class="modal-title">Thanh toán hóa đơn</h4>
                    </div>
                    <div class="modal-body">
                        <table>
                            <tr>
                                <td>
                                    <div>Tên thực phẩm:</div>
                                </td>
                                <td>
                                    <b><asp:Label ID="txtTenTPBSThanhToan" runat="server" Text="Label"></asp:Label></b>
                                    <%--<asp:TextBox ID="txtTenBTThanhToan" CssClass="txt" runat="server"></asp:TextBox>--%>
                                    <%--<asp:ListBox ID="txtTenBT" CssClass="txt" runat="server"></asp:ListBox>--%>
                                </td>
                              
                            </tr>

                            <tr>
                                <td>
                                    <div>
                                        Giá hiện hành :
                                    </div>
                                </td>
                                <td>
                                    <asp:Label ID="txtGiaThanhTona" runat="server" Text="Label"></asp:Label>
                                    <%--<asp:TextBox ID="txtGiaThanhTona" CssClass="txt" runat="server"></asp:TextBox>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div>
                                        Số lượng :
                                    </div>

                                </td>
                                <td>
                                    <asp:Label ID="txtsoLuongThanhToan" runat="server" Text="Label"></asp:Label>
                                    <%--<asp:TextBox ID="txtGiaThanhToan" runat="server"></asp:TextBox>--%>
                                    <%--<asp:TextBox ID="txtGiaThanhToan" runat="server"></asp:TextBox>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div>
                                        Giảm giá (%) :
                                    </div>

                                </td>
                                <td >
                                    <asp:Label ID="txtGiamGiaThanhToan" runat="server" Text="Label"></asp:Label>
                                    <%--<asp:TextBox ID="txtGiamGiaThanhToan" CssClass="txt" runat="server" Height="47px" Width="213px"></asp:TextBox>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div>Tổng tiền :</div>
                                </td>
                                <td>
                                    <asp:Label ID="txtTongTienThanhToan" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>

                        </table>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnLuu" runat="server" CssClass="btn btn-outline-warning" Text="Xác nhận" OnClick="btnLuu_Click" />
                        <button type="button" class="btn btn-outline-dark" data-dismiss="modal">Thoát</button>
                    </div>
                </div>
            </div>

        </div>
       
    </div>
</asp:Content>
