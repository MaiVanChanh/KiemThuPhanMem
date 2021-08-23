using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using System.Data;
using System.Data.SqlClient;

namespace Empity_Chinh_2
{
   
    public partial class ThucPhamBoSung : System.Web.UI.Page
    {
        
        public static int lc = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load();
                DataTable dt;
                string sql = "select TenThucPham from LoaiThucPham";
                dt = XLDL.GetData(sql);
                cbb_dahmuc.DataSource = dt;
                cbb_dahmuc.DataValueField = "TenThucPham";
                cbb_dahmuc.DataBind();
                cbb_dahmuc.Items.Add("Tất cả"); 
            }
        }
        public string ct(object x)
        {
            var ss = x;
            string s = "" + x + "";
            var xxx = string.Format("{0:N0}",x);
            return xxx;
        }
        public void load()
        {
            string sql = " select * from ThucPhamBoSung";
            dsThuPham.DataSource = XLDL.GetData(sql);
            dsThuPham.DataBind();
        }
       public string cd(object s )
        {
            int ma = (int)s;
            string sql = "select TenThucPham from LoaiThucPham where ID =" + ma + "";
            DataTable tb = XLDL.GetData(sql);
            string tn = tb.Rows[0][0].ToString();
            return tn;
        }
       
        protected void dsThuPham_ItemCommand(object source, DataViewItemCommandEventArgs e)
        {

            var y = ((Label)e.Item.FindControl("IDSP")).Text;
            Session["IDSanPham"] = y.Trim();
            
            Response.Redirect("~/ChiTietCacSanPham.aspx");
        }

        protected void cbb_dahmuc_Load(object sender, EventArgs e)
        {
            
        }

        protected void txt_TimSanPham_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btn_tim_Click(object sender, EventArgs e)
        {
            String txt = txt_TimSanPham.Text.Trim()+"";
            if (txt == "")
            {
                load();
            }
            else
            {
                if (txt != "")
                {
                    if(txt=="Tất cả")
                    {
                        load();
                    }
                    else
                    {
                        String sql = "select * from ThucPhamBoSung where TenThucPham like  N'%" + txt + "%' ";
                        DataTable tb = XLDL.GetData(sql);
                        if(tb==null)
                        {
                            Response.Write("<script> alert ('Sai tài khoản hoặc mật khẩu') </script>");
                        }
                        else
                        {
                            dsThuPham.DataSource = XLDL.GetData(sql);
                            dsThuPham.DataBind();
                        }
                    }
                }
            }
        }
        public int chuyendoi(String s)
        {
            String sql = "select  ID from  LoaiThucPham where  TenThucPham like  N'%" + s + "%' ";
            DataTable dt = XLDL.GetData(sql);
            return int.Parse(dt.Rows[0][0].ToString());
        }
        protected void cbb_dahmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var s = cbb_dahmuc.SelectedItem.Text.Trim()+"";
            if (s=="Tất cả")
            {
                load();
            }
            else
            {
                string x = s;
                if(x!=null)
                {
                    int key = chuyendoi(x);
                    string sql = "select * from ThucPhamBoSung where MaLoaiThucPham =" + key + "";
                    dsThuPham.DataSource = XLDL.GetData(sql);
                    dsThuPham.DataBind();
                }
            }
        }

        protected void cbb_dahmuc_DataBound(object sender, EventArgs e)
        {
            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            
        }
    }
}