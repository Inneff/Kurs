using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace BLL
{
    public class NotificationModel
    {
        public int NotificationID { get; set; }
        public int? UserID { get; set; }
        public int? ProjectID { get; set; }
        public int? TaskID { get; set; }
        public string Text { get; set; }
        public DateTime? DateTime { get; set; }


        public NotificationModel() { }
        public NotificationModel(Notification p)
        {
            NotificationID= p.NotificationID;
            UserID= p.UserID;
            ProjectID= p.ProjectID;
            TaskID= p.TaskID;
            Text = p.Text;
            DateTime = p.DateTime;
        }
    }
}
