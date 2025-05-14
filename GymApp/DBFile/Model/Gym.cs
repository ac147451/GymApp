using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.DBFile.Model
{
    public class Gym
    {
        private int Gym_id { get; set; }
        private string Gym_name { get; set; }
        
        public Gym(int inGym_id, string inGym )
        {
            Gym_id = inGym_id;
            Gym_name = inGym;
        }
    }
}