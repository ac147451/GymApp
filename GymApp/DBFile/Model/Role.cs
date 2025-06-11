using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.DBFile.Model
{
    public class Role
    {
        public int Role_id { get; set; }
        public string Rolename { get; set; }

        public Role(int role_id, string rolename)
        {
            Role_id = role_id;
            Rolename = rolename;
        }//Role Class
    }
}
