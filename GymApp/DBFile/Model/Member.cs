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
        public int Phonenumber { get; set; }
        public string Emailaddress { get; set; }

        public Member(int member_id, string firstname, string lastname, int phonenumber, string emailaddress)
        {
            Member_id = member_id;
            Firstname = firstname;
            Lastname = lastname;
            Phonenumber = phonenumber;
            Emailaddress = emailaddress;
        }//Member Class
    }
}
