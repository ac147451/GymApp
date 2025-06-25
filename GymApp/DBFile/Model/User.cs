using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.DBFile.Model
{
    public class User
    {
        public int User_id { get; set; }
        public string User_name { get; set; }
        public int Password { get; set; }
        public int Role_id { get; set; }

        public User(int user_id, string user_name, int password, int role_id)
        {
            User_id = user_id;
            User_name = user_name;
            Password = password;
            Role_id = role_id;
        }//User class
    }
}
