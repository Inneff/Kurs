using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UsersRepositorySQL : IRepository<Users>
    {
        private ProjectManagementDB db;
        public UsersRepositorySQL(ProjectManagementDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Users> GetList()
        {
            return db.Users.ToList();
        }

        public Users GetItem(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(Users item)
        {
            db.Users.Add(item);
        }

        public void Update(Users item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Users item = db.Users.Find(id);
            if (item != null)
                db.Users.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
