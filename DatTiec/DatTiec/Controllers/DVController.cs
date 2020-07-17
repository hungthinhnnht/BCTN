using DatTiec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DatTiec.Controllers
{
    public class DVController : Controller
    {
        //
        // GET: /DV/
        Model1 dte = new Model1();
        Model1 dattiec = new Model1();
        public ActionResult Index()
        {
            IQueryable<loaiDichVu> dv;
            
            dv = from s in dte.loaiDichVus
                 select s;
            ViewBag.LoaiDichVu = dv;


            var model = dte.Menusans.ToList();
            //ViewBag.DSMN = dte.Menusans.ToList();
            //ViewBag.dsmontungmenu = from a in model
            //                        join b in dte.CTMenus on a.Masomenu equals b.Masomenu
            //                       join c in dte.MonAns on b.idmonan equals c.idmonan
            //                        select new DanhSachMonAnTungMenu {MaSoMenu = a.Masomenu, idMonAn = b.idmonan, TenMonAn = c.Tenmon, TenMenu = a.Tengoi };

            //ViewBag.dsmontungmenu = dte.Database.SqlQuery<int>("SELECT distinct a.Tengoi ,a.Gia,b.idmonan,c.Tenmon FROM [tiec cuoi].[dbo].[Menusan] as a inner join [tiec cuoi].[dbo].[CTMenu] as b  on a.Masomenu = b.Masomenu inner join [tiec cuoi].[dbo].[MonAn] as con b.idmonan = c.idmonan");
            return View();
        }
        //public ActionResult LayMonTungMenu(string Masomenu)
        //{

        //    var dsmontungmenu = dte.CTMenus.Where(nh => nh.Masomenu == Masomenu)
        //                    .Select(nh => new { idmonan = nh.idmonan });

        //    return Json(dsmontungmenu, JsonRequestBehavior.AllowGet);



        //}
        public ActionResult ChiTietTiec()
        {
            return PartialView("ChiTietTiec");
        }


        public ActionResult TinTuc()
        {
            IQueryable<TinTuc> tt;

            tt = from s in dte.TinTucs
                 select s;
            ViewBag.TinTuc = tt.OrderByDescending(th => th.Ngaydang).Take(5);
            return PartialView("_TinTuc");
        }


       
        public ActionResult ChiTietTinTuc( string id)
        {
            

            var CTTT = dte.TinTucs.Where(th => th.idtin == id).ToList();
            return PartialView("_ChiTietTinTuc", CTTT);
        }


        public ActionResult LayDanhSachDichVu(string id)
        {
            var model = dte.Dichvus.Where(th => th.idloai == id).ToList();
            Session.Remove("tinhtrangdat");
            return PartialView("_DanhSachDichVu",model);
        }



        public ActionResult LayChiTietDichVu(string id)
        {

            var model = dte.Dichvus.Where(th => th.iddichvu == id).ToList();
            return PartialView("_ChiTietDichVu", model);
        }
        public ActionResult DatDichVu(DatSanh ds, string LoaiDichVu)
        {
            if (LoaiDichVu == "LDV005")
            {

                var kiemtrasanh = dte.DatSanhs.Where(th => th.IdDichVu == ds.IdDichVu).ToList();
                var kiemtrasanh2 = kiemtrasanh.Where(th => th.IdDichVu == ds.IdDichVu && th.NgayToChuc.Value.Year == ds.NgayToChuc.Value.Year && th.NgayToChuc.Value.Month == ds.NgayToChuc.Value.Month && th.NgayToChuc.Value.Day == ds.NgayToChuc.Value.Day).ToList();
                var kiemtrasanh3 = kiemtrasanh.Where(th => th.IdDichVu == ds.IdDichVu && th.NgayToChuc == ds.NgayToChuc && th.IdDichVu == ds.IdDichVu).ToList();
                var kiemtrasanh4 = kiemtrasanh.Where(th => th.IdDichVu == ds.IdDichVu && th.NgayToChuc.Value.Year == ds.NgayToChuc.Value.Year && th.NgayToChuc.Value.Month == ds.NgayToChuc.Value.Month && th.NgayToChuc.Value.Day == ds.NgayToChuc.Value.Day && th.ThoiGianToChuc.ToString() == ds.ThoiGianToChuc.ToString()).ToList();
                var kiemtrasanh5 = kiemtrasanh.Where(th => th.IdDichVu == ds.IdDichVu && th.NgayToChuc.Value.Year == ds.NgayToChuc.Value.Year && th.NgayToChuc.Value.Month == ds.NgayToChuc.Value.Month && th.NgayToChuc.Value.Day == ds.NgayToChuc.Value.Day && th.ThoiGianToChuc.ToString() == ds.ThoiGianToChuc.ToString() && th.IdDichVu.ToString() == ds.IdDichVu.ToString()).ToList();
                if (kiemtrasanh.Count != 0 && kiemtrasanh2.Count != 0 && kiemtrasanh3.Count != 0 && kiemtrasanh4.Count != 0 && kiemtrasanh5.Count != 0)
                {

                    ModelState.AddModelError("", "Sảnh này đã được đặt");
                    Session["tinhtrangdat"] = "daduocdat";
                    return RedirectToAction("LayChiTietDichVu", "DV", new { @id = ds.IdDichVu });
                }
                else
                {
                    DatSanh model = new DatSanh();
                    model.NgayToChuc = ds.NgayToChuc;
                    model.ThoiGianToChuc = ds.ThoiGianToChuc;
                    model.DiaChi = ds.DiaChi;
                    model.GhiChu = ds.GhiChu;
                    model.MaKH = ds.MaKH;
                    model.IdDichVu = ds.IdDichVu;
                    var giatien = dte.Dichvus .FirstOrDefault(th => th.iddichvu.ToString() == model.IdDichVu);
                    int a = Convert.ToInt32(giatien.Gia);
                    model.ThanhTien = a;

                    Session.Remove("tinhtrangdat");
                    Session["tinhtrangdat"] = "datthanhcong";
                    dte.DatSanhs.Add(model);
                    dte.SaveChanges();
                }
             
            }
            else
            {
                
                DatSanh model = new DatSanh();
                model.NgayToChuc = ds.NgayToChuc;
                model.ThoiGianToChuc = ds.ThoiGianToChuc;
                model.DiaChi = ds.DiaChi;
                model.GhiChu = ds.GhiChu;
                model.MaKH = ds.MaKH;
                model.IdDichVu = ds.IdDichVu;

                Session.Remove("tinhtrangdat");
                Session["tinhtrangdat"] = "datthanhcong";
                dte.DatSanhs.Add(model);
                dte.SaveChanges();
                   
              
            }
            return RedirectToAction("LayChiTietDichVu", "DV", new { @id = ds.IdDichVu });
        }
    }
}
