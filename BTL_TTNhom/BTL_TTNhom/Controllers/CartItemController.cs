using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BTL_TTNhom.Common;
using BTL_TTNhom.Models;
using BTL_TTNhom.Models.Entity;
using BTL_TTNhom.Models.Functions;
namespace BTL_TTNhom.Controllers
{
    public class CartItemController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: CartItem
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list = (List<CartItem>)cart;
            }           
            return View(list);
        }

        public ActionResult AddItem(int productId, int quantity)
        {
            var product = new FSANPHAM().FindSanPham(productId);
            var cart = Session[CartSession];
            if(cart != null)
            {
                var list = (List<CartItem>)cart;
                if(list.Exists(n=>n.SACH.MASACH == productId))
                {
                    foreach(var item in list)
                    {
                        if(item.SACH.MASACH == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.SACH = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
            }
            else
            {
                var item = new CartItem();
                item.SACH = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.SACH.MASACH == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.SACH.MASACH == item.SACH.MASACH);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);        
        }

        [HttpPost]
        public ActionResult Payment(string shipName, string mobile, string address, string email)
        {
            var order = new DONHANG();
            order.NGAYDAT = DateTime.Now;
            order.DIACHI = address;
            order.HOTEN = shipName;
            order.DIENTHOAI = mobile;
            order.EMAIL = email;
            try
            {
                var id = new FHoaDon().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailDao = new FChiTietHD();
                decimal total = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new CHITIETDONHANG();
                    orderDetail.MASACH = item.SACH.MASACH;
                    orderDetail.MADONHANG = id;
                    orderDetail.DONGIA = item.SACH.GIABAN;
                    orderDetail.SOLUONG = item.Quantity;
                    detailDao.Insert(orderDetail);
                    total += (item.SACH.GIABAN.GetValueOrDefault(0) * item.Quantity);
                }               
            }
            catch (Exception ex)
            {
                //ghi log
                return RedirectToAction("Failed"); ;
            }
            return RedirectToAction("Success");
        }

        public ActionResult Success()
        {
            return View();
        }
        //private double TongTien()
        //{
        //    double iTongTien = 0;
        //    var cart = Session[CartSession];
        //    var list = new List<CartItem>();
        //    if (cart != null)
        //    {
        //        list = (List<CartItem>)cart;
        //        foreach(var item in list)
        //        {
        //            iTongTien = iTongTien + (item.Quantity * item.GiaBan);
        //        }
        //    }
        //    return iTongTien;
        //}


    }
}