using BTL_TTNhom.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace BTL_TTNhom.Dao
{
    public class UserDao
    {
        WebbansachDbContext db = null;
        public UserDao()
        {
            db = new WebbansachDbContext();
        }

        public long Insert(USER entity)
        {
            db.USERS.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(USER entity)
        {
            try
            {
                var user = db.USERS.Find(entity.ID);
                user.Password = entity.Password;
                user.HoTen = entity.HoTen;                                          
                user.Diachi = entity.Diachi;
                user.Email = entity.Email;
                user.DienThoai = entity.DienThoai;
                user.NgaySuaDoi = DateTime.Now;               
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }           
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.USERS.Find(id);
                db.USERS.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public IEnumerable<USER> ListAllPaging( int page, int pageSize)
        {

            return db.USERS.OrderBy(x=>x.ID).ToPagedList(page, pageSize);
        }

        public USER GetById(string userName)
        {
            return db.USERS.SingleOrDefault(x => x.UserName == userName);
        }

        public USER ViewDetail(int id)
        {
            return db.USERS.Find(id);
        }

        public bool Login(string userName, string password)
        {
            var result = db.USERS.Count(x => x.UserName == userName && x.Password == password);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}