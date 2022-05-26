using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class UserDb
    {
        private HumanResourceEntities db;

        public UserDb()
        {
            db = new HumanResourceEntities();
        }
        public IEnumerable<user> GetALL()
        {
            return db.users.ToList();
        }
        public user GetByID(int Id)
        {
            return db.users.Find(Id);
        }
        public void Insert(user user)
        {
            db.users.Add(user);
            Save();
        }
        public void Delete(int Id)
        {
            user user = db.users.Find(Id);
            db.users.Remove(user);
            Save();
        }
        public void Update(user user)
        {
            db.Entry(user).State = EntityState.Modified;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    
    }
}
