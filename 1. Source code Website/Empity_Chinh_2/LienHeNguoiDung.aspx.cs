using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Empity_Chinh_2
{
    public partial class LienHeNguoiDung : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btnGui_Click(object sender, EventArgs e)
        {
            if(txtsdt.Text!="" && txtNoiDung.Text!="" && txtHoTen.Text !="" &&    txtEmail.Text!="" && txtDiaChi.Text!="")
            {
                if (XLDL.KiemTraSo(txtsdt.Text) == true && XLDL.KiemTraGmail(txtEmail.Text.Trim()))
                {
                    int a = 0;
                    DateTime d = DateTime.Now;
                    string n = d.ToString("yyyy/MM/dd");
                    string sql = "insert into LienHe(TenKhachHang,SDT,Gmail,NoiDung,NgayLienHe) values (N'"+txtHoTen.Text.Trim()+"','"+txtsdt.Text+"','"+txtEmail.Text+"',N'"+txtNoiDung.Text.Trim()+"','"+n+"')";
                    XLDL.Excute(sql);

                }
                else
                {
                    Response.Write("<script> alert ('SDT phải là số và gmail phải đúng định dạng ') </script>");
                    //Response.Write("SDT phải là dô");

                }
            }
            else
            {

                Response.Write("<script> alert ('Phải đủ dữ liệu mới liên hệ được') </script>");
                //Response.Write("SDT phải là dô");
            }

        }
    }

}