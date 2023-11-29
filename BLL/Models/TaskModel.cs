using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace BLL
{
    public class TaskModel
    {
        public int TaskID { get; set; }
        public int? ProjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }


        public TaskModel() { }

        public TaskModel(Tasks p) 
        {
            TaskID= p.TaskID;
            ProjectID= p.ProjectID;
            Name= p.Name;
            Description= p.Description;
            Status= p.Status;
            Priority= p.Priority;
        }
    }
}
