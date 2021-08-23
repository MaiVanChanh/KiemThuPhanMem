using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;


namespace test
{
    [TestFixture]
    public class CreateTest
    {
        private IWebDriver driver;
        private string baseURL;
        private int wrapper;
        private object window;

        [SetUp]
        public void SetupTest()
        {

            driver = new ChromeDriver();
            baseURL = "http://congga-001-site1.itempurl.com";

        }

        [TearDown]
        public void TeardownTest()
        {
            driver.Quit();
        }
 //đăng nhập thành công
        [Test]
   
        [TestCase("Chanh", "1234@chanh")] //đúng tk mk admin
        [TestCase("Chanh1", "1234@chanh")]       //đúng tk mk user
        public void DangNhapthanhcong(string a, string b)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL + "/DangNhap.aspx");
            driver.FindElement(By.Id("txtTaiKhoan")).Click();
            driver.FindElement(By.Id("txtTaiKhoan")).Clear();
            driver.FindElement(By.Id("txtTaiKhoan")).SendKeys(a);
            driver.FindElement(By.Id("txtMatKhau")).Click();
            driver.FindElement(By.Id("txtMatKhau")).Clear();
            driver.FindElement(By.Id("txtMatKhau")).SendKeys(b);

            if (a == "thanh")
            {
                driver.FindElement(By.Id("btn_DangNhap")).Click();

                Assert.AreEqual("Chào mừng nạn đến với quản trị", driver.FindElement(By.LinkText("Chào mừng nạn đến với quản trị")).Text);
            }
            else
            {
                driver.FindElement(By.Id("btn_DangNhap")).Click();
                return;
                Thread.Sleep(2500);
                driver.FindElement(By.Id("Dangxuat")).Click();
            }
        }


 //đăng nhập thất bại                              
        //[test]

        [TestCase("Chanh", "chanh@12345", "")]     //đúng tk sai mk
        [TestCase("Chanh32", "chanh@1234", "")]   //sai tk đúng mk
        [TestCase("", "chanh@1234", "Bạn đã đăng ký tài khoản chưa?")]//null tk đúng mk
        [TestCase("Chanh", "", "Bạn đã đăng ký tài khoản chưa?")]//đúng tk null mk
        [TestCase("", "", "Bạn đã đăng ký tài khoản chưa?")]//null tk mk
        public void DangNhapthatbai(string TaiKhoan, string MatKhau, string x)
        {
            driver.Navigate().GoToUrl(baseURL + "/DangNhap.aspx");
            driver.FindElement(By.Id("txtTaiKhoan")).Click();
            driver.FindElement(By.Id("txtTaiKhoan")).Clear();
            driver.FindElement(By.Id("txtTaiKhoan")).SendKeys(TaiKhoan);
            driver.FindElement(By.Id("txtMatKhau")).Click();
            driver.FindElement(By.Id("txtMatKhau")).Clear();
            driver.FindElement(By.Id("txtMatKhau")).SendKeys(MatKhau);
            if ((TaiKhoan == "Chanh" && MatKhau == "chanh@12345") || (TaiKhoan == "Chanh32" && MatKhau == "chanh@1234")) // chạy 2 test case đầu tiên

            {
                driver.FindElement(By.Id("btn_DangNhap")).Click();
                Assert.AreEqual("Sai tài khoản hoặc mật khẩu", driver.SwitchTo().Alert().Text);
            }
            else
            {
                driver.FindElement(By.Id("btn_DangNhap")).Click();
                Assert.AreEqual(x, driver.FindElement(By.LinkText("Bạn đã đăng ký tài khoản chưa?")).Text);
            }

        }
       
// Đăng ký tài khoản thất bại 
        //[test]
        [TestCase("", "mai@gmail.com", "121", "121")]//null họ tên ,còn lại đúng 
        [TestCase("ga", "", "121", "121")]          //null mail , còn lại đúng
        [TestCase("ga1", "maigmailcom", "121", "121")]// mail sai định dạng tên, còn lại đúng   (test lỗi )(cần thay đổi các thông số test có thể có đã fđk thành công )
        [TestCase("ga2", "mai@gmail.com", "", "121")]// NULL mật khẩu 1, còn lại đúng
        [TestCase("ga3", "mai@gmail.com", "121", "")]// NULL mật khẩu 2, còn lại đúng
        [TestCase("ga4", "mai@gmail.com", "121", "222")]// mật khẩu 1 2 không trùng, còn lại đúng
        [TestCase("ga6", "mai@gmail.com", "121", "121")]//  trùng tên tk, còn lại đúng
        [TestCase("ga90", "mai@gmail.com", "121", "121")]// mk ngắn, còn lại đúng  (test lỗi )(cần thay đổi các thông số test có thể có đã fđk thành công )
        [TestCase("ga91", "mai@gmail.com", "6786786121", "6786786121")]// ko phải có ký tự đặc biệt, còn lại đúng  (test lỗi )(cần thay đổi các thông số test có thể có đã fđk thành công )
        public void Dangkytaikhoan(string Ten, string Mail, string MatKhau1, string MatKhau2)
        {
            driver.Navigate().GoToUrl(baseURL + "/DangKy/DangKy.aspx");
            driver.FindElement(By.Id("firstname")).Click();
            driver.FindElement(By.Id("firstname")).Clear();
            driver.FindElement(By.Id("firstname")).SendKeys(Ten);
            Thread.Sleep(500);
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(Mail);
            Thread.Sleep(500);
            driver.FindElement(By.Id("password1")).Click();
            driver.FindElement(By.Id("password1")).Clear();
            driver.FindElement(By.Id("password1")).SendKeys(MatKhau1);
            Thread.Sleep(500);
            driver.FindElement(By.Id("password2")).Click();
            driver.FindElement(By.Id("password2")).Clear();
            driver.FindElement(By.Id("password2")).SendKeys(MatKhau2);
            Thread.Sleep(500);
            if (Ten == "ga1") //lỗi tiêu chuẩn gmail thiếu. com vẫn đk được
            {
                driver.FindElement(By.Id("btnDangKy")).Click();
                Assert.AreEqual("Sai tài khoản Mail", driver.SwitchTo().Alert().Text);
            }
            else if (Ten == "ga2")
            {
                driver.FindElement(By.Id("btnDangKy")).Click();
                Assert.AreEqual("Mật khẩu không trùng khớp", driver.SwitchTo().Alert().Text);
            }
            else if (Ten == "ga3")
            {
                driver.FindElement(By.Id("btnDangKy")).Click();
                Assert.AreEqual("Mật khẩu không trùng khớp", driver.SwitchTo().Alert().Text);
            }
            else if (Ten == "ga4")
            {
                driver.FindElement(By.Id("btnDangKy")).Click();
                Assert.AreEqual("Mật khẩu không trùng khớp", driver.SwitchTo().Alert().Text);
            }
            else if (Ten == "ga6")
            {
                driver.FindElement(By.Id("btnDangKy")).Click();
                Assert.AreEqual("Tên tài khoản đã tồn tại", driver.SwitchTo().Alert().Text);
            }
            else if (Ten == "ga90")
            {
                driver.FindElement(By.Id("btnDangKy")).Click();
                Assert.AreEqual("mật khẩu quá ngắn", driver.SwitchTo().Alert().Text);
            }
            else if (Ten == "ga91")
            {
                driver.FindElement(By.Id("btnDangKy")).Click();
                Assert.AreEqual("không có ký tự đặc biệt", driver.SwitchTo().Alert().Text);
            }
            else // cho ga và ""
            {
                driver.FindElement(By.Id("btnDangKy")).Click();
                Assert.AreEqual("Chưa đủ dữ liệu để thêm mới", driver.SwitchTo().Alert().Text);

            }
        }

// đăng ký taf khoản thành công
 // cần đăng ký tên khác vì đã tk này đã test
        [TestCase("ga61", "ma2i@gmail.com", "121", "121")]
        public void DangkytaikhoanTC(string Ten, string Mail, string MatKhau1, string MatKhau2)
        {
            driver.Navigate().GoToUrl(baseURL + "/DangKy/DangKy.aspx");
            driver.FindElement(By.Id("firstname")).Click();
            driver.FindElement(By.Id("firstname")).Clear();
            driver.FindElement(By.Id("firstname")).SendKeys(Ten);
            Thread.Sleep(500);
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(Mail);
            Thread.Sleep(500);
            driver.FindElement(By.Id("password1")).Click();
            driver.FindElement(By.Id("password1")).Clear();
            driver.FindElement(By.Id("password1")).SendKeys(MatKhau1);
            Thread.Sleep(500);
            driver.FindElement(By.Id("password2")).Click();
            driver.FindElement(By.Id("password2")).Clear();
            driver.FindElement(By.Id("password2")).SendKeys(MatKhau2);
            Thread.Sleep(500);
            driver.FindElement(By.Id("btnDangKy")).Click();
            Assert.AreEqual("THE GYM", driver.FindElement(By.LinkText("THE GYM")).Text);

        }

//dịch vụ mua nc sting
// Chưa đăng nhập 
        [Test]
        public void DichVu()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL + "/ThucPhamBoSung.aspx");
            Thread.Sleep(2500);
            driver.FindElement(By.Id("ContentPlaceHolder1_dsThuPham_IT1_ImageButton1_1")).Click();
            Thread.Sleep(2500);
            driver.FindElement(By.Id("ContentPlaceHolder1_Image2")).Click();
            Thread.Sleep(2500);
            driver.FindElement(By.Id("ContentPlaceHolder1_btnLuu")).Click();
            Assert.AreEqual("Phải đăng nhập mới thanh toán dc", driver.SwitchTo().Alert().Text);
        }
 // Đã đăng nhập 
        [TestCase("Chanh1", "1234@chanh")] 
        public void DichVu1(string a, string b)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL + "/DangNhap.aspx");
            driver.FindElement(By.Id("txtTaiKhoan")).Click();
            driver.FindElement(By.Id("txtTaiKhoan")).Clear();
            driver.FindElement(By.Id("txtTaiKhoan")).SendKeys(a);
            driver.FindElement(By.Id("txtMatKhau")).Click();
            driver.FindElement(By.Id("txtMatKhau")).Clear();
            driver.FindElement(By.Id("txtMatKhau")).SendKeys(b);
            driver.FindElement(By.Id("btn_DangNhap")).Click();
            Thread.Sleep(2500);
            driver.Navigate().GoToUrl(baseURL + "/ThucPhamBoSung.aspx");
            Thread.Sleep(2500);
            driver.FindElement(By.Id("ContentPlaceHolder1_dsThuPham_IT1_ImageButton1_1")).Click();
            Thread.Sleep(2500);
            driver.FindElement(By.Id("ContentPlaceHolder1_Image2")).Click();
            Thread.Sleep(2500);
            driver.FindElement(By.Id("ContentPlaceHolder1_btnLuu")).Click();
            Thread.Sleep(2500);
            driver.Navigate().GoToUrl(baseURL + "/HoaDon.aspx");
            
         
        }


// Đăng ký bài tập
 // chưa đăng nhập  
 
        [TestCase("/DangKyBaiTap.aspx?id=1")]
        [TestCase("/DangKyBaiTap.aspx?id=2")]
        [TestCase("/DangKyBaiTap.aspx?id=3")]
        [TestCase("/DangKyBaiTap.aspx?id=6")]
        [TestCase("/DangKyBaiTap.aspx?id=9")]
        [TestCase("/DangKyBaiTap.aspx?id=13")]
        public void DangKyBaiTap( string a)
        {
           
            driver.Navigate().GoToUrl(baseURL + a);
            Thread.Sleep(2500);
            driver.FindElement(By.Id("ContentPlaceHolder1_Image2")).Click();
            Thread.Sleep(2500);
            driver.FindElement(By.Id("ContentPlaceHolder1_btnLuu")).Click();
            Thread.Sleep(2500);
            Assert.AreEqual("Bạn cần đăng nhập ", driver.SwitchTo().Alert().Text);// Bạn đã đăng ký bài tập này và chưa hết hạn

        }

 // Đã đăng nhập 
 
        [TestCase("cong", "12sd1","/DangKyBaiTap.aspx?id=1")] //chỉ chạy 1 lần  cần thay đổi tài khoản vì sau khi test thì ddkbt đã lưu trong danh sách ::chay 1 lúc 6 cái có khi nó bị fail 3 cái nên chay từng cái 
        [TestCase("ga6sd1", "sd121","/DangKyBaiTap.aspx?id=2")]
        [TestCase("ga61", "12sd1","/DangKyBaiTap.aspx?id=3")]
        [TestCase("ga6sd1", "1sd21", "/DangKyBaiTap.aspx?id=6")]
        [TestCase("ga61", "121", "/DangKyBaiTap.aspx?id=9")]
        [TestCase("ga61", "121", "/DangKyBaiTap.aspx?id=13")]
        public void DangKyBaiTap1(string a, string b, string c)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL + "/DangNhap.aspx");
            driver.FindElement(By.Id("txtTaiKhoan")).Click();
            driver.FindElement(By.Id("txtTaiKhoan")).Clear();
            driver.FindElement(By.Id("txtTaiKhoan")).SendKeys(a);
            driver.FindElement(By.Id("txtMatKhau")).Click();
            driver.FindElement(By.Id("txtMatKhau")).Clear();
            driver.FindElement(By.Id("txtMatKhau")).SendKeys(b);
            driver.FindElement(By.Id("btn_DangNhap")).Click();
            Thread.Sleep(2500);
            driver.Navigate().GoToUrl(baseURL + c);
            Thread.Sleep(2500);
            driver.FindElement(By.Id("ContentPlaceHolder1_Image2")).Click();
            Thread.Sleep(2500);
            driver.FindElement(By.Id("ContentPlaceHolder1_btnLuu")).Click();
            Thread.Sleep(2500);
            driver.Navigate().GoToUrl(baseURL + "/HoaDon.aspx");
            Thread.Sleep(2500);
          
        }
// chỉnh sửa thông tin 

        [TestCase("Chanh", "1234@chanh","","")] // null tk mk mới
        [TestCase("Chanh", "1234@chanh", "Chanh12", "")]// null  mk mới
        [TestCase("Chanh", "1234@chanh", "", "1234@chanh1")]// null tk  mới
        public void thongtinfail(string a, string b ,string c , string d) // don các thông tin bị nun mà vẫn được chấp nhận
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL + "/DangNhap.aspx");
            driver.FindElement(By.Id("txtTaiKhoan")).Click();
            driver.FindElement(By.Id("txtTaiKhoan")).Clear();
            driver.FindElement(By.Id("txtTaiKhoan")).SendKeys(a);
            driver.FindElement(By.Id("txtMatKhau")).Click();
            driver.FindElement(By.Id("txtMatKhau")).Clear();
            driver.FindElement(By.Id("txtMatKhau")).SendKeys(b);
            driver.FindElement(By.Id("btn_DangNhap")).Click();
            Thread.Sleep(2500);
            driver.Navigate().GoToUrl(baseURL + "/CapNhatThongTin.aspx");
            driver.Navigate().GoToUrl(baseURL + "/CapNhatThongTin.aspx");
            driver.FindElement(By.Id("ContentPlaceHolder1_btnSuaToanBo")).Click();
            Thread.Sleep(2500);
            driver.FindElement(By.Id("ContentPlaceHolder1_txtTaiKhoan")).Click();
            driver.FindElement(By.Id("ContentPlaceHolder1_txtTaiKhoan")).Clear();
            driver.FindElement(By.Id("ContentPlaceHolder1_txtTaiKhoan")).SendKeys(c);
            Thread.Sleep(2500);
            driver.FindElement(By.Id("ContentPlaceHolder1_txtMatKhau")).Click();
            driver.FindElement(By.Id("ContentPlaceHolder1_txtMatKhau")).Clear();
            driver.FindElement(By.Id("ContentPlaceHolder1_txtMatKhau")).SendKeys(d);
            Thread.Sleep(2500);
            driver.FindElement(By.Id("ContentPlaceHolder1_btnluuToanBo")).Click();
            Assert.AreEqual("Lỗi dữ liệu ", driver.SwitchTo().Alert().Text);
        }
// test past các thông tin không quan trọng
        [TestCase("Chanh", "1234@chanh", "Chanhaaa", "Hiệp thành", "0367979432", "maichan@gamil.com")] //đúng hết
        [TestCase("Chanh", "1234@chanh", "Chanhaaa", "", "0367979432", "maichan@gamil.com")]// null địa chỉ
        [TestCase("Chanh", "1234@chanh", "Chanhaaa", "Hiệp thành", "", "maichan@gamil.com")]// null số điện thoại
        [TestCase("Chanh", "1234@chanh", "Chanhaaa", "Hiệp thành", "0367979432", "")]// null gmail
        [TestCase("Chanh", "1234@chanh", "", "Hiệp thành", "0367979432", "maichan@gamil.com")]// null  tên mới // fail vì tên người dùng không được bỏ trống
        public void thongtinpast(string a, string b, string c, string d ,string e, string f)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL + "/DangNhap.aspx");
            driver.FindElement(By.Id("txtTaiKhoan")).Click();
            driver.FindElement(By.Id("txtTaiKhoan")).Clear();
            driver.FindElement(By.Id("txtTaiKhoan")).SendKeys(a);
            driver.FindElement(By.Id("txtMatKhau")).Click();
            driver.FindElement(By.Id("txtMatKhau")).Clear();
            driver.FindElement(By.Id("txtMatKhau")).SendKeys(b);
            driver.FindElement(By.Id("btn_DangNhap")).Click();
            Thread.Sleep(2500);
            driver.Navigate().GoToUrl(baseURL + "/CapNhatThongTin.aspx");
            driver.FindElement(By.Id("ContentPlaceHolder1_btnSuaToanBo")).Click();
            Thread.Sleep(2500);
            driver.FindElement(By.Id("ContentPlaceHolder1_txtHoVaTen")).Click();
            driver.FindElement(By.Id("ContentPlaceHolder1_txtHoVaTen")).Clear();
            driver.FindElement(By.Id("ContentPlaceHolder1_txtHoVaTen")).SendKeys(c);
            Thread.Sleep(2500);
            driver.FindElement(By.Id("ContentPlaceHolder1_txtDiaChi")).Click();
            driver.FindElement(By.Id("ContentPlaceHolder1_txtDiaChi")).Clear();
            driver.FindElement(By.Id("ContentPlaceHolder1_txtDiaChi")).SendKeys(d);
            Thread.Sleep(2500);
            driver.FindElement(By.Id("ContentPlaceHolder1_txtSDT")).Click();
            driver.FindElement(By.Id("ContentPlaceHolder1_txtSDT")).Clear();
            driver.FindElement(By.Id("ContentPlaceHolder1_txtSDT")).SendKeys(e);
            Thread.Sleep(2500);
            driver.FindElement(By.Id("ContentPlaceHolder1_txtGmail")).Click();
            driver.FindElement(By.Id("ContentPlaceHolder1_txtGmail")).Clear();
            driver.FindElement(By.Id("ContentPlaceHolder1_txtGmail")).SendKeys(f);
            Thread.Sleep(2500);
            driver.FindElement(By.Id("ContentPlaceHolder1_btnluuToanBo")).Click();
            Thread.Sleep(2500);
            driver.FindElement(By.Id("ContentPlaceHolder1_txtHoVaTen")).Click();
            if (c == "Chanhaaa")
            {
                Assert.AreEqual("Chanhaaa", driver.FindElement(By.Id("ContentPlaceHolder1_ten")).Text);
            }
            else
            {
                Assert.AreEqual("Lỗi tên người dùng ", driver.SwitchTo().Alert().Text);
            }
        }
    }
}
