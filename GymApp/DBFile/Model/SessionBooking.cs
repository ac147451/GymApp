using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.DBFile.Model
{
    public class Sessionbooking
    {
        public int Session_id { get; set; }
        public int Instructor_id { get; set; }
        public int Classtype_id { get; set; }
        public int Member_id { get; set; }
        public int Gym_id { get; set; }
        public DateTime Sessiondate { get; set; }

        public Sessionbooking(int session_id, int instructor_id, int classtype_id, int member_id, int gym_id, DateTime sessiondate)
        {
            Session_id = session_id;
            Instructor_id = instructor_id;
            Classtype_id = classtype_id;
            Member_id = member_id;
            Gym_id = gym_id;
            Sessiondate = sessiondate;
        }
    }//Sessionbooking Class
}
