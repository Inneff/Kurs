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
    public class CommentsRepositorySQL : IRepository<Comments>
    {
        private ProjectManagementDB db;
        public CommentsRepositorySQL(ProjectManagementDB dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Comments> GetList()
        {
            return db.Comments.ToList();
        }

        public Comments GetItem(int id)
        {
            return db.Comments.Find(id);
        }

        public void Create(Comments item)
        {
            db.Comments.Add(item);
        }

        public void Update(Comments item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Comments item = db.Comments.Find(id);
            if (item != null)
                db.Comments.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}