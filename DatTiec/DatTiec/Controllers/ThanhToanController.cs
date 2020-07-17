using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatTiec.Models;

namespace DatTiec.Controllers
{
    public class ThanhToanController : Controller
    {
        //
        // GET: /ThanhToan/
        Model1 dbc = new Model1();
        public ActionResult Index()
        {

            if (Session["MaKH"] == null)
            {
                return View();
            }
            else
            {
                string makh = Session["MaKH"].ToString();
                var model = dbc.DatSanhs.Where(th => th.MaKH == makh).ToList();
                var model2 = dbc.DatMons.Where(th => th.MaKH == makh).ToList();

                ViewBag.abc = from s in model
                              join sa in dbc.Dichvus on s.IdDichVu equals sa.iddichvu
                              select new DanhSachDatSanh { IdDatSanh = s.IdDatSanh, iddichvu = s.IdDichVu, Tendichvu = sa.Tendichvu, Hinhanh = sa.Hinhanh, NgayToChuc = s.NgayToChuc, ThoiGianToChuc = s.ThoiGianToChuc,ThanhTien = s.ThanhTien  };
                ViewBag.dsdatmon = from s in model2
                                   join sa in dbc.MonAns on s.IdMon equals sa.idmonan
                                   select new DanhSachDatMon { IdDatMon = s.IdDatMon, idmonan = s.IdMon, Tenmon = sa.Tenmon, Hinhanh = sa.Hinhanh, NgayToChuc = s.NgayToChuc, ThoiGianToChuc = s.ThoiGianToChuc , ThanhTien  = s.ThanhTien };

                return View();
            }
     
        }
        public ActionResult XoaDatSanh(int id)
        {
            var model = dbc.Database.ExecuteSqlCommand("DELETE  FROM [tiec cuoi].[dbo].[DatSanh] where IdDatSanh=" + id);

            dbc.SaveChanges();
            return RedirectToAction("Index", "ThanhToan");
        }
        public ActionResult XoaDatMon(int id)
        {
            var model = dbc.Database.ExecuteSqlCommand("DELETE  FROM [tiec cuoi].[dbo].[DatMon] where IdDatMon=" + id);

            dbc.SaveChanges();
            return RedirectToAction("Index", "ThanhToan");
        }
    }
}
