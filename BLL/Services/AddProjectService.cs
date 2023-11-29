using BLL.Interfaces;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AddProjectService: IAddProjectService
    {
        ProjectManagementDB db;

        public AddProjectService()
        {
            db = new ProjectManagementDB();
        }

        public void AddProject(ProjectModel project)
        {

            Projects newProject = new Projects
            {
                ProjectID = project.ProjectID,
                Name = project.Name,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
            };

            db.Projects.Add(newProject);
            db.SaveChanges();
        }

        public void AddTask(TaskModel task)
        {
            Tasks newTask = new Tasks
            {
                TaskID = task.TaskID,
                Name = task.Name,
                Description = task.Description,
                Status = task.Status,
                Priority = task.Priority,
            };

            db.Tasks.Add(newTask);
            db.SaveChanges();
        }

        public void AddUser(UserModel user)
        {
            Users newUser = new Users
            {
                UserID = user.UserID,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
            };

            db.Users.Add(newUser);
            db.SaveChanges();
        }
    }
}
