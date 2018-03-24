using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models.Model
{
    public class UserPersonalDetail
    {
        [Key]
        public int UserPersonalDetailID { get; set; }

        [StringLength(maximumLength:50,MinimumLength =2),
            Display(Name ="First Name"),
            Required]
        public string FirstName { get; set; }

        [StringLength(maximumLength:100,MinimumLength =2),
            Display(Name ="Last Name")]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        
        [StringLength(maximumLength:300,MinimumLength =50)]
        public string Summary { get; set; }
        //AspNetUsers
        public string UserID { get; set; }

        //public string CVImg { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-mm-dd}",ApplyFormatInEditMode =true)]
        public DateTime DOB { get; set; }

        public Gender Gennder { get; set; }

        public City City { get; set; }
    }

    public enum Gender
    {
        Male,Female
    }
}
