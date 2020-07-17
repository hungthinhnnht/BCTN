using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatTiec.Models;


namespace DatTiec.Controllers
{
    public class LienHeController : Controller
    {
        //
        // GET: /LienHe/
        Model1 dbc = new Model1();
        public ActionResult Index()
        {
            Session.Remove("TuVan");
            return View();
        }
        public ActionResult TuVan(TuVan tv, string IdTestTuVan)
        {
              var model = new TuVan();

              var user_check = dbc.TuVans.ToList().Max(th => th.IdTuVan);

              int idlonnhat = Int32.Parse(user_check.Substring(2));

              int idlonnhat2 = idlonnhat + 1;

              tv.IdTuVan = "TV" + idlonnhat2.ToString();
              model.IdTuVan = tv.IdTuVan;
              model.Hoten = tv.Hoten;
              model.Email = tv.Email;
              model.Dienthoai = tv.Dienthoai;
              model.Loinhan = tv.Loinhan;

              dbc.TuVans.Add(model);
              dbc.SaveChanges();
              ModelState.AddModelError("", "Xác nhận mật khẩu không thành công");
              Session["TuVan"] = "DaNhan";

              if (IdTestTuVan == "1") {
                  return RedirectToAction("Index", "LienHe");
              }
              return RedirectToAction("Index", "Home");
        }

      
    }
}

