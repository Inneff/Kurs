using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDbRepos
    {
        IRepository<Assigments> Assigments { get; }
        IRepository<Categories> Categories { get; }
        IRepository<Comments> Comments { get; }
        IRepository<Files> Files { get; }
        IRepository<Notification> Notifications { get; }
        IRepository<Projects> Projects { get; }
        IRepository<Tasks> Tasks { get; }
        IRepository<Users> Users { get; }
        IRepository<ActivityLog> AvtivityLogs { get; }
        int Save();
    }
}
