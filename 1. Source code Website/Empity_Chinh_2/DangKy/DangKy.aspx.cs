using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Empity_Chinh_2.DangKy
{
    public partial class DangKy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { //do something 
                email.Text = password1.Text = "";
                
            }

            //    if (!IsPostBack)
            //{
            //    
            //}
            //else

        }
        public Boolean KiemTraTaiKhoan(string tk)
        {
            string sql = "select TK from NguoiDung where TK='" + tk + "'";
            if (XLDL.kt(sql) == 0)
                return true;
            else
                return false;
        }
        protected void btnDangKy_Click(object sender, EventArgs e)
        {
          
        }

        protected void btnDangKy_Click1(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterClientScriptResource(Items.ui);
           
        }

        protected void btnDangKy_Click2(object sender, EventArgs e)
        {
            if(password1.Text==password2.Text)
            {
                DateTime date;
                date = DateTime.Now.Date;
                string tk = firstname.Text.Trim() + "";

                if (firstname.Text.Trim() != "" && email.Text.Trim() != "" && password2.Text.Trim() != "")
                {
                    if (KiemTraTaiKhoan(tk) == true)
                    {
                        string sql = "insert into NguoiDung (TK,Gmail,Pass,NgayDangKy) values ('" + firstname.Text.Trim() + "" + "','" + email.Text.Trim() + "','" + password1.Text.Trim() + "" + "','" + date.ToString("yyyy/MM/dd") + "')";
                        XLDL.Excute(sql);
                        Response.Write("<script>alert ('Bạn đã đăng ký thành công'); </script>");
                        Response.Redirect("~/DangNhap.aspx");
                    }

                    else
                        Response.Write("<script>alert ('Tên tài khoản đã tồn tại'); </script>");
                }
                else
                    Response.Write("<script>alert ('Chưa đủ dữ liệu để thêm mới'); </script>");

            }
            else
            {
                Response.Write("<script>alert ('Mật khẩu không trùng khớp'); </script>");
            }
 
                


        }
    }
}