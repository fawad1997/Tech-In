using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models.Model
{
    public class UserExperience
    {
        public int UserExperienceID { get; set; }

        public string Title { get; set; }

        public int CityID { get; set; }
        public City City { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public string CompanyName { get; set; }
        public Boolean CurrentStatus { get; set; }

        public DateTime ExpFrom { get; set; }
        public DateTime ExpTo { get; set; }

        //AspNetUser
        public string UserID { get; set; }
    }
}
