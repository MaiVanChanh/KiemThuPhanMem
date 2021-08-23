using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Empity_Chinh_2
{
    public partial class CapNhatThongTin : System.Web.UI.Page
    {
        public static int bien = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                an();
                if (Session["IDNguoiDung"] != null)
                {
                    id = int.Parse(Session["IDNguoiDung"].ToString());
                    if (KiemTraQuanTri(id) == true)
                    {
                        UuTien = 1;
                        btnQuanLai.Visible = true;
                        loadQuanTri();
                    }
                    else
                        load();
                }
                else
                {
                    an();
                    load();
                }

            }



        }
        public static string anhcosan = "";
        public static int UuTien = 0;
        public static int id = -1;
        public Boolean KiemTraQuanTri(int id)
        {
            string sql = "select MaBoPhan from NguoiDung where ID=" + id + "";
            DataTable tb = XLDL.GetData(sql);
            int x = int.Parse(tb.Rows[0][0].ToString());
            if (x == 0)
                return false;
            else
                return true;

        }
        public string chuyentenbophan (string id)
        {
            string sql = "select TenBoPhan from LoaiBoPhan where ID =" + id + "";
            DataTable tb = XLDL.GetData(sql);
            return tb.Rows[0][0].ToString();
        }
        public string chuyenluong(string id)
        {
            string sql = "select LuongCoban from LoaiBoPhan where ID =" + id + "";
            DataTable tb = XLDL.GetData(sql);
            int x = int.Parse(tb.Rows[0][0].ToString());
            return string.Format("{0:N0}",x);
        }
        public void loadQuanTri()
        {
            string sql = "select * from NguoiDung where ID=" + id + "";
            DataTable tb = XLDL.GetData(sql);
            anhcosan = tb.Rows[0][1].ToString();
            upanh.ImageUrl = "~/image_nguoidung/AnhDaiDien/" + anhcosan;
            txtHoVaTen.Text = tb.Rows[0][2].ToString();
            txt2.Text = tb.Rows[0][8].ToString();
            txtTaiKhoan.Text = tb.Rows[0][3].ToString();
            TenLoaiKhachHangHoacBoPhan.Text = "Bộ phận làm việc :";
            txtLoaiKhachHang.Text = chuyentenbophan(tb.Rows[0][9].ToString());
            DiemTichLuyHoacLuong.Text = "Lương nhận :";
            txtDiemTichLuy.Text= chuyenluong(tb.Rows[0][9].ToString());
            txtMatKhau.Text = tb.Rows[0][4].ToString();
            ten.Text = tb.Rows[0][2].ToString();
            int gt = int.Parse(tb.Rows[0][12].ToString());
            if (gt == 1)
                gioitinh.SelectedIndex = 0;
            else gioitinh.SelectedIndex = 1;
            DateTime day = (DateTime)(tb.Rows[0][13]);   
            txtNgayDangKy.Text = day.ToString("dd/MM/yyyy");
           
        }
        public void load()
        {
     
            string sql = "select * from NguoiDung where ID=" +id+ "";
            DataTable tb = XLDL.GetData(sql);
          
            anhcosan= tb.Rows[0][1].ToString();
            upanh.ImageUrl = "~/image_nguoidung/AnhDaiDien/" + anhcosan;
            txtHoVaTen.Text = tb.Rows[0][2].ToString();
            txt2.Text = tb.Rows[0][8].ToString();
            txtTaiKhoan.Text = tb.Rows[0][3].ToString();
            txtLoaiKhachHang.Text = chuyen(tb.Rows[0][10].ToString());
            txtMatKhau.Text = tb.Rows[0][4].ToString();
            ten.Text = tb.Rows[0][2].ToString();
            int gt = int.Parse(tb.Rows[0][12].ToString());
            if (gt == 1)
                gioitinh.SelectedIndex = 0;
            else gioitinh.SelectedIndex = 1;
            DateTime day = (DateTime)(tb.Rows[0][13]);
            txtNgayDangKy.Text = day.ToString("d");
            txtDiemTichLuy.Text = tb.Rows[0][11].ToString();
        }
        public string chuyen(string id)
        {
            string sql = "select TenLoai from LoaiKhachHang where ID =" + id + " ";
            DataTable tb = XLDL.GetData(sql);
            return tb.Rows[0][0].ToString();
        }
        private void an()
        {
            txtHoVaTen.Enabled = false;
            txt2.Enabled = false;
            txtDiaChi.Enabled = false;
            txtGmail.Enabled = false;
            txtTaiKhoan.Enabled = false;
            txtMatKhau.Enabled = false;
            txtSDT.Enabled = false;
            gioitinh.Enabled = false;
            chonanh.Visible = false;
            btnluuToanBo.Enabled = false;
        }
        private void hien()
        {
            txtHoVaTen.Enabled = true;
            txt2.Enabled = true;
            txtDiaChi.Enabled = true;
            txtGmail.Enabled = true;
            txtTaiKhoan.Enabled = true;
            txtMatKhau.Enabled = true;
            txtSDT.Enabled = true;
            gioitinh.Enabled = true;
            chonanh.Visible = true;
            btnluuToanBo.Enabled = true;
        }
        public bool ktSDT(String x)
        {
            foreach(char c in x)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public void ThemAnh()
        {
            if(loadanh.FileName!="")
                loadanh.SaveAs(MapPath("~/image_nguoidung/AnhDaiDien/"+ loadanh.FileName));
        }
        public void xoaanh()
        {
            if (anhcosan != "")
            {
                string directoryimg = Server.MapPath(upanh.ImageUrl);
                System.IO.File.Delete(directoryimg);
            }
        }
        protected void btnluuToanBo_Click(object sender, EventArgs e)
        {
            if(bien==1)
            {
                var x = txt2.Text;
                    string ten = txtHoVaTen.Text.Trim();
                    string dc = txtDiaChi.Text.Trim();
                    int gt = gioitinh.SelectedIndex;
                int tuoi = 0;
                if (x != "")
                {
                     tuoi = int.Parse((x));
                }
                string sql;
                    string gmail = (string)txtGmail.Text.ToString();
                    string sdt = (string)txtSDT.Text;
                    string tk = txtTaiKhoan.Text.Trim();
                    string mk = txtMatKhau.Text.Trim();
                string anh = "";
              
                if (url != "")
                {
                    anh = url; 
                }

                if(tuoi !=0)
                {
                    
                        sql = "UPDATE NguoiDung Set HinhMinhHoa='" + anh + "', TenNguoiDung=N'" + ten + "', TK='" + tk + "', Pass='" + mk + "', DiaChi=N'" + dc + "', SDT='" + sdt + "', Gmail='" + gmail + "', Tuoi=" + tuoi + ", GioiTinh=" + gt + " where ID =" + id + "";
                    
                }
                else
                {
                    
                        sql = "UPDATE NguoiDung Set HinhMinhHoa='" + anh + "', TenNguoiDung=N'" + ten + "', TK='" + tk + "', Pass='" + mk + "', DiaChi=N'" + dc + "', SDT='" + sdt + "', Gmail='" + gmail + "', GioiTinh=" + gt + " where ID ="+id+"";
                    
                }
                XLDL.Excute(sql);
                if (UuTien == 0)
                    load();
                else
                {
                    loadQuanTri();
                   
                }
                   
                an();
                bien = 0;
            }
        }

        protected void btnSuaToanBo_Click(object sender, EventArgs e)
        {
                hien();
                bien = 1;           
        }
        public static string url="";
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(loadanh.FileName=="")
            {
                Response.Write("<script> alert ('Chưa chọn ảnh') </script>");
            }
            else
            {
                xoaanh();
                ThemAnh();
                anhcosan= url = loadanh.FileName;
                upanh.ImageUrl = "~/image_nguoidung/AnhDaiDien/"+ loadanh.FileName;
                
            }
        }

        protected void btnQuanLai_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Doanhthu.aspx");
        }
    }
}