using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DevExpress.Web;
using System.Web.UI.WebControls;
using System.Data;

namespace Empity_Chinh_2
{
    public partial class TrangChu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load();
                
            }
        }

        public String cNgay(object x)
        {
            var x1 = string.Format("{0:N0}", x);
            return x1;
        }
        public int vitri = 0;
        public int id = -1;
        protected void ds_ItemCommand(object source, DevExpress.Web.DataViewItemCommandEventArgs e)
        {

            var ma = (Label)e.Item.FindControl("txtMA");
            Session["IDBaiTap"] = ma.Text;
            Response.Redirect("~/DangKyBaiTap.aspx");

        }

        protected void btnDangKy_Click1(object sender, ImageClickEventArgs e)
        {
           
            vitri = 0;
        }

        protected void btnXemThem_Click(object sender, ImageClickEventArgs e)
        {
            vitri = 1;
        }

        protected void ds_Load(object sender, EventArgs e)
        {

        }



        protected void ds_PageIndexChanging(object source, DevExpress.Web.DataViewPageEventArgs e)
        {

            ds.PageIndex = e.NewPageIndex;

        }
        public void load()
        {
            string s = "select d.ID, d.TenBaiTap, d.HinhMinhHoa, d.Gia, d.ThoiHan  from DSBT d";
            ds.DataSource = XLDL.GetData(s);
            ds.DataBind();
        }
        
        protected void ds_Init(object sender, EventArgs e)
        {
            load();
        }

        protected void HyperLink1_DataBinding(object sender, EventArgs e)
        {
            
        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            vitri = 0;
        }

        protected void ds_DataBound(object sender, EventArgs e)
        {
            
        }
        public static int CurrentPage =0;
        
    } 
}