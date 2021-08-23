using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Empity_Chinh_2
{
    public partial class MasterNDung : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            
            
            if (Session["IDNguoiDung"]!=null)
            {
                dangnhap.Visible = false;
                anhdangnhap.Visible = false;
                dangky.Visible =false;
                int id = int.Parse(Session["IDNguoiDung"].ToString());
                String sql = "select Tk from NguoiDung where ID="+id+"";
                DataTable tb = XLDL.GetData(sql);
                String k = "Tài khoản: "+tb.Rows[0][0].ToString();
                hientennguoidung.Text =k;
                hientennguoidung.Visible = true;                              
             }
            else
            {
                Dangxuat.Visible = false;
                hientennguoidung.Visible = false;           
            }
        }

        protected void Dangxuat_Click(object sender, EventArgs e)
        {
            Session["IDNguoiDung"] = null;
            dangnhap.Visible = false;
            dangky.Visible = false;
            Dangxuat.Visible = true;
            anhdangnhap.Visible = false;
            Response.Redirect("TrangChu.aspx");
        }

        protected void HoaDon_Click(object sender, EventArgs e)
        {

            if (Session["IDNguoiDung"] != null)
            {
                Response.Redirect("~/HoaDon.aspx");
            }
            else
            {
                Response.Write("<script> alert ('Chưa đăng nhập tài khoản!') </script>");
            }
        }

        protected void dangky_DataBinding(object sender, EventArgs e)
        {
            Response.Redirect("~/DangKy/DangKy.aspx");
        }

        protected void thongtinCN_Click(object sender, EventArgs e)
        {
            if (Session["IDNguoiDung"] != null)
            {
                Response.Redirect("~/CapNhatThongTin.aspx");
            }
            else
            {
                Response.Write("<script> alert ('Chưa đăng nhập tài khoản!') </script>");
            }
        }
    }
}