<%@ Page Title="" Language="C#" MasterPageFile="~/MasterNDung.Master" AutoEventWireup="true" CodeBehind="LienHeNguoiDung.aspx.cs" Inherits="Empity_Chinh_2.LienHeNguoiDung" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

	

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script lang="javascript">
	function KiemTraThongTin()
	{
		var sdt=document.getElementById("sdt");
		if(isNaN(sdt.value)==true){
				alert("sdt  phải là số!!!");
				sdt.value="";
				sdt.focus();
				return false;
			}
			else

				return true;
		
			
	}
</script>
	<link href="styleNguoiDung/LienHeNguoiDung.css" rel="stylesheet" />
	<div id="than">
    	<article>
        	<section>
            	<div class="trangchu"><a href="TrangChu.aspx">Trang Chủ</a> >Liên hệ</div>
                <br />
                <div class="noidung">
                    <img src="image_nguoidung/anh_header.png"" class="anhnen"/>
                    <div class="ttlh1"><font size="+1.5" color="#FF0000"><b><u>THÔNG TIN LIÊN HỆ</u></b></font></div>
                    <img class="ttlh" src="image_nguoidung/ttlh.png"" />
                </div>
          
            </section>
            <aside id="benphai" >
           	 <div class="ndbenphai">
            	<div class="lhct"><b><i><t><u>LIÊN HỆ CHO CHÚNG TÔI</u></t></i></b></div>
            
            	<table class="lh" >
                	<tr >
                    	<td >
							<asp:TextBox ID="txtHoTen" CssClass="txt" placeholder="Họ và tên"  runat="server"></asp:TextBox>
							<%--<input type="text" name="họ và tên"  placeholder="Họ và tên"  size="27"/>--%>

                    	</td>
                        <td>
							<%--<input type="text" placeholder="Địa chỉ"size="27" />--%>
							<asp:TextBox ID="txtDiaChi" CssClass="txt" placeholder="Địa chỉ" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr >
                    	<td>
							<%--<input type="text" placeholder="Số điện thoại"size="27" id="sdt"/>--%>
							<asp:TextBox ID="txtsdt" placeholder="Số điện thoại" CssClass="txt" runat="server"></asp:TextBox>
                    	</td>
                        <td>
							<%--<input type="text"placeholder="Email"size="27" />--%>
							<asp:TextBox placeholder="Email" title="Emali ko hop le" TextMode="Email" CssClass="txt" ID="txtEmail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
						<td colspan="2">
							<asp:TextBox ID="txtNoiDung" placeholder="Nội dung liên hệ" CssClass="nd" runat="server" TextMode="MultiLine"></asp:TextBox>
						</td>
                    </tr>
                    
                </table>
					
                <%--<textarea class="nd" placeholder="Nội dung"  width="10" cols="62" ></textarea>--%>
                <div align="center">
					<asp:Button ID="btnGui" CssClass="btn2" runat="server"  Text="Gửi" OnClick="btnGui_Click"  />
					<%--<input type="submit" value="Gửi đi" class="gui" onclick="return KiemTraThongTin()"  />--%>
					<%--<input type="submit" value="Nhập lại" class="gui"  /></div>--%>
					<asp:Button ID="btnThoa" CssClass="btn2" runat="server" Text="Nhập lại" />
            	 </div>
            </aside>
        </article>
        </div>

</asp:Content>
