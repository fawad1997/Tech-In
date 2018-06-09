using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Models.Model
{
    public class UserPersonalDetail
    {
        [Key]
        public int UserPersonalDetailId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }
        
        [StringLength(maximumLength:300,MinimumLength =50)]
        public string Summary { get; set; }
        
        public string ProfileImage { get; set; }
        public string CoverImage { get; set; }
        public string Address { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-mm-dd}",ApplyFormatInEditMode =true)]
        public DateTime DOB { get; set; }
        public Boolean IsDOBPublic { get; set; }
        public Boolean IsEmailPublic { get; set; }
        public Boolean IsPhonePublic { get; set; }

        public Gender Gender { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
        //ApNetUser
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }

    public enum Gender
    {
        Male,Female
    }
}
