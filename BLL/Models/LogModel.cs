using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace BLL
{
    public class LogModel
    {
        public int LogID { get; set; }
        public int? UserID { get; set; }
        public string Action { get; set; }
        public DateTime? DateTime { get; set; }

        public LogModel() { }
        public LogModel(ActivityLog p)
        {
            LogID= p.LogID;
            UserID= p.UserID;
            Action= p.Action;
            DateTime= p.DateTime;
        }
    }
}
