using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_TTNhom.Models;
namespace BTL_TTNhom.Controllers
{
    public class SachController : Controller
    {
        CTSach db = new CTSach();
        // GET: Sach        

        public ActionResult Details(int masach)
        {
            var sp = db.ListCTSach().SingleOrDefault(n => n.MaSach == masach);
            return View(sp);
        }

        public PartialViewResult PartialSachHot()
        {
            var sach = db.ListCTSach().Take(8).ToList();
            return PartialView(sach);
        }
    }
}