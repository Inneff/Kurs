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
    public class FilesRepositorySQL : IRepository<Files>
    {
        private ProjectManagementDB db;
        public FilesRepositorySQL(ProjectManagementDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Files> GetList()
        {
            return db.Files.ToList();
        }

        public Files GetItem(int id)
        {
            return db.Files.Find(id);
        }

        public void Create(Files item)
        {
            db.Files.Add(item);
        }

        public void Update(Files item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Files item = db.Files.Find(id);
            if (item != null)
                db.Files.Remove(item);
        }   

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}