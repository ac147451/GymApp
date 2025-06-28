using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.DBFile.Model
{
    public class Member
    {
        public int Member_id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Int64 Phonenumber { get; set; }
        public string Emailaddress { get; set; }

        public string User_name { get; set; }
        public int Password { get; set; }
        public int Role_id { get; set; }

        public Member(int member_id, string firstname, string lastname, Int64 phonenumber, string emailaddress, string username, int password, int role_id)
        {
            Member_id = member_id;
            Firstname = firstname;
            Lastname = lastname;
            Phonenumber = phonenumber;
            Emailaddress = emailaddress;
            User_name = username;
            Password = password;
            Role_id = role_id;
        }//Member Class
    }
}
