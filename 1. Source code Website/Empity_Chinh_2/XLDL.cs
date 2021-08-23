using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Text;

namespace Empity_Chinh_2
{
     public static class XLDL
    {
        public static string ConnectString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        // public static string ConnectString = @"Data Source=THANH-LUN-PIPI\SQLEXPRESS;Initial Catalog=QLPhongGymCHinhThuc;Integrated Security=True";
        public static DataTable GetData(String lenhSQL)
        {
            SqlConnection conn = new SqlConnection(ConnectString);
            try
            {
                SqlDataAdapter sqlData = new SqlDataAdapter(lenhSQL, ConnectString);
                DataTable tb = new DataTable() ;
                sqlData.Fill(tb);
                return tb;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static int GetValue( String lenhsql)
        {
            using (SqlConnection sqlcon = new SqlConnection(ConnectString))
            {
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand(lenhsql, sqlcon);
                int value =int.Parse( sqlcmd.ExecuteScalar().ToString());
                sqlcon.Close();
                return (value);
            }
        }
        public static void Excute(String lennhSQL)
        {
            using (SqlConnection sqlcon = new SqlConnection(ConnectString))
            {
                sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand(lennhSQL, sqlcon);
                sqlCmd.ExecuteNonQuery();
                sqlcon.Close();
            }
        }
        public static int kt(String sql)
        {
           
            DataTable dt = XLDL.GetData(sql);
            int dem = dt.Rows.Count;
            if (dem > 0)
                return 1;
            else
                return 0;
        }
        public static float GetDataStore(String lenhSQL)
        {
            SqlConnection conn = new SqlConnection(ConnectString);
            SqlCommand cmm = new SqlCommand();
            cmm = new SqlCommand(lenhSQL, conn);
            cmm.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmm.ExecuteNonQuery();
            SqlDataAdapter sqlData = new SqlDataAdapter();
            sqlData.SelectCommand = cmm;
            DataTable tb = new DataTable();
            sqlData.Fill(tb);
            conn.Close();
            float dt = float.Parse(tb.Rows[0][0].ToString());
            return dt;
        }
        public static bool KiemTraGmail(string emailVerify)
        {
            using (WebClient webclient = new WebClient())
            {
                string url = "http://verify-email.org/";
                NameValueCollection formData = new NameValueCollection();
                formData["check"] = emailVerify;
                byte[] responseBytes = webclient.UploadValues(url, "POST", formData);
                string response = Encoding.ASCII.GetString(responseBytes);
                if (response.Contains("Result: Ok"))
                {
                    return true;
                }
                return false;
            }
        }
        public static int ktDoanhThu(String sql)
        {
            int x = 0;
            DataTable dt = XLDL.GetData(sql);
            if (dt.Rows[0][0].ToString() != "")
                return 1;
            else
                return 0;
        }
        public static bool KiemTraSo(string a)
        {
            a = a.Trim() + "";
            if (a == "") return false;
            else
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == '1' || a[i] == '0' || a[i] == '2' || a[i] == '3' || a[i] == '4' || a[i] == '5' || a[i] == '6' || a[i] == '7' || a[i] == '8' || a[i] == '9')
                        continue;
                    else
                        return false;
                }
                return true;
            }
            
        }
        public static bool KiemTraSoLuong(string sql)
        {
            int sl = int.Parse(sql);
            if (sl == 0)
                return false;
            return true;
        }
        public static bool KiemTraSoLuongMua(string x, string y)
        {
            int a = int.Parse(x);
            int b = int.Parse(y);
            if ((a - b) < 0)
                return false;
            return true;
        }
        public static string TinhNgayHetHan(string s, int sl)
        {
            return "DATEADD(MONTH,"+sl+",'"+s+"')";
        }
        public static String ctien(String x)
        {
            x = string.Format("{0:N0}");
            return x;
        }
        public static void CapNhatSoLuong (int sl, int id)
        {
            string sql = "update ThucPhamBoSung set DaBan =(SoLuong -" + sl + ") where ID = "+id+"";
            Excute(sql);
        }
        public static int loaGiamGia(int MaKH)
        {
           
            string sql = "select l.GiamGia from NguoiDung n, LoaiKhachHang l where l.ID = n.MaLoaiKhoachHang and n.ID=" + MaKH + "";
            DataTable tb = XLDL.GetData(sql);
            return int.Parse(tb.Rows[0][0].ToString());          
        }
        public static void CapNhatLoaiKhachHang (int ID)
        {
            string sql = "select DiemTichLuy, ID from LoaiKhachHang";
            DataTable tb = GetData(sql);
            int i = 0;
            string sql2 = " select DiemTichLuy from NguoiDung where ID =" + ID + "";
            DataTable tb2 = GetData(sql2);
            int diem = int.Parse(tb2.Rows[0][0].ToString());
            int maloai =1;
            while (i<tb.Rows.Count)
            {
                int x = int.Parse(tb.Rows[i][0].ToString());
                int ma = int.Parse(tb.Rows[i][1].ToString());
                if (diem >=x )
                {
                    maloai = ma;
                }
                i++;
            }
            string sql3= "update NguoiDung set MaLoaiKhoachHang="+maloai+" where ID ="+ID +"";
             Excute(sql3);
        }
    }
}