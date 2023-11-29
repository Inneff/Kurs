using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace BLL
{
    public class AssigmentModel
    {
        public int AssigmentID { get; set; }
        public int? UserID { get; set; }
        public int? ProjectID { get; set; }
        public int? TaskID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public AssigmentModel() { }
        public AssigmentModel(Assigments p)
        {
            AssigmentID = p.AssigmentID;
            UserID = p.UserID;
            ProjectID= p.ProjectID;
            TaskID = p.TaskID;
            StartDate= p.StartDate;
            EndDate= p.EndDate;
        }
    }
}
