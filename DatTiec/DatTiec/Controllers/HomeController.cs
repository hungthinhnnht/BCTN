using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatTiec.Models;

namespace DatTiec.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        Model1 dbc = new Model1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SlideHome()
        {
            return PartialView("_SlideHome");
        }
        public ActionResult ThucDon()
        {
            return PartialView("_ThucDon");
        }
        public ActionResult SuKien()
        {
            return PartialView("_SuKien");
        }
        public ActionResult YKienKhachHang()
        {
            return PartialView("_YKienKhachHang");
        }
        public ActionResult DatTiecNhanh()
        {
            return PartialView("_DatTiecNhanh");
        }
       
        public ActionResult _DangKy()
        {
            return PartialView("_DangKy");
        }

        public ActionResult DangKy(string Hoten, string Tendangnhap,string Email, string Diachi, string Dienthoai,
            string MatKhau, string MatKhau2)
        {
           
            var user = dbc.KhachHangs.Where(th => th.Tendangnhap == Tendangnhap).ToList();
            var user_check = dbc.KhachHangs.ToList().Max(th => th.MaKH);

            int idlonnhat = Int32.Parse(user_check.Substring(2));

            int idlonnhat2 = idlonnhat + 1;

            if (MatKhau != MatKhau2 )
            {
                ModelState.AddModelError("", "Xác nhận mật khẩu không thành công");
                return PartialView("_DangKy");

            }
            else if (user.Count == 0)
            {
                //lưu bảng khách hàng
                var model = new KhachHang();
                model.MaKH = "KH" + idlonnhat2.ToString();
                model.Tendangnhap = Tendangnhap;
                model.Hoten = Hoten;
                model.MatKhau = MatKhau;
                model.Email = Email;
                model.Diachi = Diachi;
                model.Dienthoai = Dienthoai;
                dbc.KhachHangs.Add(model);
                dbc.SaveChanges();
              

                //lưu bảng người dùng
                var model2 = new NguoiDung();
                model2.Tendn = model.Tendangnhap;
                model2.Matkhau = model.MatKhau;
                model2.Hoten = model.Hoten;
                model2.Email = model.Email;
                model2.Trangthai = true;
                model2.Quyen = false;
                dbc.NguoiDungs.Add(model2);
                dbc.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản này đã được sử dụng");
                return PartialView("_DangKy");
            }
            return PartialView("_DangNhap");
        }
        public ActionResult _DangNhap()
        {
            return PartialView("_DangNhap");
        }
        [HttpPost]
        public ActionResult _DangNhapLog(string Tendn, string Matkhau)
        {
            Session.Remove("tinhtrangdat");
            var tk = new NguoiDung();
            var user = dbc.NguoiDungs.Where(p => p.Tendn == Tendn).SingleOrDefault();
            var kh = dbc.KhachHangs.Where(p => p.Tendangnhap == Tendn).SingleOrDefault();
            if (user != null) 
            {
                if (user.Matkhau == Matkhau)
                {
                    //ModelState.AddModelError("", "đúng tên và đúng mật khẩu");
                    string[] kh_log = new string[2];
                    kh_log[0] = user.Hoten;
                    kh_log[1] = Matkhau;

                    Session["User"] = user.Hoten;
                    Session["MaKH"] = kh.MaKH;

                    if (user.Quyen == false)
                    {
                        Session["quyen"] = "khachhang";
                        return RedirectToAction("Index", "Home", new { area = "nh"});
                    }
                    else
                    {
                        return Redirect("http://localhost:53056/Admin/TrangChu.aspx");
                        //ModelState.AddModelError("", "Vào trang Admin nhưng chưa có trang Admin");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Mật khẩu không chính xác vui lòng nhập lại !");
                }
            }
            else
            {
                ModelState.AddModelError("", "Sai tên đăng nhập");
            }
            return PartialView("_DangNhap");
        }

        public ActionResult DangXuat()
        {
            if (Session.Count > 0)
            {
                if (Session["quyen"] != null || Session["quyen"].ToString() != "")
                {
                   
                    Session.Remove("User");
                    Session["quyen"] = null;
                    Session.Remove("Admin");
                   
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
             return RedirectToAction("Index", "Home");
        }
        public ActionResult GioHang()
        {

            if (Session["MaKH"] == null)
            {
                return PartialView("_GioHang");
            }
            else
            {
                string makh = Session["MaKH"].ToString();
                var model = dbc.DatSanhs.Where(th => th.MaKH == makh).ToList();
                var model2 = dbc.DatMons.Where(th => th.MaKH == makh).ToList();

                ViewBag.abc = from s in model
                              join sa in dbc.Dichvus on s.IdDichVu equals sa.iddichvu
                              select new DanhSachDatSanh { IdDatSanh = s.IdDatSanh, iddichvu = s.IdDichVu , Tendichvu = sa.Tendichvu , Hinhanh = sa.Hinhanh , NgayToChuc = s.NgayToChuc , ThoiGianToChuc = s.ThoiGianToChuc, ThanhTien=s.ThanhTien   };
                ViewBag.dsdatmon = from s in model2
                              join sa in dbc.MonAns on s.IdMon equals sa.idmonan
                              select new DanhSachDatMon { IdDatMon = s.IdDatMon, idmonan = s.IdMon, Tenmon = sa.Tenmon, Hinhanh = sa.Hinhanh, NgayToChuc = s.NgayToChuc, ThoiGianToChuc = s.ThoiGianToChuc, ThanhTien = s.ThanhTien  };
               
                return PartialView("_GioHang", model);
            }
           
        }
        public ActionResult XoaDatSanh(int id)
        {
            var model = dbc.Database.ExecuteSqlCommand("DELETE  FROM [tiec cuoi].[dbo].[DatSanh] where IdDatSanh=" + id);
            
            dbc.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult XoaDatMon(int id)
        {
            var model = dbc.Database.ExecuteSqlCommand("DELETE  FROM [tiec cuoi].[dbo].[DatMon] where IdDatMon=" + id);

            dbc.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ThongTinTaiKhoan(string id)
        {
            //IQueryable<KhachHang> kh;

            //kh = from s in dbc.loaiDichVus
            //     select s;
            //ViewBag.KhachHang = kh;
            var model = dbc.KhachHangs.Where(th => th.MaKH == id).ToList();

            return PartialView("_ThongTinTaiKhoan", model);
        }
        public ActionResult ChinhSuaTaiKhoan(string id)
        {
            var model = dbc.KhachHangs.Find(id);
            return PartialView("_ChinhSuaTaiKhoan", model);
        }

        public ActionResult UpdateCanFile(KhachHang kh)
        {

            if (ModelState.IsValid)
            {
                var abc = kh.MaKH;
                dbc.Entry(kh).State = System.Data.Entity.EntityState.Modified;

                dbc.SaveChanges();

                return RedirectToAction("ThongTinTaiKhoan", "Home", new { @id = kh.MaKH });
            }
            dbc.Entry(kh).State = System.Data.Entity.EntityState.Modified;

            dbc.SaveChanges();

            return RedirectToAction("ThongTinTaiKhoan", "Home", new { @id = kh.MaKH });
        }
      
    }
}
