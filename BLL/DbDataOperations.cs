using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL;
using System.Security.Policy;
using System.Diagnostics.Contracts;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Entities;

namespace BLL
{

    public class DbDataOperations : IDbCrud
    {
        IDbRepos db;
        public DbDataOperations(IDbRepos repos)
        {
            db = repos;
        }

        public List<AssigmentModel> GetAllAssigments()
        {
            return db.Assigments.GetList().Select(i => new AssigmentModel(i)).ToList();
        }

        public List<CategoryModel> GetAllCategories()
        {
            return db.Categories.GetList().Select(i => new CategoryModel(i)).ToList();
        }

        public List<CommentModel> GetAllComments()
        {
            return db.Comments.GetList().Select(i => new CommentModel(i)).ToList();
        }
        public List<FileModel> GetAllFiles()
        {
            return db.Files.GetList().Select(i => new FileModel(i)).ToList();
        }
        public List<LogModel> GetAllLogs()
        {
            return db.AvtivityLogs.GetList().Select(i => new LogModel(i)).ToList();
        }
        public List<NotificationModel> GetAllNotifications()
        {
            return db.Notifications.GetList().Select(i => new NotificationModel(i)).ToList();
        }
        public List<ProjectModel> GetAllProjects()
        {
            return db.Projects.GetList().Select(i => new ProjectModel(i)).ToList();
        }
        public List<TaskModel> GetAllTasks()
        {
            return db.Tasks.GetList().Select(i => new TaskModel(i)).ToList();
        }
        public List<UserModel> GetAllUsers()
        {
            return db.Users.GetList().Select(i => new UserModel(i)).ToList();
        }
        public TaskModel GetTask(int Id)
        {
            return new TaskModel(db.Tasks.GetItem(Id));
        }

        public UserModel GetUser(int Id)
        {
            return new UserModel(db.Users.GetItem(Id));
        }
        public ProjectModel GetProject(int Id)
        {
            return new ProjectModel(db.Projects.GetItem(Id));
        }
        public void DeleteTask(int id)
        {
            if (db.Tasks.GetItem(id) != null)
            {
                db.Tasks.Delete(id);
                Save();
            }
        }

        public void CreateTask(TaskModel p)
        {
            db.Tasks.Create(new Tasks() { TaskID = p.TaskID, ProjectID = p.ProjectID, Name = p.Name, Description = p.Description, Status = p.Status, Priority = p.Priority});
            Save();
        }

        public void CreateProject(ProjectModel p)
        {
            db.Projects.Create(new Projects() { ProjectID = p.ProjectID, Name = p.Name, Description = p.Description, StartDate = p.StartDate, EndDate = p.EndDate });
            Save();
        }
        public void DeleteProject(int id)
        {
            if (db.Projects.GetItem(id) != null)
            {
                db.Projects.Delete(id);
                Save();
            }
        }

        public void CreateUser(UserModel p)
        {
            db.Users.Create(new Users() { UserID = p.UserID, Name = p.Name, Email = p.Email, Password = p.Password });
        }

        public void DeleteUser(int id)
        {
            if (db.Users.GetItem(id) != null)
            {
                db.Users.Delete(id);
                Save();
            }
        }

        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }

        public void UpdateTask(TaskModel p)
        {
            Tasks ph = db.Tasks.GetItem(p.TaskID);
            ph.ProjectID = p.ProjectID;
            ph.Name = p.Name;
            ph.Description = p.Description;
            ph.Status = p.Status;
            ph.Priority = p.Priority;
            Save();
        }

        public void UpdateProject(ProjectModel p)
        {
            Projects ph = db.Projects.GetItem(p.ProjectID);
            ph.Name = p.Name;
            ph.Description = p.Description;
            ph.StartDate = p.StartDate;
            ph.EndDate = p.EndDate;
            Save();
        }

        public void UpdateUser(UserModel p)
        {
            Users ph = db.Users.GetItem(p.UserID);
            ph.Name = p.Name;
            ph.Email = p.Email;
            ph.Password = p.Password;
            Save();
        }
    }
}
