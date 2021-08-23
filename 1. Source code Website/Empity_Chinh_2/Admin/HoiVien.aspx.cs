using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace Empity_Chinh_2.Admin
{
    public partial class HoiVien : System.Web.UI.Page
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
            string sql = string.Format("select n.ID,n.HinhMinhHoa,n.TenNguoiDung,l.TenLoai,n.TK,n.Pass,n.DiemTichLuy,n.SDT,n.Gmail from NguoiDung n, LoaiKhachHang l where n.MaBoPhan=0 and l.ID=n.MaLoaiKhoachHang");
            grDSKhachHang.DataSource = XLDL.GetData(sql);
            grDSKhachHang.DataBind();
            
            

        }

        protected void btnLocNgay_Click(object sender, EventArgs e)
        {
            var d = drChonNgay.Date.Date;
            string n = d.ToString("MM/dd/yyyy");
            string sql = string.Format("select n.ID,n.HinhMinhHoa,n.TenNguoiDung,l.TenLoai,n.TK,n.Pass,n.DiemTichLuy,n.SDT,n.Gmail from NguoiDung n, LoaiKhachHang l where n.MaBoPhan=0 and l.ID=n.MaLoaiKhoachHang and n.NgayDangKy='" + n+"'");
            if(XLDL.kt(sql)>0)
            {
                grDSKhachHang.DataSource = XLDL.GetData(sql);
                grDSKhachHang.DataBind();
            }
            else
            {
                Response.Write("<script> alert ('Dữ liệu không có ') </script>");
            }


        }

        protected void drChonNgay_ButtonClick(object source, DevExpress.Web.ButtonEditClickEventArgs e)
        {
            int index = e.ButtonIndex;
            
        }

        protected void btnChonLoaiKH_Click(object sender, EventArgs e)
        {
            int x = drChonLoaiKhachHang.SelectedIndex;
            if(x==0)
            {
                load();
            }
            else
            {
                string sql = string.Format("select n.ID,n.HinhMinhHoa,n.TenNguoiDung,l.TenLoai,n.TK,n.Pass,n.DiemTichLuy,n.SDT,n.Gmail from NguoiDung n, LoaiKhachHang l where n.MaBoPhan=0 and l.ID=n.MaLoaiKhoachHang and l.ID= " + x + "");
                grDSKhachHang.DataSource = XLDL.GetData(sql);
                grDSKhachHang.DataBind();
            }
            
        }

        protected void btnTenKH_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text != "")
            {
                var key = txtTenKH.Text;
                string sql = string.Format("select n.ID,n.HinhMinhHoa,n.TenNguoiDung,l.TenLoai,n.TK,n.Pass,n.DiemTichLuy,n.SDT,n.Gmail from NguoiDung n, LoaiKhachHang l where n.MaBoPhan=0 and l.ID=n.MaLoaiKhoachHang and n.TenNguoiDung like N'%" + key + "%'");
                grDSKhachHang.DataSource = XLDL.GetData(sql);
                grDSKhachHang.DataBind();
               
            }
        }

        protected void btnMaKH_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text != "")
            {
                var key = txtMaKH.Text;
                string sql = string.Format("select n.ID,n.HinhMinhHoa,n.TenNguoiDung,l.TenLoai,n.TK,n.Pass,n.DiemTichLuy,n.SDT,n.Gmail from NguoiDung n, LoaiKhachHang l where n.MaBoPhan=0 and l.ID=n.MaLoaiKhoachHang and n.ID= " + key + "");
                grDSKhachHang.DataSource = XLDL.GetData(sql);
                grDSKhachHang.DataBind();
            }
            else
            {
                Response.Write("<script> alert ('Chưa nhập mã khách hàng cần tìm ') </script>");
            }
        }

        protected void btnLKDK_Click(object sender, EventArgs e)
        {
            var x = drLuotKhachDK.SelectedIndex;
            if (x == 0)
                load();
            if(x==1)
            {
                DateTime ngay = DateTime.Now.Date;
                int thang = ngay.Month;
                string sql = string.Format("select n.ID,n.HinhMinhHoa,n.TenNguoiDung,l.TenLoai,n.TK,n.Pass,n.DiemTichLuy,n.SDT,n.Gmail from NguoiDung n, LoaiKhachHang l where n.MaBoPhan=0 and l.ID=n.MaLoaiKhoachHang and MONTH(n.NgayDangKy)= " + thang + "");
                grDSKhachHang.DataSource = XLDL.GetData(sql);
                grDSKhachHang.DataBind();
            }
            if(x==2)
            {
                DateTime ngay = DateTime.Now.Date;

                var n= ngay.ToString("MM/dd/yyyy");
                
                string sql = string.Format("select n.ID,n.HinhMinhHoa,n.TenNguoiDung,l.TenLoai,n.TK,n.Pass,n.DiemTichLuy,n.SDT,n.Gmail from NguoiDung n, LoaiKhachHang l where n.MaBoPhan=0 and l.ID=n.MaLoaiKhoachHang and n.NgayDangKy= '" + n+ "'");
                if(XLDL.kt(sql)==1)
                {
                    grDSKhachHang.DataSource = XLDL.GetData(sql);
                    grDSKhachHang.DataBind();
                }
                else
                {
                    Response.Write("<script> alert ('Chưa có dữ liệu cần thống kê') </script>");

                }

            }
        }

        protected void btnXuatDanhSachKH_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AppendHeader("content-disposition",string.Format( "attachment; filename= {0}","QLPhongGymCHinhThuc.xls"));
            Response.ContentType = "application/ms- excel";

            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter ht = new HtmlTextWriter(stringWriter);

            GridView ds = new GridView();
            string sql = string.Format("select n.ID,n.TenNguoiDung,l.TenLoai,n.TK,n.Pass,n.DiemTichLuy,n.SDT,n.Gmail from NguoiDung n, LoaiKhachHang l where n.MaBoPhan=0 and l.ID=n.MaLoaiKhoachHang");
            ds.DataSource = XLDL.GetData(sql);
            ds.DataBind();
           
            ds.RenderControl(ht);
            Response.Write(stringWriter.ToString());
            Response.End() ;
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
           
        }

        protected void grDSKhachHang_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grDSKhachHang.EditIndex = e.NewPageIndex;
            load();
        }

        protected void grDSKhachHang_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int r = e.RowIndex;
            int ma = int.Parse(grDSKhachHang.DataKeys[r].Value.ToString());
            string sql = "delete from NguoiDung where ID=" + ma + "";
            XLDL.Excute(sql);
            load();
        }

        protected void grDSKhachHang_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && grDSKhachHang.EditIndex == -1)
            {
                var buttn = e.Row.Cells[9].Controls[0];
                ((LinkButton)buttn).OnClientClick = "return confirm('Bạn có chắc chắn muốn xóa không ?');";
            }
        }
    }
}