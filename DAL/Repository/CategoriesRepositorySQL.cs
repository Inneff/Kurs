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
    public class CategoriesRepositorySQL : IRepository<Categories>
    {
        private ProjectManagementDB db;
        public CategoriesRepositorySQL(ProjectManagementDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Categories> GetList()
        {
            return db.Categories.ToList();
        }

        public Categories GetItem(int id)
        {
            return db.Categories.Find(id);
        }

        public void Create(Categories item)
        {
            db.Categories.Add(item);
        }

        public void Update(Categories item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Categories item = db.Categories.Find(id);
            if (item != null)
                db.Categories.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
