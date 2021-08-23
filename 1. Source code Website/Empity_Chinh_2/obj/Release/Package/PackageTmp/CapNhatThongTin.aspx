<%@ Page Title="" Language="C#" MasterPageFile="~/MasterNDung.Master" AutoEventWireup="true" CodeBehind="CapNhatThongTin.aspx.cs" Inherits="Empity_Chinh_2.CapNhatThongTin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="styleNguoiDung/CSS_CapNhatThongTin.css" rel="stylesheet" />
    <div class="nd_KH">
        <article>
            <section>
                <div class="nd_right">
                    <p class="ten_kh"> Chào mừng 
                        <asp:Label ID="ten" runat="server" Text="Label"></asp:Label></p>
                    <fieldset class="bang_thong_tin">
                        <legend class="TTCB">Thông tin cơ bản </legend>
                        <table>
                            <tr>
                                <td>Họ và tên:  </td>
                                <td>
                                    <asp:TextBox ID="txtHoVaTen" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Giới tính: </td>
                                <td >
                                    <asp:RadioButtonList ID="gioitinh" runat="server" RepeatColumns="2">
                                        <asp:ListItem Value="1">Nam</asp:ListItem>
                                        <asp:ListItem Value="0">Nữ</asp:ListItem>
                                    </asp:RadioButtonList>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>Tuổi:</td>
                                <td >
                                    <asp:TextBox ID="txt2" runat="server" TextMode="Number"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 35px">Địa chi: </td>
                                <td style="height: 35px"><asp:TextBox ID="txtDiaChi" runat="server" placeholder="Nhập địa chỉ...." TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Số điện thoại: </td>
                                <td>
                                    <asp:TextBox ID="txtSDT" runat="server" TextMode="Phone" placeholder="Nhập số điện thoại...." MaxLength="10"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Gmail: </td>
                                <td><asp:TextBox ID="txtGmail" runat="server" TextMode="Email" placeholder="Nhập gmail...."></asp:TextBox></td>
                            </tr>
                        </table>
                           
                    </fieldset>
                    <div class="anh_tk">
                        <div class="anh_NGuoiDung">
                            <asp:Image ID="upanh" runat="server" Width="175" Height="200" />
                        </div>
                        <div class="nut_lenh_anh">
                            <asp:Label ID="chonanh" runat="server" CssClass="btn btn-outline-warning" data-toggle="modal" ForeColor="Black" data-target="#myModal"><b>Chọn ảnh từ máy</b></asp:Label>
                            
                            </div>
                        </div>
                    </div>
                    <img src="image_nguoidung/AnhChucNang/cay_but.gif" class="anh_cay_but" />
                <div>
                    <fieldset>
                        <legend>Thông tin tài khoản</legend>
                        <table>
                            <tr>
                                <td>Tên đăng nhập: </td>
                                <td><asp:TextBox ID="txtTaiKhoan" runat="server" ></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Mật khẩu: </td>
                                <td><asp:TextBox ID="txtMatKhau" runat="server"></asp:TextBox> </td>
                            </tr>
                            <tr>
                                <td >
                                    <asp:Label ID="TenLoaiKhachHangHoacBoPhan" runat="server" Text="Loại khách hàng:"></asp:Label> </td>
                                <td>
                                    <asp:Label ID="txtLoaiKhachHang" runat="server" Text="Khách hàng CSDL"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="NgayDangKyHoacLuong" runat="server" Text="Ngày đăng ký:"></asp:Label> </td>
                                <td>
                                    <asp:Label ID="txtNgayDangKy" runat="server" Text="Ngày đăng ký CSDL"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    <asp:Label ID="DiemTichLuyHoacLuong" runat="server" Text="Điểm tích lũy:"></asp:Label>
                                        </td>
                                <td>
                                    <asp:Label ID="txtDiemTichLuy" runat="server" Text="Điểm tích lũy CSDL"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                
            </section>
            
            <aside>
                 <div>
                    <p class="khuyen_dung">Khuyên dùng</p>
                    <p class="gc_thich"></p>
                <div class="right-khuyen_dung">
                    <img src="image_nguoidung/AnhMasterPage/khuyen_dung.png" width="270" height="400" class="ah_khuyen_dung"/>
                </div>
                <p class="ban_thich">Liên kết</p>
                <p class="gc_thich"></p>
            </div>        
                <div class="lk_trang">
                    <a href="http://www.thehinh.com/"><br />thehinh.com</a>
                    <a href="https://www.thenewgym.vn/vi"><br />thenewgame.com</a>
                    <a href="http://www.fit24.vn/"><br />fit24.vn</a>
                    <a href="https://citigym.com.vn/#"><br />citigym.com</a>
                </div>
            </aside>
      </article>

        
    <div>
        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        ...
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>
    </div>
    

        
    <div>


<!-- The Modal -->
<div class="modal" id="myModal">
  <div class="modal-dialog">
    <div class="modal-content">

      <!-- Modal Header -->
      <div class="modal-header">
        <h4 class="modal-title">Chọn ảnh người dùng</h4>
        <button type="button" class="close" data-dismiss="modal">&times;</button>
      </div>

      <!-- Modal body -->
      <div class="modal-body">
        Mời bạn chọn ảnh từ máy cảu bạn...

          <asp:FileUpload ID="loadanh" runat="server" />
      </div>

      <!-- Modal footer -->
      <div class="modal-footer">
          <asp:Button ID="btnLuuAnh" CssClass="btn btn-danger" runat="server" Text="Lưu ảnh" OnClick="Button1_Click" />
        <button type="button" class="btn btn-danger" data-dismiss="modal">&times;Thoát</button>
      </div>

    </div>
  </div>
</div>
        <div>
            <div>
        <div id="myNav" class="overlay">
  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
  <div class="overlay-content">
    <div>
        
    </div>
  </div>
</div>
            </div>
    
<script>
function openNav() {
    document.getElementById("myNav").style.height = "100%";
}

function closeNav() {
  document.getElementById("myNav").style.height = "0%";
}
</script>
        </div>

    </div>
    <div class="nutlenhcuoi">
        <asp:Button ID="btnluuToanBo" CssClass="btn btn-outline-success" runat="server" Text="Lưu thông tin" OnClick="btnluuToanBo_Click" />
        <asp:Button ID="btnSuaToanBo" CssClass="btn btn-outline-danger" runat="server" Text="Sữa thông tin" OnClick="btnSuaToanBo_Click" />
        <br />
        <asp:Button ID="btnQuanLai"  CssClass="btn btn-outline-danger" runat="server" Text="Quay lại quản trị" OnClick="btnQuanLai_Click" Visible="False" />
    </div> 
        <br />
</asp:Content>
