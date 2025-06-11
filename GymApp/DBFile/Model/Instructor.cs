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

        public Instructor(int instructor_id, string instructorname)
        {
            Instructor_id = instructor_id;
            Instructor_name = instructorname;
        }//Instructor Class
    }
}
