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

    public class City
    {
        public int City_id { get; set; }
        public string City_name { get; set; }

        public City(int city_id, string cityname)
        {
            City_id = city_id;
            City_name = cityname;
        }//City Class
    }

    public class Suburb
    {
        public int Suburb_id { get; set; }
        public string Suburb_name { get; set; }

        public Suburb(int suburb_id, string suburbname)
        {
            Suburb_id = suburb_id;
            Suburb_name = suburbname;
        }//Suburb Class
    }

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

    public class ClassType
    {
        public int Classtype_id { get; set; }
        public string Classtype { get; set; }
        public int Classprice { get; set; }

        public ClassType(int classtype_id, string classtype, int classprice)
        {
            Classtype_id = classtype_id;
            Classtype = classtype;
            Classprice = classprice;
        }//Classtype Class
    }

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