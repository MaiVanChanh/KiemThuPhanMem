using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Empity_Chinh_2
{
    public partial class DangKyBaiTap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {

                        if(Session["IDBaiTap"] != null)
                            MaBT = int.Parse(Session["IDBaiTap"].ToString());
                        else
                        {
                            MaBT= int.Parse(Request.QueryString[0].ToString());
                        }
                          load();
                
            }
        }
        public void load()
        {
            
            
            if (Session["IDNguoiDung"] != null)
            {
                MaKH = int.Parse( Session["IDNguoiDung"].ToString());
                giamgia = XLDL.loaGiamGia(MaKH);
                txtGiamGiaThanhToan.Text = "" + giamgia + "";
            }
            else
            {
                txtGiamGiaThanhToan.Text = "chưa đăng nhập";
                giamgia = 0;
            }
            string sql2 = "select TenBaiTap,HinhMinhHoa,Gia,ThoiHan,GhiChu from DSBT where ID ="+MaBT+"";
            DataTable tb2 = XLDL.GetData(sql2);
            url = tb2.Rows[0][1].ToString();
            tenbaitap.Text = tb2.Rows[0][0].ToString();
            giaDK  =int.Parse( tb2.Rows[0][2].ToString());
            gia.Text= string.Format("{0:N0}", giaDK);
            hethan.Text = tb2.Rows[0][3].ToString();
             url = tb2.Rows[0][1].ToString();
            upAnh.ImageUrl = "~/image_nguoidung/AnhBaiTap/" +url;
            txtChiTiet.Text= tb2.Rows[0][4].ToString();
            loadThanhToan(tb2);

        }
        public void loadThanhToan (DataTable tb)
        {

            txtTenBTThanhToan.Text = tb.Rows[0][0].ToString();
            txtGiamGiaThanhToan.Text = ""+giamgia+"";
            int x=giaDK;
            txtGiaThanhTona.Text = string.Format("{0:N0}", x);
            txtthoihan.Text= tb.Rows[0][3].ToString();           
            if(giamgia==0)
            {
                tongtien = giaDK;
                txtTongTienThanhToan.Text = string.Format("{0:N0}", x);
            }
               
            else
            {
                 tongtien = (giaDK - ((giaDK * giamgia) / 100));
                txtTongTienThanhToan.Text = string.Format("{0:N0}", tongtien);
            }
          
        }
        protected void btnXemThem_Click(object sender, ImageClickEventArgs e)
        {
            
        }
        public static string url = "";
        public static int MaBT;
        public static int giamgia;
        public static int giaDK;
        public static int MaKH=-1;
        public static int tongtien;

        protected void btnDangKy_Click(object sender, ImageClickEventArgs e)
        {
           
        }

        protected void btnLuu_Command(object sender, CommandEventArgs e)
        {

        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            if(MaKH==-1)
            {
                Response.Write("<script> alert ('Bạn chưa đăng nhập') </script>");
            }
            else
            {
                DateTime date = DateTime.Now;
                string ngay = date.ToString("yyyy/MM/dd");
                string ngayhethan = XLDL.TinhNgayHetHan(ngay, int.Parse(txtthoihan.Text));
                string sql4 = "select * from DSDKBT where MaBT =" + MaBT + " and NgayHetHan >= '" + ngay + "' and MaKH ="+MaKH+"";
                if(XLDL.kt(sql4) == 0)
                {
                    string sql = "insert into DSDKBT (MaKH,MaBT,TenBT,HinhMinhHoa,NgayDangKy,NgayHetHan,Gia) values(" + MaKH + "," + MaBT + ",N'" + tenbaitap.Text.Trim() + "','" + url + "','" + ngay + "'," + ngayhethan + "," + giaDK + ")";
                   
                    //  string sql3 = "update DSDKBT set NgayHetHan=" + ngayhethan + " where ID ="+MaHoaDon+"";
                    XLDL.Excute(sql);
                    string sql2 = "select MAX(ID) from DSDKBT";
                    DataTable tbb = XLDL.GetData(sql2);
                    int MaHoaDon = int.Parse(tbb.Rows[0][0].ToString());
                    //  XLDL.Excute(sql3);
                    //Thêm điểm tích lũy
                    string sql5 = "update NguoiDung set DiemTichLuy = DiemTichLuy+10 where ID = " + MaKH + "";
                    XLDL.Excute(sql5);
                    XLDL.CapNhatLoaiKhachHang(MaKH);

                }
                else
                {
                    Response.Write("<script> alert ('Bạn đã đăng ký bài tập này và chưa hết hạn') </script>");
                }


               
            }
        }
    }
}