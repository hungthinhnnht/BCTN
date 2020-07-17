using DatTiec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
namespace DatTiec.Controllers
{
    public class BangGiaController : Controller
    {
        //
        // GET: /BangGia/
        Model1 dte = new Model1();
        public ActionResult Index()
        {

         
            //IQueryable<DanhSachCacMon> dscm;
       
              //Lien KET BANG  
            //dscm = from s in dte.MonAns
            //       join b in dte.LoaiMons on s.idloaimon equals b.idloaimon
            //        select new DanhSachCacMon {idmonan = s.idmonan ,Tenloai = b.Tenloai,Tenmon = s.Tenmon,Gia = s.Gia};
            //ViewBag.TT = dscm;


            IQueryable<LoaiMon> ma;
            Session.Remove("tinhtrangdatmon");
            ma = from s in dte.LoaiMons
                 select s;
            ViewBag.monan = ma;

            //var model = dte.Menusans.ToList().Distinct();
            ////ViewBag.DSMN = dte.Menusans.ToList();
            //ViewBag.dsmontungmenu = (from a in model.Distinct()
            //                        join b in dte.CTMenus on a.Masomenu equals b.Masomenu
            //                      join c in dte.MonAns on b.idmonan equals c.idmonan
            //                        select new DanhSachMonAnTungMenu {MaSoMenu = a.Masomenu, idMonAn = b.idmonan, TenMonAn = c.Tenmon, TenMenu = a.Tengoi } );


            return View();
        }
        public JsonResult LayMenuID()
        {
            IEnumerable<Menusan> ee = null;
            ee = dte.Menusans.ToList();
            ViewBag.DSMN = ee;

            return Json(new { mn = ViewBag.DSMN}, JsonRequestBehavior.AllowGet);



        }
        public JsonResult LayMonTungMenu(string Masomenu)
        {

            var dsmontungmenu = dte.CTMenus.Where(nh => nh.Masomenu == Masomenu)
                            .Select(nh => new { idmonan = nh.idmonan });

            return Json(dsmontungmenu, JsonRequestBehavior.AllowGet);



        }
        public ActionResult ChiTietMonAn()
        {
            return PartialView("ChiTietMonAn");
        }
        public ActionResult DanhSachMonAn()
        {
            return PartialView("_DanhSachMonAn");
        }
        public ActionResult LayDanhSachMon(string id)
        {
            //int a;
            //a = id;
            IQueryable<DanhSachCacMon> dscm;

           // Lien KET BANG  
            //dscm = from s in dte.MonAns
            //       join b in dte.LoaiMons on s.idloaimon equals b.idloaimon
            //        select new DanhSachCacMon {idmonan = s.idmonan ,Tenloai = b.Tenloai,Tenmon = s.Tenmon,Gia = s.Gia};

            var model = dte.MonAns.Where(th => th.idloaimon == id).ToList();
            //ViewBag.TT = dscm;
            ViewBag.abc = dte.LoaiMons.Where(th => th.idloaimon == id).ToList();


            return PartialView("_DanhSachMonAn", model);
        } 

         public ActionResult LayChiTietMon(string id)
        {

            var model = dte.MonAns.Where(th => th.idmonan == id).ToList();
            return PartialView("ChiTietMonAn", model);
        }
         public ActionResult LuuDatMon(string idmonan)
         {
             string abc = idmonan;

             var dsChon = dte.MonAns.Where(th => th.idmonan == idmonan)
                           .Select(th => new { idmonan = th.idmonan, Tenmon = th.Tenmon });
                           
            //var cde = dsChon.Where(th => th.idmonan == abc).ToList();

             //if (dsChon.Count() != 0) {
             //    List<DanhSachMonChon> ds = new List<DanhSachMonChon>();
             //    ds.Add(new DanhSachMonChon { dsChon.FirstOrDefault().idmonan, dsChon.FirstOrDefault().Tenmon });
             //    ViewBag.DanhSachCuoi = ds;
             //}
           
         
          


            return Json( dsChon, JsonRequestBehavior.AllowGet );

         }
         public ActionResult DatMon(DatMon dm, string chuoian, string LoaiMonAn)
         {
             //string abc = chuoian.TrimStart('"','/');
            
             JavaScriptSerializer jss = new JavaScriptSerializer();
             List<string> arrListStr = (List<string>)jss.Deserialize(chuoian, typeof(List<string>));
             for (int i = 0; i < arrListStr.Count(); i++)
              {
                  DatMon model = new DatMon();
                  var def = dte.DatMons.Max(th => th.IdDatMon);

                  model.IdDatMon = def + 1;

                  model.NgayToChuc = dm.NgayToChuc;
                  model.ThoiGianToChuc = dm.ThoiGianToChuc;
                  model.DiaChi = dm.DiaChi;
                  model.GhiChu = dm.GhiChu;
                  model.MaKH = dm.MaKH;
                  model.IdMon = arrListStr[i];
                  model.SoLuong = dm.SoLuong;
                  var giatien = dte.MonAns.FirstOrDefault(th => th.idmonan.ToString() == model.IdMon );
                 int a =  Convert.ToInt32(giatien.Gia);
                  model.ThanhTien = a * dm.SoLuong;
                  Session["tinhtrangdatmon"] = "datthanhcong";

                  dte.DatMons.Add(model);
                  dte.SaveChanges();
              }
             //DatMon model = new DatMon();
             //var abc = dte.DatMons.Max(th => th.IdDatMon);
           
             //    model.IdDatMon = abc + 1;
            
             //model.NgayToChuc = dm.NgayToChuc;
             //model.ThoiGianToChuc = dm.ThoiGianToChuc;
             //model.DiaChi = dm.DiaChi;
             //model.GhiChu = dm.GhiChu;
             //model.MaKH = dm.MaKH;
             //model.IdMon = dm.IdMon;
             //model.SoLuong = dm.SoLuong;
             //var giatien = dte.MonAns.FirstOrDefault(th => th.idmonan == dm.IdMon);
             //int a =  Convert.ToInt32(giatien.Gia);
             //model.ThanhTien = a * dm.SoLuong;
         
            
             //dte.DatMons.Add(model);
             //dte.SaveChanges();

          
             //var model2 = dte.MonAns.Where(th => th.idloaimon == giatien.idloaimon).ToList();
             ////ViewBag.TT = dscm;
             //ViewBag.abc = dte.LoaiMons.Where(th => th.idloaimon == giatien.idloaimon).ToList();

             return RedirectToAction("LayDanhSachMon", "BangGia", new { @id =LoaiMonAn});

         }
       
    }
}
