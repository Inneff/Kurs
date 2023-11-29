using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDbCrud

    {
        List<AssigmentModel> GetAllAssigments();
        List<CategoryModel> GetAllCategories();
        List<CommentModel> GetAllComments();
        List<FileModel> GetAllFiles();
        List<LogModel> GetAllLogs();
        List<NotificationModel> GetAllNotifications();
        List<ProjectModel> GetAllProjects();
        List<TaskModel> GetAllTasks();
        List<UserModel> GetAllUsers();

        TaskModel GetTask(int Id);
        ProjectModel GetProject(int Id);
        UserModel GetUser(int Id);

        void CreateProject(ProjectModel p);
        void UpdateProject(ProjectModel p);
        void DeleteProject(int id);
        void CreateTask(TaskModel p);
        void UpdateTask(TaskModel p);
        void DeleteTask(int id);
        void CreateUser(UserModel p);
        void UpdateUser(UserModel p);
        void DeleteUser(int id);

    }
}
