using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.DBFile.Model
{
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
}
