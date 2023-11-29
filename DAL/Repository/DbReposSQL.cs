using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DbReposSQL : IDbRepos
    {
        private ProjectManagementDB db;
        private AssigmentsRepositorySQL assigmentsRepository;
        private NotificationRepositorySQL notificationRepository;
        private CommentsRepositorySQL commentsRepository;
        private ActivityLogRepositorySQL activitylogRepository;
        private ProjectsRepositorySQL projectsRepository;
        private FilesRepositorySQL filesRepository;
        private UsersRepositorySQL usersRepository;
        private CategoriesRepositorySQL categoriesRepository;
        private TasksRepositorySQL tasksRepository;

        public DbReposSQL()
        {
            db = new ProjectManagementDB();
        }

        public IRepository<Assigments> Assigments
        {
            get
            {
                if (assigmentsRepository == null)
                    assigmentsRepository = new AssigmentsRepositorySQL(db);
                return assigmentsRepository;
            }
        }
        public IRepository<Tasks> Tasks
        {
            get
            {
                if (tasksRepository == null)
                    tasksRepository = new TasksRepositorySQL(db);
                return tasksRepository;
            }
        }
        public IRepository<Categories> Categories
        {
            get
            {
                if (categoriesRepository == null)
                    categoriesRepository = new CategoriesRepositorySQL(db);
                return categoriesRepository;
            }
        }
        public IRepository<Users> Users
        {
            get
            {
                if (usersRepository == null)
                    usersRepository = new UsersRepositorySQL(db);
                return usersRepository;
            }
        }
        public IRepository<Projects> Projects
        {
            get
            {
                if (projectsRepository == null)
                    projectsRepository = new ProjectsRepositorySQL(db);
                return projectsRepository;
            }
        }
        public IRepository<ActivityLog> ActivityLogs
        {
            get
            {
                if (activitylogRepository == null)
                    activitylogRepository = new ActivityLogRepositorySQL(db);
                return activitylogRepository;
            }
        }
        public IRepository<Files> Files
        {
            get
            {
                if (filesRepository == null)
                    filesRepository = new FilesRepositorySQL(db);
                return filesRepository;
            }
        }

        public IRepository<Notification> Notifications
        {
            get
            {
                if (notificationRepository == null)
                    notificationRepository = new NotificationRepositorySQL(db);
                return notificationRepository;
            }
        }

        public IRepository<Comments> Comments
        {
            get
            {
                if (commentsRepository == null)
                    commentsRepository = new CommentsRepositorySQL(db);
                return commentsRepository;
            }
        }

        public IRepository<ActivityLog> AvtivityLogs
        {
            get
            {
                if (activitylogRepository == null)
                    activitylogRepository= new ActivityLogRepositorySQL(db);
                return activitylogRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}