using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_TTNhom.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace BTL_TTNhom.Controllers
{
    public class HomeController : Controller
    {
        Quanlybansach db = new Quanlybansach();
        public ActionResult Index(int? page)
        {
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return View(db.SACHes.Take(48).ToList().OrderBy(x => x.MASACH).ToPagedList(pageNumber, pageSize));
        }

        
        public PartialViewResult PartnerPartial()
        {
            var nxb = db.NHAXUATBANs.ToList();
            return PartialView(nxb);
        }
        
        public ActionResult Timkiem(string tensach)
        {
            var tk = db.SACHes.Where(x => (x.TENSACH.Contains(tensach))).ToList();          
            return View(tk);
        }
    }
}