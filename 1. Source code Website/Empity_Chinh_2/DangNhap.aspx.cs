using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Empity_Chinh_2
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IDNguoiSung"] != null)
                Session["IDNguoiSung"] = null;
          
        }
       
        protected void btn_DangNhap_Click(object sender, EventArgs e)
        {
            String tk = txtTaiKhoan.Text;
            String mk = txtMatKhau.Text;
            int bien1 = 0;
            String sql = "select ID,MaBoPhan from NguoiDung where TK='" + tk + "' and Pass='" + mk + "'";
            if (XLDL.kt(sql) == 1)
            {
                DataTable id = XLDL.GetData(sql);
                int x = int.Parse(id.Rows[0][0].ToString());
                int y = int.Parse(id.Rows[0][1].ToString());

                var mabophan = y;
                switch (mabophan)
                {   
                    case 0:

                        Session["IDNguoiDung"] = x;
                        Response.Redirect("~/TrangChu.aspx");
                        break;
                    default:
                    // Admin
                        Session["IDNguoiDung"] = x;
                        Response.Redirect("~/Admin/Doanhthu.aspx");
                        break;

                }

            }
            else
            {
                bien1 = 0;
                Response.Write("<script> alert ('Sai tài khoản hoặc mật khẩu') </script>");
            }
        }
    }
}