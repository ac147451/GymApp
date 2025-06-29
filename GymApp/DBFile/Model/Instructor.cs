using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.DBFile.Model
{
    public class Instructor
    {
        public int Instructor_id { get; set; }
        public string Instructor_name { get; set; }
        public int Gym_id { get; set; }
        public Int64 Phonenumber { get; set; }
        public string Emailaddress { get; set; }
        public string User_name { get; set; }
        public int Password { get; set; }
        public int Role_id { get; set; }

        public Instructor(int instructor_id, string instructorname, int gym_id, Int64 phonenumber, string emailaddress, string username, int password, int role_id)
        {
            Instructor_id = instructor_id;
            Instructor_name = instructorname;
            Gym_id = gym_id;
            Phonenumber = phonenumber;
            Emailaddress = emailaddress;
            User_name = username;
            Password = password;
            Role_id = role_id;
        }//Instructor Class
    }
}
