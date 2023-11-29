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
    public class NotificationRepositorySQL : IRepository<Notification>
    {
        private ProjectManagementDB db;
        public NotificationRepositorySQL(ProjectManagementDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Notification> GetList()
        {
            return db.Notification.ToList();
        }

        public Notification GetItem(int id)
        {
            return db.Notification.Find(id);
        }

        public void Create(Notification item)
        {
            db.Notification.Add(item);
        }

        public void Update(Notification item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Notification item = db.Notification.Find(id);
            if (item != null)
                db.Notification.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
