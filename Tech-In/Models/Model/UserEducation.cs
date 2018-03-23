using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models.Model
{
    public class UserEducation
    {
        public int UserEducationID { get; set; }
        public string Title { get; set; }
        public string SchoolName { get; set; }
        public string Details { get; set; }
        public DateTime EduFrom { get; set; }
        public DateTime EduTo { get; set; }
        public Boolean CurrentCheck { get; set; }
        public int CityID { get; set; }
        public City City { get; set; }

        //ApNetUser
        public string UserID { get; set; }
    }
}
