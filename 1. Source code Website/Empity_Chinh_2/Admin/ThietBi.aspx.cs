using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Empity_Chinh_2.Admin
{
    public partial class ThietBi : System.Web.UI.Page
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
            string sql = "select t.ID,t.HinhMinhHoa,t.TenThietBi,t.Gia,t.TinhTrang,t.NgayMua,t.HuongDan from ThietBi t";
            gr_chinh.DataSource = XLDL.GetData(sql);
            gr_chinh.DataBind();
        }
        public string cd(object s)
        {
            DateTime ngay = (DateTime)s;
            var x = ngay.ToString("d");
            int key = 0;
            return x;
        }
        protected void gr_chinh_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gr_chinh.EditIndex = e.NewEditIndex;
            load();
        }

        protected void gr_chinh_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gr_chinh.EditIndex = -1;
            load();

        }

        protected void gr_chinh_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int x = e.RowIndex;
            int id = int.Parse(gr_chinh.Rows[x].Cells[0].Text);
            string sql = "delete from ThietBi where ID =" + id + "";
            XLDL.Excute(sql);
            gr_chinh.EditIndex = -1;
            load();
        }

        protected void gr_chinh_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gr_chinh.EditIndex == -1)
            {
                var buttn = e.Row.Cells[7].Controls[2];
                ((LinkButton)buttn).OnClientClick = "return confirm('Bạn có chắc chắn muốn xóa không ?');";
            }
        }

        protected void gr_chinh_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int x = e.RowIndex;
            int id = int.Parse(gr_chinh.Rows[x].Cells[0].Text);
            string tt = (gr_chinh.Rows[x].Cells[4].FindControl("drtinhTrang") as DropDownList).SelectedItem.ToString();
            string sql = "update ThietBi set TinhTrang =N'" + tt + "' where ID="+id+"";
            XLDL.Excute(sql);
            gr_chinh.EditIndex = -1;
            load();
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ThemDuLieu/ThemThietBi.aspx");
        }

        protected void btnTimtenThietBi_Click(object sender, EventArgs e)
        {
            string t = txtTimTenThietBi.Text.Trim() + "";
            string sql = "select t.ID,t.HinhMinhHoa,t.TenThietBi,t.Gia,t.TinhTrang,t.NgayMua,t.HuongDan from ThietBi t where t.TenThietBi like N'%"+t+"%'";
            if (XLDL.kt(sql) == 0)
            {
                Response.Write("<script> alert ('Không có dữ liệu') </script>");
                load();
            }
                
            else
            {
                gr_chinh.DataSource = XLDL.GetData(sql);
                gr_chinh.DataBind();
            }

        }

        protected void btnluulai_Click(object sender, EventArgs e)
        {
           
        }
        public void luuAnh(String url)
        {

            upAnh.SaveAs(MapPath("~/image_nguoidung/ThietBiAdmin/" + upAnh.FileName));
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            int key = 0;
            if (txtGia.Text != "" && txtHD.Text != "" && txtTenTB.Text != "" && upAnh.FileName != "")
            {
                var s = txtGia.Text.Trim() + "";
                if (XLDL.KiemTraSo(s) == true)
                {
                    DateTime ngay = DateTime.Now;
                    string date = ngay.ToString("MM/dd/yyyy");
                    string url = upAnh.FileName;
                    luuAnh(url);
                    string sql = "insert into ThietBi(TenThietBi,Gia,HinhMinhHoa,TinhTrang,HuongDan,NgayMua) values(N'" + txtTenTB.Text.Trim() + "" + "'," + float.Parse(txtGia.Text) + ",'" + url.Trim() + "" + "',N'" + drTinhTrang.SelectedItem.Text.Trim() + "',N'" + txtHD.Text+"" + "','" + date + "') ";
                    XLDL.Excute(sql);
                    Response.Write("<script> alert ('Thêm thành công') </script>");
                    Response.Redirect("~/Admin/ThietBi.aspx");


                }
                else
                {
                    Response.Write("<script> alert ('Giá chỉ có số') </script>");

                }


            }
            else
            {
                Response.Write("<script> alert ('Phải đủ dữ liệu mới thêm được') </script>");

            }
        }

        protected void btnXuatDS_Click(object sender, EventArgs e)
        {
            GridView ds = new GridView();
            string sql = "select t.ID,t.TenThietBi,t.Gia,t.TinhTrang,t.NgayMua,t.HuongDan from ThietBi t";
            ds.DataSource = XLDL.GetData(sql);

            Response.ClearContent();
            Response.Buffer = true;
            Response.AppendHeader("content-disposition", string.Format("attachment; filename= {0}", "QLPhongGymCHinhThuc.xls"));
            Response.ContentType = "application/ms- excel";

            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter ht = new HtmlTextWriter(stringWriter);


            ds.RenderControl(ht);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void btnTimMaTB_Click(object sender, EventArgs e)
        {
            string ma = txtTimMaThietBi.Text.Trim();
            if(XLDL.KiemTraSo(ma)==true)
            {
                string sql = "select t.ID,t.HinhMinhHoa,t.TenThietBi,t.Gia,t.TinhTrang,t.NgayMua,t.HuongDan from ThietBi t where t.ID = "+int.Parse(ma)+"";
                if (XLDL.kt(sql) == 0)
                {
                    Response.Write("<script> alert ('Không có dữ liệu') </script>");
                    load();
                }

                else
                {
                    gr_chinh.DataSource = XLDL.GetData(sql);
                    gr_chinh.DataBind();
                }
            }

        }
    }
}