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
    public class TasksRepositorySQL : IRepository<Tasks>
    {
        private ProjectManagementDB db;
        public TasksRepositorySQL(ProjectManagementDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Tasks> GetList()
        {
            return db.Tasks.ToList();
        }

        public Tasks GetItem(int id)
        {
            return db.Tasks.Find(id);
        }

        public void Create(Tasks item)
        {
            db.Tasks.Add(item);
        }

        public void Update(Tasks item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Tasks item = db.Tasks.Find(id);
            if (item != null)
                db.Tasks.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}