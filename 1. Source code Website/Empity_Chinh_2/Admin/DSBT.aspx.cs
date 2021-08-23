using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Empity_Chinh_2.Admin
{
    public partial class DSBT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IDNguoiDung"] == null)
            {

                Response.Redirect("~/DangNhap.aspx");
            }

            if (!IsPostBack)
            {
                load();
            }
        }
        public void load()
        {
            string sql = @"select * from DSBT";
            grDS.DataSource = XLDL.GetData(sql);
            grDS.DataBind();
        }
        protected void btnTimMaBt_Click(object sender, EventArgs e)
        {
            string s= txttMaBT.Text.Trim();
            if(XLDL.KiemTraSo(s)==false)
            {
                Response.Write("<script> alert ('Phải nhập dữ liệu mới tìm được ') </script>");
                load();
            }
            else
            {
                int ma = int.Parse(s);
                string sql = @"select * from DSBT where ID ="+ma+" ";
                grDS.DataSource = XLDL.GetData(sql);
                grDS.DataBind();
            }
        }

        protected void grDS_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grDS.EditIndex = e.NewEditIndex;
            load();
        }

        protected void grDS_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grDS.EditIndex = -1;
            load();
        }

        protected void grDS_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int key = e.RowIndex;
            int ma = int.Parse((grDS.Rows[key].Cells[0].Text));
            float gia = float.Parse((grDS.Rows[key].Cells[4].Controls[0] as TextBox).Text);
            int thoihan = int.Parse((grDS.Rows[key].Cells[5].FindControl("drChonThoiHan") as DropDownList).SelectedValue);
            string sql = "update DSBT set Gia="+gia+", ThoiHan ="+thoihan+" where ID="+ma+"";
            XLDL.Excute(sql);
            grDS.EditIndex = -1;
            load();
        }

        protected void grDS_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            int ma = int.Parse(grDS.Rows[index].Cells[0].Text);
            string sql = "delete from DSBT where ID=" + ma + " ";
            XLDL.Excute(sql);
            load();
        }

        protected void grDS_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && grDS.EditIndex == -1)
            {
                var buttn = e.Row.Cells[6].Controls[2];
                ((LinkButton)buttn).OnClientClick = "return confirm('Bạn có chắc chắn muốn xóa không ?');";
            }
        }

        protected void btnXuat_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnThemMoi_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/ThemDuLieu/ThemBaiTap.aspx");
        }

        protected void grDS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grDS.PageIndex = e.NewPageIndex;
            load();
        }
        public bool KiemTraSo(string a)
        {
            string s = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '1' || a[i] == '0' || a[i] == '2' || a[i] == '3' || a[i] == '4' || a[i] == '5' || a[i] == '6' || a[i] == '7' || a[i] == '8' || a[i] == '9')
                    continue;
                else return false;
            }
            return true;
        }
        
             public void luuAnh(String url)
        {

            upAnh.SaveAs(MapPath("~/image_nguoidung/AnhBaiTap/" + upAnh.FileName));
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string x = txtGhiChu.Text;

            string xx = txtGia.Text;
            string xxx = txtTenBT.Text;
            if (x != "" && xx != "" && xxx != "" && upAnh.FileName!="")
            {
                if (KiemTraSo(txtGia.Text) == true)
                {
                    string url = upAnh.FileName;
                    luuAnh(url);
                    string sql = "insert into DSBT (TenBaiTap,HinhMinhHoa,Gia,ThoiHan,GhiChu) values (N'" + txtTenBT.Text + "','" + url + "'," + float.Parse(txtGia.Text) + "," + int.Parse(drThoiHan.SelectedItem.Text) + ",N'" + txtGhiChu.Text + "')";
                    XLDL.Excute(sql);
                    Response.Write("<script> alert ('Bạn đã thêm mới thành công ') </script>");
                    Response.Redirect("~/Admin/DSBT.aspx");
                }
                else
                {
                    Response.Write("<script> alert ('Lương và trợ cấp phải là số ') </script>");

                }
            }
            else
            {
                Response.Write("<script> alert ('Phải đủ dữ liệu mới thêm mới được ') </script>");

            }
        }

        protected void btnTimtenBT_Click(object sender, EventArgs e)
        {
            string s = txtTimTenBt.Text.Trim();
            if(s=="")
            {
                btnTimMaBt.Focus();
                load();
            }
           
            else
            {
                string sql = @"select * from DSBT where TenBaiTap like N'%"+s+"%' ";
                grDS.DataSource = XLDL.GetData(sql);
                grDS.DataBind();
            }
        }
    }
}