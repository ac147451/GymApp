using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.DBFile.Model
{
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
}
