using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.DBFile.Model
{
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
