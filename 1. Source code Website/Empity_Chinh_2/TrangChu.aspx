<%@ Page Title="" Language="C#" MasterPageFile="~/MasterNDung.Master" AutoEventWireup="true" CodeBehind="TrangChu.aspx.cs" Inherits="Empity_Chinh_2.TrangChu" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="chay_QC">
           <div class="chayquangcao">
   		 <div id="myCarousel" class="carousel slide border" data-ride="carousel">
                   <div class="carousel-inner">
                      <div class="carousel-item active">
                         <img class="d-block w-100" src="/image_nguoidung/TrangChu/bgr15_trangchu4.png" alt="Leopard"   />
                      </div>
                          <div class="carousel-item">
                             <img class="d-block w-100" src="/image_nguoidung/TrangChu/bgr16_trangchu4.png" alt="Cat"  />
                          </div>
                       <div class="carousel-item">
                             <img class="d-block w-100" src="/image_nguoidung/TrangChu/qc13.png" alt="Cat" />
                          </div>
                     </div>
                    
                   <div>
                   </div>
                           <a class="carousel-control-prev" href="#myCarousel" role="button" data-slide="prev">
                     <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                     <span class="sr-only">Previous</span>
                   </a>
                   <a class="carousel-control-next" href="#myCarousel" role="button" data-slide="next">
                     <span class="carousel-control-next-icon" aria-hidden="true"></span>
                     <span class="sr-only">Next</span>
                   </a>
                   </div>
              </div>
       </div>
    <link href="styleNguoiDung/BacGround.css" rel="stylesheet" />
           <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
          <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
          <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <!--kết thúc phần quảng cáo-->
    <link href="styleNguoiDung/CSS_TrangChu.css" rel="stylesheet" />
    <div class="body_trangchu">
        <div class="dsbt">
            <dx:ASPxDataView ID="ds" runat="server" OnItemCommand="ds_ItemCommand" AlwaysShowPager="True" OnLoad="ds_Load" AccessibilityCompliant="True" EnableScrolling="True" OnPageIndexChanging="ds_PageIndexChanging" OnInit="ds_Init" OnDataBound="ds_DataBound" Width="1200px">
                <SettingsTableLayout ColumnCount="4" RowsPerPage="1" />
<PagerSettings EnableAdaptivity="True">
    <Summary Text="Trang {0} của {1}" />
                </PagerSettings>
               
                <ItemTemplate>
                    <div class="phantrong">
                    <asp:Label CssClass="TenBaiTap" ID="Label2" runat="server" Text='<%# Eval("TenBaiTap") %>'></asp:Label>
                    <br />
                    <asp:Label ID="txtMA" runat="server" Text='<%# Eval("ID") %>' Visible="False"></asp:Label>
                    <br />
                    <asp:Image ID="Image1" runat="server" Height="240px" Width="200px" ImageUrl='<%# "~/image_nguoidung/AnhBaiTap/"+ Eval("HinhMinhHoa") %>' />
                    <br />
                    <b class="gia1">Giá: </b>
                    <asp:Label ID="Label3" CssClass="gia" runat="server" Text='<%# cNgay(Eval("Gia")) %>'></asp:Label> <u>đ</u>
                    <br />
                    <div class="phanThoiHan">
                    Thời hạn(Tháng):
                    <asp:Label ID="Label4" CssClass="thoihan" runat="server" Text='<%# Eval("ThoiHan") %>'></asp:Label>
                    </div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:ImageButton ID="btnXemThem" CssClass="xemthem" runat="server" Height="50px" OnClick="btnXemThem_Click" Width="115px" ImageUrl="image_nguoidung/AnhChucNang/dangky.gif" />
                </div>
                        </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </dx:ASPxDataView>

        </div>
        </div>
    <div>
    </div>
        <div class="chuyengia">
            <h1>Tập luyện cùng chuyên gia</h1>
            <div class="dsChuyenGia">
                <aside class="chuyengia">
                 <div class="chgia">  
                     <table class="ctCG" >
                    	<tr>
                        	<td rowspan="4" class="anhchinh"><img src="image_nguoidung/AnhChuyenGia/chuyen_gia1.png" width="200"  height="230"/></td>
                            <td>    <font color="#FF6666" size="+2"><b>NGUYỄN PHẠM THÁI DUY</b></font></td>
                        </tr>
                        <tr>
                        	<td><font size="+1.5"><b>PERSONAL TRAINER</b></font></td>
                        </tr>
                         <tr>
                             <td>Trưởng Bộ Phận Fitness</td>
                         </tr>
                        <tr>
                        	<td><font>Trên 10 năm kinh nghiệm
                                      &nbsp;đào tạo các VĐV&nbsp;
                                      Quốc Gia &amp; 
                                      Hội Viên thành công trong việc 
                                      chinh phục các mục tiêu hình thể.</font></td>
            
                        </tr>
                      
                       
                    </table>
                         <!--<img class="anh_chgia" src="image/qc1.png" width="250" height="250" />
                         <p class="ten_cg">Nguyễn Phạm Thái Duy</p>
                         <a href="Chi_tiet_san_pham - Culi.html"><img class="linh_vuc" src="../HTML/Chonmua.png" /></a> -->
                    </div>
                     <div class="chgia"> 
                         <table class="ctCG" >
                    	<tr>
                        	<td rowspan="4" class="anhchinh"><img src="image_nguoidung/AnhChuyenGia/chuyen_gia_phuc_1.png" width="200"  height="230"/></td>
                            <td>    <font color="#FF6666" size="+2"><b>JUMMY</b></font></td>
                        </tr>
                        <tr>
                        	<td><font size="+1.5"><b>DANCE</b></font></td>
                        </tr>
                         <tr>
                             <td>Trưởng Bộ Phận DANCE</td>
                         </tr>
                        <tr>
                        	<td ><font>-Nhiều năm kinh nghiệm trong việc giảng dạy, hỗ trợ Hội viên và đạt được bằng cấp 
                                quốc tế như chứng chỉ 200h Alliance International,...</font>
                        </tr>
                      
                       
                    </table>

                         <!--<img class="anh_chgia" src="image/chuyen_gia/chuyen_gia_phuc_1.png" width="200" height="230" />
                         <p class="ten_cg">Trần Tấn Phát</p>
                         <a href="Chi_tiet_san_pham - Culi.html"><img class="linh_vuc" src="../HTML/Chonmua.png" /></a> -->
                    </div>
                    <div class="chgia"> 
                         <table class="ctCG" >
                    	<tr>
                        	<td rowspan="4" class="anhchinh"><img src="image_nguoidung/AnhChuyenGia/Jim_my.png" width="200"  height="230" /></td>
                            <td>    <font color="#FF6666" size="+2"><b>NGUYỄN ĐÌNH BẢO</b></font></td>
                        </tr>
                        <tr>
                        	<td><font size="+1.5"><b>LesMills</b></font></td>
                        </tr>
                         <tr>
                             <td>Trưởng Bộ Môn&nbsp;LesMills&nbsp;</td>
                         </tr>
                        <tr>
                        	<td><font>-Nhiều năm kinh nghiệm trong việc truyền tải cảm hứng tập luyện đến Hội Viên và sở hữu các&nbsp;
                                chứng chỉ&nbsp;LesMills Quốc tế.</font>
                        </tr>
                      
                       
                    </table>

                         <!--<img class="anh_chgia" src="image/chuyen_gia/chuyen_gia_phuc_1.png" width="200" height="230" />
                         <p class="ten_cg">Trần Tấn Phát</p>
                         <a href="Chi_tiet_san_pham - Culi.html"><img class="linh_vuc" src="../HTML/Chonmua.png" /></a> -->
                    </div>
            </aside>
            </div>
             
    </div>
        <div class="phan_24h">
            <img src="image_nguoidung/AnhChucNang/mo_cua_24h.png" />  
            <div class="dkngay">
                <a href="DangKy/DangKy.aspx">
                    <img src="image_nguoidung/AnhChucNang/dang_ky_ngay.png" class="dkngay_2"/>
                </a>
            </div>
        </div>
</asp:Content>
