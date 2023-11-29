using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace BLL
{
    public class ProjectModel
    {
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ProjectModel() { }

        public ProjectModel(Projects p)
        {
            ProjectID= p.ProjectID;
            Name= p.Name;
            Description= p.Description;
            StartDate= p.StartDate;
            EndDate= p.EndDate;
        }
    }
}
