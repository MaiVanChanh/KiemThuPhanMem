using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Empity_Chinh_2
{
    public partial class HoaDon : System.Web.UI.Page
    {
        public static int MaKH;
        protected void Page_Load(object sender, EventArgs e)
        {
           


            if (Session["IDNguoiDung"] !=null)
            {
                MaKH = int.Parse(Session["IDNguoiDung"].ToString());
                dl();
            }

            else
            {
                Response.Write("<script> alert ('Bạn chưa đăng nhập tài khoản') </script>");
            }
        }      
        public string cdd(object x)
        {
            DateTime d = (DateTime)x;
            
            //int n = d.Day;
            //int t = d.Month;
            //int nam = d.Year;
            String s = d.Date.ToString("d");
            
            //string k=""+n+"-"+t+"-"+nam+"";
            return s;
        }
        public String cd(object x)
        {
            int idex = (int)x;
            String sql = "select TenThucPham from ThucPhamBoSung where ID=" + idex + "";
            DataTable tb = XLDL.GetData(sql);
            String s = tb.Rows[0][0].ToString();
            return s;
        }
        public void loadDSDKBT(String sql)
        {
            //In danh sách đăng ký bài tập
             DataTable table = XLDL.GetData(sql);
            if (table == null)
            {

            }
            else
            {
                dsDangkyBaiTap.DataSource = table;
                dsDangkyBaiTap.DataBind();
                //Response.Write("<script> alert ('danh sách đăng ký bài tập') </script>");
            }
        }
        public void loadHDSP(String sql)
        {
            
            //in hóa đơn mua sản phẩm 
            DataTable tb = XLDL.GetData(sql);
            if (tb == null)
            {

            }
            else
            {
                GridView1.DataSource = tb;
                GridView1.DataBind();
            }
        }
      
        public void dl()
        {

                int giamgia = XLDL.loaGiamGia(MaKH);
                String sql1 = "select hd.ID,ds.TenBaiTap,ds.HinhMinhHoa,ds.Gia,hd.NgayDangKy,hd.NgayHetHan,(ds.Gia - ((l.GiamGia*ds.Gia)/100)) as TongTien from DSDKBT hd, DSBT ds, NguoiDung n, LoaiKhachHang l where hd.MaBT = ds.ID and hd.MaKH=n.ID and n.MaLoaiKhoachHang = l.ID and n.ID = " + MaKH+"";
                loadDSDKBT(sql1);
                String sql2 = "select hd.ID,hd.HinhMinhHoa,hd.TenThucPham,hd.SoLuong,hd.Gia,hd.TongTien,(hd.Gia*hd.SoLuong - (hd.Gia*hd.SoLuong*l.GiamGia)/100) as TraTien,hd.NgayMua from HoaDonThucPhamBoSung hd, NguoiDung n, LoaiKhachHang l where l.ID=n.MaLoaiKhoachHang and n.ID=hd.MaKH and n.ID = " + MaKH+" ";
                loadHDSP(sql2);
        }
        public void dltheongay( String txtngay)
        {
            // int.Parse(Session["bien"].ToString());
            if (Session["IDNguoiDung"] != null)
            {
                
                String sql1 = "select hd.ID,ds.TenBaiTap,ds.HinhMinhHoa,ds.Gia,hd.NgayDangKy,hd.NgayHetHan,(ds.Gia - ((l.GiamGia*ds.Gia)/100)) as TongTien from DSDKBT hd, DSBT ds, NguoiDung n, LoaiKhachHang l where hd.MaBT = ds.ID and hd.MaKH=n.ID and n.MaLoaiKhoachHang = l.ID and n.ID = " + MaKH + " and hd.NgayHetHan = '" + txtngay+"'";
                loadDSDKBT(sql1);
                String sql2 = "select hd.ID,hd.HinhMinhHoa,hd.TenThucPham,hd.SoLuong,hd.Gia,hd.TongTien,(hd.Gia*hd.SoLuong - (hd.Gia*hd.SoLuong*l.GiamGia)/100) as TraTien,hd.NgayMua from HoaDonThucPhamBoSung hd, NguoiDung n, LoaiKhachHang l where l.ID=n.MaLoaiKhoachHang and n.ID=hd.MaKH and hd.NgayMua='" + txtngay + "' and n.ID = " + MaKH + "";
                loadHDSP(sql2);
            }
        }
        protected void timTheoNgay_Click(object sender, ImageClickEventArgs e)
        {

            var date = ngay1.Date;
            string ChonNgay = date.ToString("yyyy/MM/dd");
            dltheongay(ChonNgay);
            
        }

        protected void menuHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = int.Parse(menuHD.SelectedValue.ToString());
            if (x == 1)
            {
                dsDangkyBaiTap.Visible = true;
                GridView1.Visible = true;
                dsTPBS.Visible = true;
                dsBT.Visible = true;
                dl();
            }
            if (x == 2)
            {
                //in danh sách đăng ký bài tập
                dsDangkyBaiTap.Visible = true;
                GridView1.Visible = false;
                dsTPBS.Visible = false;
                dsBT.Visible = true;

            }
            if (x == 3)
            {
                //in danh sách mua sản phẩm  
                GridView1.Visible = true;
                dsDangkyBaiTap.Visible = false;
                dsTPBS.Visible = true;
                dsBT.Visible = false;
            }
        }

        protected void dsDangkyBaiTap_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dsDangkyBaiTap.PageIndex = e.NewPageIndex;
            dl();
        }

        protected void dsDangkyBaiTap_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            dl();
        }
    }
}