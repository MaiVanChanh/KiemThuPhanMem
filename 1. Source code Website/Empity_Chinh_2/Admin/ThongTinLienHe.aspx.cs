using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Empity_Chinh_2.Admin
{
    public partial class ThongTinLienHe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IDNguoiDung"] == null)
            {

                Response.Redirect("~/DangNhap.aspx");
            }

            if (!IsPostBack)
                load();
        }
        public void load()
        {
            string sql = "select * from LienHe";
            gr.DataSource = XLDL.GetData(sql);
            gr.DataBind();
        }
        public string cd(object s)
        {
            if(s.ToString()!=null)
            {
                
                var nn= s;
                DateTime n = (DateTime)s;
                return n.ToString("dd/mm/yyyy");
            }
            return "rong";
        }
        protected void gr_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int key = 0;
        }

        protected void gr_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
          
        }

        protected void gr_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gr.EditIndex = e.NewEditIndex;
            load();
        }

        protected void gr_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gr.EditIndex = -1;
            load();
        }

        protected void gr_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gr.EditIndex == -1)
            {
                var buttn = e.Row.Cells[6].Controls[0];
                ((LinkButton)buttn).OnClientClick = "return confirm('Bạn có chắc chắn muốn xóa không ?');";
            }
        }

        protected void gr_DataBound(object sender, EventArgs e)
        {

        }

        protected void gr_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gr.EditIndex = e.NewPageIndex;
            load();
        }

        protected void gr_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ma = int.Parse(gr.Rows[e.RowIndex].Cells[0].Text);
            string sql = "delete from LienHe where ID = " + ma + "";
            XLDL.Excute(sql);
            gr.EditIndex = -1;
            load();

        }

        protected void btnXuat_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AppendHeader("content-disposition", string.Format("attachment; filename= {0}", "DanhSachLienHe.xls"));
            Response.ContentType = "application/ms- excel";

            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter ht = new HtmlTextWriter(stringWriter);

            GridView ds = new GridView();
            string sql = string.Format("select * from LienHe");
            ds.DataSource = XLDL.GetData(sql);
            ds.DataBind();

            ds.RenderControl(ht);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void drlocNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = drlocNgay.SelectedIndex;
            if (x == 0)
                load();
            else
            {
                DateTime d = DateTime.Now;
                string ngay = d.ToString("yyyy/MM/dd");
                if(x==1)
                {
                    string sql = "select* from LienHe where NgayLienHe='"+ngay+"'";
                    gr.DataSource = XLDL.GetData(sql);
                    gr.DataBind();
                }
                else
                {
                    if (x == 2)
                    {
                        string sql = "select * from LienHe where YEAR(NgayLienHe)=" + d.Year + "";
                        gr.DataSource = XLDL.GetData(sql);
                        gr.DataBind();
                    }
                    else
                    {
                        string sql = "select * from LienHe where YEAR(NgayLienHe)=" + d.Year + " and MOTH(NgayLienHe)="+d.Month+"";
                        gr.DataSource = XLDL.GetData(sql);
                        gr.DataBind();
                    }
                }
              
            }
        }
    }
}