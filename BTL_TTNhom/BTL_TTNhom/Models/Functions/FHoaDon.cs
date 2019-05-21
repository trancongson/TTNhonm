using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTL_TTNhom.Models.Entity;

namespace BTL_TTNhom.Models.Functions
{
    public class FHoaDon
    {
        Quanlybansach db = null;
        public FHoaDon()
        {
            db = new Quanlybansach();
        }
        public int Insert(DONHANG order)
        {
            db.DONHANGs.Add(order);
            db.SaveChanges();
            return order.MADONHANG;
        }
    }
}