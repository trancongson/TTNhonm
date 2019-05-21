using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_TTNhom.Models;
using BTL_TTNhom.Models.Entity;
namespace BTL_CNWeb.Controllers
{
    public class KhachhangController : Controller
    {
        Quanlybansach db = new Quanlybansach();

        // GET: Khachhang
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dangky(KHACHHANG kh)
        {
            if (ModelState.IsValid)
            {
                db.KHACHHANGs.Add(kh);
                db.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult Dangnhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Dangnhap(FormCollection f)
        {
            string sTaikhoan = f["TAIKHOAN"];
            string sMatkhau = f["MATKHAU"];
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => (n.TAIKHOAN == sTaikhoan && n.MATKHAU == sMatkhau));
            if (kh != null)
            {
                int id = kh.MAKH;
                Session["Taikhoan"] = id;
                return RedirectToAction("Taikhoan", new { id });
            }
            ViewBag.ThongBao = "Tài khoản hoặc mật khẩu không đúng!!";
            return View();

        }

        public ActionResult Taikhoan(int id)
        {
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.MAKH == id);
            return View(kh);
        }

        public ActionResult Kiemtradonhang(string Email, string Number)
        {
            KTDonHang ktDH = new KTDonHang();
            var kiemtra = ktDH.DonHangCT().Where(n => n.Email == Email && n.Dienthoai == Number).ToList();
            return View(kiemtra);
        }      
    }
}