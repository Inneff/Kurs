using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace BLL
{
    public class CommentModel
    {
        public int CommentID { get; set; }
        public int? ProjectID { get; set; }
        public int? TaskID { get; set; }
        public int? UserID { get; set; }
        public string Text { get; set; }
        public DateTime? DateTime { get; set; }

        public CommentModel() { }
        public CommentModel(Comments p )
        {
            CommentID= p.CommentID;
            ProjectID= p.ProjectID;
            TaskID= p.TaskID;
            UserID= p.UserID;
            Text = p.Text;
            DateTime? DateTime = p.DateTime;
        }
    }
}
