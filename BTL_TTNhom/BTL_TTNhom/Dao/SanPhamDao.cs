using BTL_TTNhom.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_TTNhom.Dao
{
    public class SanPhamDao
    {
        WebbansachDbContext db = null;
        public SanPhamDao()
        {
            db = new WebbansachDbContext();
        }

        public long Insert(SACH entity)
        {
            db.SACHes.Add(entity);
            db.SaveChanges();
            return entity.MASACH;
        }

        public bool Update(SACH entity)
        {
            try
            {
                var sach = db.SACHes.Find(entity.MASACH);             
                sach.GIABAN = entity.GIABAN;                          
                sach.NGAYCAPNHAT = DateTime.Now;
                sach.SOLUONG = entity.SOLUONG;                
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int masach)
        {
            try
            {
                var sach = db.SACHes.Find(masach);
                db.SACHes.Remove(sach);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<SACH> ListAllPaging(int page, int pageSize)
        {

            return db.SACHes.OrderBy(x => x.MASACH).ToPagedList(page, pageSize);
        }
       
        public SACH ViewDetail(int masach)
        {
            return db.SACHes.Find(masach);
        }
      
    }
}
