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

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }
        
        [StringLength(maximumLength:300,MinimumLength =50)]
        public string Summary { get; set; }
        //AspNetUsers
        public string UserID { get; set; }

        public byte[] CVImage { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-mm-dd}",ApplyFormatInEditMode =true)]
        public DateTime DOB { get; set; }
        public short DOBVisibility { get; set; }
        public short EmailVisibility { get; set; }
        public short PhonoNoVisibility { get; set; }

        public Gender Gender { get; set; }

        public int CityID { get; set; }
        public City City { get; set; }
    }

    public enum Gender
    {
        Male,Female
    }
}
