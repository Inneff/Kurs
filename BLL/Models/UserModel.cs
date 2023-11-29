using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace BLL
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserModel() { }  
        public UserModel(Users p)
        {
            UserID= p.UserID;
            Name= p.Name;
            Email= p.Email;
            Password= p.Password;
        }
    }
}
