using DatTiec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatTiec.Controllers
{
    public class TuVanController : Controller
    {
        //
        // GET: /TuVan/
        Model1 dte = new Model1();
        public ActionResult Index()
        {
            IQueryable<TinTuc> tt;

            tt = from s in dte.TinTucs
                 select s;
            ViewBag.Tintuc = tt;
            return View();
        }

    }
}
