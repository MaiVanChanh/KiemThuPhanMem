<%@ Page Title="" Language="C#" MasterPageFile="~/MasterNDung.Master" AutoEventWireup="true" CodeBehind="DangKyBaiTap.aspx.cs" Inherits="Empity_Chinh_2.DangKyBaiTap" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="styleNguoiDung/CSS_DangKyBaiTap.css" rel="stylesheet" />
    <div class="than">
        <table>
            <tr>
                <td rowspan="5">
                    <div class="phuanh">
                    <asp:Image ID="upAnh" CssClass="anhbaitap" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <h1>&nbsp;<asp:Label ID="tenbaitap" runat="server" CssClass="tenbaitap" Text="Label"></asp:Label>
                    </h1>
                </td>
            </tr>


            <tr>
                <td>Thời hạn hết hạn(tháng):&nbsp;
                    <asp:Label ID="hethan" runat="server" Text="Label"></asp:Label>

                </td>
            </tr>
            <tr>
                <td>

                    <b>Giá:&nbsp;</b>

                    <asp:Label ID="gia" runat="server" Text="Label"></asp:Label> <u>đ</u>

                </td>
            </tr>
            <tr>
                <td>

                    <a><asp:Image ID="Image2" data-toggle="modal" data-target="#myModal" runat="server" style="cursor:pointer" Height="150px" ImageUrl="~/image_nguoidung/AnhChucNang/dangkyngay4.jfif" Width="210px" /></a>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div>
                       <b><i aria-grabbed="undefined">Chi tiết bài tập:</i></b> 
                    </div>

                  
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="txtChiTiet" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
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
                        
                        <h4 class="modal-title" >Thanh toán hóa đơn</h4>
                    </div>
                    <div class="modal-body">
                        <table>
                            <tr>
                                <td>
                                    <div>Tên bài tập :</div>
                                </td>
                                <td>
                                    <asp:Label ID="txtTenBTThanhToan" runat="server" Text="Label"></asp:Label>
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
                                    <asp:Label ID="txtGiaThanhTona" runat="server" Text="Label"></asp:Label> <u>đ</u>
                                    <%--<asp:TextBox ID="txtGiaThanhTona" CssClass="txt" runat="server"></asp:TextBox>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div>
                                        Thời hạn sử dụng (Tháng) :
                                    </div>

                                </td>
                                <td>
                                    <asp:Label ID="txtthoihan" runat="server" Text="Label"></asp:Label>
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
                                    <asp:Label ID="txtTongTienThanhToan" runat="server" Text="Label"></asp:Label> <u>đ</u>
                                </td>
                            </tr>

                        </table>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnLuu" runat="server" CssClass="btn btn-outline-danger" Text="Xác nhận" OnClick="btnLuu_Click" OnCommand="btnLuu_Command" />
                        <button type="button" class="btn btn-outline-dark" data-dismiss="modal">Thoát</button>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
