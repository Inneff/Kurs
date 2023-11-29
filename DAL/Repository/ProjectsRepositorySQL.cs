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
    public class ProjectsRepositorySQL : IRepository<Projects>
    {
        private ProjectManagementDB db;
        public ProjectsRepositorySQL(ProjectManagementDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Projects> GetList()
        {
            return db.Projects.ToList();
        }

        public Projects GetItem(int id)
        {
            return db.Projects.Find(id);
        }

        public void Create(Projects item)
        {
            db.Projects.Add(item);
        }

        public void Update(Projects item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Projects item = db.Projects.Find(id);
            if (item != null)
                db.Projects.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}