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
        public string Streetaddress { get; set; }
        public int Country_id { get; set; }
        public int City_id { get; set; }
        public int Suburb_id { get; set; }
        
        public Gym(int gym_id, string gymName, string streetaddress, int country_id, int city_id, int suburb_id)
        {
            Gym_id = gym_id;
            Gym_name = gymName;
            Streetaddress = streetaddress;
            Country_id = country_id;
            City_id = city_id;
            Suburb_id = suburb_id;
        }//Gym Class
    }

}