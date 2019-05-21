using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.Dao
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
        public USER GetById(string userName)
        {
            return db.USERS.SingleOrDefault(x=>x.UserName == userName);
        }
        public bool Login(string userName, string password)
        {
            var result = db.USERS.Count(x => x.UserName == userName && x.Password == password);
            if(result > 0)
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
