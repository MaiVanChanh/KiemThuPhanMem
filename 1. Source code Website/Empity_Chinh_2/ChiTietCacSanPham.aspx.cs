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
    public partial class ChiTietCacSanPham : System.Web.UI.Page
    {
        public static string url="";
      
        public static int giamgia;
        public static int tongtien;
        public static int MaDANU;
        public static int giamua;
        public static int MaKh = -1;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["IDSanPham"] != null)
            {
                //int index = int.Parse(Session["MATP"].ToString());
                MaDANU = int.Parse(Session["IDSanPham"].ToString());
                load();
                
            }
        }
        public void load()
        {
            string sql = @"select ID,TenThucPham,Gia,(SoLuong-DaBan) as cl,HinhMinhHoa from ThucPhamBoSung where ID=" + MaDANU + "";
            DataTable dt = XLDL.GetData(sql);
            {
                txtMa.Text = dt.Rows[0][0].ToString();
                txtTen.Text = dt.Rows[0][1].ToString();
                giamua = int.Parse(dt.Rows[0][2].ToString());
                txtGia.Text = string.Format("{0:N0}", giamua);
                txtConLAi.Text = dt.Rows[0][3].ToString();
                url = dt.Rows[0][4].ToString();
                upAnh.ImageUrl = "../image_nguoidung/AnhSanPham/" + url + "";
                int sl = int.Parse(txtConLAi.Text);
                loadSL(sl);

                if (Session["IDNguoiDung"] != null)
                    loaGiamGia();
                else
                {
                    txtTenTPBSThanhToan.Text = dt.Rows[0][1].ToString();
                    giamua = int.Parse(dt.Rows[0][2].ToString());
                    txtsoLuongThanhToan.Text = "" + (drSoLuong.SelectedIndex + 1) + "";
                    tongtien = giamua * (drSoLuong.SelectedIndex + 1) - (giamua * (drSoLuong.SelectedIndex + 1) * giamgia) / 100;
                    txtTongTienThanhToan.Text = string.Format("{0:N0}", tongtien);
                    txtGiaThanhTona.Text = "" + giamua + "";
                    txtGiamGiaThanhToan.Text = "chưa đăng nhập";
                }
                loadThanhToan(dt);
            }
        }
        public void loadThanhToan(DataTable dt)
        {
            txtTenTPBSThanhToan.Text= dt.Rows[0][1].ToString();
            giamua = int.Parse(dt.Rows[0][2].ToString());
            txtsoLuongThanhToan.Text=""+(drSoLuong.SelectedIndex+1)+"";
            tongtien = giamua * (drSoLuong.SelectedIndex + 1) - (giamua * (drSoLuong.SelectedIndex + 1) * giamgia) / 100;
            txtTongTienThanhToan.Text=string.Format("{0:N0}",tongtien);
            txtGiaThanhTona.Text=""+giamua+"";
        }
        public void loadSL(int sl)
        {
            int i = 1;
            while (i<=sl)
            {
                drSoLuong.Items.Add(""+i+"");
                i++;
            }
        }
        public void loaGiamGia()
        {
            MaKh =  int.Parse(Session["IDNguoiDung"].ToString());          
            txtGiamGiaThanhToan.Text = "" + XLDL.loaGiamGia(MaKh) + "";
            giamgia = XLDL.loaGiamGia(MaKh);
        }
        
        protected void btnMua_Click(object sender, ImageClickEventArgs e)
        {
            

        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            if (Session["IDNguoiDung"] !=null)
            {
                int.Parse(drSoLuong.SelectedItem.Text);
                if (int.Parse(txtConLAi.Text) > 0)
                {
                    int x = drSoLuong.SelectedIndex + 1;
                    int y = int.Parse(txtConLAi.Text);
                    if (x > y)
                    {
                        Response.Write("<script> alert ('Số lượng mua lớn hơn số lượng còn  ') </script>");

                    }
                    else
                    {
                        


                        //  string sql3 = "select l.GiamGia from NguoiDung n, LoaiKhachHang l where l.ID = n.MaLoaiKhoachHang and n.ID=" + MaKH + "";
                        // DataTable tb = XLDL.GetData(sql3);
                        //  giamgia = int.Parse(tb.Rows[0][0].ToString());

                        DateTime d = DateTime.Now;
                        string ngay = d.ToString("yyyy/MM/dd");
                        string sql = " update ThucPhamBoSung set DaBan=DaBan+" + (drSoLuong.SelectedIndex + 1) + " where ID =" + int.Parse(txtMa.Text.Trim()) + "";
                        string sql2 = "insert into HoaDonThucPhamBoSung (HinhMinhHoa,MaTPBS,TenThucPham,MaKH,Gia,SoLuong,TongTien,NgayMua) values ('"+url+"',"+ MaDANU + ",N'"+txtTenTPBSThanhToan.Text.Trim()+"',"+MaKh+","+giamua+","+(drSoLuong.SelectedIndex+1)+","+tongtien+",'"+ngay+"')";
                        XLDL.Excute(sql);
                        XLDL.Excute(sql2);
                        //cập nhật điểm tích luy
                        int diem = drSoLuong.SelectedIndex + 1;
                        string sql5 = "update NguoiDung set DiemTichLuy=DiemTichLuy +" + (diem * 5) + " where ID =" + MaKh + "";
                        XLDL.Excute(sql5);
                        load();

                    }
                }
                else
                {
                    Response.Write("<script> alert ('Tạm thời hết sản phẩm  ') </script>");
                }
            }
            else
            {
                Response.Write("<script> alert ('Phải đăng nhập mới thanh toán dc') </script>");

            }
        }
    }
}