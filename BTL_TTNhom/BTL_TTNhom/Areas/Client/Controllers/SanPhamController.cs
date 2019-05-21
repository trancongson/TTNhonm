using BTL_TTNhom.Dao;
using BTL_TTNhom.EF;
using BTL_TTNhom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_TTNhom.Areas.Client.Controllers
{
    public class SanPhamController : BaseController
    {

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new SanPhamDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        CTSach db = new CTSach();
        public ActionResult Details(int masach)
        {
            var sp = db.ListCTSach().SingleOrDefault(n => n.MaSach == masach);
            return View(sp);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SACH sach)
        {
            if (ModelState.IsValid)
            {
                var dao = new SanPhamDao();
                long id = dao.Insert(sach);
                if (id > 0)
                {
                    return RedirectToAction("Index", "SanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user không thành công");
                }
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edit(int masach)
        {
            var sach = new SanPhamDao().ViewDetail(masach);
            return View(sach);
        }

        [HttpPost]
        public ActionResult Edit(SACH sach)
        {
            if (ModelState.IsValid)
            {
                var dao = new SanPhamDao();
                var result = dao.Update(sach);
                if (result)
                {
                    return RedirectToAction("Index", "SanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật sách không thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int masach)
        {
            new SanPhamDao().Delete(masach);
            return RedirectToAction("Index");
        }
    }
}