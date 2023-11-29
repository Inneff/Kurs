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
    public class ActivityLogRepositorySQL : IRepository<ActivityLog>
    {
        private ProjectManagementDB db;
        public ActivityLogRepositorySQL(ProjectManagementDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<ActivityLog> GetList()
        {
            return db.ActivityLog.ToList();
        }

        public ActivityLog GetItem(int id)
        {
            return db.ActivityLog.Find(id);
        }

        public void Create(ActivityLog item)
        {
            db.ActivityLog.Add(item);
        }

        public void Update(ActivityLog item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ActivityLog item = db.ActivityLog.Find(id);
            if (item != null)
                db.ActivityLog.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
