using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BTL_TTNhom.Models.Entity;

namespace BTL_TTNhom.Models.Functions
{
    public class FChiTietHD
    {
        Quanlybansach db = null;
        public FChiTietHD()
        {
            db = new Quanlybansach();
        }
        public bool Insert(CHITIETDONHANG detail)
        {
            try
            {
                db.CHITIETDONHANGs.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}