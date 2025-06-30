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
        public Int64 Phonenumber { get; set; }
        public string Emailaddress { get; set; }
        public string User_name { get; set; }
        public int Password { get; set; }
        public int Role_id { get; set; }

        public Gym(int gym_id, string gymName, string streetaddress, int country_id, int city_id, int suburb_id, Int64 phonenumber, string emailaddress, string username, int password, int role_id)
        {
            Gym_id = gym_id;
            Gym_name = gymName;
            Streetaddress = streetaddress;
            Country_id = country_id;
            City_id = city_id;
            Suburb_id = suburb_id;
            Phonenumber = phonenumber;
            Emailaddress = emailaddress;
            User_name = username;
            Password = password;
            Role_id = role_id;
        }//Gym Class
    }

}