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
    public partial class Doanhthu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IDNguoiDung"] == null)
            {

                Response.Redirect("~/DangNhap.aspx");
            }
            
            if (!IsPostBack)
            {
                loadDoanhThuLanDau();
                load();
            }
                

            
        }
        public void load()
        {
            string sql = "select ds.ID,ds.MaKH,ds.MaBT,ds.TenBT,ds.NgayDangKy,ds.NgayHetHan, ds.Gia, (ds.Gia - (Gia*l.GiamGia)/100) as TongTien  from DSDKBT ds, NguoiDung n, LoaiKhachHang l where ds.MaKH=n.ID and n.MaLoaiKhoachHang=l.ID ";
            dsdkbt.DataSource = XLDL.GetData(sql);
            dsdkbt.DataBind();
            string sql2 = "select * from HoaDonThucPhamBoSung";
            dsThucPham.DataSource = XLDL.GetData(sql2);
            dsThucPham.DataBind();    
        }
        public void loadDoanhThuLanDau()
        {
            float s = XLDL.GetDataStore("HodonTPBS");
            string ss = string.Format("{0:N0}", s);
            txtTongDoanhThu.Text = ss;
           
        }
        public string cd(object s)
        {
            DateTime ngay = (DateTime)s;
            var x = ngay.ToString("d");
            int key = 0;
            return x;
            
        }

        public static DateTime d;
        protected void btnTinh_Click(object sender, EventArgs e)
        {
            d = DateTime.Now;
            int t = d.Month;
            int day = d.Day;
            int n = d.Year;
            if (dateChonNgay.SelectedIndex==0)
                load();
            else
            {
                if (dateChonNgay.SelectedIndex == 1)
                {

                    if (drChonDoanhThu.SelectedIndex == 0)
                    {
                        string sql = "select sum (TongTien) from HoaDonThucPhamBoSung h where MONTH(h.NgayMua)= '" + t + "'";

                        if (XLDL.ktDoanhThu(sql) == 1)
                        {
                            DataTable tb = XLDL.GetData(sql);
                            float s = float.Parse(tb.Rows[0][0].ToString());
                            string ss = string.Format("{0:N0}", s);
                            txtTongDoanhThu.Text = ss;
                        }
                        else
                        {
                            Response.Write("<script> alert ('Không có dữ liệu ') </script>");
                            load();
                        }
                        string sql2 = "select * from HoaDonThucPhamBoSung where MONTH (NgayMua)="+t+" and YEAR(NgayMua)="+n+" ";
                        dsThucPham.DataSource = XLDL.GetData(sql2);
                        dsThucPham.DataBind();

                    }
                    else
                    {
                        string sql = "select sum((ds.Gia - (Gia*l.GiamGia)/100)) as TongTien  from DSDKBT ds, NguoiDung n, LoaiKhachHang l where ds.MaKH=n.ID and n.MaLoaiKhoachHang=l.ID and MONTH(ds.NgayDangKy)= " + t + " and YEAR(ds.NgayDangKy)= " + n + "";
                        if (XLDL.ktDoanhThu(sql) == 1)
                        {
                            DataTable tb = XLDL.GetData(sql);
                            float s = float.Parse(tb.Rows[0][0].ToString());
                            string ss = string.Format("{0:N0}", s);
                            txtTongDoanhThu.Text = ss;
                        }
                        else
                        {
                            Response.Write("<script> alert ('Không có dữ liệu ') </script>");
                            load();
                        }

                        string sql2 = "select ds.ID,ds.MaKH,ds.MaBT,ds.TenBT,ds.NgayDangKy,ds.NgayHetHan, ds.Gia, (ds.Gia - (Gia*l.GiamGia)/100) as TongTien  from DSDKBT ds, NguoiDung n, LoaiKhachHang l where ds.MaKH=n.ID and n.MaLoaiKhoachHang=l.ID and MONTH(ds.NgayDangKy)= "+t+" and YEAR(ds.NgayDangKy)= "+n+" ";
                        dsdkbt.DataSource = XLDL.GetData(sql2);
                        dsdkbt.DataBind();

                    }
                }
                else
                {
                    if (drChonDoanhThu.SelectedIndex == 0)
                    {
                        string sql = "select sum (TongTien) from HoaDonThucPhamBoSung h where h.NgayMua= '" + d.ToString("yyyy/MM/dd") + "'";

                        if (XLDL.ktDoanhThu(sql) == 1)
                        {
                            DataTable tb = XLDL.GetData(sql);
                            float s = float.Parse(tb.Rows[0][0].ToString());
                            string ss = string.Format("{0:N0}", s);
                            txtTongDoanhThu.Text = ss;
                        }
                        else
                        {
                            Response.Write("<script> alert ('Không có dữ liệu ') </script>");
                            load();
                        }
                        string sql2 = "select * from HoaDonThucPhamBoSung where NgayMua='" +d.ToString("yyyy/MM/dd")+"' ";
                        dsThucPham.DataSource = XLDL.GetData(sql2);
                        dsThucPham.DataBind();
                    }
                    else
                    {
                        string sql = "select sum((ds.Gia - (Gia*l.GiamGia)/100)) as TongTien  from DSDKBT ds, NguoiDung n, LoaiKhachHang l where ds.MaKH=n.ID and n.MaLoaiKhoachHang=l.ID and  ds.NgayDangKy= '" + d.ToString("yyyy/MM/dd") + "'";
                        if (XLDL.ktDoanhThu(sql) == 1)
                        {
                            DataTable tb = XLDL.GetData(sql);
                            float s = float.Parse(tb.Rows[0][0].ToString());
                            string ss = string.Format("{0:N0}", s);
                            txtTongDoanhThu.Text = ss;
                        }
                        else
                        {
                            Response.Write("<script> alert ('Không có dữ liệu ') </script>");
                            load();
                        }
                        string sql2 = "select ds.ID,ds.MaKH,ds.MaBT,ds.TenBT,ds.NgayDangKy,ds.NgayHetHan, ds.Gia, (ds.Gia - (Gia*l.GiamGia)/100) as TongTien  from DSDKBT ds, NguoiDung n, LoaiKhachHang l where ds.MaKH=n.ID and n.MaLoaiKhoachHang=l.ID and ds.NgayDangKy= '" + d.ToString("yyyy/MM/dd") + "' ";
                        dsdkbt.DataSource = XLDL.GetData(sql2);
                        dsdkbt.DataBind();
                    }
                }
            }

            
        }

        protected void dateChonNgay_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private static int tabSo=0;
      
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void btnXuat_Click(object sender, EventArgs e)
        {
            
            if(drChonDoanhThu.SelectedIndex == 0)
            {
                Response.ClearContent();
                Response.Buffer = true;
                Response.AppendHeader("content-disposition", string.Format("attachment; filename= {0}", "HoaDonThucPham.xls"));
                Response.ContentType = "application/ms- excel";

                StringWriter stringWriter = new StringWriter();
                HtmlTextWriter ht = new HtmlTextWriter(stringWriter);

                GridView ds = new GridView();
                string sql = string.Format("select *from HoaDonThucPhamBoSung");
                ds.DataSource = XLDL.GetData(sql);
                ds.DataBind();

                ds.RenderControl(ht);
                Response.Write(stringWriter.ToString());
                Response.End();
            }
            else
            {
                Response.ClearContent();
                Response.Buffer = true;
                Response.AppendHeader("content-disposition", string.Format("attachment; filename= {0}", "HoaDonDSDKBT.xls"));
                Response.ContentType = "application/ms- excel";

                StringWriter stringWriter = new StringWriter();
                HtmlTextWriter ht = new HtmlTextWriter(stringWriter);

                GridView ds = new GridView();
                string sql = string.Format("select ds.ID,ds.MaKH,ds.MaBT,ds.TenBT,ds.NgayDangKy,ds.NgayHetHan, ds.Gia, (ds.Gia - (Gia*l.GiamGia)/100) as TongTien  from DSDKBT ds, NguoiDung n, LoaiKhachHang l where ds.MaKH=n.ID and n.MaLoaiKhoachHang=l.ID");
                ds.DataSource = XLDL.GetData(sql);
                ds.DataBind();

                ds.RenderControl(ht);
                Response.Write(stringWriter.ToString());
                Response.End();
            }
            
        }

        protected void dsdkbt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dsdkbt.EditIndex = e.NewPageIndex;
            load();
        }

        protected void dsThucPham_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dsThucPham.EditIndex = e.NewPageIndex;
            load();
        }

        protected void drChonDoanhThu_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (drChonDoanhThu.SelectedIndex==0)
            {
                tabSo = 0;
                dsThucPham.Visible = true;
                dsdkbt.Visible = false;
                float s = XLDL.GetDataStore("HodonTPBS");
                string ss = string.Format("{0:N0}", s);
                txtTongDoanhThu.Text = ss;
                tabSo = 1;
            }
            else
            {
                dsThucPham.Visible = false;
                dsdkbt.Visible = true;
                float s = XLDL.GetDataStore("DoanhThuDSDKBT");
                string ss = string.Format("{0:N0}", s);
                txtTongDoanhThu.Text = ss;
            }
        }
    }
}