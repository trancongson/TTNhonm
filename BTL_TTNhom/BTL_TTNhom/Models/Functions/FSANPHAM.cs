using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTL_TTNhom.Models.Entity;
namespace BTL_TTNhom.Models.Functions
{
    public class FSANPHAM
    {
        Quanlybansach db = null;
        public FSANPHAM()
        {
            db = new Quanlybansach();
        }

        public IQueryable<SACH> SACHes
        {
            get { return db.SACHes; }
        }
        public SACH FindSanPham(int MASACH)
        {
            SACH dbEntry = db.SACHes.Find(MASACH);
            return dbEntry;
        }
    }
}