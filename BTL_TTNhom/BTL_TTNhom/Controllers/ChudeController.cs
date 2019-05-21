using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_TTNhom.Models.Entity;
namespace BTL_TTNhom.Controllers
{
    public class ChudeController : Controller
    {
        Quanlybansach db = new Quanlybansach();
        // GET: Chude
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ChudePartial()
        {
            var cd = db.CHUDEs.ToList();
            return PartialView(cd);
        }

        public ViewResult Sachtheochude(int MaChuDe)
        {
            CHUDE cd = db.CHUDEs.SingleOrDefault(n => n.MACHUDE == MaChuDe);
            if(cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<SACH> sach = db.SACHes.Where(n => n.MACHUDE == MaChuDe).OrderBy(n => n.GIABAN).ToList();
            if (sach.Count == 0)
            {
                ViewBag.Sach = "Không có sách nào thuộc chủ đề này";
            }
            return View(sach);
        }

        public ActionResult Sachmoi()
        {
            var sm = db.SACHes.Take(12).OrderBy(n => n.GIABAN).ToList();
            return View(sm);
        }
       
    }
}