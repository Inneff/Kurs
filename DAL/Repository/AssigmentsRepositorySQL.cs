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
    public class AssigmentsRepositorySQL : IRepository<Assigments>
    {
        private ProjectManagementDB db;
        public AssigmentsRepositorySQL(ProjectManagementDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Assigments> GetList()
        {
            return db.Assigments.ToList();
        }

        public Assigments GetItem(int id)
        {
            return db.Assigments.Find(id);
        }

        public void Create(Assigments item)
        {
            db.Assigments.Add(item);
        }

        public void Update(Assigments item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Assigments item = db.Assigments.Find(id);
            if (item != null)
                db.Assigments.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
