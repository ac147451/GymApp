using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.DBFile.Model
{
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
}
