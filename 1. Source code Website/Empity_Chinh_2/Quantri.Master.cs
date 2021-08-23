using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace Empity_Chinh_2
{
    public partial class Quantri : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadChao();
            }
        }
        public void loadChao()
        {
            int ma = int.Parse(Session["IDNguoiDung"].ToString());
            string sql = "select TK from NguoiDung where ID =" + ma + "";
            DataTable tb = XLDL.GetData(sql);
            string ten = tb.Rows[0][0].ToString();
            txtChaoTaiKhoan.Text = ten;
        }
        protected void btnDX_Click(object sender, EventArgs e)
        {
            if(Session["IDNguoiDung"] != null)
            {
                Session["IDNguoiDung"] = null;
                Response.Redirect("~/DangNhap.aspx");
            }
        }

        protected void btnThongTin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CapNhatThongTin.aspx");
            
        }
    }
}