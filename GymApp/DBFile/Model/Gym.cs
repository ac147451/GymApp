using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.DBFile.Model
{
    public class Gym
    {
        public int Gym_id { get; set; }
        public string Gym_name { get; set; }
        
        public Gym(int gym_id, string gymName )
        {
            Gym_id = gym_id;
            Gym_name = gymName;
        }//Gym Class
    }

    public class Member
    {
        public int Member_id { get; set; }
        public string Member_name { get; set; }

        public Member(int member_id, string memberName)
        {
            Member_id = member_id;
            Member_name = memberName;
        }//Member Class
    }

}