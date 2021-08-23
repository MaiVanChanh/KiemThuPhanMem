using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace Empity_Chinh_2.Admin
{
    public partial class ThucPhamBoSung : System.Web.UI.Page
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
            string sql = string.Format("select ID,HinhMinhHoa,TenThucPham,Gia,SoLuong,Daban,MaLoaiThucPham  from ThucPhamBoSung");
            gr.DataSource = XLDL.GetData(sql);
            gr.DataBind();
        }
        public string cd(object s)
        {
            int x = (int)s;
            string sql = "select TenThucPham from LoaiThucPham where ID=" + x + " ";
            DataTable tb = XLDL.GetData(sql);
            string ten = tb.Rows[0][0].ToString();
            return ten;
        }
        protected void gr_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gr.PageIndex = e.NewPageIndex;
            load();
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ThemDuLieu/ThemThucPhamBoSung.aspx");
        }

        protected void gr_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gr.EditIndex = e.NewEditIndex;
            load();
        }

        protected void gr_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int r = e.RowIndex;
            int ma = int.Parse(gr.DataKeys[r][0].ToString());
           
            int daban = int.Parse(gr.Rows[r].Cells[5].Text);
            if(daban ==0)
            {
                string sql = "delete from ThucPhamBoSung where ID = " + ma + " ";
                XLDL.Excute(sql);
                gr.EditIndex = -1;
                load();
            }
            else
            {
                Response.Write("<script> alert ('Đã có khách hàng mua nên không xóa đưuọc') </script>");
            }
           
        }

        protected void gr_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gr.EditIndex == -1)
            {
                var buttn = e.Row.Cells[7].Controls[2];
                ((LinkButton)buttn).OnClientClick = "return confirm('Bạn có chắc chắn muốn xóa không ?');";
            }
        }

        protected void gr_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int r = e.RowIndex;
            int ma = int.Parse(gr.DataKeys[r][0].ToString());
            var s = gr.Rows[r].Cells[3].Controls[0] as TextBox;
            string ss = s.Text;
            if (XLDL.KiemTraSo(ss)==true)
            {
                float gia = float.Parse(ss);
                string sql = "update ThucPhamBoSung set Gia=" + gia + " where ID="+ma+"";
                XLDL.Excute(sql);
                gr.EditIndex = -1;
                load();
            }
            else
            {
                Response.Write("<script> alert ('Giá chỉ có nhập số ') </script>");
                load();
            }
            
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
        protected void upAnh_Load(object sender, EventArgs e)
        {

        }
        public void luuAnh(String url)
        {
            
                upAnh.SaveAs(MapPath("~/image_nguoidung/AnhSanPham/" + upAnh.FileName));
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtGia.Text != "" && txtSoLuong.Text != "" && txtTenDANU.Text != "" && upAnh.FileName != "")
            {
                if (KiemTraSo(txtGia.Text) == true)
                {
                    string url = upAnh.FileName;
                    luuAnh(url);
                    string sql = "insert into ThucPhamBoSung(TenThucPham,HinhMinhHoa,Gia,SoLuong,MaLoaiThucPham) values (N'" + txtTenDANU.Text + "','" + url + "'," + float.Parse(txtGia.Text) + "," + int.Parse(txtSoLuong.Text) + "," + (drloaiThucPham.SelectedIndex + 1) + ")";
                    XLDL.Excute(sql);
                    Response.Write("<script> alert ('Bạn đã thêm mới thành công ') </script>");
                    load();
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

        protected void gr_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gr.EditIndex = -1;
            load();
            
        }

        protected void btnTimTenThucPham_Click(object sender, EventArgs e)
        {
            if(txtNhapTenThucPhamTim.Text.Trim()=="")
            {
                load();
            }
            else
            {
                string ten = txtNhapTenThucPhamTim.Text.Trim();
                string sql = "select ID,HinhMinhHoa,TenThucPham,Gia,SoLuong,Daban,MaLoaiThucPham  from ThucPhamBoSung where TenThucPham like '%"+ten+"%'";
                 gr.DataSource=XLDL.GetData(sql);
                gr.DataBind();
            }
        }

        protected void btnTimNhomThucPham_Click(object sender, EventArgs e)
        {
            int ma = drNhomThucPham.SelectedIndex + 1;
            string sql = "select ID,HinhMinhHoa,TenThucPham,Gia,SoLuong,Daban,MaLoaiThucPham  from ThucPhamBoSung where MaLoaiThucPham="+ma+"";
            gr.DataSource = XLDL.GetData(sql);
            gr.DataBind();
        }

        protected void btntimMaThucPham_Click(object sender, EventArgs e)
        {
           string s= txtTimMaThucPham.Text.Trim();
            if(XLDL.KiemTraSo(s)==false || txtTimMaThucPham.Text.Trim()=="")
            {
                Response.Write("<script> alert ('Mã bắt buộc phải là số ') </script>");
                load();

            }
            else
            {
                int ma = int.Parse(s);
                string sql = "select ID,HinhMinhHoa,TenThucPham,Gia,SoLuong,Daban,MaLoaiThucPham  from ThucPhamBoSung where ID=" + ma + "";
                gr.DataSource = XLDL.GetData(sql);
                gr.DataBind();
            }
        }
    }
}