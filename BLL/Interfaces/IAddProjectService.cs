using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAddProjectService
    {
        //Создает или изменяет существующий проект
        void AddProject(ProjectModel project);
        void AddTask(TaskModel task);

        void AddUser(UserModel user);
    }
}
