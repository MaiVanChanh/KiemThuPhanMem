using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
namespace Empity_Chinh_2.Admin
{
    public partial class NhanVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IDNguoiDung"] == null)
            {

                Response.Redirect("~/DangNhap.aspx");
            }


            if (!IsPostBack)
            {
                string sql = "select TenBoPhan from LoaiBoPhan";
                drBoPhan.DataSource = XLDL.GetData(sql);
                drBoPhan.DataValueField = "TenBoPhan";
                drBoPhan.DataBind();
               
                load();
                loadTimBoPhan();
            }
                
        }
        public void loadTimBoPhan()
        {
            string sql1 = "select TenBoPhan from LoaiBoPhan";
            DataTable tb = XLDL.GetData(sql1);
            drTimBoPhan.Items.Add("Tất cả");
            int i = 0;
           while(i< tb.Rows.Count)
            {
                drTimBoPhan.Items.Add(tb.Rows[i][0].ToString());
                i++;
            }
        }
        public string cd(object gt)
        {
            int x = (int)gt;
            if (x == 1)
                return "Nam";
            else return "Nữ";
        }
        public void load()
        {
            string sql = "select n.ID,n.HinhMinhHoa,n.TenNguoiDung,n.GioiTinh,l.TenBoPhan,n.Tuoi,n.SDT,n.Gmail,l.LuongCoban,n.NgayDangKy from NguoiDung n,LoaiBoPhan l where n.MaBoPhan=l.ID";
            grDS.DataSource = XLDL.GetData(sql);
            grDS.DataBind();

        }
        
        protected void btntimMNV_Click(object sender, EventArgs e)
        {
            if(txttmanv.Text=="")
            {
                 
                load();
            }
           else
            {
                if (XLDL.KiemTraSo(txttmanv.Text.Trim() + "") == true)
                {
                    int ma = int.Parse(txttmanv.Text.Trim() + "");
                    string sql = "select n.ID,n.HinhMinhHoa,n.TenNguoiDung,n.GioiTinh,l.TenBoPhan,n.Tuoi,n.SDT,n.Gmail,l.LuongCoban,n.NgayDangKy from NguoiDung n,LoaiBoPhan l where n.MaBoPhan=l.ID and n.ID =" + ma + "";
                    if (XLDL.kt(sql) == 1)
                    {
                        grDS.DataSource = XLDL.GetData(sql);
                        grDS.DataBind();
                    }
                    else
                    {
                        Response.Write("<script> alert ('Không có nhân viên cần tìm ') </script>");
                        load();
                    }
                }
                else
                {
                    Response.Write("<script> alert ('Mã phải là số ') </script>");
                    load();

                }
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
            int index = e.RowIndex;
            int key = int.Parse(grDS.Rows[index].Cells[0].Text);
            int x = (grDS.Rows[index].Cells[4].Controls[1] as DropDownList).SelectedIndex+1;
            
            string sql = "update NguoiDung set MaBoPhan="+x+" where ID ="+key+"";
            XLDL.Excute(sql);
            grDS.EditIndex = -1;
            load();

        }

        protected void grDS_DataBound(object sender, EventArgs e)
        {
           
        }

        protected void grDS_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && grDS.EditIndex == -1)
            {
                var buttn = e.Row.Cells[10].Controls[2];
                ((LinkButton)buttn).OnClientClick = "return confirm('Bạn có chắc chắn muốn xóa không ?');";
            }
        }

        protected void grDS_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            int key = int.Parse(grDS.Rows[index].Cells[0].Text);           
            string sql = "delete from NguoiDung   where ID =" + key + "";
            XLDL.Excute(sql);
            load();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ThemDuLieu/ThemMoiNhanVien.aspx");
            
        }

        protected void btnXuat_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AppendHeader("content-disposition", string.Format("attachment; filename= {0}", "QLPhongGymCHinhThuc.xls"));
            Response.ContentType = "application/ms- excel";

            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter ht = new HtmlTextWriter(stringWriter);

            GridView ds = new GridView();
            string sql = "select n.ID,n.TenNguoiDung,n.GioiTinh,n.MaBoPhan,n.Tuoi,n.SDT,n.Gmail,l.LuongCoban,n.NgayDangKy from NguoiDung n,LoaiBoPhan l where n.MaBoPhan=l.ID";
            ds.DataSource = XLDL.GetData(sql);
            ds.DataBind();

            ds.RenderControl(ht);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void btntmabp_Click(object sender, EventArgs e)
        {
           

           // string sql = "select n.ID,n.HinhMinhHoa,n.TenNguoiDung,n.GioiTinh,l.TenBoPhan,n.Tuoi,n.SDT,n.Gmail,l.LuongCoban,n.NgayDangKy from NguoiDung n,LoaiBoPhan l where n.MaBoPhan=l.ID and n.MaBoPhan=" + ma+" ";
           // grDS.DataSource = XLDL.GetData(sql);
         //   grDS.DataBind();
        }

        protected void btntataCa_Click(object sender, EventArgs e)
        {
            load();
        }
        public bool dkPas(string a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '1' || a[i] == '0' || a[i] == '2' || a[i] == '3' || a[i] == '4' || a[i] == '5' || a[i] == '6' || a[i] == '7' || a[i] == '8' || a[i] == '9')
                    return true;
            }
            return false;
        }

        public string cd(string s)
        {
            string sql = "select LuongCoban from LoaiBoPhan where TenBoPhan like N'%" + s + "%' ";
            DataTable dt = XLDL.GetData(sql);
            string l = dt.Rows[0][0].ToString();
            return l;
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            var pas = txtPass.Text.Trim() + "";
            if (dkPas(pas) == true)
            {
                
                var xx = txtPass.Text;
                var xxx = txtTenTK.Text;
                if ( txtPass.Text != "" && txtTenNV.Text != "" && txtTenTK.Text != "")
                {
                    DateTime ngay = DateTime.Now;
                    int mabp = drBoPhan.SelectedIndex + 1;
                    string date = ngay.ToString("MM/dd/yyyy");
                    string sql = "insert into NguoiDung(TenNguoiDung,TK,Pass,GioiTinh,MaBoPhan,MaLoaiKhoachHang,NgayDangKy) values(N'" + txtTenNV.Text.Trim()+"" + "','" + txtTenTK.Text.Trim() + "" + "','" + txtPass.Text.Trim() + "" + "'," + drGioiTinh.SelectedValue + "," + mabp + ",0,'" + date + "')";
                    XLDL.Excute(sql);
                    Response.Write("<script> alert ('Thêm nhân viên thành công') </script>");
                    load();
                }
                else
                {
                    Response.Write("<script> alert ('Chưa đủ dữ liệu để thêm mới') </script>");
                }

            }
            else
            {
                Response.Write("<script> alert ('Mật khẩu bắt buộc có số') </script>");
            }
        }

        protected void drGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void drGioiTinh_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void drBoPhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            float l = float.Parse(cd(drBoPhan.SelectedItem.Text.Trim() + ""));
            var s = string.Format("{0:N0}", l);
   
        }

        protected void btntTenNV_Click(object sender, EventArgs e)
        {
            string ten = txtttennv.Text.Trim() + "";
            string sql = "select n.ID,n.HinhMinhHoa,n.TenNguoiDung,n.GioiTinh,l.TenBoPhan,n.Tuoi,n.SDT,n.Gmail,l.LuongCoban,n.NgayDangKy from NguoiDung n,LoaiBoPhan l where n.MaBoPhan=l.ID and n.TenNguoiDung  like N'%" + ten + "%'";
            grDS.DataSource = XLDL.GetData(sql);
            grDS.DataBind();
        }

        protected void drTimBoPhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ma = drTimBoPhan.SelectedIndex;
            if(ma==0)
            {
                load();
            }
            else
            {
                string sql = "select n.ID,n.HinhMinhHoa,n.TenNguoiDung,n.GioiTinh,l.TenBoPhan,n.Tuoi,n.SDT,n.Gmail,l.LuongCoban,n.NgayDangKy from NguoiDung n,LoaiBoPhan l where n.MaBoPhan=l.ID and n.MaBoPhan="+ma+" ";
                grDS.DataSource = XLDL.GetData(sql);
                grDS.DataBind();
            }
        }
    }
}