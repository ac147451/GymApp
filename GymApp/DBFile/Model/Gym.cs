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

    public class Country
    {
        public int Country_id { get; set; }
        public string Country_name { get; set; }

        public Country(int country_id, string countryname)
        {
            Country_id = country_id;
            Country_name = countryname;
        }//Country Class
    }

}